using MyApiProject.DomainLayer.Shared;
using System.ComponentModel.DataAnnotations;

namespace MyApiProject.ViewModel
{
    public class PersonelFilterModel
    {
        [StringLength(100, ErrorMessage = "Arama adı en fazla 100 karakter olabilir.")]
        public string SearchName { get; set; }

        [Range(1900, 2100, ErrorMessage = "Doğum yılı 1900 ile 2100 arasında olmalıdır.")]
        public int? Birthyear { get; set; }

        public GenderType? Gender { get; set; }

        [StringLength(50, ErrorMessage = "Şehir adı en fazla 50 karakter olabilir.")]
        public string CityName { get; set; }

        public List<string> DistrictNames { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Index 0 veya daha büyük bir değer olmalıdır.")]
        public int Index { get; set; }

        [Range(1, 100, ErrorMessage = "Sayfa sayısı 1 ile 100 arasında olmalıdır.")]
        public int PageCount { get; set; }
    }
}
