using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Model;

namespace PokemonReviewApp.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _dataContext;

        public ReviewerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Reviewer GetReviewer(int reviewerId)
        {
            return _dataContext.Reviewers.Where(
                r => r.Id==reviewerId).Include(e => e.Reviews).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _dataContext.Reviewers.Include(r => r.Reviews).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _dataContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _dataContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
