using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface IDeliveryService
    {
        Task<ApiResponse<bool>> DeliverOrder(int userId, string deliveryPartner, string role, DeliverOrderRequestDto request);
        Task<ApiResponse<bool>> ReturnOrder(int userId, string deliveryPartner, string role, ReturnOrderRequestDto request);
    }
}
