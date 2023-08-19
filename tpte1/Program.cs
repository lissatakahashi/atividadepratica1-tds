using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var produtos = new List<tpte1.Model.Produto>
{
    new tpte1.Model.Produto { Id = 1, Nome = "Garrafa térmica", Preco = 40.00M, Quantidade = 10},
    new tpte1.Model.Produto { Id = 2, Nome = "Chaveiro", Preco = 10.00M, Quantidade = 30},
    new tpte1.Model.Produto { Id = 3, Nome = "Camiseta", Preco = 35.00M, Quantidade = 50}
};

builder.Services.AddSingleton(produtos);
builder.Services.AddSwaggerGen(c => { 
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Produtos.API", Version = "v1" }); 
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/produtos", () =>
{
    var produtoService = app.Services.GetRequiredService<List<tpte1.Model.Produto>>();
    return Results.Ok(produtoService);
});

app.MapGet("/produtos/{id}", (int id, HttpRequest request) =>
{
    var produtoService = app.Services.GetRequiredService<List<tpte1.Model.Produto>>();
    var produto = produtoService.FirstOrDefault(t => t.Id == id);

    if (produto == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(produto);
});

app.MapPost("/produtos", (tpte1.Model.Produto produto) =>
{
    if (produto.Quantidade > 0)
    {
        if (Math.Round(produto.Preco, 2) == produto.Preco) { 
            var produtoService = app.Services.GetRequiredService<List<tpte1.Model.Produto>>();
            produto.Id = produtoService.Max(t => t.Id) + 1;
            produtoService.Add(produto);
            return Results.Created($"/produtos/{produto.Id}", produto);
        }
        else
        {
            return Results.BadRequest("O preço do produto deve ter duas casas decimais.");
        }
    }
    else
    {
        return Results.BadRequest("Para adicionar um produto, a quantidade deve ser maior que 0.");
    }
});

app.MapPut("/produtos/{id}", (int id, tpte1.Model.Produto produto) =>
{
    var produtoService = app.Services.GetRequiredService<List<tpte1.Model.Produto>>();
    var existingProduto = produtoService.FirstOrDefault(t => t.Id == id);

    if (existingProduto == null)
    {
        return Results.NotFound();
    }

    existingProduto.Nome = produto.Nome;
    existingProduto.Preco = produto.Preco;
    existingProduto.Quantidade = produto.Quantidade;

    return Results.NoContent();
});

app.MapDelete("/produtos/{id}", (int id) =>
{
    var produtoService = app.Services.GetRequiredService<List<tpte1.Model.Produto>>();
    var existingProduto = produtoService.FirstOrDefault(t => t.Id == id);

    if (existingProduto == null)
    {
        return Results.NotFound();
    }

    produtoService.Remove(existingProduto);

    return Results.NoContent();
});

app.Run();
