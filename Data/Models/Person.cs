using LoginExample.Data.Models;

namespace LoginExample.Data.Models {
public class Person :IPerson {
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public int Age { get; set; }
    public float Weight { get; set; }
    public int Height { get; set; }
    public string Sex { get; set; }
    
    
    
    public void Update(Person toUpdate)
    {
        FirstName = toUpdate.FirstName;
        LastName = toUpdate.LastName;
        HairColor = toUpdate.LastName;
        EyeColor = toUpdate.EyeColor;
        Age = toUpdate.Age;
        Weight = toUpdate.Weight;
        Height = toUpdate.Height;
        Sex = toUpdate.Sex;
    }
}


}