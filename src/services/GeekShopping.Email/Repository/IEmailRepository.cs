using GeekShopping.Email.Messages;
using GeekShopping.Email.Model;

namespace GeekShopping.Email.Repository
{
    public interface IEmailRepository
    {
        Task LogEmail(UpdatePaymentResultMessage message);
    }
}
