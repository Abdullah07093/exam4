using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuoteControllers:ControllerBase
{
    
    private QuoteService quoteService; 
    public QuoteControllers(QuoteService quoteService)
    {
        this.quoteService=quoteService;
    }

  [HttpPost("AddQuote")]
    
    public QuoteDto AddQuote(QuoteDto quote){
        return quoteService.AddQuote(quote);
    }

    [HttpGet("GetQoute")]
    public List<QuoteDto>GetQuotes(){
        return quoteService.GetQuotes();
    }
 
   [HttpGet("GetQouteId")]
    public QuoteDto GetQoute(int id){
        return quoteService.GetquoteiById(id);
    }
   

      [HttpDelete("Delete Qoute")]
    public int DeleteQoute(int id){
        return quoteService.DeleteQuote(id);
    }

      [HttpPut("Update Qoute")]
    public QuoteDto UpdateQoute(QuoteDto quote){
        return quoteService.UpdateQuote(quote);
    }

}