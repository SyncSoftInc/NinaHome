using SyncSoft.App;
using SyncSoft.App.EngineConfigs;

namespace Nina
{
    public static class EngineExtensions
    {
        public static CommonConfigurator UseHomeComponents(this CommonConfigurator configurator)
        {
            Engine.PreventDuplicateRegistration(nameof(UseHomeComponents));


            return configurator;
        }
    }
}
