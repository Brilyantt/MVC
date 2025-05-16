
namespace NFT_MVCProject.DAL.Models;

public class CollectionsMarket : BaseModel
{
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int CountOfItem { get; set; }

    public string ImgPath { get; set; }
}
