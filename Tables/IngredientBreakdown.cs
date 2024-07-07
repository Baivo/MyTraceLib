using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTraceLib.Tables
{
    public class IngredientBreakdown
    {
        [Key] 
        public string IngredientBreakdownId { get; set; } = Guid.NewGuid().ToString();
        [StringLength(250)]
        public string IngredientName { get; set; } = string.Empty;
        public string Purpose { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string Toxicity { get; set; } = string.Empty;
        public string CarcinogenicProperties { get; set; } = string.Empty;
        public List<string> HealthierAlternatives { get; set; } = [];
        public List<string> CommonUses { get; set; } = [];
        public string RegulatoryStatusInAustralia { get; set; } = string.Empty;
        public string EnvironmentalImpact { get; set; } = string.Empty;
        public IngredientBreakdown()
        {

        }
    }
    
}
