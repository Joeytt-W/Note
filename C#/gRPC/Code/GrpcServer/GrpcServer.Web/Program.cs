using GrpcServer.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

}

app.UseRouting();

app.UseHttpsRedirection();

app.UseEndpoints(endpoint =>
{
    endpoint.MapGrpcService<MyEmployeeService>();
});

app.Run();
