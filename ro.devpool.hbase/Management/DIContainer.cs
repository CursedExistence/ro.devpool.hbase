using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ro.devpool.hbase.Exceptions;
using BindingFlags = System.Reflection.BindingFlags;

namespace ro.devpool.hbase.Management
{
    internal class DIContainer
    {
        private readonly List<RegisteredObject> _registrations;


        internal DIContainer()
        {
            _registrations = new List<RegisteredObject>();
        }

        internal void Register(Type @interface, Type concrete,
            ConstructionMode constructionMode = ConstructionMode.Public)
        {
  
            if (!(@interface.IsAssignableFrom(concrete) ||
                 @interface.IsGenericType && concrete.GetInterfaces()
                    .Where(i => i.IsGenericType)
                    .Select(i => i.GetGenericTypeDefinition())
                    .Contains(@interface)))
            {
                throw new Exception($"{concrete.Name} does not implement {@interface.Name}");
            }

            var reg = _registrations.SingleOrDefault(x => x.InterfaceType == @interface);

            if (reg != null)
            {
                _registrations.Remove(reg);
            }

            _registrations.Add(new RegisteredObject(@interface, concrete, constructionMode));
        }

        internal void Register<TInterface, TImplementation>(ConstructionMode mode = ConstructionMode.Public) where TImplementation : TInterface
        {
            Register(typeof(TInterface), typeof(TImplementation), mode);
        }

        internal void Register<TInterface>(Func<TInterface> predicate, ConstructionMode mode = ConstructionMode.Public)
        {
            var reg = _registrations.SingleOrDefault(x => x.InterfaceType == typeof(TInterface));

            if (reg != null)
            {
                _registrations.Remove(reg);
            }

            var inst = new RegisteredObject(mode);
            inst.CreateReference(predicate);
            _registrations.Add(inst);
        }

        internal object Retrieve(Type type, params object[] contextualConstructorParams)
        {
            Type[] genericArguments = null;
           
            RegisteredObject registration;

            if (type.IsGenericType)
            {
                genericArguments = type.GetGenericArguments();
                registration = _registrations.SingleOrDefault(x => x.InterfaceType == type.GetGenericTypeDefinition());
            }
            else
            {
                registration = _registrations.SingleOrDefault(x => x.InterfaceType == type);
            }

            if (registration != null)
            {
                var instance = registration.Instance;

                if (instance == null) // no static object, build it!
                {
                    ConstructorInfo[] ctors;

                    switch (registration.ConstructionMode)
                    {
                        case ConstructionMode.Public:
                            ctors = registration.ImplementationType.GetConstructors();
                            break;
                        case ConstructionMode.Internal:
                            ctors = registration.ImplementationType.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(registration.ConstructionMode), registration.ConstructionMode, null);
                    }

                    var target = ctors[0];
                    var prms = target.GetParameters();


                    var dependencies = new List<object>();
                    foreach (var paramObj in prms)
                    {
                        var reg = _registrations.SingleOrDefault(x => x.InterfaceType == paramObj.ParameterType);

                        if (reg != null)
                            dependencies.Add(Retrieve(reg.InterfaceType));
                    }
                    //TODO: automatic constructor params order
                    dependencies.AddRange(contextualConstructorParams); // ALWAYS REGISTER EXPLICIT DEPENDENCIES LATER ON THE CONSTRUCTOR

                    return registration.Create(dependencies, genericArguments);
                }

                return registration.Instance; // static link : () => instance will always return the configured object
            }

            throw new SessionFactoryConfigurationException($"Cannot create a concrete instance of {type}");

        }

        internal TInterface Retrieve<TInterface>(params object[] contextualConstructorParams)
        {
            return (TInterface)Retrieve(typeof(TInterface), contextualConstructorParams);
        }

    }
}