using AutoMapper;
using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;

namespace WorkingWithDapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            SetCauseMappings();
        }

       private void SetCauseMappings()
       {
            CreateMap<PostCausaRequestModel, CausaEntity>();
            CreateMap<PutCausaRequestModel, CausaEntity>();
        }
    }
}
