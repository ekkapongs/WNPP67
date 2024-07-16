using System;
using System.Collections.Generic;

namespace WNPP_WEB.Models;

public partial class TBuddhistLentDetail
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

    public int Blid { get; set; }

    public int MonkId { get; set; }

    public int? MonkSeq { get; set; }

    public string? MonkName { get; set; }

    public string? MonkNicName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public DateTime? DateOfOrdination { get; set; }

    public string? TempleName { get; set; }

    public string? Preceptor { get; set; }

    public int? MonkAge { get; set; }

    public int? MonkPhanSa { get; set; }
}
