using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gazan.WEB.Models
{
    public class Dimension
    {
        public int Id { get; set; }
        public HarmfulSubstance HarmfulSubstance { get; set; }
        public int HarmfulSubstanceId { get; set; }
        public int Value { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
