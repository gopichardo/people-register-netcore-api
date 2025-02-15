using FluentValidation;
using Microsoft.EntityFrameworkCore;
using People.Api.Utils;
using People.Application.UseCases;
using People.Application.Validators;
using People.Domain.Interfaces;
using People.Infrastructure.Persistence;
using People.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Inject Services
builder.Services.AddScoped<IRegisterPersonUseCase, RegisterPersonUseCase>();
builder.Services.AddScoped<IGetPersonByIdUseCase, GetPersonByIdUseCase>();
builder.Services.AddScoped<IGetAllPeopleUseCase, GetAllPeopleUseCase>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<ValidationResultFormatter, ValidationResultFormatter>();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fluent validators
builder.Services.AddValidatorsFromAssemblyContaining<PersonValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CompanyValidator>();

// Entity Framework
builder.Services.AddDbContext<PeopleDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeopleDB"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
