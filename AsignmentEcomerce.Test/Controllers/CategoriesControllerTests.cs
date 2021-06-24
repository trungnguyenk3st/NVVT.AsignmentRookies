using AsignmentEcomerce.Controllers;
using AsignmentEcomerce.Models;
using AsignmentEcomerce.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AsignmentEcomerce.Test.Controllers
{
    public class CategoriesControllerTests : IClassFixture<SqliteInMemoryFixture>
    {
        private readonly SqliteInMemoryFixture _fixture;
        public CategoriesControllerTests(SqliteInMemoryFixture fixture)
        {
            _fixture = fixture;
            _fixture.CreateDatabase();
        }

        [Fact]
        public async Task PostCategory_Success()
        {
            var dbContext = _fixture.Context;
            var category = new CategoryCreateRequest { NameCategory = "Test category" };

            var controller = new CategoryController(dbContext);
            var result = await controller.PostCategorys(category);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<CategoryVm>(createdAtActionResult.Value);
            Assert.Equal("Test category", returnValue.NameCategory);
        }

        [Fact]
        public async Task GetCategory_Success()
        {
            var dbContext = _fixture.Context;
            dbContext.Categorys.Add(new Category { NameCategory = "Test category" });
            await dbContext.SaveChangesAsync();

            var controller = new CategoryController(dbContext);
            var result = await controller.GetCategory();

            var actionResult = Assert.IsType<ActionResult<IEnumerable<CategoryVm>>>(result);
            Assert.NotEmpty(actionResult.Value);
        }

        [Theory]
        [InlineData(2)]
        public async Task GetCategoryById_Success(int id)
        {
            var dbContext = _fixture.Context;
            dbContext.Categorys.Add(new Category { IDCategory = 2 , NameCategory = "Test category"});

            await dbContext.SaveChangesAsync();

            var controller = new CategoryController(dbContext);
            var result = await controller.GetCategorys(id);

            var actionResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            Assert.NotNull(actionResult.Value);
        }
        [Fact]
        public async Task PutCategory_Success()
        {
            // Arrange
            var dbContext = _fixture.Context;

            dbContext.Categorys.Add(new Category { NameCategory = "Test category" });
            await dbContext.SaveChangesAsync();

            var oldCategory = TestData.CateTestData();
            await dbContext.AddAsync(oldCategory);
            await dbContext.SaveChangesAsync();

            var newCategory = TestData.CateCreateTestData();

            var categoriesController = new CategoryController(dbContext);

            // Act
            var result = await categoriesController.PutCategorys(oldCategory.IDCategory, newCategory);

            // Assert
            var postCategoryResult = Assert.IsType<ActionResult<CategoryVm>>(result);
            var resultValue = Assert.IsType<CategoryVm>(postCategoryResult.Value);

            Assert.Equal("Name Category Test New", resultValue.NameCategory);
         
        }
    }
}
