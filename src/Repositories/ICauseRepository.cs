using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;

namespace WorkingWithDapper.Repositories
{
    public interface ICauseRepository : IRepository<CausaEntity>
    {
        Task<IEnumerable<GetCausaResponseModel>> GetAllCausesWithActoCondicion();
    }
}
