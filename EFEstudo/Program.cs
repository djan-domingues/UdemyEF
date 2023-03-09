// See https://aka.ms/new-console-template for more information
using modelo;

Console.WriteLine("Hello, World!");


dal.mysql.Class1 mysql = new dal.mysql.Class1();  
//dal.sql.Class1 sql = new dal.sql.Class1();

dal.sql.Funcoes fun =new dal.sql.Funcoes();

//fun.Selecionar(2);
//fun.SelecionarLinq(2);

//fun.Listar();

//fun.ListarWhereDinamico(string.Empty, "Vermelho", exemplo: 500);
//fun.ListarWhereDinamico(string.Empty, string.Empty, quantidade: 500);

//fun.SelecionarComInclude(2);

//fun.ListarPerfomatizado();

fun.ListarQuery();



//for (int i = 0; i <= 10000; i++)
//{
//    //adicionar
//    Produtos produto = new Produtos();
//    produto.Nome = $"Sapato {i}";
//    produto.Cor = "Vermelho";

//    Estoque estoque = new Estoque();
//    estoque.Quantidade = new Random().Next(1000);
//    estoque.Exemplo = new Random().Next(1000);

//    produto.Estoques = estoque;
//    fun.Adicionar(produto);
//}
//Alterar

//produto.Id = 1;
//produto.Cor = "Bege";
//fun.Atualizar(produto);

//Alterar
//Produtos p = new Produtos();
//p.Cor = "Amarelo";
//p.Id = 1;
//p.Nome = "Sapato novo";

//fun.Alterar(p);


//Deletar
//fun.Deletar(1);
//fun.Deletar(new Produtos() { Id = 4 });


Console.ReadKey(true);
