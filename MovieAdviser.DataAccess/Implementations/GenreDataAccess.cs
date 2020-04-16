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
    public class GenreDataAccess : IGenreDataAccess
    {
        private GenreContext Context { get; }
        private IMapper Mapper { get; }
        
        public GenreDataAccess(GenreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }
        
        public async Task<Genre> InsertAsync(GenreUpdateModel genreUpdateModel)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Genre>(genreUpdateModel));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Genre>(result.Entity);
        }

        public async Task<IEnumerable<Genre>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Genre>>(
                await this.Context.Genre.ToListAsync());
        }

        public async Task<Genre> GetAsync(IGenreIdentity iGenreIdentity)
        {
            var result = await this.Get(iGenreIdentity);

            return this.Mapper.Map<Genre>(result);
        }

        public async Task<Genre> UpdateAsync(GenreUpdateModel genreUpdateModel)
        {
            var existing = await this.Get(genreUpdateModel);

            var result = this.Mapper.Map(genreUpdateModel, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Genre>(result);
        }

        public async Task<Genre> GetByAsync(IGenreContainer iGenreContainer)
        {
            return iGenreContainer.GenreId.HasValue 
                ? this.Mapper.Map<Genre>(await this.Context.Genre.FirstOrDefaultAsync(x => x.Id == iGenreContainer.GenreId)) 
                : null;
        }
        
        private async Task<MovieAdviser.DataAccess.Entities.Genre> Get(IGenreIdentity genre)
        {
          
            if(genre == null)
                throw new ArgumentNullException(nameof(genre));
            return await this.Context.Genre.FirstOrDefaultAsync(x => x.Id == genre.Id);
        }
    }
}