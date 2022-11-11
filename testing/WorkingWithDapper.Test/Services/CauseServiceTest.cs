using AutoMapper;
using FluentAssertions;
using Moq;
using WorkingWithDapper.Entities;
using WorkingWithDapper.Models;
using WorkingWithDapper.Repositories;
using WorkingWithDapper.Services.Implementations;

namespace WorkingWithDapper.Test.Services
{
    public class CauseServiceTest
    {
        [Fact]
        public async Task GetCausesTest()
        {
            //Arrange - (setup)
            var mockCauseRepository = new Mock<ICauseRepository>();
            var mockMapper = new Mock<IMapper>();

            mockCauseRepository.Setup(repo => repo.GetAllAsync())
                               .ReturnsAsync(new List<CausaEntity>());

            var service = new CausaService(mockCauseRepository.Object, mockMapper.Object);


            //Act - (call)
            var result = await service.GetCausasAsyc();

            //Assert - (verify)
            result.Should().BeAssignableTo<IEnumerable<CausaEntity>>();
        }

        [Fact]
        public async Task GetCausesWithActoCondicionTest()
        {
            //Arrange - (setup)
            var mockCauseRepository = new Mock<ICauseRepository>();
            var mockMapper = new Mock<IMapper>();

            mockCauseRepository.Setup(repo => repo.GetAllCausesWithActoCondicion())
                               .ReturnsAsync(new List<GetCausaResponseModel>());

            var service = new CausaService(mockCauseRepository.Object, mockMapper.Object);


            //Act - (call)
            var result = await service.GetAllCausesWithActoCondicion();

            //Assert - (verify)
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<GetCausaResponseModel>>();
        }

        [Fact]
        public async Task PostCauseTest()
        {
            //Arrange - (setup)
            var mockCauseRepository = new Mock<ICauseRepository>();
            var mockMapper = new Mock<IMapper>();
            var entity = new CausaEntity();
            var request = new PostCausaRequestModel();

            mockMapper.Setup(mapper => mapper.Map<CausaEntity>(request))
                                             .Returns(entity);

            mockCauseRepository.Setup(repo => repo.AddAsync(entity))
                               .ReturnsAsync(1);


            var service = new CausaService(mockCauseRepository.Object, mockMapper.Object);


            //Act - (call)
            var result = await service.PostCausaAsync(request);

            //Assert - (verify)
            result.Should().BeOfType(typeof(int));
            result.Equals(1);
        }

        [Fact]
        public async Task PutCauseTest()
        {
            //Arrange - (setup)
            var mockCauseRepository = new Mock<ICauseRepository>();
            var mockMapper = new Mock<IMapper>();
            var entity = new CausaEntity();
            var request = new PutCausaRequestModel();
            var id = 1;

            mockCauseRepository.Setup(repo => repo.GetByIdAsync(id))
                               .ReturnsAsync(entity);

            mockMapper.Setup(mapper => mapper.Map(request, entity))
                                             .Returns(entity);

            mockCauseRepository.Setup(repo => repo.UpdateAsync(entity))
                               .ReturnsAsync(1);


            var service = new CausaService(mockCauseRepository.Object, mockMapper.Object);


            //Act - (call)
            var result = await service.PutCausaAsync(id, request);

            //Assert - (verify)
            result.Should().BeOfType(typeof(int));
            result.Equals(1);
        }
    }
}
