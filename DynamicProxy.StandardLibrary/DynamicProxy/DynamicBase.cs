using System;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;

namespace DynamicProxy.StandardLibrary.DynamicProxy
{
    public class DynamicBase<TConcreteObject> : DynamicObject where TConcreteObject : class
    {
        protected TConcreteObject ConcreteObjectInstance;
        protected Type InterfaceObjectType;

        #region [ TryInvokeMember ]
        protected ActivityModel TryInvokeMember(InvokeMemberBinder binder, object[] args)
        {
            Console.WriteLine($"{binder.Name} methodu çalıştırılıyor...");

            var argsTypes = GetTypesOfArgs(args);
            var currentMethodInfo = ConcreteObjectInstance.GetType().GetMethod(binder.Name, argsTypes);

            var activity = new ActivityModel
            {
                ServiceName = InterfaceObjectType.Name.Substring(1, InterfaceObjectType.Name.Length - 1),
                MethodArgs = args,
                MethodName = binder.Name,
                ReturnType = currentMethodInfo?.ReturnType
            };

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                var result = currentMethodInfo?.Invoke(ConcreteObjectInstance, args);
                stopwatch.Stop();
                activity.ReturnValue = result;
                activity.Status = ProcessStatus.Done;
                activity.ElapsedTime = stopwatch.ElapsedMilliseconds;
                // (Async) ActivityLog(activity);

                Console.WriteLine($"{binder.Name} methodu başarılı.");
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                activity.Status = ProcessStatus.Failed;
                activity.Exception = ex.InnerException;
                activity.ElapsedTime = stopwatch.ElapsedMilliseconds;
                // (Async) ActivityExceptionLog(activity);

                Console.WriteLine($"{binder.Name} methodu hata aldı.");
            }

            return activity;
        }
        #endregion

        #region [ GetTypesOfArgs ]
        protected Type[] GetTypesOfArgs(object[] args)
        {
            return args.Select(arg => arg.GetType()).ToArray();
        } 
        #endregion
    }
}
