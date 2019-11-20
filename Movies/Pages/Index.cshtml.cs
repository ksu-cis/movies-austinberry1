using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {

       
        public List<Movie> Movies;

        [BindProperty]
        public string search { get; set; }

        [BindProperty]
        public List<string> mpaa { get; set; } = new List<string>();

        [BindProperty]
        public float? minIMDB { get; set; }

        [BindProperty]
        public float? maxIMDB { get; set; }


        public void OnGet()
        {
            Movies = MovieDatabase.All;
        }


        public void OnPost()
        {
            Movies = MovieDatabase.All;
            if (search != null)
            {
                Movies = MovieDatabase.SearchAndFilter(Movies, search);
            }

            if (mpaa.Count != 0)
            {
                Movies = MovieDatabase.FilterByMPAA(Movies, mpaa);
            }
            if(minIMDB != null)
            {
                Movies = MovieDatabase.FilterByMinMPAA(Movies,(float)minIMDB);
            }
            if (maxIMDB != null)
            {
                Movies = MovieDatabase.FilterByMaxMPAA(Movies, (float)maxIMDB);
            }
        }
    }
}
