using Jysk.BLL.Infrastructure;
using Jysk.BLL.Interfaces;
using Jysk.BLL.Servives;
using Jysk.DAL.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddJyskContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.AddTransient<IManufacturerService, ManufacturerService>();
builder.Services.AddTransient<ICargoService, CargoService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IDeliveryService, DeliveryService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IReviewService, ReviewService>();
builder.Services.AddTransient<IStorageService, StorageService>();
builder.Services.AddTransient<IStoreService, StoreService>();
builder.Services.AddTransient<ISupplyService, SupplyService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IWorkHoursService, WorkHoursService>();
builder.Services.AddTransient<IWriteOffService, WriteOffService>();
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("https://localhost:51042").AllowAnyHeader().AllowAnyMethod());
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
