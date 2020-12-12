using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gazan.Backend.Models
{
    public class CriticalValueViewModel
    {
        public int Id { get; set; }
        public string HarmfulSubstanceName { get; set; }
        public int HarmfulSubstanceId { get; set; }
        public int Value { get; set; }
        public bool IsApproved { get; set; }
    }
}
