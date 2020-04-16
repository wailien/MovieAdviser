using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MovieAdviser.BusinessLogic.Implementations;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;
using NUnit.Framework;

namespace MovieAdviser.BusinessLogic.Tests
{
    public class CartoonGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_CartoonExists_DoesNothing()
        {
            // Arrange
            var cartoonContainer = new Mock<ICartoonContainer>();

            var cartoon = new Cartoon();
            var cartoonDataAccess = new Mock<ICartoonDataAccess>();
            cartoonDataAccess.Setup(x => x.GetByAsync(cartoonContainer.Object)).ReturnsAsync(cartoon);

            var cartoonGetService = new CartoonGetService(cartoonDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cartoonGetService.ValidateAsync(cartoonContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_CartoonNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var cartoonContainer = new Mock<ICartoonContainer>();
            cartoonContainer.Setup(x => x.CartoonId).Returns(id);

            var cartoon = new Cartoon();
            var cartoonDataAccess = new Mock<ICartoonDataAccess>();
            cartoonDataAccess.Setup(x => x.GetByAsync(cartoonContainer.Object)).ReturnsAsync((Cartoon)null);

            var cartoonGetService = new CartoonGetService(cartoonDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => cartoonGetService.ValidateAsync(cartoonContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Cartoon not found by id {id}");
        }
    }
}