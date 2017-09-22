using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication6.Pages
{
    public class IndexModel : PageModel
    {
        private string filePath { get; } = "C:\\windows\\temp\\";

        [BindProperty]
        public IFormFile SentFile { get; set; }

        public void OnGet()
        {

        }

        public async void OnPostAsync()
        {
            if (SentFile.Length > 0)
            {
                var filePathAndName = filePath + SentFile.FileName;
                using (var stream = new FileStream(filePathAndName, FileMode.Create))
                {
                    await SentFile.CopyToAsync(stream);
                }
            }
        }
    }
}
