
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services;

public class FileService : IFileService
{
    readonly IWebHostEnvironment environment;
    public FileService(IWebHostEnvironment environment)
    {
        this.environment=environment;
    }
   

    public string CreateFile(string folder, IFormFile file)
    {

var path=Path.Combine(environment.WebRootPath,folder, file.FileName) ;
using (var stream = new FileStream(path,FileMode.Create)) {
    file.CopyTo(stream);
}
return file.FileName;    }

    public bool DeleteFile(string folder, string filename)
    {
var path=Path.Combine(environment.WebRootPath,folder,filename);
if(File.Exists(path)){
    File.Delete(path);
    return true;
}else{
    return false;
}   
   }

    string IFileService.CreateFile(string folder, IFormFile file)
    {
        throw new NotImplementedException();
    }

    bool IFileService.DeleteFile(string folder, string filename)
    {
        throw new NotImplementedException();
    }
}