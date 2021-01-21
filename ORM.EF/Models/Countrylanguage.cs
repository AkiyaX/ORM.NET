using System;
using System.Collections.Generic;

#nullable disable

namespace ORM.EF.Models
{
    public partial class Countrylanguage
    {
        public string CountryCode { get; set; }
        public string Language { get; set; }
        public string IsOfficial { get; set; }
        public float Percentage { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
    }
}
