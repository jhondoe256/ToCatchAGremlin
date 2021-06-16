using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToCatchAGemlin.POCO;
using ToCatchAGemlin.POCO.ENUMs;
using ToCatchAGremlin.Repository;

namespace ToCatchAGremlin.UI
{
    public class Program_UI
    {
        //Reference the ToCatchAGremlinRepository...
        private readonly GremlinRepository _gRepo = new GremlinRepository();


        //create entry point method that fires off the application
        public void Run()
        {
            Seed();
            RunApplication();
        }

      

        private void RunApplication()
        {
           
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Welcome to CATCH A GREMLIN!\n" +
                                  "1.Add A Gremlin\n" +
                                  "2.View all Gremlins\n" +
                                  "3.View Gremlin by ID\n" +
                                  "4.Update Existing Gremlin\n" +
                                  "5.Delete Existing Gremlin\n" +
                                  "30. Close application\n");

                //we need a variable that holds the userInput
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddAGremlin();
                        break;
                    case "2":
                        ViewAllGremlins();
                        break;
                    case "3":
                        ViewGremlinById();
                        break;
                    case "4":
                        UpdateExistingGremlin();
                        break;
                    case "5":
                        DeleteExistingGremlin();
                        break;
                    case "30":
                        Console.Clear();
                        isRunning = false;
                        Console.WriteLine("Thank you for your time, press any key to continue.");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Invalid Operation");
                        break;
                }
                Console.Clear();

            }
        }

        private void AddAGremlin()
        {
            //we want an empty screen
            Console.Clear();

            Console.WriteLine("Please input a Gremlin name:");
            string userInputGremlinName = Console.ReadLine();

            Console.WriteLine("Please input a Gremlin type\n" +
                              "1.King\n" +
                              "2.Commander\n" +
                              "3.Soldger\n" +
                              "4.Pesant\n");

            int userInputGremlinType = int.Parse(Console.ReadLine());
            //make a conversion from the userInputGremlinType to the actual gremlin type
            GremlinType gremlinType = (GremlinType)userInputGremlinType;

            Console.WriteLine("Is Gremlin Violent. y/n");
            bool isViolent = false;
            string userInputIsViolent = Console.ReadLine();

            if (userInputIsViolent=="Y".ToLower())
            {
                isViolent = true;
            }
            else
            {
                isViolent = false;
            }

            //now we need to CONSTRUCT A GREMLIN AND ASSIGN THE VALUES! 
            Gremlin gremlin = new Gremlin(userInputGremlinName, gremlinType, isViolent);

            //next is assign the gremlin to the repository...
            bool isSuccessful= _gRepo.CreateGremlin(gremlin);
            if (isSuccessful)
            {
                Console.WriteLine($"{gremlin.Name} was added to the Repository!");
            }
            else
            {
                Console.WriteLine($"{gremlin.Name} has  FAILD to be added to the Repository!");
            }
        }

        private void ViewAllGremlins()
        {
            Console.Clear();
            List<Gremlin> gremlins = _gRepo.GetGremlins().ToList();
            foreach (Gremlin gremlin in gremlins)
            {
                DisplayGremlinDetails(gremlin);
            }
            Console.ReadKey();
        }

        //Helper method 
        private void DisplayGremlinDetails(Gremlin gremlin)
        {
            Console.WriteLine($"{gremlin.ID}\n" +
                              $"{gremlin.Name}\n" +
                              $"{gremlin.GremlinType}\n" +
                              $"{gremlin.IsViolent}\n");

            Console.WriteLine("*********************************************");
            
        }

        private void ViewGremlinById()
        {
            Console.Clear();
            Console.WriteLine("Please input an Existing Gremlin ID:");
            int userInputID = int.Parse(Console.ReadLine());

            //store the existing/non-exsiting gremin value
            Gremlin gremlin = _gRepo.GetGremlinByID(userInputID);

            if (gremlin==null)
            {
                Console.WriteLine("Gremlin does not EXIST!");
            }
            Console.Clear();
            DisplayGremlinDetails(gremlin);
            Console.ReadKey();
        }

        private void UpdateExistingGremlin()
        {
            Console.Clear();
            Console.WriteLine("Please input an Existing Gremlin ID:");
            int userInputID = int.Parse(Console.ReadLine());


            //we want an empty screen
            Console.Clear();

            Console.WriteLine("Please input a Gremlin name:");
            string userInputGremlinName = Console.ReadLine();

            Console.WriteLine("Please input a Gremlin type\n" +
                              "1.King\n" +
                              "2.Commander\n" +
                              "3.Soldger\n" +
                              "4.Pesant\n");

            int userInputGremlinType = int.Parse(Console.ReadLine());
            //make a conversion from the userInputGremlinType to the actual gremlin type
            GremlinType gremlinType = (GremlinType)userInputGremlinType;

            Console.WriteLine("Is Gremlin Violent. y/n");
            bool isViolent = false;
            string userInputIsViolent = Console.ReadLine();

            if (userInputIsViolent == "Y".ToLower())
            {
                isViolent = true;
            }
            else
            {
                isViolent = false;
            }

            //now we need to CONSTRUCT A GREMLIN AND ASSIGN THE VALUES! 
            Gremlin gremlin = new Gremlin(userInputGremlinName, gremlinType, isViolent);

            //we will call _gRepo.UpdateGremlin(id,Gremlin)
            bool isSuccessful = _gRepo.UpdateGremlin(userInputID, gremlin);

            if (isSuccessful)
            {
                Console.WriteLine("Gremlin has been updated!");
            }
            else
            {
                Console.WriteLine("Gremlin has NOT been updated!");

            }
        }

        private void DeleteExistingGremlin()
        {
            Console.Clear();
            Console.WriteLine("Please input an Existing Gremlin ID:");
            int userInputID = int.Parse(Console.ReadLine());

            bool isSuccessful = _gRepo.DeleteGremlin(userInputID);
            if (isSuccessful)
            {
                Console.WriteLine("Gemlin Deleted");
            }
            else
            {
                Console.WriteLine("Gremlin was not Deleted");
            }
        }

        private void Seed()
        {
            //creating initial Gremlin object values to be created EVERY TIME we run the application.
            Gremlin gremlinA = new Gremlin("Terry", GremlinType.King, false);
            Gremlin gremlinB = new Gremlin("Chad", GremlinType.Commander, true);
            Gremlin gremlinC = new Gremlin("Melissa", GremlinType.Solidger, true);
            Gremlin gremlinD = new Gremlin("Gomez", GremlinType.Pesant, false);

            //add them to the repository (_gRepo)
            _gRepo.CreateGremlin(gremlinA);
            _gRepo.CreateGremlin(gremlinB);
            _gRepo.CreateGremlin(gremlinC);
            _gRepo.CreateGremlin(gremlinD);
        }
    }
}
