using System;

namespace DynamicProxy.ConsoleApp.IntegrationManager
{
    public class NetsisIntegration : INetsisIntegration
    {
        public void Method1()
        {
            throw new NotImplementedException();
        }

        public void Method2(string a)
        {
            Console.WriteLine("Method2() çalıştım");
        }

        public void Method3(int a)
        {
            Console.WriteLine("Method3() çalıştım");
        }
    }
}
