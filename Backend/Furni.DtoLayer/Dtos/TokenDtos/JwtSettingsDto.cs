namespace Furni.DtoLayer.Dtos.TokenDtos
{
    public class JwtSettingsDto
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int Expires { get; set; }
    }
}
