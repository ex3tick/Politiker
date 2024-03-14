namespace WebApp_FileUpload.Models;

public interface IAccessable
{
    List<Politiker>getAllPolitikers();
    Politiker getPolitikerById(int id);
    int addPolitiker(Politiker politiker);
    
    bool updatePolitiker(Politiker politiker);
    bool deletePolitiker(int id);
    
    
}