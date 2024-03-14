namespace WebApp_FileUpload.Models;

public class Politiker
{
    int PId { get; set; }
    string Vorname { get; set; }
    string Nachname { get; set; }
    DateOnly? Geburtsdatum { get; set; }
    int? Größe { get; set; }
    string? Bild { get; set; }
    double? Gewicht { get; set; }
}