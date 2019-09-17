using SyncSoft.App;
using SyncSoft.App.Components;
using SyncSoft.App.Configurations;
using SyncSoft.App.Logging;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Nina.Components
{
    public class EmailSender : IEmailSender
    {
        // *******************************************************************************************************************************
        #region -  Field(s)  -

        private static SmtpClient _client;
        private static string _user => "nina@mylightangel.com";
        private static string _pass => "4hqZc$t44H";

        #endregion
        // *******************************************************************************************************************************
        #region -  Lazy Object(s)  -

        private static readonly Lazy<ILogger> _lazyLogger = ObjectContainer.LazyResolveLogger<EmailSender>();
        private ILogger Logger => _lazyLogger.Value;

        private static readonly Lazy<IConfigProvider> _lazyConfigProvider = ObjectContainer.LazyResolve<IConfigProvider>();
        private IConfigProvider ConfigProvider => _lazyConfigProvider.Value;

        #endregion
        // *******************************************************************************************************************************
        #region -  Constructor(s)  -

        public EmailSender()
        {
            _client = new SmtpClient("smtp.zoho.com", 587);
            _client.EnableSsl = true;
            _client.UseDefaultCredentials = false;
            _client.Credentials = new NetworkCredential(_user, _pass);
        }

        #endregion
        // *******************************************************************************************************************************
        #region -  SendEmailAsync  -

        //public async Task<string> SendAsync(string from, string to, string subject, string body)
        //{
        //    try
        //    {
        //        using (var message = new MailMessage(from, to, subject, body))
        //        {
        //            message.IsBodyHtml = true;

        //            await _client.SendMailAsync(message).ConfigureAwait(false);
        //        }

        //        //Logger.Debug($"Email sent!");
        //        return MSGCODES.SUCCESS;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Logger.Error($"Error: {ex.Message}");
        //        return ex.GetRootExceptionMessage();
        //    }
        //}

        public async Task<string> SendAsync(string subject, string body)
        {
            var receipt = ConfigProvider.GetValue<string>("Email:Receipt");

            try
            {
                using (var message = new MailMessage(_user, receipt, subject, body))
                {
                    message.IsBodyHtml = true;

                    await _client.SendMailAsync(message).ConfigureAwait(false);
                }

                //Logger.Debug($"Email sent!");
                return MSGCODES.SUCCESS;
            }
            catch (Exception ex)
            {
                Logger.Error($"Error: {ex.Message}");
                return ex.GetRootExceptionMessage();
            }
        }

        #endregion
    }
}
