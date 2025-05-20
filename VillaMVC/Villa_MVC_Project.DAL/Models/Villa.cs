

using System.ComponentModel.DataAnnotations;

namespace Villa_MVC_Project.DAL.Models;

public class Villa : BaseModel
{
    public string CategoryName { get; set; }


    public double Price { get; set; }


    public string Location { get; set; }


    public string ImgPath { get; set; }
}
