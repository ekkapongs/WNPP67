using System;
using System.Collections.Generic;

namespace WNPP_WEB.Models;

public partial class TAbbotImg
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

    public string? AbbotName { get; set; }

    public string? ImgType { get; set; }

    public long? ImgSize { get; set; }

    public string? ImgNotation { get; set; }

    public byte[]? ImgBinary { get; set; }
}
