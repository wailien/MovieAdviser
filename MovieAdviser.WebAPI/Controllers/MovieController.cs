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
    [Route("api/movie")]

    public class MovieController
    {
        private ILogger<MovieController> Logger { get; }
        private IMovieCreateService MovieCreateService { get; }
        private IMovieGetService MovieGetService { get; }
        private IMovieUpdateService MovieUpdateService { get; }
        private IMapper Mapper { get; }

        public MovieController(ILogger<MovieController> logger, IMapper mapper, IMovieCreateService movieCreateService, IMovieGetService movieGetService, IMovieUpdateService movieUpdateService)
        {
            this.Logger = logger;
            this.MovieCreateService = movieCreateService;
            this.MovieGetService = movieGetService;
            this.MovieUpdateService = movieUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<MovieDTO> PutAsync(MovieCreateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.MovieCreateService.CreateAsync(this.Mapper.Map<MovieUpdateModel>(movie));

            return this.Mapper.Map<MovieDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<MovieDTO> PatchAsync(MovieUpdateDTO movie)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.MovieUpdateService.UpdateAsync(this.Mapper.Map<MovieUpdateModel>(movie));

            return this.Mapper.Map<MovieDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<MovieDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<MovieDTO>>(await this.MovieGetService.GetAsync());
        }

        [HttpGet]
        [Route("{MovieId}")]
        public async Task<MovieDTO> GetAsync(int movieId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {movieId}");

            return this.Mapper.Map<MovieDTO>(await this.MovieGetService.GetAsync(new MovieIdentityModel(movieId)));
        }
    }
}