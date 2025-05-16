
using Microsoft.EntityFrameworkCore;
using NFT_MVCProject.BL.Exceptions;
using NFT_MVCProject.DAL.Contexts;
using NFT_MVCProject.DAL.Models;
using NFT_MVCProject.MVC.ViewModels;

namespace NFT_MVCProject.BL.Services;

public class CollectionsMarketService
{
    private readonly AppDbContext _context;
    public CollectionsMarketService(AppDbContext context)
    {
        _context = context;
    }

    #region Create

    public void Create(CollectionsMarketVM collectionsMarketVM)
    {
        CollectionsMarket collections = new CollectionsMarket();
        collections.Name = collectionsMarketVM.Name;
        collections.CategoryName = collectionsMarketVM.CategoryName;
        collections.CountOfItem = collectionsMarketVM.CountOfItem;

        string fileName = Path.GetFileNameWithoutExtension(collectionsMarketVM.Name);
        string extension = Path.GetExtension(collectionsMarketVM.Name);
        string fullname = fileName + Guid.NewGuid().ToString() + extension;
        Console.WriteLine(fullname);

        collections.ImgPath = fullname;

        string uploadedPath = "C:\\Users\\ca r221.14\\source\\repos\\NFT_MVCProject\\NFT_MVCProject.MVC\\wwwroot\\assets\\images\\img";

        if (!Directory.Exists(uploadedPath))
        {
            Directory.CreateDirectory(uploadedPath);
        }

        uploadedPath = Path.Combine(uploadedPath, fullname);
        using FileStream fileStream = new FileStream(uploadedPath, FileMode.Create);

        collectionsMarketVM.File.CopyTo(fileStream);

        _context.CollectionsMarkets.Add(collections);
        _context.SaveChanges();

    }

    #endregion

    #region Read

    public List<CollectionsMarket> CollectionsMarkets()
    {
        return _context.CollectionsMarkets.ToList();
    }

    public CollectionsMarket GetCollectionsMarketById(int id)
    {
        CollectionsMarket collections = _context.CollectionsMarkets.Find(id);
        if (collections is not null)
        {
            return collections;
        }
        throw new CollectionsMarketException($"Database-de {id}-li data yoxdur");
    }


    #endregion

    #region Update

    public void Update(int id, CollectionsMarket updatedcollections)
    {
        if (id != updatedcollections.Id)
        {
            throw new CollectionsMarketException("Data yoxdur");
        }

        CollectionsMarket? basecollectionsMarket = _context.CollectionsMarkets.AsNoTracking().SingleOrDefault(cM => cM.Id == id);
        if (basecollectionsMarket is not null)
        {
            throw new CollectionsMarketException($"Database-de {id}-li data yoxdur");
        }

        _context.CollectionsMarkets.Update(updatedcollections);
        _context.SaveChanges();
    }

    #endregion

    #region Delete
    public void Delete(int id)
    {
        CollectionsMarket? collections = _context.CollectionsMarkets.Find(id);
        if (collections is not null)
        {
            _context.CollectionsMarkets.Remove(collections);
            _context.SaveChanges();
        }
        else
        {
            throw new CollectionsMarketException($"Database-de {id}-li data yoxdur");

        }
    }

    #endregion
}
