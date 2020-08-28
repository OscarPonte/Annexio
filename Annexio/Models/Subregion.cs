using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Annexio.Models
{
    public class Subregion
    {
        public string Name { get; set; }
        public long Population { get; set; }
        public string Region { get; set; }
        public IEnumerable<Country> Countries { get; set; }

    }
}