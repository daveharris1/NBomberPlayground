namespace HttpHelper
{
    public class HttpCaller
    {
        private HttpClient _httpClient;
        public HttpCaller()
        {
            if(_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }

        public async Task<string> Get(string url)
        {
            return await _httpClient.GetStringAsync(url);
        }
    }
}
