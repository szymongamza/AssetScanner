using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetScanner.Model;
public class QueryResultResource<T>
{
    public int TotalItems { get; set; } = 0;
    public List<T> Items { get; set; } = new List<T>();
}
