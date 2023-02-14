
namespace University_API_Backend.Models
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigingKey { get; set; }
        public string IssuserSingingKey { get; set; } = string.Empty;
        
        public bool ValidateIssuser { get; set; } = true;
        public string? ValidIssuser { get; set; }
        
        public bool ValidateAudiance { get; set; } = true;
        public string? ValidAudience { get; set; }

        public bool RequiredExpirationTime { get; set; }
        public bool ValidateLifeTime { get; set; } = true;
    }
}
