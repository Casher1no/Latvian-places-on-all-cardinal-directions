using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BackEnd_LatvianMap.LatvianPlaces.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Controllers
{
    [Route("api/latvia/places")]
    [ApiController]
    public class LatvianPlacesController : ControllerBase
    {
        [HttpGet(Name = "latvia/places")]
        public string GetPlaces()
        {
            string uri = "https://data.gov.lv/dati/dataset/0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";

            string zipPath = "Downloads/Zip/resource.zip";

            string csvDataFile = "AW_VIETU_CENTROIDI.CSV";

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(uri,zipPath);
            }
            
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName == csvDataFile)
                    {
                        var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            Delimiter = "#",
                        };
                        
                        using (var reader = new StreamReader(entry.Open()))
                        using (var csv = new CsvReader(reader, csvConfig))
                        {
                            var records = csv.GetRecords<Centroids>().ToList();
                            foreach (var record in records)
                            {
                                return record.STD;
                            }
                            
                        }
                            
                        
                    }
                }
            }

            return "none";

        }
    }
}
