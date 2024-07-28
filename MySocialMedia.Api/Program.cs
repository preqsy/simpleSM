using MySocialMedia.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.MapPostEndpoint();


app.Run();
