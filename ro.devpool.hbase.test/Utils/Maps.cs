﻿namespace ro.devpool.hbase.test.Utils
{
    public class Maps
    {
        public class MockDomainObject
        {
            public const string TestColumnFamily = "t";
            public const string NameColumn = "Name";
            public const string AgeColumn = "Age";
            public const string TableName = "MockUsers";
            public const string Namespace = "Mock";
            public const string ListColumnFamily = "l";
        }

        public class MockSubclassObject
        {
            public const string ColumnFamily = "a";
            public const string StreetColumn = "Street";
            public const string NumberColumn = "Number";
        }
    }
}