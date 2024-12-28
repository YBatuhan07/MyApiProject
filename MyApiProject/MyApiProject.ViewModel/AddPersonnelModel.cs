using MyApiProject.DomainLayer.Shared;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.ViewModel
{
    public class AddPersonnelModel
    {
        [Required(ErrorMessage = "Id zorunludur.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [StringLength(100, ErrorMessage = "Ad Soyad 100 karakterden fazla olamaz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Doğum Tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(AddPersonnelModel), nameof(ValidateBirthDate))]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Cinsiyet zorunludur.")]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = "İlçe Id zorunludur.")]
        [Range(1, int.MaxValue, ErrorMessage = "İlçe Id pozitif bir sayı olmalıdır.")]
        public int DistrictId { get; set; }

        public static ValidationResult ValidateBirthDate(DateTime birthDate, ValidationContext context)
        {
            if (birthDate >= DateTime.Now)
            {
                return new ValidationResult("Doğum Tarihi geçmişte bir tarih olmalıdır.");
            }
            return ValidationResult.Success;
        }
    }
}
