using AutoFixture;
using AutoMapper;
using eShop.Application.Commands;
using eShop.Application.Commands.Handlers;
using eShop.Domain.Services.Interfaces;
using eShop.Models.eShopDbModels;
using Moq;

namespace eShop.UnitTests.Domain.Commands;

public sealed class CreateCatalogBrandCommandHandlerTests
{
    private readonly Mock<ICatalogBrandService> _service;
    private readonly CreateCatalogBrandCommandHandler _handler;
    private readonly IFixture _fixture;
    private readonly Mock<IMapper> _mapper;

    public CreateCatalogBrandCommandHandlerTests()
    {
        this._service = new Mock<ICatalogBrandService>();
        this._mapper = new Mock<IMapper>();
        this._handler = new CreateCatalogBrandCommandHandler(_service.Object, _mapper.Object);
        this._fixture = new Fixture();

    }

    [Fact]
    public async Task ShouldCreateSingleCatalogBrandItem()
    { 
        // Arrange
        var command = CreateCatalogBrandCommandObject();
        CancellationToken cancellationToken = default;
        var response = CreateCatalogBrandObject();

        _mapper.Setup(x => x.Map<CatalogBrand>(command)).Returns(response);
        _service.Setup(x => x.CreateCatalogBrand(It.IsAny<CatalogBrand>())).Returns(Task.FromResult(response));

        // Act
        var result = await _handler.Handle(command, cancellationToken);

        // Assert
        result.Equals(response);
    }

    private CreateCatalogBrandCommand CreateCatalogBrandCommandObject()
    {
        return _fixture.Build<CreateCatalogBrandCommand>().Create();
    }

    private CatalogBrand CreateCatalogBrandObject()
    {
        return _fixture.Build<CatalogBrand>().Without(x => x.Catalogs).Create();
    }
}
