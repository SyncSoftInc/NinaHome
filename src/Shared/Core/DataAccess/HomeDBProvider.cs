using Microsoft.Extensions.Configuration;
using SyncSoft.App.Components;
using System;

namespace Nina.DataAccess
{
    public class HomeDBProvider
    {
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<IConfiguration> _lazyConfigurationRoot = ObjectContainer.LazyResolve<IConfiguration>();
        private IConfiguration _ConfigurationRoot => _lazyConfigurationRoot.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Property(ies)  -

        private string ConnStrName => "MONGO_DEFAULT";
        public string DB => "NinaHome";

        #endregion
        // *******************************************************************************************************************************
        #region -  Get  -

        public HomeDB Get()
        {
            return CreateDbContextInstance();
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  CreateDbContextInstance  -

        private HomeDB CreateDbContextInstance()
        {
            var connStr = _ConfigurationRoot.GetConnectionString(ConnStrName);
            if (null == connStr)
            {
                throw new ArgumentNullException("ConnectionStringName", $"ConnectionString: '{ConnStrName}' cannot be found.");
            }

            return new HomeDB($"{connStr}/{this.DB}");
        }

        #endregion
    }
}
