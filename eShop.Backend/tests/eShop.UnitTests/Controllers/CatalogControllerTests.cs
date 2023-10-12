using AutoFixture;
using eShop.API.Controllers;
using eShop.Application.Commands;
using eShop.Models.eShopDbModels;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace eShop.UnitTests.Controllers;

public sealed class CatalogControllerTests
{
    private CatalogController _catalogController;
    private IFixture _fixture;
    private Mock<IMediator> _mediator;
    public CatalogControllerTests()
    {
        this._fixture = new Fixture();
        this._mediator = new Mock<IMediator>();
        
        this._catalogController = new CatalogController(this._mediator.Object)
        {
            ControllerContext = new ControllerContext()
        };
    }

    [Fact]
    public async Task ShouldCreateSingleCatalogItem() {
        
        // Arrange
        var catalogItem = CreateCatalogCommandObject();
        _mediator.Setup(m => m.Send(It.IsAny<CreateCatalogCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(CreateCatalogObject()));  
       
        // Act
        var response = await this._catalogController.Post(catalogItem);

        // Assert
        response.Should().BeOfType<CreatedResult>();
    }

    private CreateCatalogCommand CreateCatalogCommandObject()
    {
        return _fixture.Build<CreateCatalogCommand>().Create();
    }

    private Catalog CreateCatalogObject()
    {
        return _fixture.Build<Catalog>()
            .Without(x => x.CatalogBrand)
            .Without(x => x.CatalogType)
            .Create();
    }
}
