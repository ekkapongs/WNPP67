using System;
using System.Collections.Generic;

namespace WNPP_WEB.Models;

public partial class MMonastery
{
    public int Id { get; set; }

    public bool? ActiveStatus { get; set; }

    public int? LanguageId { get; set; }

    public string? RecordStatus { get; set; }

    public int? CreatedBy { get; set; }

    public int? ModifiedBy { get; set; }

    public string? CreatedByName { get; set; }

    public string? ModifiedByName { get; set; }

    public string? Notation { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? MonasteryNo { get; set; }

    public string? MonasteryName { get; set; }

    public string? MonasteryType { get; set; }

    public string? Denomination { get; set; }

    public string? RegisterType { get; set; }

    public string? DateOfFoundingTxt { get; set; }

    public string? WisungkhamType { get; set; }

    public string? DateOfWisungkhamTxt { get; set; }

    public string? SubDistrictMonatery { get; set; }

    public string? DistrictMonatery { get; set; }

    public string? ProvinceMonatery { get; set; }

    public string? CountryMonatery { get; set; }

    public string? PostCodeMonatery { get; set; }
}
