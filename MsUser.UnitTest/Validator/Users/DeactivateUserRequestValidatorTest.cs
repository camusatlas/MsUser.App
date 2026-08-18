using MsUser.Application;
using MsUser.Application.Users.Validators;
using MsUser.Internal.Contract.Users.Commands;

namespace MsUser.UnitTest.Validator.Users
{
    public class DeactivateUserRequestValidatorTest
    {
        private readonly DeactivateUserRequestValidator _validator = new();

        [Fact]
        public void Validate_WhenIdIsGreaterThanZero_ShouldBeValid()
        {
            var command = new DeactivateUserCommand(1);

            var result = _validator.Validate(command);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenIdIsZero_ShouldBeInvalid()
        {
            var command = new DeactivateUserCommand(0);

            var result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.IdGreaterZero);
        }

        [Fact]
        public void Validate_WhenIdIsNegative_ShouldBeInvalid()
        {
            var command = new DeactivateUserCommand(-1);

            var result = _validator.Validate(command);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.IdGreaterZero);
        }
    }
}