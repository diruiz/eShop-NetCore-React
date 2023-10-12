using AutoFixture;
using eShop.Models.eShopDbModels;
using eShop.Persistence.Context;
using eShop.Persistence.Repository.Implementation;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace eShop.UnitTests.Persistence.Repository;

public sealed class CatalogTypeRepositoryTests
{
    private EShopDBContext _context;
    private CatalogTypeRepository _repository;
    private IFixture _fixture;
    public CatalogTypeRepositoryTests()
    {
        _fixture = new Fixture();
        var options = new DbContextOptionsBuilder<EShopDBContext>()
            .UseInMemoryDatabase(databaseName: "DatabaseName")
            .Options;

        _context = new EShopDBContext(options);
        _repository = new CatalogTypeRepository(_context);

    }

    [Fact]
    public async Task TestYourMethod()
    {
        // Arrange
        var catalogTypeObject = CreateCatalogTypeObject();             

        // Act: 
        await _repository.Add(catalogTypeObject);
        _context.SaveChanges();

        // Assert: 
        catalogTypeObject.Id.Should().BeGreaterThan(0);        
    }

    private CatalogType CreateCatalogTypeObject()
    {
        return _fixture.Build<CatalogType>()
            .With(x => x.Id, 0)
            .Without(x => x.Catalogs)            
            .Create();
    }
}
