﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace GoFpg.API.Helpers.VINdecode
{
    [DataContract]
    public class RootObject
    {
        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string SearchCriteria { get; set; }

        [DataMember]
        public List<Result> Results { get; set; }
    }
}
