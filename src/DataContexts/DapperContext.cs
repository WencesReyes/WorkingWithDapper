using System.Data;
using System.Data.SqlClient;

namespace WorkingWithDapper.DataContexts
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection(string connectionString = "DapperConnection")
            => new SqlConnection(_configuration.GetConnectionString(connectionString));
    }
}
