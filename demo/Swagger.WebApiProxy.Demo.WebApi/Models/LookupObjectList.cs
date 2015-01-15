using System.Collections.Generic;
using System.Linq;

namespace Swagger.WebApiProxy.Demo.WebApi.Models
{
    public class LookupObjectList<T> where T : LookupObject
    {
        public Dictionary<int, T> Lookups { get; private set; }

        public LookupObjectList(IEnumerable<T> list)
        {
            Lookups = new Dictionary<int, T>();
            foreach (T elem in list) Lookups[elem.Id] = elem;
        }

        public T GetByValue(string value)
        {
            return Lookups.Values.FirstOrDefault(e => e.Value == value);
        }

        public T GetById(int id)
        {
            return Lookups.Values.FirstOrDefault(e => e.Id == id);
        }
    }
}