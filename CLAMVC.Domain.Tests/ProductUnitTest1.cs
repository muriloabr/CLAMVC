using CLAMVC.Domain.Entities;
using FluentAssertions;
using System;
using System.Diagnostics;
using Xunit;

namespace CLAMVC.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidParameters_ResultObjetctValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, 1500, "Product Image");
            action.Should().NotThrow<CLAMVC.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Negative Id Value")]
        public void CreateProduct_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Descripition", 1.10m, 1500, "Product Image");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The id cannot be less than 0.");
        }
        [Fact(DisplayName = "Create Product With Short Name Value")]
        public void CreateProduct_WithShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Descripition", 1.10m, 1500, "Product Image");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The name cannot be less than 3 characters.");
        }
        [Fact(DisplayName = "Create Product With Image Name Long")]
        public void CreateProduct_WithLongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, 1500, "Product ImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImageImage");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The image name cannot be more than 250 characters.");
        }
        [Fact(DisplayName = "Create Product With Null Image Name Value")]
        public void CreateProduct_WithNullImageNameValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, 1500, null);
            action.Should().NotThrow<CLAMVC.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Null Image Name Value")]
        public void CreateProduct_WithNullImageNameValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, 1500, null);
            action.Should().NotThrow<NullReferenceException>();
        }
        [Fact(DisplayName = "Create Product With Empty Image Name Value")]
        public void CreateProduct_WithEmptyImageNameValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, 1500, "");
            action.Should().NotThrow<CLAMVC.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Product With Invalid Price Value")]
        public void CreateProduct_WithEmptyInvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", -1.10m, 1500, "");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The price cannot be less than 0.");
        }

        [Theory(DisplayName = "Create Product With Invalid Stock Value")]
        [InlineData(-5)]
        public void CreateProduct_WithInvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Product Name", "Product Descripition", 1.10m, value, "Product Image");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The stock cannot be less than 0.");
        }
    }
}
