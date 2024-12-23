
using Microsoft.Extensions.Options;
using RefitExample.Services;

namespace RefitExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddOptions<GithubSettings>().BindConfiguration(GithubSettings.GithubConfiguration).ValidateDataAnnotations().ValidateOnStart();

            builder.Services.AddHttpClient<GithubHttpService>((sp, httpClient) => {
                var githubSettings = sp.GetRequiredService<IOptions<GithubSettings>>().Value;
                
                httpClient.BaseAddress = new Uri(githubSettings.BaseUrl);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {githubSettings.AccessToken}");
                httpClient.DefaultRequestHeaders.Add("User-Agent",githubSettings.UserAgent);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("api/users/{username}", async (string username,GithubHttpService githubHttpService) => Results.Ok(await githubHttpService.GetUserByUsernameAsync(username)));
           

            app.UseHttpsRedirection();

            app.UseAuthorization();

           

           

            app.Run();
        }
    }
}
