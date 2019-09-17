using System.Threading.Tasks;

namespace Nina.Components
{
    public interface IEmailSender
    {
        //Task<string> SendAsync(string from, string to, string subject, string body);
        Task<string> SendAsync(string subject, string body);
    }
}
