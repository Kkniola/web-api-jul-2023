//This is Main .NET
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//above this is configuration for the "behind the scenes" things in your API
var app = builder.Build();
//after this is setting up "middleware" - that's the code that receives the HTTP request and makes the response

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //the code that will let you get the documentation
    app.UseSwaggerUI(); //this is the middleware that provides the UI for viewing that documentation
}

app.UseAuthorization();


app.MapControllers(); //when we are doing "controller based" APIs this is where it creates the "lookup table" (route table)

app.Run(); //this is when API is up and running and it "blocks" here
