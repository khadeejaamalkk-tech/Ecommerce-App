using Ecommerce_App.DTOs;
using Ecommerce_App.Helpers;
using Ecommerce_App.Repositories;

namespace Ecommerce_App.Services
{
    public class SalesService: ISalesService
    {
        private readonly ISalesRepository _repository;
        public SalesService(ISalesRepository repository)
        {
            _repository = repository;
        }
        public async Task<ApiResponse<OrderDashboardDto>> GetOrderDashboard(int userId, DateTime? fromDate, DateTime? toDate)

        {
            try
            {
                var data = await _repository.GetOrderDashboard(userId, fromDate, toDate);

                if (data == null)
                {
                    return ApiResponse<OrderDashboardDto>.Fail("No data found");
                }

                return ApiResponse<OrderDashboardDto>.Success(data, "Dashboard fetched successfully");
            }
            catch (Exception ex)
            {
                return ApiResponse<OrderDashboardDto>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<IEnumerable<AllOrderListDto>>> GetAllOrders(int userId,DateTime? fromDate, DateTime? toDate)
        {
            try
            {
                var data = await _repository.GetAllOrders(userId, fromDate, toDate);
                return ApiResponse<IEnumerable<AllOrderListDto>>.Success(data, "Orders fetched successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<AllOrderListDto>>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<OrderDetailsDto>> GetOrderDetails(int orderId, int userId)
        {
            try
            {
                var data = await _repository.GetOrderDetails(orderId, userId);
                if (data == null)
                    return ApiResponse<OrderDetailsDto>.Fail("Order not found");
                return ApiResponse<OrderDetailsDto>.Success(data,"Order details fetched successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<OrderDetailsDto>.Fail(ex.Message);

            }
        }
        public async Task<ApiResponse<IEnumerable<AllOrderListDto>>> GetOrdersByStatus(int userId, string status, DateTime? fromDate, DateTime? toDate)

        {
            try
            {
                var data = await _repository.GetOrdersByStatus(userId, status,fromDate,toDate);
                return ApiResponse<IEnumerable<AllOrderListDto>>.Success(data, "Orders fetched successfully");
            }
            catch(Exception ex)
            {
                return ApiResponse<IEnumerable<AllOrderListDto>>.Fail(ex.Message);
            }
        }
        public async Task<ApiResponse<IEnumerable<CustomerListDto>>> GetCustomers(int userId)
        {
            try
            {
                var data = await _repository.GetCustomer(userId);
                return ApiResponse<IEnumerable<CustomerListDto>>.Success(data, "Customers fetched successfully");

            }
            catch (Exception ex)
            {
                return ApiResponse<IEnumerable<CustomerListDto>>.Fail(ex.Message);
            }
        }





    }
}
