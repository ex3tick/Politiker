using System.ComponentModel.DataAnnotations;

namespace WebApp_FileUpload.Models;

    


    public class UploadModel
{

    [Required(ErrorMessage = "Bitte geben Sie eine Bezeichnung ein.")]
    public string Bezeichnung { get; set; }

    [Required(ErrorMessage = "Bitte wählen Sie ein Bild aus.")]
    public IFormFile UploadDatei { get; set; }
}

