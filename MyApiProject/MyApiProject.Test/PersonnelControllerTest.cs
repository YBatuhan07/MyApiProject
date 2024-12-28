using Moq;
using MyApiProject.ApplicationLayer.Personnels;
using MyApiProject.Database.UnitOfWork;
using MyApiProject.ViewModel;
using MyApiProject.DomainLayer.Shared;
using MyApiProject.DomainLayer;

namespace MyApiProject.Test;

public class PersonnelControllerTest
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly PersonnelService _service;

    public PersonnelControllerTest()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _service = new PersonnelService(_mockUnitOfWork.Object);
    }

    [Fact]
    public async Task AddAsync_ValidModel_AddsPersonnelAndReturnsModelWithId()
    {
        var model = new AddPersonnelModel()
        {
            BirthDate = new DateTime(1990,1,1),
            DistrictId = 1,
            FullName = "Batuhan Keskin",
            Gender = GenderType.Male,
        };

        var personnel = new Personnel()
        {
            BirthDate = model.BirthDate,
            DistrictId = model.DistrictId,
            FullName = model.FullName,
            Gender = model.Gender,
        };

        _mockUnitOfWork.Setup(u => u.PersonelRepository.AddAsync(It.IsAny<Personnel>())).ReturnsAsync((Personnel p) => { 
            p.Id = 1;
            return p;
        });

        _mockUnitOfWork.Setup(u => u.CompleteAsync()).Returns(Task.FromResult(0));
        _mockUnitOfWork.Setup(u => u.PersonelRepository.AddAsync(It.Is<Personnel>(p => p == personnel)))
            .Callback<Personnel>(p => model.Id = p.Id);

        var result = await _service.AddAsync(model);

        Assert.Equal(1, result.Id);
        _mockUnitOfWork.Verify(u => u.PersonelRepository.AddAsync(It.IsAny<Personnel>()),Times.Once);
        _mockUnitOfWork.Verify(u => u.CompleteAsync(),Times.Once);
    }

}
