using Dapper;
using Ecommerce_App.Data;
using Ecommerce_App.DTOs;
using System.Data;

namespace Ecommerce_App.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly DapperContext _context;
        public CategoryRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<CategoryResponseDto> GetCategoryList(CategoryRequestDto request)
        {
            using var connection = _context.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "GET TO LIST");
            parameters.Add("@PageNumber", request.PageNumber);
            parameters.Add("@PageSize", request.PageSize);
            using var multi = await connection.QueryMultipleAsync(
                "sp_Category_CRUD",
                parameters,
                commandType: CommandType.StoredProcedure);
            var categories = await multi.ReadAsync<CategoryDto>();
            var totalRecords = await multi.ReadFirstOrDefaultAsync<int>();
            return new CategoryResponseDto
            {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalRecords = totalRecords,
                Categories = categories
            };

        }
    }
}
