using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using University_API_Backend.Models;

namespace University_API_Backend
{
    public static class AddJwtTokenServicesExtensions
    {
        //El this se usa para que el metodo se puede llamar de IServiceCollecion
        public static void AddJwtTokenServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Añadir JWTSetting
            var bindJwtSetting = new JwtSettings();
            configuration.Bind("JsonWebTokenKeys", bindJwtSetting);
            //Añadimos un Singleton de los JwtSettings
            services.AddSingleton(bindJwtSetting);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata= false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = bindJwtSetting.ValidateIssuerSigingKey,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(bindJwtSetting.IssuserSingingKey)),
                    ValidateIssuer = bindJwtSetting.ValidateIssuser,
                    ValidIssuer = bindJwtSetting.ValidIssuser,
                    ValidateAudience = bindJwtSetting.ValidateAudiance,
                    ValidAudience = bindJwtSetting.ValidAudience,
                    RequireExpirationTime = bindJwtSetting.RequiredExpirationTime,
                    ValidateLifetime = bindJwtSetting.ValidateLifeTime,
                    ClockSkew = TimeSpan.FromDays(1)
                };
            });
        }
    }
}
