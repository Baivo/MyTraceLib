using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyTraceLib.Tables
{
    public class CostcoProduct
    {
        [Key]
        public string CostcoProductId { get; set; } = Guid.NewGuid().ToString();
        public DateTime EntryDate { get; set; } = DateTime.Now;
        public string? Name { get; set; }
        public bool Active { get; set; }
        public string? StockCode { get; set; }
        public string? Brand { get; set; }
        public string? BrandExternalId { get; set; }
        public string[]? EANs { get; set; }
        public string[]? ManufacturerPartNumbers { get; set; }
        public string[]? UPCs { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductPageUrl { get; set; }
    }

    public class CostcoProductResponsePage
    {
        public int Limit { get; set; }
        public int? Offset { get; set; }
        public int TotalResults { get; set; }
        public string? Locale { get; set; }
        public List<CostcoProductResult>? Results { get; set; }
        public CostcoProductIncludes? Includes { get; set; }
        public bool HasErrors { get; set; }
        public List<object>? Errors { get; set; }
    }

    public class CostcoProductIncludes
    {
    }

    public class CostcoProductResult
    {
        public List<string>? FamilyIds { get; set; }
        public List<string>? AttributesOrder { get; set; }
        public CostcoProductAttributes? Attributes { get; set; }
        public string? Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? Id { get; set; }
        public string? CategoryId { get; set; }
        public bool Active { get; set; }
        public string? ProductPageUrl { get; set; }
        public bool Disabled { get; set; }
        public List<string>? ISBNs { get; set; }
        public List<string>? QuestionIds { get; set; }
        public List<string>? ManufacturerPartNumbers { get; set; }
        public List<string>? ReviewIds { get; set; }
        public List<string>? UPCs { get; set; }
        public string? BrandExternalId { get; set; }
        public CostcoProductBrand? Brand { get; set; }
        public string? Description { get; set; }
        public List<string>? ModelNumbers { get; set; }
        public List<string>? StoryIds { get; set; }
        public List<string>? EANs { get; set; }
    }

    public class CostcoProductAttributes
    {
        public CostcoProductAttribute? DEPARTMENT_NO { get; set; }
        public CostcoProductAttribute? AVAILABILITY { get; set; }
        public CostcoProductAttribute? BV_FE_EXPAND { get; set; }
        public CostcoProductAttribute? INVALID_EAN { get; set; }
        public CostcoProductAttribute? BV_FE_FAMILY { get; set; }
    }

    public class CostcoProductAttribute
    {
        public string? Id { get; set; }
        public List<CostcoProductAttributeValue>? Values { get; set; }
    }

    public class CostcoProductAttributeValue
    {
        public string? Value { get; set; }
        public object? Locale { get; set; }
    }

    public class CostcoProductBrand
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
    }
}
