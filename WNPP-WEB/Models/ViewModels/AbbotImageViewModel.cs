namespace WNPP_WEB.Models.ViewModels
{
    public class AbbotImageViewModel
    {
        public int Id { get; set; }
        public int AbbotImageId { get; set; }
        public int DataId { get; set; }
        public string AbbotName { get; set; }
        public string CallBackPath { get; set; }
        public IFormFile? FileUploadFormFile { get; set; }
    }
}
