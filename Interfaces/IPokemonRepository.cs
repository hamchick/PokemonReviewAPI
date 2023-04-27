using PokemonReviewApp.Model;

namespace PokemonReviewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemon(int id);
        Pokemon GetPokemon(String name);
        decimal GetPokemonRatings(int pokeId);
        bool PokemonExists(int pokeId);
    }
}
