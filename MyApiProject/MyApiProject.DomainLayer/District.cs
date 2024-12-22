namespace MyApiProject.DomainLayer;

public class District : BaseClass
{
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public ICollection<Personnel> Personnels { get; set; }
}
