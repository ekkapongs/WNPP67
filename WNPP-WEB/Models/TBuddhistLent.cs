﻿using System;
using System.Collections.Generic;

namespace WNPP_WEB.Models;

public partial class TBuddhistLent
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

    public int BuddhistLentYear { get; set; }

    public DateTime? BuddhistLentStartDate { get; set; }

    public DateTime? BuddhistLentEndDate { get; set; }

    public string? BuddhistLentInFo { get; set; }

    public int? MonkCount { get; set; }

    public int? NoviceCount { get; set; }

    public int? NunsCount { get; set; }

    public int? UpasikaCount { get; set; }

    public string? MonkNote { get; set; }

    public string? NunsNote { get; set; }
}
