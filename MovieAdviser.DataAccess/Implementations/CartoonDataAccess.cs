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
    public class CartoonDataAccess : ICartoonDataAccess
    {
        private GenreContext Context { get; }
        private IMapper Mapper { get; }

        public CartoonDataAccess(GenreContext context, IMapper mapper)
        {
            this.Context = context;
            Mapper = mapper;
        }

        public async Task<Cartoon> InsertAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<DataAccess.Entities.Cartoon>(cartoonUpdateModel));
            await this.Context.SaveChangesAsync();
            return this.Mapper.Map<Cartoon>(result.Entity);
        }

        public async Task<IEnumerable<Cartoon>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<Cartoon>>(
                await this.Context.Cartoon.Include(x => x.Genre).ToListAsync());

        }

        public async Task<Cartoon> GetAsync(ICartoonIdentity iCartoonIdentity)
        {
            var result = await this.Get(iCartoonIdentity);
            return this.Mapper.Map<Cartoon>(result);
        }

        public async Task<Cartoon> UpdateAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            var existing = await this.Get(cartoonUpdateModel);

            var result = this.Mapper.Map(cartoonUpdateModel, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<Cartoon>(result);
        }

        public async Task<Cartoon> GetByAsync(ICartoonContainer iCartoonContainer)
        {
            return iCartoonContainer.CartoonId.HasValue 
                ? this.Mapper.Map<Cartoon>(await this.Context.Cartoon.FirstOrDefaultAsync(x => x.Id == iCartoonContainer.CartoonId)) 
                : null;
        }

        private async Task<MovieAdviser.DataAccess.Entities.Cartoon> Get(ICartoonIdentity cartoon)
        {
            if(cartoon == null)
                throw new ArgumentNullException(nameof(cartoon));
            return await this.Context.Cartoon.Include(x => x.Genre).FirstOrDefaultAsync(x => x.Id == cartoon.Id);
        }
    }
}