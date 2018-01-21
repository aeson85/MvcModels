using Microsoft.AspNetCore.Mvc;

namespace MvcModels_WebApp.Models
{
    public class HeaderModel
    {
        [FromHeader]
        public string Accept { get; set; }

        [FromHeader(Name="Upgrade-Insecure-Requests")]
        public string UpgradeInsecureRequests { get; set; }

        [FromHeader(Name = "Accept-Language")]
        public string AcceptLanguage { get; set; }
        
        [FromHeader(Name = "Accept-Encoding")]
        public string AcceptEncoding { get; set; }
    }
}