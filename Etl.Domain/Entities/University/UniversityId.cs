using CSharpFunctionalExtensions;

namespace Etl.Domain.Entities.University
{
    public class UniversityId : ComparableValueObject
    {
        private UniversityId(Guid value)
        {
            Value = value;
        }

        public Guid Value { get; }

        public static UniversityId NewUniversityId() => new(Guid.NewGuid());

        public static UniversityId Empty() => new(Guid.Empty);

        public static UniversityId Create(Guid id) => new(id);

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
