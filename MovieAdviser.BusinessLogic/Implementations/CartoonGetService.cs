using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class CartoonGetService : ICartoonGetService
    {
        public Task<IEnumerable<Cartoon>> GetAsync()
        {
            return this.CartoonDataAccess.GetAsync();
        }

        public Task<Cartoon> GetAsync(ICartoonIdentity iCartoonIdentity)
        {
            return this.CartoonDataAccess.GetAsync(iCartoonIdentity);
        }

        public async Task ValidateAsync(ICartoonContainer cartoonContainer)
        {
            if (cartoonContainer == null)
            {
                throw new ArgumentNullException(nameof(cartoonContainer));
            }
            
            var cartoon = await this.GetBy(cartoonContainer);

            if (cartoonContainer.CartoonId.HasValue && cartoon == null)
            {
                throw new InvalidOperationException($"Cartoon not found by id {cartoonContainer.CartoonId}");
            }
        }
        
        private ICartoonDataAccess CartoonDataAccess { get; }
        
        public CartoonGetService(ICartoonDataAccess cartoonDataAccess)
        {
            this.CartoonDataAccess = cartoonDataAccess;
        }
        
        private Task<Cartoon> GetBy(ICartoonContainer cartoonContainer)
        {
            return this.CartoonDataAccess.GetByAsync(cartoonContainer);
        }
    }
}