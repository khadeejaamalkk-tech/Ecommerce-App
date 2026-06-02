using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;

namespace Ecommerce_App.Services
{
    public interface ISalesService
    {
        Task<ApiResponse<OrderDashboardDto>> GetOrderDashboard(int userId, DateTime? fromDate, DateTime? toDate);
        Task<ApiResponse<IEnumerable<AllOrderListDto>>> GetAllOrders(int userId, DateTime? fromDate, DateTime? toDate);
        Task<ApiResponse<OrderDetailsDto>> GetOrderDetails(int orderId, int userId);
        Task<ApiResponse<IEnumerable<AllOrderListDto>>> GetOrdersByStatus(int userId, string status, DateTime? fromDate, DateTime? toDate);
        Task<ApiResponse<IEnumerable<CustomerListDto>>> GetCustomers(int userId);
    }
}
