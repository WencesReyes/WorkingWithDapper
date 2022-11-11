using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;

namespace WorkingWithDapper.Services
{
    public interface ICausaService
    {
        Task<IEnumerable<GetCausaResponseModel>> GetAllCausesWithActoCondicion();
        Task<IEnumerable<CausaEntity>> GetCausasAsyc();
        Task<CausaEntity> GetCausaByIdAsync(int id);
        Task<int> PostCausaAsync(PostCausaRequestModel model);
        Task<int> PutCausaAsync(int id, PutCausaRequestModel model);
        Task<int> DeleteCausaAsync(int id);
    }
}
