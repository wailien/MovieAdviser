using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieAdviser.DataAccess.Context;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.DataAccess.Implementations
{
    public class MovieDataAccess : IMovieDataAccess
    {
        private GenreContext Context { get; }
        private IMapper Mapper { get; }

        public MovieDataAccess(GenreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Movie> InsertAsync(MovieUpdateModel movieUpdateModel)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Movie>(movieUpdateModel));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Movie>(result.Entity);
        }

        public async Task<IEnumerable<Movie>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Movie>>(
                await this.Context.Movie.Include(x => x.Genre).ToListAsync());

        }

        public async Task<Movie> GetAsync(IMovieIdentity iMovieIdentity)
        {
            var result = await this.Get(iMovieIdentity);
            return this.Mapper.Map<Movie>(result);
        }

        public async Task<Movie> UpdateAsync(MovieUpdateModel movieUpdateModel)
        {
            var existing = await this.Get(movieUpdateModel);

            var result = this.Mapper.Map(movieUpdateModel, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Movie>(result);
        }

        public async Task<Movie> GetByAsync(IMovieContainer iMovieContainer)
        {
            return iMovieContainer.MovieId.HasValue 
                ? this.Mapper.Map<Movie>(await this.Context.Movie.FirstOrDefaultAsync(x => x.Id == iMovieContainer.MovieId)) 
                : null;
        }

        private async Task<MovieAdviser.DataAccess.Entities.Movie> Get(IMovieIdentity movie)
        {
            if(movie == null)
                throw new ArgumentNullException(nameof(movie));
            return await this.Context.Movie.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == movie.Id);
        }
    }
}