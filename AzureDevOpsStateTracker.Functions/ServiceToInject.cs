using System;
using System.Collections.Generic;
using System.Text;

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
