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
        public void Validate_WhenRequestIsValid_ShouldBeValid()
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
        public void Validate_WhenSortColumnAndSortDirectionAreNull_ShouldBeValid()
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: null,
                SortDirection: null);

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

        [Theory]
        [InlineData("Name")]
        [InlineData("Mail")]
        [InlineData("Asset")]
        [InlineData("State")]
        [InlineData("CreatedDate")]
        public void Validate_WhenSortColumnIsAllowed_ShouldBeValid(string sortColumn)
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: sortColumn,
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("Password")]
        [InlineData("Id")]
        [InlineData("CreatedUser")]
        [InlineData("name")]
        [InlineData("mail")]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenSortColumnIsInvalid_ShouldBeInvalid(string sortColumn)
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: sortColumn,
                SortDirection: "ASC");

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.SortColumnInvalid);
        }

        [Theory]
        [InlineData("ASC")]
        [InlineData("DESC")]
        public void Validate_WhenSortDirectionIsAllowed_ShouldBeValid(string sortDirection)
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: "Name",
                SortDirection: sortDirection);

            var result = _validator.Validate(query);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData("DOWN")]
        [InlineData("UP")]
        [InlineData("asc")]
        [InlineData("desc")]
        [InlineData("ORDER")]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenSortDirectionIsInvalid_ShouldBeInvalid(string sortDirection)
        {
            var query = new GetUserPagination(
                name: null,
                Paging: new Paging(1, 10),
                SortColumn: "Name",
                SortDirection: sortDirection);

            var result = _validator.Validate(query);

            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, x =>
                x.ErrorMessage == ValidationMessages.SortDirectionInvalid);
        }
    }
}