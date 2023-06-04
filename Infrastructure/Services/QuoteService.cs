using Dapper;
using Npgsql;

public class QuoteService
{
    DapperContext context;
    public QuoteService (DapperContext context)
    {
        this.context=context;
    }

 public List<QuoteDto>GetQuotes()
    {
    using(var conn=context.CreateConnection() ){
        var sql="select id as Id,quote_text QuoteText,category_id CategoryId from quotes";
            var result = conn.Query<QuoteDto>(sql);
       return result.ToList();
    }
    }

      // get by id
     public QuoteDto GetquoteiById(int id)
    {
    using(var conn=context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,quote_text QuoteText,category_id CategoryId from quotes where id=@ID";
       var result = conn.QuerySingle<QuoteDto>(sql,new {Id=id});
       return result;
    }
    }



   public QuoteDto AddQuote(QuoteDto quote)
    {
    using(var conn= context.CreateConnection()){
        var sql=$"insert into quotes(id,quote_text,category_id )values ( @Id,@QuoteText,CategoryId) returning id";
       var result = conn.Execute(sql,new {quote.Id,quote.QuoteText});
       quote.Id=result;
       return quote;
    }
    }

        public QuoteDto UpdateQuote(QuoteDto quote)
    {
    using(var conn= context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update quotes set id=@Id,quote_text=@QuoteText,category_id CategoryId where id=@Id returning id";
       var result = conn.Execute(sql,new {quote.Id,quote.QuoteText});
       quote.Id=result;
       return quote;
    }
    }
       public  int DeleteQuote(int id)
    {
        using (var conn = context.CreateConnection())
        {
            var sql = $"Delete from quotes where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }


}