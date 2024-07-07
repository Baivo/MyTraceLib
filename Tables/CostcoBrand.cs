using System.ComponentModel.DataAnnotations;

namespace MyTraceLib.Tables
{
    public class CostcoBrand
    {
        [Key]
        public string CostcoBrandId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EntryDate = DateTime.Now;
        public string Name { get; set; }
        public string InternalId { get; set; }
    }

    public class CostcoBrandResponsePage
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int TotalResults { get; set; }
        public string Locale { get; set; }
        public CostcoBrandResult[] Results { get; set; }
        public CostcoBrandIncludes Includes { get; set; }
        public bool HasErrors { get; set; }
        public object[] Errors { get; set; }
    }

    public class CostcoBrandIncludes
    {
    }

    public class CostcoBrandResult
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }
        public object[] AttributesOrder { get; set; }
        public object[] ProductIds { get; set; }
        public CostcoBrandAttributes Attributes { get; set; }
    }

    public class CostcoBrandAttributes
    {
    }
}
