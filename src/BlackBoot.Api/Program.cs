using BlackBoot.Api.Extentions;
using BlackBoot.Api.Middlewares;
using BlackBoot.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


#region Services
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddBlockBootDbContext(configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBlackBootAuthentication(configuration);
builder.Services.RegisterApplicatioinServices();
#endregion

#region Application
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.UseEndpoints(config =>
{
    config.MapControllers();
});

app.Run();
#endregion

