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
    public class MovieGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_MovieExists_DoesNothing()
        {
            // Arrange
            var movieContainer = new Mock<IMovieContainer>();

            var movie = new Movie();
            var movieDataAccess = new Mock<IMovieDataAccess>();
            movieDataAccess.Setup(x => x.GetByAsync(movieContainer.Object)).ReturnsAsync(movie);

            var movieGetService = new MovieGetService(movieDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => movieGetService.ValidateAsync(movieContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_MovieNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var movieContainer = new Mock<IMovieContainer>();
            movieContainer.Setup(x => x.MovieId).Returns(id);

            var movie = new Movie();
            var movieDataAccess = new Mock<IMovieDataAccess>();
            movieDataAccess.Setup(x => x.GetByAsync(movieContainer.Object)).ReturnsAsync((Movie)null);

            var movieGetService = new MovieGetService(movieDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => movieGetService.ValidateAsync(movieContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Movie not found by id {id}");
        }
    }
}