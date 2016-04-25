using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDynamicaLabs.DataClass
{
    [JsonObject(Id = "responce")]
    public class Data
    {
        public Responce responce { get; set; }
    }
}
