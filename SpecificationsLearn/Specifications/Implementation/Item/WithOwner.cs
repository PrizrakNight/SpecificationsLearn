using SpecificationsLearn.Models;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class WithOwner : Specification<Item>
    {
        private readonly Human _human;

        public WithOwner(Human human)
        {
            _human = human;
        }

        protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        {
            return models.Where(i => i.HumanId == _human.Id);
        }
    }
}
