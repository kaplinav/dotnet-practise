using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WebImageViewer
{
    public class Client
    {
        private const string uaValue = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/78.0.3904.97 Safari/537.36";
        private const string ua = "user-agent";
        private const string searchPattern = "https://yandex.ru/images/search?text=";

        private static HttpClient client = new HttpClient();

        public static List<string> uriImg = new List<string>();
        ///public static List<BitmapImage> images = new List<BitmapImage>();
        public static List<byte[]> imagesInBytes = new List<byte[]>();

        
        static Client()
        {
            // Add a user-agent header
            client.DefaultRequestHeaders.Add(ua, uaValue);
        }

        public static void Get(string search)
        {
            RunAsync(search);
        }

        private static void ParseOneItemBlock(string OneItem)
        {
            const string tagBegin = @"origin"":{";
            const string linkBegin = "http";
            const string linkEnd = "}";

            // This method need for getting link to current image 

            int position = 0;
            position = OneItem.IndexOf(tagBegin);

            while (position >= 0)
            {
                int start = OneItem.IndexOf(linkBegin, position);
                int end = OneItem.IndexOf(linkEnd, position);

                if (end > 0)
                {
                    
                    uriImg.Add(OneItem.Substring(start, (end - start) - 1));

                    // need only one link to item
                    return;
                }
                
                position = OneItem.IndexOf(tagBegin, end);
            }
        }

        private static void ParsePage(string page)
        {
            const string divBegin = "<div class=\"serp-item";
            const string divEnd = "</div>";

            // This method contain logic for parse all web-page
            // split search result by items: < div > block for image 1,  < div > block for image 2, etc..


            int beginBlock = 0;
            beginBlock = page.IndexOf(divBegin);

            if (beginBlock < 0)
                return;

            while (beginBlock >= 0)
            {
                int endBlock = 0;
                endBlock = page.IndexOf(divEnd, beginBlock);

                if (endBlock >= 0)
                    ParseOneItemBlock(page.Substring(beginBlock, endBlock - beginBlock));

                beginBlock = page.IndexOf(divBegin, endBlock);
            }

        }

        static async Task RunAsync(string search)
        {
            if (uriImg.Count > 0) 
                uriImg.Clear();

            HttpResponseMessage response = await client.GetAsync(searchPattern + search);
            if (!response.IsSuccessStatusCode)
                return;

            string page = await response.Content.ReadAsStringAsync();
            ParsePage(page);

            if (uriImg.Count == 0)
                return;

            int counter = 0;
            // Get images by URIs and store them onto disk
            foreach (var item in uriImg)
            {
                if (item.Contains(".jpg"))
                {
                    counter++;
                    using (FileStream SourceStream = File.Create(counter.ToString() + "myfile.jpg"))
                    {
                        var byteBlock = await client.GetByteArrayAsync(item);                   
                        using (var stream = new MemoryStream(byteBlock))
                        {
                            Images.GetInstance().Add(BitmapFrame.Create(
                                stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad));
                        }
                        await SourceStream.WriteAsync(byteBlock, 0, byteBlock.Length);
                    }
                }
            }
        }
    }
}