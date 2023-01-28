using System.Globalization;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using BackEnd_LatvianMap.LatvianPlaces.Model;
using CsvHelper;
using CsvHelper.Configuration;

namespace BackEnd_LatvianMap.LatvianPlaces.Infrastructure.Persistence.csv;

public class CsvLatvianCardinalPlacesRepository : ILatvianCardinalPlacesRepository
{
    public List<Centroids> GetLatvianPlaces()
    {
        string uri = "https://data.gov.lv/dati/dataset/0c5e1a3b-0097-45a9-afa9-7f7262f3f623/resource/1d3cbdf2-ee7d-4743-90c7-97d38824d0bf/download/aw_csv.zip";

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

                return csvReader.GetRecords<Centroids>().ToList();
            }
        }
    }
}