using Server.Configuration;
using Server.Configuration.Interfaces;
using Server.DbConnections;
using Server.Repositories;
using Server.Repositories.Interfaces;
using Server.Services;
using Server.Services.Interfaces;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Server {
    public class Startup {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config) {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services) {

            services.AddControllers();
            services.AddSingleton(new MySQLDbConnection(_config.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options => {
                   options.TokenValidationParameters = new TokenValidationParameters {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false,
                   };
               });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();

            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
               builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod()
           );

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
