using AutoMapper;
using MovieAdviser.Client.DataTransferObjects.Read;
using MovieAdviser.Client.Requests;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.WebAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DataAccess.Entities.Genre, Domain.Genre>();
            this.CreateMap<DataAccess.Entities.Movie, Domain.Movie>();
            this.CreateMap<DataAccess.Entities.Cartoon, Domain.Cartoon>();

            this.CreateMap<Domain.Genre, GenreDTO>();
            this.CreateMap<Domain.Movie, MovieDTO>();
            this.CreateMap<Domain.Cartoon, CartoonDTO>();

            this.CreateMap<GenreCreateDTO, GenreUpdateModel>();
            this.CreateMap<GenreUpdateDTO, GenreUpdateModel>();
            this.CreateMap<GenreUpdateModel, DataAccess.Entities.Genre>();

            this.CreateMap<MovieCreateDTO, MovieUpdateModel>();
            this.CreateMap<MovieUpdateDTO, MovieUpdateModel>();
            this.CreateMap<MovieUpdateModel, DataAccess.Entities.Movie>();

            this.CreateMap<CartoonCreateDTO, CartoonUpdateModel>();
            this.CreateMap<CartoonUpdateDTO, CartoonUpdateModel>();
            this.CreateMap<CartoonUpdateModel, DataAccess.Entities.Cartoon>();
        }
    }
}