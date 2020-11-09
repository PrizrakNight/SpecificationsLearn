using SpecificationsLearn.Models;
using System.Collections.Generic;
using System.Linq;

namespace SpecificationsLearn.Specifications.Implementation
{
    public class WithOwners : Specification<Item>
    {
        private readonly Human[] _humen;

        public WithOwners(params Human[] humen)
        {
            _humen = humen;
        }

        protected override IQueryable<Item> ApplySpecificationInternal(IQueryable<Item> models)
        {
            var result = new List<Item>();

            for (int i = 0; i < _humen.Length; i++)
                result.AddRange(models.Where(item => item.HumanId == _humen[i].Id));

            return result.AsQueryable();
        }
    }
}
