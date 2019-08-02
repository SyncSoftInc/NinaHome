using NUnit.Framework;
using SyncSoft.App;
using System;

namespace Tests
{
    [SetUpFixture]
    public class Startup
    {
        [OneTimeSetUp]
        public void Start()
        {
            Environment.SetEnvironmentVariable("APP_REDIS_CONFIGS", "192.168.188.199,password=Famous901,defaultDatabase=0");

            Engine.Init()
                .UseSimpleInjector()
                .UseAppDefaultComponents()
                .UseJsonNet()
                .UseSerilog()
                .UseUnitTestApiClient()
                .UseHomeComponents()
                .UseConfigurations()
                .Start();
        }
    }
}
