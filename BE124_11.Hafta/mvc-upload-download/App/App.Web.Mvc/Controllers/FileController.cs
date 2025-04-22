using Microsoft.AspNetCore.Mvc;

namespace App.Web.Mvc.Controllers
{
    public class FileController : Controller
    {
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Upload(IFormFile uploadedFile)
        {
            //string path = "C:\\BE124";

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string fullFilePath = Path.Combine(path, uploadedFile.FileName);

            using (var fileStream = new FileStream(fullFilePath, FileMode.Create))
            {
                uploadedFile.CopyTo(fileStream); // yüklenen dosyanın byte'larını parça parça bu stream'e kopyala
                fileStream.Flush(); // önbellekte olan byte'ları stream'e yazılır.
                fileStream.Close();
            }


                return View();
        }

        [HttpGet]
        public IActionResult FileList()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            var files = Directory.GetFiles(path);

            var fileNames = files.Select(Path.GetFileName);

            return View(fileNames);
        }

        [HttpGet]
        public IActionResult Download([FromQuery] string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

            if (!Directory.Exists(path)) // klasör yoksa
            {
                return NotFound();
            }

            string fullFilePath = Path.Combine(path, fileName);

            if (!Path.Exists(fullFilePath)) // dosya yoksa
            {
                return NotFound();
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(fullFilePath);

            return File(fileBytes, "image/jpeg", "adsiz.jpg");
        }
    }
}
