using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToCatchAGemlin.POCO;

namespace ToCatchAGremlin.Repository
{
    public class GremlinRepository
    {
        //Our goal here is to use C.R.U.D
        //we need to have a 'fake database' -> List<Gremlin> 
        private readonly List<Gremlin> _grimlinRepo = new List<Gremlin>();

        //create a field 
        //this _count will help the Gremlin ID auto increment,
        private int _count = 0;

        //C. create
        public bool CreateGremlin(Gremlin gremlin)
        {
            if (gremlin != null)
            {
                _count++;
                gremlin.ID = _count;
                _grimlinRepo.Add(gremlin);
                return true;
            }
            return false;
        }

        //R. read -> gives the list of gremlins
        public IEnumerable<Gremlin> GetGremlins()
        {
            return _grimlinRepo;
        }

        //R. readById -> gives us a specific gremlin (helper method)
        public Gremlin GetGremlinByID(int id)
        {
            //look threw every gremlin in the _grimlinRepo (repository)
            foreach (Gremlin gremlin in _grimlinRepo)
            {
                if (gremlin.ID==id)
                {
                    return gremlin;
                }
            }
                return null;
        }

        //U. update
        public bool UpdateGremlin(int id, Gremlin updatedGemlinValue)
        {
            //we want to get an existing gremlin form the repository
            //use the 'helper method' from above...
            Gremlin oldGremlin = GetGremlinByID(id);
            if (oldGremlin ==null)
            {
                return false;
            }

            oldGremlin.ID = id;
            oldGremlin.Name = updatedGemlinValue.Name;
            oldGremlin.GremlinType = updatedGemlinValue.GremlinType;
            oldGremlin.IsViolent = updatedGemlinValue.IsViolent;

            return true;
        }

        //D. delete
        public bool DeleteGremlin(int id)
        {
            //we want to get an existing gremlin form the repository
            //use the 'helper method' from above...
            Gremlin gremlin = GetGremlinByID(id);
            if (gremlin!=null)
            {
                _grimlinRepo.Remove(gremlin);
                return true;
            }
            return false;
        }

    }
}
