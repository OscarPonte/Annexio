using System.Collections;
using System.Collections.Generic;

namespace Annexio.Models
{
    public class Country
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Subregion { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public IEnumerable<string> Borders { get; set; }
        public IEnumerable<Currency> Currencies { get; set; }
        public IEnumerable<Language> Languages { get; set; }


    }
}