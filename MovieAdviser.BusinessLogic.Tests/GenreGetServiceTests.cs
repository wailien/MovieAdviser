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
    public class GenreGetServiceTests
    {
        [Test]
        public async Task ValidateAsync_GenreExists_DoesNothing()
        {
            // Arrange
            var genreContainer = new Mock<IGenreContainer>();

            var genre = new Genre();
            var genreDataAccess = new Mock<IGenreDataAccess>();
            genreDataAccess.Setup(x => x.GetByAsync(genreContainer.Object)).ReturnsAsync(genre);

            var genreGetService = new GenreGetService(genreDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => genreGetService.ValidateAsync(genreContainer.Object));
            
            // Assert
            await action.Should().NotThrowAsync<Exception>();
        }
        
        [Test]
        public async Task ValidateAsync_GenreNotExists_ThrowsError()
        {
            // Arrange
            var fixture = new Fixture();
            var id = fixture.Create<int>();
            
            var genreContainer = new Mock<IGenreContainer>();
            genreContainer.Setup(x => x.GenreId).Returns(id);

            var genre = new Genre();
            var genreDataAccess = new Mock<IGenreDataAccess>();
            genreDataAccess.Setup(x => x.GetByAsync(genreContainer.Object)).ReturnsAsync((Genre)null);

            var genreGetService = new GenreGetService(genreDataAccess.Object);
            
            // Act
            var action = new Func<Task>(() => genreGetService.ValidateAsync(genreContainer.Object));
            
            // Assert
            await action.Should().ThrowAsync<InvalidOperationException>($"Genre not found by id {id}");
        }
    }
}