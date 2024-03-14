using Microsoft.AspNetCore.Mvc;
using WebApp_FileUpload.Models;

namespace WebApp_FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment hostinfo;
        public HomeController(IWebHostEnvironment webHostEnvironment)
        {

            hostinfo = webHostEnvironment;

        }


        public IActionResult Index()
        {
            string Pfad = hostinfo.WebRootPath + "\\Images";
            DirectoryInfo di = new DirectoryInfo(Pfad);
            List<FileInfo> AlleBilder = di.GetFiles().ToList();
            //AlleBilder.Sort((x, y) => x.CreationTime.CompareTo(y.CreationTime));
            List<string> Bildnamen = new List<string>(AlleBilder.Select(x => x.Name));
            //List<string> Bildnamen = new List<string>();
            //foreach (FileInfo fi in AlleBilder)
            //{
            //    Bildnamen.Add(fi.Name);
            //}
            return View(Bildnamen);
        }

        [HttpGet]
        public IActionResult Upload()
        {
            

            UploadModel model = new UploadModel();
            model.Bezeichnung = "Bild";
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync(UploadModel uploadModel)
        {
            ModelState.Remove("UploadDatei");
            if (!ModelState.IsValid)
            {
                return View(uploadModel);
            }
            if(uploadModel.UploadDatei == null ||
               uploadModel.UploadDatei.Length == null ||
              !uploadModel.UploadDatei.ContentType.Contains("image"))
            {
                ModelState.AddModelError("UploadDatei", "Es wurde kein Bild ausgewählt");
                return View(uploadModel);
            }


            string Pfad = hostinfo.WebRootPath + "\\Images\\";
            string guid = Guid.NewGuid().ToString();
            string Extension = System.IO.Path.GetExtension(uploadModel.UploadDatei.FileName);
            string neuerName = guid + uploadModel.Bezeichnung +  Extension;

            using (var stream = new FileStream(Pfad + neuerName, FileMode.Create))
            {
                await uploadModel.UploadDatei.CopyToAsync(stream);
            }
            return RedirectToAction("Index");
        }
    }
}
