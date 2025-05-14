using CharityMVC.Contexts;
using CharityMVC.Exceptions;
using CharityMVC.Models;
using CharityMVC.ViewModel;

namespace CharityMVC.Services;

public class OurSectionService
{
    private readonly OurSectionContext _ourSectionContext;

    public OurSectionService()
    {
        _ourSectionContext = new OurSectionContext();
    }

    #region Create
    public void Create(OurSectionVM ourSectionVM)
    {
        OurSection ourSection = new OurSection();

        ourSection.Category = ourSectionVM.Category;
        ourSection.RaisedPrice = ourSectionVM.RaisedPrice;
        ourSection.GoalPrice = ourSectionVM.GoalPrice;


        string fileName = Path.GetFileNameWithoutExtension(ourSectionVM.File.FileName);
        string extension = Path.GetExtension(ourSectionVM.File.FileName);
        string fullName = fileName + Guid.NewGuid().ToString() + extension;
        Console.WriteLine(fullName);

        ourSection.ImgPath = fullName;

        string uploadedPath = "C:\\Users\\ca r221.14\\source\\repos\\CharityMVC\\CharityMVC\\wwwroot\\assets\\images\\img";


        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }
        uploadedPath = Path.Combine(uploadedPath, fullName);


        using FileStream stream = new FileStream(uploadedPath, FileMode.Create);

        ourSectionVM.File.CopyTo(stream);


        _ourSectionContext.OurSections.Add(ourSection);
        _ourSectionContext.SaveChanges();
    }
    #endregion

    #region Read

    public List<OurSection> OurSections()
    {
        return _ourSectionContext.OurSections.ToList();
    }

    public OurSection GetOurSectionById(int id)
    {
        OurSection ourSection = _ourSectionContext.OurSections.Find(id);

        if (ourSection is not null)
        {
            return ourSection;
        }
        throw new OurSectionException("DATA yoxdu");
    }

    #endregion

    #region Update


    #endregion

    #region Delete

    #endregion
}
