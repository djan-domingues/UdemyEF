namespace dal.mysql
{
    public class Class1
    {
        public Class1()
        {
            Console.WriteLine("camada2 - Mysql");

            using ( mysql.Models.Cliente01Context ctx = new Models.Cliente01Context() )
            {
                //ctx.Produtos.ToList().ForEach( x => Console.WriteLine( x.Nome ) );
            }
            
        }
    }
}



//Scaffold-DbContext "Server=localhost;Database=Cliente01;Uid=root;Pwd=senha@123;" Pomelo.EntityFrameworkCore.MySql -o Models -f;

//dotnet ef dbcontext "Server=localhost;Database=Cliente01;Uid=root;Pwd=senha@123;" Pomelo.EntityFrameworkCore.MySql -o Models -f;
