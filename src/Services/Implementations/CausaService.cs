using AutoMapper;
using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;
using WorkingWithDapper.Repositories;

namespace WorkingWithDapper.Services.Implementations
{
    public class CausaService : ICausaService
    {
        private readonly ICauseRepository _causeRepository;
        private readonly IMapper _mapper;

        public CausaService(ICauseRepository causeRepository,
            IMapper mapper)
        {
            _causeRepository = causeRepository;
            _mapper = mapper;
        }

        public async Task<int> DeleteCausaAsync(int id)
        {
            try
            {
                return await _causeRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<IEnumerable<CausaEntity>> GetCausasAsyc()
        {
            return await _causeRepository.GetAllAsync();
        }

        public async Task<CausaEntity> GetCausaByIdAsync(int id)
        {
            return await _causeRepository.GetByIdAsync(id);
        }

        public async Task<int> PostCausaAsync(PostCausaRequestModel model)
        {
            var cause = _mapper.Map<CausaEntity>(model);

            try
            {
                return await _causeRepository.AddAsync(cause);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<int> PutCausaAsync(int id, PutCausaRequestModel model)
        {
            
            var cause = await GetCausaByIdAsync(id);

            _mapper.Map(model, cause);

            try
            {
                return await _causeRepository.UpdateAsync(cause);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        public async Task<IEnumerable<GetCausaResponseModel>> GetAllCausesWithActoCondicion()
        {
            return await _causeRepository.GetAllCausesWithActoCondicion();
        }
    }
}
