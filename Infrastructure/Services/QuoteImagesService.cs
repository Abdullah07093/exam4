using Dapper;
using Npgsql;

public class QuoteImagesService
{
    DapperContext context;
    public QuoteImagesService (DapperContext context)
    {
        this.context=context;
    }

 public List<QuoteImagesDto>GetQuoteImages()
    {
    using(var conn=context.CreateConnection() ){
        var sql="select id as Id,image_name ImageName,quote_id QuoteId from quoteimages";
            var result = conn.Query<QuoteImagesDto>(sql);
       return result.ToList();
    }
    }

      // get by id
     public QuoteImagesDto GetquoteImageiById(int id)
    {
    using(var conn=context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,image_name ImageName,quote_id QuoteId from quoteimages where id=@ID";
       var result = conn.QuerySingle<QuoteImagesDto>(sql,new {Id=id});
       return result;
    }
    }



   public QuoteImagesDto AddQuoteImage(QuoteImagesDto quoteimage)
    {
    using(var conn= context.CreateConnection()){
        var sql=$"insert into quoteimages(id,image_name,quote_id )values ( @Id,@ImageName,QuoteId) returning id";
       var result = conn.Execute(sql,new {quoteimage.Id,quoteimage.ImageName,quoteimage.QuoteId});
       quoteimage.Id=result;
       return quoteimage;
    }
    }

        public QuoteImagesDto UpdateQuoteImage(QuoteImagesDto quoteimage)
    {
    using(var conn= context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update quoteimages set id=@Id,image_name=@ImageName,quote_id QuoteId where id=@Id returning id";
       var result = conn.Execute(sql,new {quoteimage.Id,quoteimage.ImageName,quoteimage.QuoteId});
       quoteimage.Id=result;
       return quoteimage;
    }
    }
       public  int DeleteQuoteImage(int id)
    {
        using (var conn = context.CreateConnection())
        {
            var sql = $"Delete from quoteimages where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }


}