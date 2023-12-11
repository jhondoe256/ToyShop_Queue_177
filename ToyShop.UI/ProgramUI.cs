using ToyShop.Data;
using ToyShop.Repository;

namespace ToyShop.UI
{
    public class ProgramUI
    {
        private readonly ToyRepository _toyRepo;

        public ProgramUI()
        {
            _toyRepo = new ToyRepository();
        }

        public void Run()
        {
            RunApplication();
        }

        private void RunApplication()
        {
            bool isRunning = true;
            while (isRunning)
            {
                ClearConsole();
                System.Console.WriteLine("Welcome to Toys R Us Admin App\n" +
                                         "Please make a selection:\n" +
                                         "1.  Add a Toy\n" +
                                         "2.  View All Toys\n" +
                                         "3.  View Current Toy\n" +
                                         "4.  Update Current Toy\n" +
                                         "5.  Delete Current Toy\n" +
                                         "00. Close App\n" +
                                         "================================================\n");

                int userInput = int.Parse(Console.ReadLine()!);

                switch (userInput)
                {
                    case 1:
                        AddAToy();
                        break;
                    case 2:
                        ViewAllToys();
                        break;
                    case 3:
                        ViewCurrentToy();
                        break;
                    case 4:
                        UpdateCurrentToy();
                        break;
                    case 5:
                        DeleteCurrentToy();
                        break;
                    case 00:
                        isRunning = CloseApp();
                        break;
                    default:
                        System.Console.WriteLine("Invalid operation, please try again.");
                        break;
                }
            }
        }

        public void ClearConsole()
        {
            Console.Clear();
        }

        public bool CloseApp()
        {
            ClearConsole();
            System.Console.WriteLine("Thx.");
            PressAnyKey();
            ClearConsole();
            return false;
        }

        private void PressAnyKey()
        {
            System.Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private void ViewAllToys()
        {
            ClearConsole();
            System.Console.WriteLine("== Toy Listing Menu ==");
            if (_toyRepo.GetToys().Count() > 0)
            {
                foreach (Toy toy in _toyRepo.GetToys())
                {
                    System.Console.WriteLine(toy);
                }
            }
            else
            {
                System.Console.WriteLine("Sorry, no toys available.");
            }
            PressAnyKey();
        }

        private void ViewCurrentToy()
        {
            ClearConsole();
            System.Console.WriteLine("== Toy Information ==");
            Toy currentToy = _toyRepo.GetToy();
            if (currentToy != null)
            {
                System.Console.WriteLine(currentToy);
            }
            else
            {
                System.Console.WriteLine("Sorry, no toys available.");
            }

            PressAnyKey();
        }

        private void UpdateCurrentToy()
        {
            ClearConsole();
            System.Console.WriteLine("== Update Current Toy ==");
            Toy currentToy = _toyRepo.GetToy();
            if (currentToy != null)
            {
                Toy newToyData = UpsertToyData();
                if (_toyRepo.UpdateCurrentToy(newToyData))
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Fail!");
                }
            }
            else
            {
                System.Console.WriteLine("Sorry, no toys available.");
            }

            PressAnyKey();
        }

        private Toy UpsertToyData()
        {
            try
            {
                Toy data = new Toy();

                Console.Write("Please enter a toy name: ");
                data.Name = Console.ReadLine()!;

                Console.Write("Please enter a discription: ");
                data.Description = Console.ReadLine()!;

                System.Console.WriteLine("Select a Toy Type:\n" +
                                        "1. Action Figure\n" +
                                        "2. Building And Construction\n" +
                                        "3. Retro\n" +
                                        "4. Office and Desk\n" +
                                        "5. Plush\n" +
                                        "6. Puzzles\n" +
                                        "7. Rc and Electronics\n" +
                                        "8. Board Games\n");

                int userInput = int.Parse(Console.ReadLine()!);

                data.ToyType = (ToyType)userInput;

                System.Console.Write("Please enter a Toy Price: ");

                data.Price = decimal.Parse(Console.ReadLine()!);

                return data;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Something went wrong {ex.Message}");
            }
            return null;
        }

        private void DeleteCurrentToy()
        {
            ClearConsole();
            System.Console.WriteLine("== Delete Toy Menu ==");
            if (_toyRepo.GetToys().Count() > 0)
            {
                System.Console.Write("Do you want to remove the current toy? y/n \n");

                System.Console.WriteLine(_toyRepo.GetToy());

                string userInput = Console.ReadLine()!;
                if (userInput == "Y".ToLower())
                {
                    Toy currentToy = _toyRepo.RemoveCurrentToy();
                    if (currentToy != null)
                    {
                        System.Console.WriteLine($"You Successfully removed: {currentToy.Name}!");
                    }
                    else
                    {
                        System.Console.WriteLine($"Sorry unable to remove: null value!");
                    }
                }
                else
                {
                    System.Console.WriteLine("Deletion Cancelled.");
                }

            }
            else
            {
                System.Console.WriteLine("Sorry, no toys available.");
            }
            PressAnyKey();
        }

        private void AddAToy()
        {
            ClearConsole();
            System.Console.WriteLine("== Add Current Toy ==");
            
            Toy toyData = UpsertToyData();
            
            if(_toyRepo.AddToy(toyData))
            {
                System.Console.WriteLine("Success!");
            }
            else
            {
                System.Console.WriteLine("Fail!");
            }

            PressAnyKey();
        }
    }
}