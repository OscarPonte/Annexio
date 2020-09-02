using System.Collections.Generic;

namespace Annexio.Models
{
    public class Region
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<string> Subregion { get; set; }


    }
}