using System;
using System.Dynamic;
using ImpromptuInterface;

namespace DynamicProxy.StandardLibrary.DynamicProxy
{
    public class DynamicProxyManager<TConcreteObject> : DynamicBase<TConcreteObject> where TConcreteObject : class, new()
    {
        #region [ CTor ]
        private DynamicProxyManager(TConcreteObject subject, Type interfaceObjectType)
        {
            base.ConcreteObjectInstance = subject;
            base.InterfaceObjectType = interfaceObjectType;
        }
        #endregion

        #region [ As ]
        public static TInterfaceObject As<TInterfaceObject>() where TInterfaceObject : class

        {
            if (!typeof(TInterfaceObject).IsInterface)
                throw new Exception($"The {typeof(TInterfaceObject).Name} must be an interface type!");

            return new DynamicProxyManager<TConcreteObject>(new TConcreteObject(), typeof(TInterfaceObject)).ActLike<TInterfaceObject>();
        }
        #endregion

        #region [ TryInvokeMember ]
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var activityResult = base.TryInvokeMember(binder, args);
            result = activityResult.ReturnValue;
            return activityResult.Status == ProcessStatus.Done;
        }
        #endregion
    }
}
