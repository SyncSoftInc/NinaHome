using SyncSoft.App.Components;
using SyncSoft.App.Configurations;
using System;

namespace Nina.Models
{
    public class User
    {
        private static readonly Lazy<IConfigProvider> _lazyConfigProvider = ObjectContainer.LazyResolve<IConfigProvider>();
        private static IConfigProvider ConfigProvider => _lazyConfigProvider.Value;

        public static User Nina { get; }

        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        static User()
        {
            Nina = ConfigProvider.Get<User>("User");
        }
    }
}
