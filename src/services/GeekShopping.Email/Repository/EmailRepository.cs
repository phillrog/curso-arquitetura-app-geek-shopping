using GeekShopping.Email.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Email.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly DbContextOptions<EmailContext> _context;

        public EmailRepository(DbContextOptions<EmailContext> context)
        {
            _context = context;
        }

        public async Task UpdateOrderPaymentStatus(int orderheaderId, bool paid)
        {
            //await using var db = new EmailContext(_context);
            //var header = db.OrderHeaders.FirstOrDefault(x => x.Id == orderheaderId);
            //if (header != null)
            //{
            //    header.PaymentStatus = paid;
            //    await db.SaveChangesAsync();
            //}
        }
    }
}
