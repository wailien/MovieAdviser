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
    [Route("api/genre")]

    public class GenreController
    {
        private ILogger<GenreController> Logger { get; }
        private IGenreCreateService GenreCreateService { get; }
        private IGenreGetService GenreGetService { get; }
        private IGenreUpdateService GenreUpdateService { get; }
        private IMapper Mapper { get; }

        public GenreController(ILogger<GenreController> logger, IMapper mapper, IGenreCreateService genreCreateService, IGenreGetService genreGetService, IGenreUpdateService genreUpdateService)
        {
            this.Logger = logger;
            this.GenreCreateService = genreCreateService;
            this.GenreGetService = genreGetService;
            this.GenreUpdateService = genreUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<GenreDTO> PutAsync(GenreCreateDTO genre)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.GenreCreateService.CreateAsync(this.Mapper.Map<GenreUpdateModel>(genre));

            return this.Mapper.Map<GenreDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<GenreDTO> PatchAsync(GenreUpdateDTO genre)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.GenreUpdateService.UpdateAsync(this.Mapper.Map<GenreUpdateModel>(genre));

            return this.Mapper.Map<GenreDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<GenreDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<GenreDTO>>(await this.GenreGetService.GetAsync());
        }

        [HttpGet]
        [Route("{GenreId}")]
        public async Task<GenreDTO> GetAsync(int genreId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {genreId}");

            return this.Mapper.Map<GenreDTO>(await this.GenreGetService.GetAsync(new GenreIdentityModel(genreId)));
        }
    }
}