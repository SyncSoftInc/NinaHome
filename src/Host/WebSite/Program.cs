using SyncSoft.App;
using SyncSoft.ECP.AspNetCore.Hosting;

namespace Nina.WebSite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Engine.Init()
                .UseSimpleInjector()
                .UseAppDefaultComponents()
                .UseJsonNet()
                .UseSerilog()
                .UseEcpBasicComponents()
                .UseECPSecurityComponents()
                .UseECPRedis()
                .UseConfigurations()
                .Start();

            ECPHost.Run<Startup>(args);
        }
    }
}
