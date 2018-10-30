using DynamicProxy.ConsoleApp.IntegrationManager;
using DynamicProxy.StandardLibrary.DynamicProxy;
using ImpromptuInterface;

namespace DynamicProxy.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var netsisIntegration = DynamicProxyManager<NetsisIntegration>.As<INetsisIntegration>();
            //var y = DynamicProxyManager<NetsisIntegration>.As<INetsisIntegration>();

            netsisIntegration.Method1();
            netsisIntegration.Method2("veri");
            netsisIntegration.Method3(1);

        }
    }
}
