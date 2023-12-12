using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using StudentPlatform.API.Data;
using StudentPlatform.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(options => {
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<Context>(
    options =>
    options.UseSqlServer("Server=localhost;Database=StudentPlatform;Trusted_Connection=True;Trust Server Certificate=Yes")
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/student", () =>
{
    using(Context context = new Context()){
        return context.Students.Include("Courses").ToList();
    }
}
);

app.MapPost("/student", (string name) =>
{
    using (Context context = new Context()){
        Student student = new Student(name);
        Course course = context.Courses.First();
        student.Courses.Add(course);
        context.Students.Add(student);
        context.SaveChanges();
    }
});

app.MapPost("/course", (string name) =>
{
    using (Context context = new Context()){
        context.Courses.Add(new Course(name));
        context.SaveChanges();
    }
});
app.Run();

