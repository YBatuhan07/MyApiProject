using MyApiProject.DomainLayer.Shared;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.ViewModel;

public class AddPersonnelInfoModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "İsim girilmesi zorunludur")]
    [StringLength(100, ErrorMessage = "En fazla 100 karakter girilebilir")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Doğum tarihi girilmesi zorunludur")]
    [DataType(DataType.Date, ErrorMessage = "Tarih formatında girilmeli")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "Cinsiyet bilgisi girilmesi zorunludur")]
    [CustomValidation(typeof(AddPersonnelInfoModel), nameof(ValidateGender))]
    public GenderType Gender { get; set; }

    [Required(ErrorMessage = "Şehir adı girilmesi zorunludur")]
    [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
    public string CityName { get; set; }

    [Required(ErrorMessage = "İlçe adı girilmesi zorunludur")]
    [StringLength(50, ErrorMessage = "En fazla 50 karakter girilebilir")]
    public string DistrictName { get; set; }

    public static ValidationResult ValidateGender(GenderType gender, ValidationContext context)
    {
        if (!Enum.IsDefined(typeof(GenderType), gender))
        {
            return new ValidationResult("Cinsiyet bilgisi sadece 0 (Kadın) veya 1 (Erkek) olabilir.");
        }
        return ValidationResult.Success;
    }
}
