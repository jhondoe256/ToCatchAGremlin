using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToCatchAGemlin.POCO
{
    public class GremlinCatcher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Gremlin> CapturedGremlins { get; set; } = new List<Gremlin>();

        public decimal Earnings 
        {
            get
            {
                //this initializes the total earnings variable
                decimal totalEarnings = 0;

                //loop threw all of the gremlins and add their total value to 
                // the total earnings based on their GremlinType
                foreach (Gremlin gremlin in CapturedGremlins)
                {
                    //this is where the ADDITION happens...
                    totalEarnings += CalculateGremlinEarnings(gremlin);

                }
                    return totalEarnings;
              
            }
        }

        private decimal CalculateGremlinEarnings(Gremlin gremlin)
        {
            switch (gremlin.GremlinType)
            {
                case ENUMs.GremlinType.King:
                    return 20000.00m;
                case ENUMs.GremlinType.Commander:
                    return 10000.00m;
                case ENUMs.GremlinType.Solidger:
                    return 1000.00m;
                case ENUMs.GremlinType.Pesant:
                    return 1.00m;
                default:
                    Console.WriteLine("Invalid Gremlin Option");
                    return 0;
                    
            }
        }

        public GremlinCatcher()
        {

        }

        public GremlinCatcher(string name, List<Gremlin> capturedGremlins)
        {
            Name = name;
            CapturedGremlins = capturedGremlins;
        }
    }
}
