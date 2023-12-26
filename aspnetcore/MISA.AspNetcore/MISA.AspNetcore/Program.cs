using Microsoft.AspNetCore.Mvc;
using MISA.AspNetcore;
using MISA.AspNetcore.Application;
using MISA.AspNetcore.Domain;
using MISA.AspNetcore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MISAApp",
        policy =>
        {
            policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Values.SelectMany(x => x.Errors);

            return new BadRequestObjectResult(new BaseException()
            {
                ErrorCode = 400,
                DevMessage = "Lỗi nhập thông tin từ người dùng",
                UserMessage = "Lỗi nhập thông tin từ người dùng",
                TraceId = "",
                MoreInfo = ""
            });
        };
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration["ConnectionString"];

builder.Services.AddScoped<IUnitOfWork>(provider =>  new UnitOfWork(connectionString));
    
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeManager, EmployeeManager>();


builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();


builder.Services.AddScoped<IPositionRepository, PositionRepository>();
builder.Services.AddScoped<IPositionService, PositionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MISAApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ExceptionMiddleware>();

app.Run();
