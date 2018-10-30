using System;

namespace DynamicProxy.StandardLibrary.DynamicProxy
{
    public class ActivityModel
    {
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public object[] MethodArgs { get; set; }
        public long ElapsedTime { get; set; }
        public ProcessStatus Status { get; set; }
        public Exception Exception { get; set; }
        public object ReturnType { get; set; }
        public object ReturnValue { get; set; }
    }

    public enum ProcessStatus
    {
        Done,
        Failed
    }
}
