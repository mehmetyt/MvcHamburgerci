using System.ComponentModel.DataAnnotations;

namespace MvcHamburgerProje.Attributes
{
    public class ResimAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null) return true;

            var resim = (IFormFile)value;

            if (!resim.ContentType.StartsWith("/image"))
            {
                ErrorMessage = "Sadece resim dosyası yükleyebilirsiniz";
                return false;
            }
            return true;
        }
    }
}
