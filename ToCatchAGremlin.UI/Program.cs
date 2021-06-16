using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToCatchAGremlin.UI
{
    class Program
    {
        //SEPERATION OF CONCERNS IS KEY....!
        //Front facing prortion of the application
        //This is our main entry point 
        //Everything starts here. Its the control center
        //We only want methond calls
        //"Front end "
        static void Main(string[] args)
        {
            Program_UI UI = new Program_UI();
            UI.Run();
        }
    }
}
