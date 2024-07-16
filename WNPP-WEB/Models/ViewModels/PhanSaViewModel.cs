namespace WNPP_WEB.Models.ViewModels
{
    public class PhanSaViewModel : TBuddhistLent
    {
        public int? MonkType { get; set; }
        public string? MonkName { get; set; }
        public string? NickName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfOrdination { get; set; }
        public string? TempleName { get; set; }
        public string? Preceptor { get; set; }
        public List<TBuddhistLentDetail> Details { get; set; }
    }
}
