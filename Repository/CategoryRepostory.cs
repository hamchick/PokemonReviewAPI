using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepostory : ICategoryRepository
    {
        private DataContext _context;
        public CategoryRepostory(DataContext context) 
        {
            _context = context;
        }
        public bool CategoryExists(int id)
        {
            return _context.Catagories.Any(c => c.Id == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Catagories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Catagories.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonByCategory(int categoryId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == categoryId).Select(c => c.Pokemon).ToList();
        }
    }
}
