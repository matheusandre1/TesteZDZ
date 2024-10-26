using TesteZDZ.Domain.Base;
using TesteZDZ.Domain.Entities;
using TesteZDZ.Domain.Enums;

namespace TesteZDZ.Domain.Repository
{
    public  interface IRevenueRepository : IRepository<Revenue>
    {
        Task<List<Revenue>> SearchByPaymentMethod(PaymentMethod paymentMethod);
    }
}
