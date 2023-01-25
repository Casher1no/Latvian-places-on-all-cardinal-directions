using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Controllers
{
    [Route("api/latvia/places")]
    [ApiController]
    public class LatvianPlacesController : ControllerBase
    {
        [HttpGet(Name = "latvia/places")]
        public void GetPlaces()
        {
            string uri =
                "https://data.gov.lv/dati/dataset/0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";
            
            WebClient webClient = new WebClient();
            webClient.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            webClient.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            
            webClient.DownloadFileAsync(new Uri(uri),"Downloads/resource.zip");

            using (ZipArchive)
            {
                
            }

        }
    }
}
