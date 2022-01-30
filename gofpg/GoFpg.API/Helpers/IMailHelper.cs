using gofpg.Common.Models;

namespace GoFpg.API.Helpers
{
    public interface IMailHelper
    {
        Response SendMail(string to, string subject, string tbody, string body);
    }
}
