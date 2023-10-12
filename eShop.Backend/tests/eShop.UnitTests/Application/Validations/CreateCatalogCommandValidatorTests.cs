using AutoFixture;
using eShop.Application.Commands;
using eShop.Application.Validations;
using eShop.Models.eShopDbModels;
using FluentAssertions;
using FluentValidation.TestHelper;

namespace eShop.UnitTests.Application.Validations;

public class CreateCatalogCommandValidatorTests
{
    private readonly CreateCatalogCommandValidator _validator;
    private readonly IFixture _fixture;
    public CreateCatalogCommandValidatorTests()
    {
        _validator = new CreateCatalogCommandValidator();
        _fixture = new Fixture();
    }

    [Fact]
    public void ShouldHaveErrorWhenNameIsNull()
    {
        // Arrange
        var catalog = CreateCatalogObject();
        catalog.Name = null;

        // Act
        var result = _validator.TestValidate(catalog);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ShouldHaveErrorWhenNameIsEmpty()
    {
        // Arrange
        var catalog = CreateCatalogObject();
        catalog.Name = string.Empty;

        // Act
        var result = _validator.TestValidate(catalog);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Name);
    }

    [Fact]
    public void ShouldHaveErrorWhenPictureFileNameIsNotUrl()
    {
        // Arrange
        var catalog = CreateCatalogObject();
        catalog.PictureFileName = "random string";

        // Act
        var result = _validator.TestValidate(catalog);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.PictureFileName);
    }

    [Fact]
    public void ShouldNotHaveError()
    {
        var catalog = CreateCatalogObject();
        var result = _validator.TestValidate(catalog);
        result.IsValid.Should().Be(true);
    }
    private CreateCatalogCommand CreateCatalogObject()
    {
        return _fixture.Build<CreateCatalogCommand>()
            .With(x => x.PictureFileName, "https://image.com")            
            .Create();
    }
}
