using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GraphQL.API.GraphqlCore
{
    public class GraphqlQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        //[JsonConverter(typeof(InputsConverter))]
        //public Dictionary<string, object> Variables
        //{
        //    get; set;
        //}

        public JObject Variables { get; set; }
    }
}
