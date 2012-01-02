using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ReplaceOneManyDistictionWithComposite.Specifications
{
    public class CompositeSpecification : Specification
    {
        private IList<Specification> _specs;

        public CompositeSpecification(IList<Specification> specs)
        {
            _specs = specs;
        }

        public ReadOnlyCollection<Specification> Specs
        {
            get
            {
                return new ReadOnlyCollection<Specification>(_specs);
            }
        }

        public override bool IsSatisfiedBy(Product product)
        {
            bool satisfiesAllSpecs = true;

            foreach (Specification spec in Specs)
            {
                satisfiesAllSpecs &= spec.IsSatisfiedBy(product);
            }

            return satisfiesAllSpecs;
        }
    }
}