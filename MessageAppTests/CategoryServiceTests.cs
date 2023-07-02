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

        public CategoryServiceTests()
        {
            this.configuration = new Mock<IConfiguration>();
            this.logger = new Mock<ILogger<ICategoryService>>();
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