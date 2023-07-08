using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssetScanner.Model;

namespace AssetScanner.Services;
public interface IRestService
{
    Task<QueryResultResource<AssetResource>> GetAsset(AssetQueryResource query);
}
