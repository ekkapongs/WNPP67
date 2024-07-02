using static System.Net.Mime.MediaTypeNames;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace WNPP_WEB.Services
{
    public interface ICommonService
    {
        public Bitmap ResizeImage(System.Drawing.Image image, int width, int height);
    }
    public class CommonService
    {
        /// === Administrator
        public const int _Admin_ID = 0;
        public const string _Admin_Name = "Administrator";

        /// === LANG
        public const int _Lang_TH = 1;
        public const int _Lang_EN = 2;

        /// === RECORD STATUS
        public const bool _Record_Active = true;
        public const bool _Record_DisActive = false;

        /// === DROP DOWN TYPE
        public const string _DropDown_BranchType = "BranchType";
        public const string _DropDown_LanguageType = "LanguageType";
        public const string _DropDown_MonasteryType = "MonasteryType";
        public const string _DropDown_AcademicType = "AcademicType";
        public const string _DropDown_SageType = "SageType";
        public const string _DropDown_TheologianType = "TheologianType";

        public Bitmap ResizeImage(System.Drawing.Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }

    
}
