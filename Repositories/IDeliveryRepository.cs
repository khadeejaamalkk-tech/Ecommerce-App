using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface IDeliveryRepository
    {
        Task<bool> DeliverOrder(int userId, string deliveryPartner, string role, DeliverOrderRequestDto request);
        Task<bool> ReturnOrder(int userId, string deliveryPartner, string role, ReturnOrderRequestDto request);
    }
}
