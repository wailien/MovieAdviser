using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.Client.DataTransferObjects.Read;
using MovieAdviser.Client.Requests;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.WebAPI.Controllers
{
    [ApiController]
    [Route("api/cartoon")]
    public class CartoonController
    {
        private ILogger<CartoonController> Logger { get; }
        private ICartoonCreateService CartoonCreateService { get; }
        private ICartoonGetService CartoonGetService { get; }
        private ICartoonUpdateService CartoonUpdateService { get; }
        private IMapper Mapper { get; }

        public CartoonController(ILogger<CartoonController> logger, IMapper mapper, ICartoonCreateService cartoonCreateService, ICartoonGetService cartoonGetService, ICartoonUpdateService cartoonUpdateService)
        {
            this.Logger = logger;
            this.CartoonCreateService = cartoonCreateService;
            this.CartoonGetService = cartoonGetService;
            this.CartoonUpdateService = cartoonUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<CartoonDTO> PutAsync(CartoonCreateDTO cartoon)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CartoonCreateService.CreateAsync(this.Mapper.Map<CartoonUpdateModel>(cartoon));

            return this.Mapper.Map<CartoonDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<CartoonDTO> PatchAsync(CartoonUpdateDTO cartoon)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.CartoonUpdateService.UpdateAsync(this.Mapper.Map<CartoonUpdateModel>(cartoon));

            return this.Mapper.Map<CartoonDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<CartoonDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<CartoonDTO>>(await this.CartoonGetService.GetAsync());
        }

        [HttpGet]
        [Route("{CartoonId}")]
        public async Task<CartoonDTO> GetAsync(int cartoonId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {cartoonId}");

            return this.Mapper.Map<CartoonDTO>(await this.CartoonGetService.GetAsync(new CartoonIdentityModel(cartoonId)));
        }
    }
}