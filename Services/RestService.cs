using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using AssetScanner.Model;
using AssetScanner.Services;

namespace AssetScanner;
public class RestService : IRestService
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    IHttpsClientHandlerService _httpsClientHandlerService;

    public QueryResultResource<AssetResource> QueryResult { get; private set; }

    public RestService(IHttpsClientHandlerService httpsClientHandlerService)
    {
#if DEBUG
        _httpsClientHandlerService = httpsClientHandlerService;
        HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
        if (handler != null)
            _client = new HttpClient(handler);
        else
            _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

    }

    public async Task<QueryResultResource<AssetResource>> GetAsset(AssetQueryResource query)
    {
        QueryResult = new QueryResultResource<AssetResource>();

        var builder = new UriBuilder($"{Constants.AssetsUrl}");
        builder.Port = -1;
        var q = HttpUtility.ParseQueryString(builder.Query);
        q["QRCode"] = $"{query.QRCode}";
        builder.Query = q.ToString();
        string url = builder.ToString();

        try
        {
            HttpResponseMessage response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                QueryResult = JsonSerializer.Deserialize<QueryResultResource<AssetResource>>(content, _serializerOptions);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(@"\tERROR {0}", ex.Message);
        }

        return QueryResult;

    }
}
