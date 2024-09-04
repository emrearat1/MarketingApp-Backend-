using Business;
using Business.Abstracts;
using Business.Contretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBusinessServices();

builder.Services.AddSingleton<IUserDal, EfUserDal>();
builder.Services.AddSingleton<IUserService,UserService>();

//builder.Services.AddSingleton<ITransmissionDal, EFTransmissionDal>();
//builder.Services.AddSingleton<TransmissionBussinessRules>();
//builder.Services.AddSingleton<ITransmissionService, TransmissionManager>();


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
});
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
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
