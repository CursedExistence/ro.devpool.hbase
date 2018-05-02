using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using ro.devpool.hbase.Exceptions;
using ro.devpool.hbase.Interfaces.Mapping;
using ro.devpool.hbase.Models;

namespace ro.devpool.hbase.Utils
{
    internal class MapVisitor : ExpressionVisitor
    {
        private readonly ClassMap _classMap;
        private IMap _map;
        
        public MapVisitor(ClassMap classmap)
        {
            _classMap = classmap;
        }

        internal PropertyMap ExposeMap()
        {
            return _map.ExtractPropertyMaps().SingleOrDefault();
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            //todo: handle enumerable maps?

            var exp = node.Expression;
            var propinfo = node.Member as PropertyInfo;

            if (propinfo == null)
                return node;

            if (exp is MemberExpression)
            {
                Visit(exp);
                if (_map is SubClassMap subClassMap)
                {
                    var maps = subClassMap.Mappers.Select(x => x.ExposeMap());
                    var map = maps.SingleOrDefault(x => x.Name.Equals(propinfo.Name));
                    _map = map;
                }               
            }
            else
            {
                var map = _classMap?.Maps?.SingleOrDefault(x => x.Name.Equals(propinfo.Name));
                _map = map ?? throw new MappingException($"Map not found for property: {propinfo.Name}");
            }

            return node;
        }
    }
}