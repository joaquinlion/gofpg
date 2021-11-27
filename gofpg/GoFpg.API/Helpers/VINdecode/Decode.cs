﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace GoFpg.API.Helpers.VINdecode
{
    public class Decode
    {
        public async static Task<RootObject> GetInfo(string vin)
        {
            var http = new HttpClient();
            var response = await http.GetAsync("https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvalues/" + vin + "?format=json");
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
    }
}
