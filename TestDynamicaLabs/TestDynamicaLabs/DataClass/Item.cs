using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDynamicaLabs.DataClass
{
    public class Item
    {
        [JsonProperty(PropertyName = "maker")]
        public string maker { get; set; }
        [JsonProperty(PropertyName = "model")]
        public string model { get; set; }

    }
}
