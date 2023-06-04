using Dapper;
using Npgsql;

public class CategoriService
{
    DapperContext context;
    public CategoriService (DapperContext context)
    {
        this.context=context;
    }

 public List<CategoriDto>GetCategories()
    {
    using(var conn=context.CreateConnection() ){
        var sql="select id as Id,categoriname CategoryName from categories";
            var result = conn.Query<CategoriDto>(sql);
       return result.ToList();
    }
    }

      // get by id
     public CategoriDto GetCategoriById(int id)
    {
    using(var conn=context.CreateConnection() ){
        //var sql="select * from teachers order by id desc";
        var sql=$"select id as Id,categoriname CategoryName from categories where id=@ID";
       var result = conn.QuerySingle<CategoriDto>(sql,new {Id=id});
       return result;
    }
    }



   public CategoriDto AddCategori(CategoriDto categori)
    {
    using(var conn= context.CreateConnection()){
        var sql=$"insert into categories(id,categoriname )values ( @Id,@CategoryName) returning id";
       var result = conn.Execute(sql,new {categori.Id,categori.CategoryName});
       categori.Id=result;
       return categori;
    }
    }

        public CategoriDto UpdateCategori(CategoriDto categori)
    {
    using(var conn= context.CreateConnection()){
        //var sql="select * from teachers order by id desc";
        var sql=$"update categories set id=@Id,categoriname=@CategoryName where id=@Id returning id";
       var result = conn.Execute(sql,new {categori.Id,categori.CategoryName});
       categori.Id=result;
       return categori;
    }
    }
       public  int DeleteCategori(int id)
    {
        using (var conn = context.CreateConnection())
        {
            var sql = $"Delete from categories where id = @Id";
            var result=  conn.Execute(sql,new { Id = id});
            return result;
        }
    }


}