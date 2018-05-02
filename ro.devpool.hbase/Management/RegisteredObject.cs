using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ro.devpool.hbase.Management
{
    internal class RegisteredObject
    {
        public Type InterfaceType { get; set; }
        public Type ImplementationType => _definedImplementationType ?? _instance?.GetType();

        private readonly Type _definedImplementationType;

        public ConstructionMode ConstructionMode { get; private set; }

        internal RegisteredObject(ConstructionMode mode)
        {
            ConstructionMode = mode;
        }

        internal RegisteredObject(Type interfaceType, Type definedImplementationType, ConstructionMode mode)
        {
            InterfaceType = interfaceType;
            _definedImplementationType = definedImplementationType;
            ConstructionMode = mode;
        }

        public object Instance
        {
            get
            {
                if (_instance == null && _activationFunc != null)
                {
                    _instance = _activationFunc();
                }

                return _instance;
            }
        }

        private object _instance;
        private dynamic _activationFunc;

        public void CreateReference<TInterface>(Func<TInterface> activationFunc)
        {
            InterfaceType = typeof(TInterface);

            _activationFunc = activationFunc;
        }

        public object Create(IEnumerable<object> constructorParams, Type[] genericArguments)
        {

            //todo: Convert this into IL.EMIT 
            var instType = ImplementationType;
            if (ImplementationType.IsGenericType && genericArguments.Length > 0)
            {
                instType = ImplementationType.MakeGenericType(genericArguments);
            }


            switch (ConstructionMode)
            {
                case ConstructionMode.Public:
                    return Activator.CreateInstance(type: instType, args: constructorParams.ToArray());

                case ConstructionMode.Internal:
                    var ctor = instType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
                    return ctor.Invoke(constructorParams.ToArray());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}