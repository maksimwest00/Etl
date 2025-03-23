using System.Text;

namespace Etl.Domain.Entities.University
{
    public class University : Shared.Entity<UniversityId>
    {
        // ef core
        private University(UniversityId id) : base(id)
        {

        }

        public University(
            UniversityId id,
            string name,
            string country,
            string site) : base(id)
        {
            Name = name;
            Country = country;
            Site = site;
        }

        public string? Name { get; set; }

        public string? Country { get; set; }

        public string? Site { get; set; }

        public static University Create(
            UniversityId id,
            string name,
            string country,
            List<string> sites)
        {

            var sbSites = new StringBuilder();
            for (int i = 0; i < sites.Count; i++)
            {
                sbSites.Append(sites[i]);
                if (i < sites.Count - 1)
                {
                    sbSites.Append(";");
                }
            }

            return new University(
                id,
                name,
                country,
                sbSites.ToString());
        }
    }
}
