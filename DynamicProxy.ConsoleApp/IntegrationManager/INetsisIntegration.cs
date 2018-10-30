namespace DynamicProxy.ConsoleApp.IntegrationManager
{
    public interface INetsisIntegration : IIntegration
    {
        void Method1();
        void Method2(string a);
        void Method3(int a);
    }
}
