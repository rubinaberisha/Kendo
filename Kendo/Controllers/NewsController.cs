using Kendo.Data;
using Kendo.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class NewsController : Controller
{
    private readonly AppDbContext _context;

    public NewsController(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View();
    }

    public async Task<IActionResult> News()
    {
        var newsList = await _context.News.ToListAsync(); // Fetch news items from the database
        return View(newsList); // Pass the model to the view
    }

    // Fetch News for Admin Grid
    public JsonResult GetNews([DataSourceRequest] DataSourceRequest request)
    {
        
            var news =  _context.News.ToListAsync().Result;
        return Json(news.ToDataSourceResult(request));
     
    }

    // Add or Update News
    [HttpPost]
    public async Task<IActionResult> AddEditNews(News news)
    {
        if (news == null)
        {
            return BadRequest("Invalid news data.");
        }

        if (news.Id == 0)
        {
            _context.News.Add(news);
        }
        else
        {
            _context.News.Update(news);
        }
        await _context.SaveChangesAsync();
        return Json(news);
    }



    //[HttpPost]
    //public IActionResult AddEditNews(News news, IFormFile file)
    //{
    //    if (news == null)
    //    {
    //        return BadRequest("Invalid news data.");
    //    }

    //    try
    //    {
    //        if (file != null)
    //        {
    //            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFiles");
    //            if (!Directory.Exists(uploadsFolder))
    //            {
    //                Directory.CreateDirectory(uploadsFolder);
    //            }

    //            var filePath = Path.Combine(uploadsFolder, file.FileName);
    //            using (var stream = new FileStream(filePath, FileMode.Create))
    //            {
    //                file.CopyTo(stream);
    //            }

    //            news.ImagePath = "/ImageFiles/" + file.FileName; // Save the image path in the news object
    //        }

    //        _context.News.Add(news);
    //        _context.SaveChangesAsync();
    //        return Json(news);
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Error adding news: {ex.Message}");
    //        return BadRequest("An error occurred while adding the news.");
    //    }
    //}


    [HttpPost]
    public async Task<IActionResult> UpdateNews(News news)
    {
        if (news == null)
        {
            return BadRequest("Invalid news data.");
        }

        try
        {
            var existingNews = await _context.News.FindAsync(news.Id);
            if (existingNews == null)
            {
                return NotFound("News not found.");
            }

            // Update the properties of the existing news
            existingNews.Title = news.Title;
            existingNews.Content = news.Content;
            existingNews.ImagePath = news.ImagePath; // If image is updated, this should be handled in the AddNews method
            existingNews.PublishDate = news.PublishDate;

            // Save the changes to the database
            _context.News.Update(existingNews);
            await _context.SaveChangesAsync();

            return Json(existingNews); // Return the updated news item
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating news: {ex.Message}");
            return BadRequest("An error occurred while updating the news.");
        }
    }




    // Delete News
    [HttpPost]
    public async Task<IActionResult> DeleteNews(int id)
    {
        var news = await _context.News.FindAsync(id);
        if (news != null)
        {
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }
        return Json(news);
    }


    // News Display Page

    [HttpPost]
    public IActionResult SaveFile(IFormFile file)
    {
        if (file != null && file.Length > 0)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ImageFiles");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return Json("/ImageFiles/" + file.FileName);
        }

        return BadRequest("Invalid file.");
    }


    public async Task<IActionResult> Details(int id)
    {
        var news = await _context.News.FirstOrDefaultAsync(n => n.Id == id);

        if (news == null)
        {
            return NotFound(); // Handle the case where the news item does not exist.
        }

        return View(news); // Pass the news item to the view.
    }

}
