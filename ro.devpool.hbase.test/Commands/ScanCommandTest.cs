using System;
using System.Collections.Generic;
using System.Linq;
using FakeItEasy;
using FluentAssertions;
using ro.devpool.hbase.Commands;
using ro.devpool.hbase.Transform;
using ro.devpool.hbase.Connection;
using ro.devpool.hbase.Interfaces.Commands;
using ro.devpool.hbase.Interfaces.Configuration;
using ro.devpool.hbase.Interfaces.Connection;
using ro.devpool.hbase.Models;
using ro.devpool.hbase.Models.Apache;
using ro.devpool.hbase.test.Mock;
using ro.devpool.hbase.test.Mock.Configuration;
using ro.devpool.hbase.test.Utils;
using ro.devpool.hbase.Utils;
using Xunit;

namespace ro.devpool.hbase.test.Commands
{
    public class ScanCommandTest
    {
        private readonly IHBaseConfiguration _config;
        private readonly IConnectionPool _pool;
        private readonly IThriftClient _thriftClient;
        private readonly ClassMap _map;

        private readonly List<MockDomainObject> _expectedResults = new List<MockDomainObject>();
        public ScanCommandTest()
        {
            _config = A.Fake<IHBaseConfiguration>();
            _pool = A.Fake<IConnectionPool>();
            _thriftClient = A.Fake<IThriftClient>();
            var configuration = new MockDomainObjectConfiguration();
            _map = configuration.ExposeClassMap();

            var pg = new ProxyGenerator();

            _map.Generator = pg.ProduceGenerator<MockDomainObject>();

            A.CallTo(() => _pool.GetClient()).Returns(_thriftClient);
            // A.CallTo(() => _pool.ReleaseClient(_thriftClient)).MustHaveHappened();


            //A.CallTo(() =>
            //    _thriftClient.scannerOpenWithScan(Maps.MockDomainObject.TableName.GetBytes(), A.Dummy<TScan>(),
            //        new Dictionary<byte[], byte[]>())).Returns(1);

            var results = new List<TRowResult>()
            {
                BuildRow("test",21,"some street",1 ),
                BuildRow("Foo",21,"some street",1),
            };

            A.CallTo(() => _thriftClient.scannerGetList(A.Dummy<int>(), A.Dummy<int>())).ReturnsLazily(() => results);
            A.CallTo(_thriftClient).WithReturnType<List<TRowResult>>().Returns(results);
        }

        private TRowResult BuildRow(string name, int age, string street, int streetNumber)
        {
            _expectedResults.Add(new MockDomainObject()
            {
                Name = name,
                Age = age,
                Address = new MockSubclass()
                {
                    Number = streetNumber,
                    Street = street
                }
            });

            return new TRowResult()
            {
                Row = name.GetBytes(),
                Columns = new Dictionary<byte[], TCell>()
                {
                    [$"{Maps.MockDomainObject.TestColumnFamily}:{Maps.MockDomainObject.NameColumn}".GetBytes()] =
                    new TCell()
                    {
                        Timestamp = long.MaxValue,
                        Value = name.GetBytes()
                    },
                    [$"{Maps.MockDomainObject.TestColumnFamily}:{Maps.MockDomainObject.AgeColumn}".GetBytes()] =
                    new TCell()
                    {
                        Timestamp = long.MaxValue,
                        Value = age.ToString().GetBytes()
                    },

                    [$"{Maps.MockSubclassObject.ColumnFamily}:{Maps.MockSubclassObject.StreetColumn}".GetBytes()] =
                    new TCell()
                    {
                        Timestamp = long.MaxValue,
                        Value = street.GetBytes()
                    },
                    [$"{Maps.MockSubclassObject.ColumnFamily}:{Maps.MockSubclassObject.NumberColumn}".GetBytes()] =
                    new TCell()
                    {
                        Timestamp = long.MaxValue,
                        Value = streetNumber.ToString().GetBytes()
                    },
                }
            };
        }

        private bool CheckObject(Type type, object expected, object actual)
        {
            var pass = false;
            var props = type.GetProperties();

            foreach (var propertyInfo in props)
            {
                var val1 = propertyInfo.GetValue(expected);
                var val2 = propertyInfo.GetValue(actual);
                if (val1 == null && val2 == null)
                {
                    pass = true;
                    continue;
                }

                if ((propertyInfo.PropertyType != typeof(string) && !propertyInfo.PropertyType.IsValueType)) 
                {
                    pass = CheckObject(propertyInfo.PropertyType, val1, val2);
                }
                else
                {
                    pass = val1.Equals(val2);
                }

                if (pass == false)
                    return false;
            }

            return pass;
        }
        private bool CheckEntities(IList<MockDomainObject> expected, IList<MockDomainObject> actual)
        {
            var pass = false;
            foreach (var obj in expected)
            {
                //use name as discriminator (rowkey)
                var actualObj = actual.SingleOrDefault(x => x.Name.Equals(obj.Name));

                pass = CheckObject(typeof(MockDomainObject), obj, actualObj);
            }

            return pass;
        }

        [Fact]
        public void ScanCommand_Test_Fluent_FetchColumns()
        {
            var command = new ScanCommand<MockDomainObject>(_config, _pool, _map);

            command.FetchColumns(x => x.Name);


            command.FetchColumns(x => x.RandomDictionary, "manele");
            command.FetchColumns(x => x.RandomEnumerable, "manele");

            var actual = command.List();

            var test = actual.SingleOrDefault(x => x.Name == "test");
            var foo = actual.SingleOrDefault(x => x.Name == "Foo");

            var expectedTest = _expectedResults.SingleOrDefault(x => x.Name == "test");
            var expectedFoo = _expectedResults.SingleOrDefault(x => x.Name == "Foo");

           

            Assert.Equal(expectedTest?.Name, test?.Name);
            Assert.Equal(expectedFoo?.Name, foo?.Name);


            Assert.Null(test.Address);
            Assert.Null(foo.Address);

        }

        [Fact]
        public void ScanCommand_Test_List()
        {
            var command = new ScanCommand<MockDomainObject>(_config, _pool, _map);

            var actual = command.List();

            Assert.True(CheckEntities(_expectedResults, actual));
        }

        [Fact]
        public void ScanCommand_Test_Start_End_row()
        {
            var command = new ScanCommand<MockDomainObject>(_config, _pool, _map);
            command.StartFrom("test");
            command.EndTo("Foo");

            //intercept TSCAN
            

            var actual = command.List();

            Assert.True(CheckEntities(_expectedResults, actual));
        }
    }
}