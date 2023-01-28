using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BackEnd_LatvianMap.LatvianPlaces.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Controllers
{
    [Route("api/latvia/further-places")]
    [ApiController]
    public class LatvianPlacesController : ControllerBase
    {
        [HttpGet]
        public Dictionary<string,Centroids> GetFurtherPlaces()
        {
            string uri =
                "https://data.gov.lv/dati/dataset/0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";

            string zipPath = "Downloads/Zip/resource.zip";

            string csvDataFile = "/AW_VIETU_CENTROIDI.CSV";

            string extracted = "Downloads/extracted";

            string tempFile = "Downloads/temp";

            Centroids place = new Centroids();

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(uri, zipPath);
            }

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                var entry = archive.GetEntry(csvDataFile);

                if (!Directory.Exists(extracted))
                {
                    archive.ExtractToDirectory(extracted);
                }

                string csvFileContent = System.IO.File.ReadAllText(extracted + csvDataFile);
                string cleanedFileContent = Regex.Replace(csvFileContent, "#", "");
                System.IO.File.WriteAllText(tempFile, cleanedFileContent);

                using (var streamReader = new StreamReader(tempFile))
                using (var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture)
                       {
                           Delimiter = ";",
                           BadDataFound = null
                       }))
                {
                    csvReader.Read();
                    csvReader.ReadHeader();

                    var centroids = csvReader.GetRecords<Centroids>().ToList();

                    Dictionary<string,Centroids> centroidsList = new Dictionary<string, Centroids>();
                    
                    centroidsList.Add("furthestNorth",centroids.MaxBy(c => c.DD_N));
                    centroidsList.Add("furthestSouth",centroids.MinBy(c => c.DD_N));
                    centroidsList.Add("furthestEast",centroids.MaxBy(c => c.DD_E));
                    centroidsList.Add("furthestWest",centroids.MinBy(c => c.DD_E));
                    
                    return centroidsList;
                }
            }
        }
    }
}