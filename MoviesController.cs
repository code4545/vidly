using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!Hulk!"};
            var customers = new List<Customer>
            {
                new Customer {Name = "RamaChandra"},
                new Customer {Name = "Ram Charan"},
                new Customer {Name = "Veera"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

            //using View Data Dictionary
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;  //These two method viewbag and view data are not the best because we have to change things in html too.
            //var viewresult = new ViewResult();
            //viewresult.ViewDate.Model  //This operation is carried out when view is called , the movie object is assigned to this model and 
            //given to html
            //return Content("Hello World!");
            // return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });


        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+ "/" +month);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("pageIndex={0}&sortBy={1}",pageIndex, sortBy));
        }

    }
}