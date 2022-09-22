using Mongo.Business.Interface;
using Mongo.Business.Services;
using Mongo.Infrastructure.DBSettings;
using Mongo.Infrastructure.DBSettings.Interface;
using Mongo.Infrastructure.Interfaces;
using Mongo.Infrastructure.Repositories;
using ServiceStack;

var builder = WebApplication.CreateBuilder(args);

var mongoDatabase = builder.Configuration.GetSection(typeof(MongoDatabase).Name).Get<MongoDatabase>();
builder.Services.AddSingleton<IMongoDatabase, MongoDatabase>(I => mongoDatabase);


builder.Services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));


builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductManager>();


builder.Services.AddSingleton<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();


// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
