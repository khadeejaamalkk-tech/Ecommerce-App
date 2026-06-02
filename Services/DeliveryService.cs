using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;

namespace Ecommerce_App.Services
{
    public class DeliveryService: IDeliveryService
    {
        private readonly IDeliveryRepository _repository;
        public DeliveryService (IDeliveryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<bool>> DeliverOrder(int userId, string deliveryPartner, string role, DeliverOrderRequestDto request)
        {
            try
            {
                var data = await _repository.DeliverOrder(userId,deliveryPartner,role, request);
                return ApiResponse<bool>.Success(data, "Order delivered successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(
                    ex.Message
                );
            }
        }
        public async Task<ApiResponse<bool>> ReturnOrder(int userId, string deliveryPartner, string role, ReturnOrderRequestDto request)
        {
            try
            {
                var data = await _repository.ReturnOrder(userId, deliveryPartner,role, request);
                return ApiResponse<bool>.Success(data, "Order returned successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<bool>.Fail(
                    ex.Message
                );
            }
        }
    }
}
