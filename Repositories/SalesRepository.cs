using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using System.Data;

namespace Ecommerce_App.Repositories
{
    public class SalesRepository : ISalesRepository
    {
        private readonly DapperContext _context;
        public SalesRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<OrderDashboardDto> GetOrderDashboard(int userId, DateTime? fromDate, DateTime? toDate)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "DASHBOARD");
            parameters.Add("@UserId", userId);
            parameters.Add("@FromDate", fromDate);
            parameters.Add("@ToDate", toDate);
            var result = await connection.QueryFirstOrDefaultAsync<OrderDashboardDto>(
                "Sp_Order_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            return result ?? new OrderDashboardDto();
        }
        public async Task<IEnumerable<AllOrderListDto>> GetAllOrders(int userId, DateTime? fromDate, DateTime? toDate)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET ALL ORDERS");
            parameters.Add("@UserId", userId);
            parameters.Add("@FromDate", fromDate);
            parameters.Add("@ToDate", toDate);
            var result = await connection.QueryAsync<AllOrderListDto>(
                "Sp_Order_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
        public async Task<OrderDetailsDto> GetOrderDetails(int orderId, int userId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET ORDER DETAILS");
            parameters.Add("@OrderId", orderId);
            parameters.Add("@UserId", userId);

            using var multi = await connection.QueryMultipleAsync(
                "Sp_Order_CRUD",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            var order = await multi.ReadFirstOrDefaultAsync<OrderDetailsDto>();
            if (order == null)
                return null;
            order.StatusHistory = (await multi.ReadAsync<OrderStatusDto>()).ToList();
            order.Products = (await multi.ReadAsync<OrderProductDto>()).ToList();
            return order;
        }
        public async Task<IEnumerable<AllOrderListDto>> GetOrdersByStatus(int userId, string status,DateTime? fromDate,DateTime? todate)
        {
            using var connection = _context.CreateConnection();

            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET ORDERS BY STATUS");
            parameters.Add("@UserId", userId);
            parameters.Add("@Status", status);
            parameters.Add("@FromDate",fromDate?? DateTime.Today);
            parameters.Add("@ToDate", todate?? DateTime.Today);
            var result = await connection.QueryAsync<AllOrderListDto>(
                "Sp_Order_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return result;
        }
        public async Task<IEnumerable<CustomerListDto>> GetCustomer(int userId)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "CUSTOMER_LIST");
            parameters.Add("@UserId", userId);
            var result = await connection.QueryAsync<CustomerListDto>(
                "Sp_Order_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure);
            return result;
        }

    }
}
