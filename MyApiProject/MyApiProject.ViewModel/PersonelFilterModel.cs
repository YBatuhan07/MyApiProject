using MyApiProject.DomainLayer.Shared;

namespace MyApiProject.ViewModel;

public class PersonelFilterModel
{
    public string SearchName { get; set; }
    public int? Birthyear { get; set; }
    public GenderType? Gender { get; set; }
    public string CityName { get; set; }
    public List<string> DistrictNames { get; set; }
    public int Index { get; set; }
    public int PageCount { get; set; }
}
