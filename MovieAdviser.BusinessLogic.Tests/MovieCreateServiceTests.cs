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
    public class MovieCreateServiceTests
    {
        public class ScreeningCreateServiceTests
        {
            [Test]
            public async Task CreateAsync_MovieValidationSucceed_CreatesScreening()
            {
                // Arrange
                var movie = new MovieUpdateModel();
                var expected = new Movie();

                var genreGetService = new Mock<IGenreGetService>();
                genreGetService.Setup(x => x.ValidateAsync(movie));

                var movieDataAccess = new Mock<IMovieDataAccess>();
                movieDataAccess.Setup(x => x.InsertAsync(movie)).ReturnsAsync(expected);

                var movieGetService = new MovieCreateService(movieDataAccess.Object, genreGetService.Object);

                // Act
                var result = await movieGetService.CreateAsync(movie);

                // Assert
                result.Should().Be(expected);
            }

            [Test]
            public async Task CreateAsync_MovieValidationFailed_ThrowsError()
            {
                // Arrange
                var fixture = new Fixture();
                var movie = new MovieUpdateModel();
                var expected = fixture.Create<string>();

                var genreGetService = new Mock<IGenreGetService>();
                genreGetService
                    .Setup(x => x.ValidateAsync(movie))
                    .Throws(new InvalidOperationException(expected));

                var movieDataAccess = new Mock<IMovieDataAccess>();

                var movieGetService = new MovieCreateService(movieDataAccess.Object, genreGetService.Object);

                // Act
                var action = new Func<Task>(() => movieGetService.CreateAsync(movie));

                // Assert
                await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
                movieDataAccess.Verify(x => x.InsertAsync(movie), Times.Never);
            }
        }
    }
}