using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;

using System.Text.Json.Serialization;
namespace Algoritma2
{
    

    class Program
    {

        static void Main(string[] args)
        {

            // json dosyasinin yolu
            string address = Environment.CurrentDirectory + @"\response.json";
            // dosya icin gonderilen istek ve alinan cevap
            WebRequest request = HttpWebRequest.Create(address);
            WebResponse response;
            response = request.GetResponse();
            StreamReader returnInfo = new StreamReader(response.GetResponseStream());
            string getInfo = returnInfo.ReadToEnd();

            // json dosyasindan alinan bilgileri parse etme
            List<Root> info = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Root>>(getInfo);

            // bilgileri vertices y'ye gore siralama
            var newList = info.OrderBy(p => p.boundingPoly.vertices[0].y).ToList();


            for (int i=2; i<newList.Count;i++)
            {
                // alt satira gecme icin x'i degerlendirme
                if (newList[i].boundingPoly.vertices[0].x > newList[i - 1].boundingPoly.vertices[0].x)
                {
                    Console.Write(newList[i-1].description+" ");
                }
                else
                {
                    Console.WriteLine(newList[i-1].description);
                }
                
            }
        }

    }
}
