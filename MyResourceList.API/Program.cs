using MyResourceList.API.Data;
using MyResourceList.API.Services.Errors;
using MyResourceList.API.Services.Resources;
using MyResourceList.API.Services.ResourceTags;
using MyResourceList.API.Services.Tags;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddSingleton<MyResourceListContext>();
    builder.Services.AddSingleton<IResourceService, DBResourceService>();
    builder.Services.AddSingleton<ITagService, DBTagService>();
    builder.Services.AddSingleton<IResourceTagService, InMemResourceTagService>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddExceptionHandler<ErrorHandler>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler(opt => { });
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}