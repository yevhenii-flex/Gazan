using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gazan.WEB.Models
{
    public class CriticalValue
    {
        public int Id { get; set; }
        public HarmfulSubstance HarmfulSubstance { get; set; }
        public int HarmfulSubstanceId { get; set; }
        public int Value { get; set; }
        public bool IsApproved { get; set; }
    }
}
