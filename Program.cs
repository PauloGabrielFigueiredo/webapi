using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServices(builder.Configuration);




// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer("server=localhost;database=EFCore;user=sa;password=R.desktop123");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.WebHost.UseUrls("https://10.0.2.2", "https://localhost");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.Urls.Add("https://10.0.2.2/");
//app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
