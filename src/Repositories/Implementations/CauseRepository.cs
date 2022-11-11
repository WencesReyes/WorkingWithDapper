using Dapper;
using WorkingWithDapper.DataContexts;
using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;

namespace WorkingWithDapper.Repositories.Implementations
{
    public class CauseRepository : ICauseRepository
    {
        private readonly DapperContext _dapperContext;

        public CauseRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<int> AddAsync(CausaEntity entity)
        {
            using var connection = _dapperContext.GetConnection();

            var sqlStatement = "insert into Causa values (@Nombre, @ActoCondicionId, @Tipo)";

            var rowsAffected = await connection.ExecuteAsync(sqlStatement, entity);

            return rowsAffected;
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var connection = _dapperContext.GetConnection();

            var parameters = new DynamicParameters(new
            {
                Id = id,
            });

            var sqlStatement = "delete Causa where Id = @Id";

            var rowsAffected = await connection.ExecuteAsync(sqlStatement, parameters);

            return rowsAffected;
        }

        public async Task<IEnumerable<CausaEntity>> GetAllAsync()
        {
            using var connection = _dapperContext.GetConnection();

            var sqlStatement = @"select Id, Nombre, ActoCondicionId, Tipo
                                 from Causa";

            var causas = await connection.QueryAsync<CausaEntity>(sqlStatement);

            return causas;
        }

        public async Task<IEnumerable<GetCausaResponseModel>> GetAllCausesWithActoCondicion()
        {
            using var connection = _dapperContext.GetConnection();

            var sqlStatement = @"select c.Id, c.Nombre, a.Nombre as ActoCondicion
                                from Causa c
                                inner join ActoCondicion a
                                on c.ActoCondicionId = a.Id";

            var causes = await connection.QueryAsync<GetCausaResponseModel>(sqlStatement);

            return causes;
        }

        public async Task<CausaEntity> GetByIdAsync(int id)
        {
            using var connection = _dapperContext.GetConnection();

            var parameters = new DynamicParameters(new
            {
                Id = id,
            });

            var sqlStatement = @"select Id, Nombre, ActoCondicionId, Tipo
                                 from Causa
                                 where Id = @Id";

            var causa = await connection.QueryFirstOrDefaultAsync<CausaEntity>(sqlStatement, parameters);

            return causa;
        }

        public async Task<int> UpdateAsync(CausaEntity entity)
        {
            using var connection = _dapperContext.GetConnection();

            var sqlStatement = @"update Causa
                                 set Nombre = @Nombre,
                                     ActoCondicionId = @ActoCondicionId,
                                     Tipo = @Tipo
                                 where Id = @Id";
   
            var rowsAffected = await connection.ExecuteAsync(sqlStatement, entity);
            
            return rowsAffected;
        }
    }
}
