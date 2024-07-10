namespace WNPP_WEB.Models.ViewModels
{
    public class BranchViewModel
    {
        public int Id { get; set; }
        public string? BranchName { get; set; }
        public string? MonasteryName { get; set; }
        public string? MonasteryPhoneNO { get; set; }
        public string? AbbotName { get; set; }
        public string? AbbotImageUrl { get; set; }
        public string? Notation { get; set; }
        public string? CertifierName { get; set; }
        public string? CertifierTemple { get; set; }
        public string? AddressTextMonatery { get; set; }
        public string? SubDistrictMonatery { get; set; }
        public string? DistrictMonatery { get; set; }
        public string? ProvinceMonatery { get; set; }
        public string? CountryMonatery { get; set; }
        public string? PostCodeMonatery { get; set; }

        public IFormFile? FileUploadFormFile { get; set; }
    }
}
