using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class QuoteImagesController:ControllerBase
{
    
    private QuoteImagesService quoteImagesService; 
    public QuoteImagesController(QuoteImagesService quoteImagesService)
    {
        this.quoteImagesService=quoteImagesService;
    }

  [HttpPost("AddQuoteImage")]
    
    public QuoteImagesDto AddQuoteImage(QuoteImagesDto quoteImage){
        return quoteImagesService.AddQuoteImage(quoteImage);
    }

    [HttpGet("GetQuoteImages")]
    public List<QuoteImagesDto>GetQuotesImages(){
        return quoteImagesService.GetQuoteImages();
    }
 
   [HttpGet("GetQuoteImage")]
    public QuoteImagesDto GetQuoteImage(int id){
        return quoteImagesService.GetquoteImageiById(id);
    }
   

      [HttpDelete("Delete QuoteImage")]
    public int DeleteQuoteImage(int id){
        return quoteImagesService.DeleteQuoteImage(id);
    }

      [HttpPut("Update QuoteImage")]
    public QuoteImagesDto UpdateCategori(QuoteImagesDto quoteImage){
        return quoteImagesService.UpdateQuoteImage(quoteImage);
    }

}