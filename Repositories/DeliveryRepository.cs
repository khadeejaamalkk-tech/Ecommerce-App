using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;
using System.Data;

namespace Ecommerce_App.Repositories
{
    public class DeliveryRepository: IDeliveryRepository
    {
        private readonly DapperContext _context;
        public DeliveryRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<bool> DeliverOrder(int userId, string deliveryPartner,string role, DeliverOrderRequestDto request)
        {
            using var connection =_context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "DELIVERED");
            parameters.Add("@UserId", userId);
            parameters.Add("@DeliveryPartner", deliveryPartner);
            parameters.Add("@OrderId", request.OrderId);
            parameters.Add("@Role", role);
            var result = await connection.ExecuteAsync(
                         "Deliver_CRUD",
                         parameters,
                         commandType: CommandType.StoredProcedure);
            return result > 0;

        }
        public async Task<bool> ReturnOrder(int userId, string deliveryPartner, string role, ReturnOrderRequestDto request)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "RETURNED");
            parameters.Add("@UserId", userId);
            parameters.Add("@DeliveryPartner", deliveryPartner);
            parameters.Add("@OrderId", request.OrderId);
            parameters.Add("@Role", role);
            var result = await connection.ExecuteAsync(
                         "Deliver_CRUD",
                         parameters,
                         commandType: CommandType.StoredProcedure);
            return result > 0;

        }
    }
}
