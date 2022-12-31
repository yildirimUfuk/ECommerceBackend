using ECommerceBackend.Application.Validators.Products;
using ECommerceBackend.Infrastructure.Filters;
using ECommerceBackend.Persistence;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


#pragma warning disable CS0618 // Type or member is obsolete
//custom 'validationFilter' filter is adding to controller
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    //adding fluent validation service
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    // to disable default filter. My filters will be active now.
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
#pragma warning restore CS0618 // Type or member is obsolete
builder.Services.AddPersistenceServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//allow request for "http://localhost:4200" or secure ones.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// adding CORS middleware
app.UseCors();

app.MapControllers();

app.Run();
