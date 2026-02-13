using Microsoft.AspNetCore.Mvc;
using Mission06_Meek.Data;
using Mission06_Meek.Models;

namespace Mission06_Meek.Controllers;

public class MovieController(MovieDbContext context) : Controller
{
    [HttpGet]
    public IActionResult Add()
    {
        return View(new Movie());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            return View(movie);
        }

        context.Movies.Add(movie);
        context.SaveChanges();

        return View("Confirmation", movie);
    }
}
