using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class CartoonIdentityModel : ICartoonIdentity
    {
        public CartoonIdentityModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}