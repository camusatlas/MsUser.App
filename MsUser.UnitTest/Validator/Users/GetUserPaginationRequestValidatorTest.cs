using MsUser.Application;
using MsUser.Application.Users.Validators;
using MsUser.Internal.Contract.Users.Queries;
using RealPlaza.Core.Common.Contracts;

namespace MsUser.UnitTest.Validator.Users
{
    public class GetUserPaginationRequestValidatorTest
    {
        private readonly GetUserPaginationRequestValidator _validator = new();

        [Fact]
        public void Validate_WhenPageAndPageSizeAreGreaterThanZero_ShouldBeValid()
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: "Name",
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void Validate_WhenPageIsZero_ShouldBeInvalid()
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(0, 10),
                SortColumn: "Name",
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.IntPagination);
        }

        [Fact]
        public void Validate_WhenPageSizeIsZero_ShouldBeInvalid()
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 0),
                SortColumn: "Name",
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.PageSizePagination);
        }

        [Fact]
        public void Validate_WhenPageAndPageSizeAreNegative_ShouldBeInvalid()
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(-1, -10),
                SortColumn: "Name",
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.IntPagination);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.PageSizePagination);
        }
    }
}