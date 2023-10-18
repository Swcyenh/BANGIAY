using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BANGIAY.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowGiayNam()
        {
            var imageFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            var imageFiles = Directory.GetFiles(imageFolder);

            var imageNames = new List<string>();
            foreach (var imageFile in imageFiles)
            {
                var fileName = Path.GetFileName(imageFile);
                imageNames.Add(fileName);
                Console.WriteLine(fileName);
            }

            ViewBag.ImageNames = imageNames;
            return View();
        }



    }
}
