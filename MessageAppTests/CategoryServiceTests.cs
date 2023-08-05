using MessageApp.Controllers;
using MessageApp.Interfaces;
using MessageApp.Models;
using MessageApp.Repositories;
using MessageApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

using Microsoft.Extensions.Configuration;



namespace MessageAppTests
{
    public class CategoryServiceTests

    {
        readonly Mock<IConfiguration> configuration;
        readonly Mock<ILogger<ICategoryService>> logger;

        private Mock<ICategoryRepository> _mockCategoryRepository = new Mock<ICategoryRepository>();
        private Category[] _categories = { 
            new Category { CategoryID = 1, Date = DateTime.MinValue, Title = "ABC" },
            new Category { CategoryID = 2, Date = DateTime.MaxValue, Title = "BBC" } };

        public CategoryServiceTests()
        {
            this.configuration = new Mock<IConfiguration>();
            this.logger = new Mock<ILogger<ICategoryService>>();
        }

        [Fact]
        public async void GetCategory_ReturnsCategories_WhenCategoriesFound()
        {
            _mockCategoryRepository.Setup(r => r.GetCategories()).ReturnsAsync(_categories);
            ICategoryService categoryService = new CategoryService(_mockCategoryRepository.Object);

            var result = (await categoryService.GetCategories()).Value;
            Assert.Equal(result, _categories);
            Assert.NotNull(result);
        }

        [Fact]
        public async void PostCategory_ReturnsString_WhenCategoryPosted()
        {
            //Arrange
            Category category = new Category()
            {
                Title = "Abc abc bbx"
            };
            Mock<ICategoryRepository> mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(r => r.PostCategory(category)).ReturnsAsync("Category added successfully");
            ICategoryService categoryService = new CategoryService(mockCategoryRepository.Object);
            string expected = "Category added successfully";

            //Act
            
            var result = await categoryService.PostCategory(category);

            //Assert
            Assert.Equal(expected, result?.Value?.ToString());

        }

        [Fact]
        public async void PostCategory_ReturnsString_WhenCategoryInvalid()
        {
            //Arrange
            Category category = new Category();
            Mock<ICategoryRepository> mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(r => r.PostCategory(category)).ReturnsAsync("Category added successfully");
            ICategoryService categoryService = new CategoryService(mockCategoryRepository.Object);
            string expected = "Category invalid";

            //Act

            var result = await categoryService.PostCategory(category);

            //Assert
            Assert.Equal(expected, result?.Value?.ToString());
        }
    }
}