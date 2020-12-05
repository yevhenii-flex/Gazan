using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gazan.WEB.Models
{
    public class HarmfulSubstance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CriticalValue> CriticalValues { get; set; }
    }
}
