namespace APICore
{
    public class APICore
    {
        public string getCotizacion()
        {
            UriBuilder builder = new UriBuilder("http://api.currencylayer.com/live?access_key=b78cb57dd723721f03aa5746506069be&currencies=UYU&source=USD&format=1");

            //Create a Query
            HttpClient client = new HttpClient();
            var result = client.GetAsync(builder.Uri).Result;

            using (StreamReader sr = new StreamReader(result.Content.ReadAsStreamAsync().Result))
            {
                return sr.ReadToEnd();
            }
        }
    }
}