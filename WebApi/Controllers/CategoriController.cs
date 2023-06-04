using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CategoriControllers:ControllerBase
{
    
    private CategoriService categoriService; 
    public CategoriControllers(CategoriService categoriService)
    {
        this.categoriService=categoriService;
    }

  [HttpPost("AddCategori")]
    
    public CategoriDto AddCategori(CategoriDto categori){
        return categoriService.AddCategori(categori);
    }

    [HttpGet("GetCategori")]
    public List<CategoriDto>GetTodoCategori(){
        return categoriService.GetCategories();
    }
 
   [HttpGet("GetTodoCategori")]
    public CategoriDto GetStudent(int id){
        return categoriService.GetCategoriById(id);
    }
   

      [HttpDelete("Delete TodoCategori")]
    public int DeleteCategori(int id){
        return categoriService.DeleteCategori(id);
    }

      [HttpPut("Update TodoCategori")]
    public CategoriDto UpdateCategori(CategoriDto categori){
        return categoriService.UpdateCategori(categori);
    }

}