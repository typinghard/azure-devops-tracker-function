using System;

namespace AzureDevOpsStateTracker.Functions
{
    public class ServiceToInject
    {
        public void DoSomething()
        {
            Console.WriteLine("Ok! Dependency Injection resolved!");
        }
    }
}