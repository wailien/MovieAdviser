using System;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Moq;
using MovieAdviser.BusinessLogic.Implementations;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;
using NUnit.Framework;

namespace MovieAdviser.BusinessLogic.Tests
{
    public class CartoonUpdateServiceTests
    {
        public class ScreeningCreateServiceTests
        {
            [Test]
            public async Task CreateAsync_CartoonValidationSucceed_CreatesScreening()
            {
                // Arrange
                var cartoon = new CartoonUpdateModel();
                var expected = new Cartoon();

                var genreGetService = new Mock<IGenreGetService>();
                genreGetService.Setup(x => x.ValidateAsync(cartoon));

                var cartoonDataAccess = new Mock<ICartoonDataAccess>();
                cartoonDataAccess.Setup(x => x.InsertAsync(cartoon)).ReturnsAsync(expected);

                var cartoonGetService = new CartoonCreateService(cartoonDataAccess.Object, genreGetService.Object);

                // Act
                var result = await cartoonGetService.CreateAsync(cartoon);

                // Assert
                result.Should().Be(expected);
            }

            [Test]
            public async Task CreateAsync_CartoonValidationFailed_ThrowsError()
            {
                // Arrange
                var fixture = new Fixture();
                var cartoon = new CartoonUpdateModel();
                var expected = fixture.Create<string>();

                var genreGetService = new Mock<IGenreGetService>();
                genreGetService
                    .Setup(x => x.ValidateAsync(cartoon))
                    .Throws(new InvalidOperationException(expected));

                var cartoonDataAccess = new Mock<ICartoonDataAccess>();

                var cartoonGetService = new CartoonCreateService(cartoonDataAccess.Object, genreGetService.Object);

                // Act
                var action = new Func<Task>(() => cartoonGetService.CreateAsync(cartoon));

                // Assert
                await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
                cartoonDataAccess.Verify(x => x.InsertAsync(cartoon), Times.Never);
            }
        }
    }
}