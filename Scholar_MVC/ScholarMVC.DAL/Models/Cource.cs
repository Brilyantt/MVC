

namespace ScholarMVC.DAL.Models;

public class Cource : BaseModel
{
    public string ImgPath { get; set; }
    public string Category { get; set; }
    public string Teacher { get; set; }
    public double Price { get; set; }
}
