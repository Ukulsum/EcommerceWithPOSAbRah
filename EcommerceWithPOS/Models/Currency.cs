using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceWithPOS.Models
{
    // Table: currencies
    //public class Currency
    //{ 
    //    [Key]
    //    public int Id { get; set; }

    //    [StringLength(255)]
    //    public string Name { get; set; }

    //    [StringLength(255)]
    //    public string Code { get; set; }

    //    [StringLength(2)]
    //    public string Symbol { get; set; }

    //    public double ExchangeRate { get; set; }

    //    public bool IsActive { get; set; } // tinyint(1) maps to bool

    //    //public DateTime CreatedAt { get; set; }
    //    //public DateTime UpdatedAt { get; set; }
    //}


    // Table: currencies
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Short Name")]
        public string ShortName { get; set; }
        [DisplayName("Symbol Path")]
        public string? SymbolPath { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        [ForeignKey("Currency")]
        public int CurrencyID { get; set; }
        public bool IsActive { get; set; }
        [ValidateNever]
        public Currency Currency { get; set; }
    }
    //state
    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Country")]
        public int CountryID { get; set; }
        [ValidateNever]
        public Country Country { get; set; }
    }
    //City
    public class District
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public double CourierFee { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Division")]
        public int DivisionID { get; set; }
        [ValidateNever]
        public Division Division { get; set; }
    }
    //Area
    public class Thana
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        [ValidateNever]
        public District District { get; set; }
    }
}
