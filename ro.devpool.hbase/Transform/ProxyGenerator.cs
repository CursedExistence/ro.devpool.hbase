using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using ro.devpool.hbase.Interfaces.Proxy;

[assembly: InternalsVisibleTo("FloatingDomain")]
namespace ro.devpool.hbase.Transform
{
    internal class ProxyGenerator
    {
        private readonly ModuleBuilder _floatingModule;
        private readonly ConstructorInfo _dictionaryConstructor;

        public ProxyGenerator()
        {
            var name = new AssemblyName("FloatingDomain");
            var floatingAssembly = AssemblyBuilder.DefineDynamicAssembly(name, AssemblyBuilderAccess.Run);
            _floatingModule = floatingAssembly.DefineDynamicModule("FloatingDomain");
            _dictionaryConstructor = typeof(Dictionary<string, long>).GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { });
        }

        private Type CreateProxyType<TEntity>() where TEntity : class
        {
            var entityType = typeof(TEntity);
            var ts = typeof(ITimestamp);

            var floatingType = _floatingModule.DefineType(entityType.FullName, TypeAttributes.Class | TypeAttributes.Public);
            floatingType.SetParent(entityType);
            floatingType.AddInterfaceImplementation(ts);

            var backingFieldType = typeof(Dictionary<string, long>);

            var backingField = floatingType.DefineField("_timestamps", backingFieldType, FieldAttributes.Private);

            var constructor = floatingType.DefineConstructor(MethodAttributes.Public |
                                                             MethodAttributes.HideBySig |
                                                             MethodAttributes.SpecialName |
                                                             MethodAttributes.RTSpecialName,
                CallingConventions.HasThis,
                new Type[] { });

            var baseConstructor = entityType.GetConstructor(BindingFlags.Public | BindingFlags.Instance, null, new Type[] { }, new ParameterModifier[] { });

            var constructorEmitter = constructor.GetILGenerator();

            constructorEmitter.Emit(OpCodes.Ldarg_0);
            constructorEmitter.Emit(OpCodes.Call, baseConstructor);
            constructorEmitter.Emit(OpCodes.Ldarg_0);
            constructorEmitter.Emit(OpCodes.Newobj, _dictionaryConstructor);
            constructorEmitter.Emit(OpCodes.Stfld, backingField);
            constructorEmitter.Emit(OpCodes.Ret);

            var getDef = ts.GetMethod(nameof(ITimestamp.Get));
            var setDef = ts.GetMethod(nameof(ITimestamp.Set));

            const MethodAttributes attrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final;

            var getMethod = floatingType.DefineMethod($"{getDef.Name}", attrs, backingFieldType, Type.EmptyTypes);

            var setMethod = floatingType.DefineMethod($"{setDef.Name}", attrs, null, new Type[] { backingFieldType });

            var getil = getMethod.GetILGenerator();

            getil.Emit(OpCodes.Ldarg_0);
            getil.Emit(OpCodes.Ldfld, backingField);
            getil.Emit(OpCodes.Ret);

            var setil = setMethod.GetILGenerator();
            setil.Emit(OpCodes.Ldarg_0);
            setil.Emit(OpCodes.Ldarg_1);
            setil.Emit(OpCodes.Stfld, backingField);
            setil.Emit(OpCodes.Ret);

            floatingType.DefineMethodOverride(getMethod, getDef);
            floatingType.DefineMethodOverride(setMethod, setDef);



            return floatingType.CreateTypeInfo().AsType();
        }

        public object ProduceGenerator<TEntity>() where TEntity:class
        {
            var type = CreateProxyType<TEntity>();
            var floatingType =
                _floatingModule.DefineType($"{type.Name}_generator", TypeAttributes.Class | TypeAttributes.Public);
            floatingType.AddInterfaceImplementation(typeof(IActivator<TEntity>));
            const MethodAttributes attrs = MethodAttributes.Private | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual | MethodAttributes.Final;

            var method = floatingType.DefineMethod(nameof(IActivator<TEntity>.Activate), attrs, typeof(TEntity), Type.EmptyTypes);

            var il = method.GetILGenerator();
            var ctor = type.GetConstructor(Type.EmptyTypes);
            il.Emit(OpCodes.Newobj, ctor);
            il.Emit(OpCodes.Ret);


            floatingType.DefineMethodOverride(method,typeof(IActivator<TEntity>).GetMethod(nameof(IActivator<TEntity>.Activate)));

            return Activator.CreateInstance(floatingType.CreateTypeInfo().AsType());
        }
    }
}