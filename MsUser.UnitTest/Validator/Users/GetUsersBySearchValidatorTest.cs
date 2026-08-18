using MsUser.Application;
using MsUser.Application.Users.Validators;
using MsUser.Internal.Contract.Users.Queries;

namespace MsUser.UnitTest.Users.Validators
{
    public class GetUsersBySearchValidatorTest
    {
        private readonly GetUsersBySearchValidator _validator = new();

        [Fact]
        public void Validate_WhenNoFilters_ShouldBeValid()
        {
            var query = new GetUserBySearch(
                id: null,
                name: null,
                mail: null,
                asset: null,
                state: null);

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenIdIsZero_ShouldBeInvalid()
        {
            var query = new GetUserBySearch(
                id: 0,
                name: null,
                mail: null,
                asset: null,
                state: null);

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.IdGreaterZero);
        }

        [Fact]
        public void Validate_WhenIdIsPositive_ShouldBeValid()
        {
            var query = new GetUserBySearch(
                id: 1,
                name: null,
                mail: null,
                asset: null,
                state: null);

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenMailHasInvalidFormat_ShouldBeInvalid()
        {
            var query = new GetUserBySearch(
                id: null,
                name: null,
                mail: "correo-invalido",
                asset: null,
                state: null);

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.Mail);
        }

        [Fact]
        public void Validate_WhenMailHasValidFormat_ShouldBeValid()
        {
            var query = new GetUserBySearch(
                id: null,
                name: null,
                mail: "usuario@gmail.com",
                asset: null,
                state: null);

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }
    }
}