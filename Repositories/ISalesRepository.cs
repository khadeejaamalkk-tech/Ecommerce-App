using Ecommerce_App.DTOs;

namespace Ecommerce_App.Repositories
{
    public interface ISalesRepository
    {
        Task<OrderDashboardDto> GetOrderDashboard(int userId, DateTime? fromDate, DateTime? toDate);
        Task<IEnumerable<AllOrderListDto>> GetAllOrders(int userId, DateTime? fromDate, DateTime? toDate);
        Task<OrderDetailsDto> GetOrderDetails(int orderId, int userId);
        Task<IEnumerable<AllOrderListDto>> GetOrdersByStatus(int userId, string status, DateTime? fromDate, DateTime? todate);
        Task<IEnumerable<CustomerListDto>> GetCustomer(int userId);
    }
}
