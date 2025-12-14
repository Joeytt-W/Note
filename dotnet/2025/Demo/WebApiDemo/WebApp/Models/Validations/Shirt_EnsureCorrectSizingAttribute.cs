using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Models.Validations
{
    public class Shirt_EnsureCorrectSizingAttribute : ValidationAttribute
    {
        /// <summary>
        /// 验证属性：验证男性尺寸>8 女性尺寸>6
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var shirt = (Shirt)validationContext.ObjectInstance as Shirt;
            if (shirt != null && !string.IsNullOrWhiteSpace(shirt.Gender))
            {
                if (shirt.Gender.Equals("men", StringComparison.OrdinalIgnoreCase) && shirt.Size < 8)
                {
                    return new ValidationResult("男性衬衫尺寸必须大于8");
                }
                else if (shirt.Gender.Equals("women", StringComparison.OrdinalIgnoreCase) && shirt.Size < 6)
                {
                    return new ValidationResult("女性衬衫尺寸必须大于6");
                }    
            }
            return ValidationResult.Success;
        }
    }
}
