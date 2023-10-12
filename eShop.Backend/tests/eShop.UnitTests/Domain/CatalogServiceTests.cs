using AutoFixture;
using eShop.Domain.Services.Implementation;
using eShop.Models.eShopDbModels;
using eShop.Persistence.UnitOfWork.Interface;
using FluentAssertions;
using Moq;

namespace eShop.UnitTests.Domain;

public sealed class CatalogServiceTests
{
    private readonly CatalogService _catalogService;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly IFixture _fixture;
    public CatalogServiceTests()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _catalogService = new CatalogService(_unitOfWork.Object);
        _fixture = new Fixture();
    }

    [Theory]
    [InlineData(1)]
    public async Task ShouldGetCatalogById(int id)
    {
        // Arrange
        var catalog = CreateCatalogObject();
        _unitOfWork.Setup(u => u.Catalog.GetById(It.IsAny<int>())).Returns(Task.FromResult(catalog));

        // Act
        var response = await _catalogService.GetCatalogById(id);

        // Assert
        response.Should().Be(catalog);

    }

    private Catalog CreateCatalogObject()
    {
        return _fixture.Build<Catalog>()
            .Without(x => x.CatalogBrand)
            .Without(x => x.CatalogType)
            .Create();
    }
}
