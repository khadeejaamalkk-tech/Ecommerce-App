using Dapper;
using Ecommerce_App.DTOs;
using Ecommerce_App.Models;
using Ecommerce_App.Data;
using System.Data;

namespace Ecommerce_App.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly DapperContext _context;
        public UserRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<UpdateUserResponseDto> UpdateUser(int Id, UpdateUserRequestDto request,string photoPath)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", "UPDATE_USER");
            parameters.Add("@Id", Id);

            parameters.Add("@Name", request.Name);
            parameters.Add("@Pin", request.Pin);
            parameters.Add("@Address1", request.Address1);
            parameters.Add("@Address2", request.Address2);
            parameters.Add("@Address3", request.Address3);
            parameters.Add("@Photo", photoPath);

            using (var connection = _context.CreateConnection())
            {
                var result= await connection.QuerySingleOrDefaultAsync<UpdateUserResponseDto>(
                    "sp_Registration_CRUD",
                    parameters,
                    commandType: CommandType.StoredProcedure);
                return result;
            }

        }
    }
}
