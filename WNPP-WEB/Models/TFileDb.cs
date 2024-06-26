using System;
using System.Collections.Generic;

namespace WNPP_WEB.Models;

public partial class TFileDb
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

    public string? FileName { get; set; }

    public string? FileType { get; set; }

    public long? FileSize { get; set; }

    public string? FileNotation { get; set; }

    public byte[]? FileBinary { get; set; }
}
