using CLAMVC.Domain.Entities;
using FluentAssertions;
using System;
using Xunit;

namespace CLAMVC.Domain.Tests
{
    public class CategoryUnutTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjetctValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CLAMVC.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category With Negative Id Value")]
        public void CreateCategory_WithNegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id value.");
        }
        [Fact(DisplayName = "Create Category With Short Name Value")]
        public void CreateCategory_WithShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The name cannot be less than 3 characters.");
        }
        [Fact(DisplayName = "Create Category With Missing Name Value")]
        public void CreateCategory_WithMissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("The name cannot be null.");
        }
        [Fact(DisplayName = "Create Category With Null Name Value")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<CLAMVC.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
