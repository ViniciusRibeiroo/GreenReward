using GreenReward.Server.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDataContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });

var app = builder.Build();

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseDefaultFiles(); 
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseEndpoints(e => {});

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
