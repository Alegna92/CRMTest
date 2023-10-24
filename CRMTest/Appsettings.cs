namespace CRMTest
{
    public class Appsettings
    {
        public bool Incognito { get; set; }
        public bool RunHeadless { get; set; }
        public string Browser { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Theme { get; set; } = string.Empty;

    }
}
