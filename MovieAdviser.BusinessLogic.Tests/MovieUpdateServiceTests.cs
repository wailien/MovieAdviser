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
    public class MovieUpdateServiceTests
    {
        [Test]
        public async Task UpdateAsync_MovieValidationSucceed_CreatesScreening()
        {
            // Arrange
            var movie = new MovieUpdateModel();
            var expected = new Movie();
            
            var genreGetService = new Mock<IGenreGetService>();
            genreGetService.Setup(x => x.ValidateAsync(movie));
            
            var movieDataAccess = new Mock<IMovieDataAccess>();
            movieDataAccess.Setup(x => x.UpdateAsync(movie)).ReturnsAsync(expected);
            
            var movieGetService = new MovieUpdateService(movieDataAccess.Object, genreGetService.Object);
            
            // Act
            var result = await movieGetService.UpdateAsync(movie);
            
            // Assert
            result.Should().Be(expected);
        }
        
        [Test]
        public async Task UpdateAsync_MovieValidationFailed_ThrowsError()
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

            var movieGetService = new MovieUpdateService(movieDataAccess.Object, genreGetService.Object);
            
            // Act
            var action = new Func<Task>(() => movieGetService.UpdateAsync(movie));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>().WithMessage(expected);
            movieDataAccess.Verify(x => x.UpdateAsync(movie), Times.Never);
        }
    }
}