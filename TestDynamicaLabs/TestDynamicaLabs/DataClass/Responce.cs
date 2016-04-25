using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDynamicaLabs.DataClass
{
    [JsonObject(Id = "items")]
    public class Responce
    {
        public List<Item> items { get; set; }
    }
}
