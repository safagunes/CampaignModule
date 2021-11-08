using Campaign.Domain.Dtos.Order;

namespace Campaign.Domain.Services
{
    public interface IOrderService
    {
        void OrderCreate(OrderCreateDto model);
    }
}
