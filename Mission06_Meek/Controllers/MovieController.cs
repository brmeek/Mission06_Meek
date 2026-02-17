using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mission06_Meek.Data;
using Mission06_Meek.Models;

namespace Mission06_Meek.Controllers;

public class MovieController(MovieDbContext context) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var movies = context.Movies
            .Include(movie => movie.Category)
            .OrderBy(movie => movie.Title)
            .ToList();

        return View(movies);
    }

    [HttpGet]
    public IActionResult Add()
    {
        PopulateCategories();
        return View(new Movie());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            PopulateCategories(movie.CategoryId);
            return View(movie);
        }

        context.Movies.Add(movie);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = context.Movies.SingleOrDefault(m => m.MovieId == id);

        if (movie is null)
        {
            return NotFound();
        }

        PopulateCategories(movie.CategoryId);
        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            PopulateCategories(movie.CategoryId);
            return View(movie);
        }

        context.Movies.Update(movie);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = context.Movies
            .Include(movie => movie.Category)
            .SingleOrDefault(m => m.MovieId == id);

        if (movie is null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Movie movie)
    {
        var movieToDelete = context.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId);

        if (movieToDelete is null)
        {
            return NotFound();
        }

        context.Movies.Remove(movieToDelete);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    private void PopulateCategories(int? selectedCategoryId = null)
    {
        var categories = context.Categories
            .OrderBy(category => category.CategoryName)
            .ToList();

        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName", selectedCategoryId);
    }
}
