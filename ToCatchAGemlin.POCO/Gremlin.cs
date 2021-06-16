using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToCatchAGemlin.POCO.ENUMs;

namespace ToCatchAGemlin.POCO
{
    public class Gremlin
    {
        //attributes that define a Gremlin...
        public int ID { get; set; }
        public string Name { get; set; }
        public GremlinType GremlinType { get; set; }

        public bool IsViolent { get; set; }


        //I want to create an empty or a complete Gremlin on the fly
        public Gremlin()
        {

        }

        public Gremlin(string name, GremlinType gremlinType,bool isViolent)
        {
            Name = name;
            GremlinType = gremlinType;
            IsViolent = isViolent;
        }

    }
}
