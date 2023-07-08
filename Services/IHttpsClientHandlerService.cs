

namespace AssetScanner.Services;
public interface IHttpsClientHandlerService
{
    HttpMessageHandler GetPlatformMessageHandler();
}
