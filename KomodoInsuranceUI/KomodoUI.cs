using KomodoInsuranceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceUI
{
    public class KomodoUI
    {
        //persistant object
        private DeveloperRepo _developerRepo = new DeveloperRepo();
        private DevTeamRepo _devTeamRepo = new DevTeamRepo();
        // Method that runs/starts the application
        public void Run()
        {
            SeedDeveloperContentList();
            CreateInitialTeams();
            Menu();
        }

        // Menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Display the options to the user
                Console.WriteLine("Select a menu option:\n" +
                    "1. Create a new developer\n" +
                    "2. View all developers\n" +
                    "3. View specific developer by ID\n" +
                    "4. Update existing developer\n" +
                    "5. Delete existing developer\n\n" +
                    "6. Add new developer team\n" +
                    "7. View all developer teams\n" +
                    "8. View members of developer team\n" +
                    "9. Update existing developer team\n" +
                    "10. Delete existing developer team\n" +
                    "11. Add developer to team\n" +
                    "12. Add multiple developers to team\n" +
                    "13. Remove developer from team\n" +
                    "14. Number of licenses needed\n" +
                    "15. Exit");

                // Get user input
                string input = Console.ReadLine();

                // Evaluate the user's input and act accordingly 

                switch (input)
                {
                    case "1":
                        CreateNewDeveloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayDeveloperbyID();
                        break;
                    case "4":
                        UpdateExistingDeveloper();
                        break;
                    case "5":
                        DeleteExistingDeveloper();
                        break;
                    case "6":
                        CreateNewDevTeam();
                        break;
                    case "7":
                        DisplayAllDevTeams();
                        break;
                    case "8":
                        ViewMemembersOnTeam();
                        break;
                    case "9": //update existing team
                        UpdateExistingDevTeam();
                        break;
                    case "10": //delete existing team
                        DeleteExistingDevTeam();
                        break;
                    case "11": //add developer to team
                        AddMembertoDevTeam();
                        break;
                    case "12": //add multiple devs
                        AddMultipleMemberstoDevTeam();
                        break;
                    case "13": //remove devs from team
                        RemoveDeveloperFromTeam();
                        break;
                    case "14": //number of licenses needed
                        GetNumberOfLicenses();
                        break;
                    case "15":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number");
                        break;

                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        //CreateNewDeveloper
        private void CreateNewDeveloper()
        {
            Console.Clear();
            Developer newDeveloper = new Developer();

            //Name
            Console.WriteLine("Enter the developer's Name (First, Middle, Last): ");
            newDeveloper.DevName = Console.ReadLine();
            //ID
            Console.WriteLine("Enter the developer's ID (xxxxxx): ");
            string idAsString = Console.ReadLine();
            newDeveloper.DevID = int.Parse(idAsString);
            //PluralSight
            Console.WriteLine("Does developer have access to PluralSight? (y/n)");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if(pluralSightAsString == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }
            _developerRepo.AddContenttoList(newDeveloper);
        }


        //View Current Developer
        private void DisplayAllDevelopers()
        {
            Console.Clear();
            List<Developer> listofDevelopers = _developerRepo.GetContentList();

            foreach(Developer developer in listofDevelopers)
            {
                Console.WriteLine($"\nDeveloper Name: {developer.DevName}\n" +
                    $"DevID: {developer.DevID}\n" +
                    $"PluralSight Access? {developer.PluralSight}\n");
            }
        }

        //View Developer by ID
        private void DisplayDeveloperbyID()
        {
            Console.Clear();
            //prompt user for ID
            Console.WriteLine("Enter the Employee ID");

            // Find the developer by ID
            string developerID = Console.ReadLine();
            int developerIDAsInt = int.Parse(developerID);
            Developer developer = _developerRepo.GetDeveloperByID(developerIDAsInt);

            //Display developer info if it isnt null
            if(developer != null)
            {
                Console.WriteLine($"Name: {developer.DevName}\n" +
                    $"DevID: {developer.DevID}\n" +
                    $"PluralSight Access? {developer.PluralSight}");
            }
            else
            {
                Console.WriteLine("No employee by that ID");
            }
        }

        //Update existing developer
        private void UpdateExistingDeveloper()
        {
            Console.Clear();
            List<Developer> listofDevelopers = _developerRepo.GetContentList();

            foreach (Developer developer in listofDevelopers)
            {
                Console.WriteLine($"Name: {developer.DevName}\n" +
                    $"EmployeeID: {developer.DevID}");
            }
            Console.WriteLine("\nEnter the ID of the employee you want to update:");
            string developerID = Console.ReadLine();
            int developerIDAsInt = int.Parse(developerID);

            Developer newDeveloper = new Developer();

            //Name
            Console.WriteLine("Enter the developer's Name (First, Middle, Last): ");
            newDeveloper.DevName = Console.ReadLine();
            //ID
            Console.WriteLine("Enter the developer's ID (xxxxxx): ");
            string idAsString = Console.ReadLine();
            newDeveloper.DevID = int.Parse(idAsString);
            //PluralSight
            Console.WriteLine("Does developer have access to PluralSight? (y/n)");
            string pluralSightAsString = Console.ReadLine().ToLower();

            if (pluralSightAsString == "y")
            {
                newDeveloper.PluralSight = true;
            }
            else
            {
                newDeveloper.PluralSight = false;
            }

            bool wasUpdated = _developerRepo.UpdateExistingDeveloper(developerIDAsInt, newDeveloper);
            if (wasUpdated == true)
            {
                Console.WriteLine("Employee updated");
            }
            else
            {
                Console.WriteLine("Did not update");
            }


        }

        //delete existing developer
        private void DeleteExistingDeveloper()
        {
            Console.Clear();

            // Get the developer we want to remove
            List<Developer> listofDevelopers = _developerRepo.GetContentList();

            foreach (Developer developer in listofDevelopers)
            {
                Console.WriteLine($"Name: {developer.DevName}\n" +
                    $"EmployeeID: {developer.DevID}");
            }
            Console.WriteLine("\nEnter the ID of the employee you want to delete:");
            string developerID = Console.ReadLine();
            int developerIDAsInt = int.Parse(developerID);

            // call the delete method
            bool wasDeleted = _developerRepo.RemoveDeveloperFromList(developerIDAsInt);

            // If the want was deleted, say so
            if( wasDeleted == true)
            {
                Console.WriteLine("The employee was deleted");
            }
            else
            {
                Console.WriteLine("Employee could not be deleted");
            }
            //otherwise, say it wasnt deleted

        }

        //Create new Dev Team

        private void CreateNewDevTeam()
        {
            Console.Clear();
            DevTeam newDevTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the developer team's name: ");
            newDevTeam.TeamName = Console.ReadLine();
            //ID
            Console.WriteLine("Enter the developer team's ID (xxxx): ");
            string idAsString = Console.ReadLine();
            newDevTeam.TeamID = int.Parse(idAsString);

            _devTeamRepo.AddDevTeam(newDevTeam.TeamName, newDevTeam.TeamID);
        }

        //View current Dev Teams

        private void DisplayAllDevTeams()
        {
            List<DevTeam> listofDevTeams = _devTeamRepo.GetDevTeam();

            foreach (DevTeam devTeam in listofDevTeams)
            {
                Console.WriteLine($"\nDev Team Name: {devTeam.TeamName}\n" +
                    $"DevTeamID: {devTeam.TeamID}\n");
            }
        }

        //View members on Team
        private void ViewMemembersOnTeam()
        {
            Console.WriteLine("Teams and their members: ");
            foreach (DevTeam t in _devTeamRepo.GetDevTeam())
            {
                Console.WriteLine($"\nTeam Name {t.TeamName} \n" +
                    $"\nTeam ID: {t.TeamID}");
                foreach(Developer d in t.GetDevelopers())
                {
                    Console.WriteLine($"\nName: {d.DevName}\n" +
                        $"\nDevID: {d.DevID}" +
                        $"\nPluralSight: {d.PluralSight}");
                }
            }
            Console.WriteLine();
        }

        //Update existing dev team
        private void UpdateExistingDevTeam()
        {
            Console.Clear();
            List<DevTeam> listOfDevTeam = _devTeamRepo.GetDevTeam();

            foreach (DevTeam t in listOfDevTeam)
            {
                Console.WriteLine($"Dev Team Name: {t.TeamName}\n" +
                    $"Dev Team ID: {t.TeamID}");
            }
            Console.WriteLine("\nEnter the ID of the team you want to update:");
            int devID = GetID();

            DevTeam newDevTeam = new DevTeam();

            //Name
            Console.WriteLine("Enter the Dev Team's new name: ");
            newDevTeam.TeamName = Console.ReadLine();
            //ID
            Console.WriteLine("Enter the Dev Team's new ID");
            int teamID = GetID();
            newDevTeam.TeamID = teamID;

            bool wasUpdated = _devTeamRepo.UpdateExistingDevTeam(devID, newDevTeam);
            if (wasUpdated == true)
            {
                Console.WriteLine("Team updated");
            }
            else
            {
                Console.WriteLine("Did not update");
            }


        }

        //delete existing dev team
        private void DeleteExistingDevTeam()
        {
            Console.Clear();

            // Get the devTeam we want to remove
            List<DevTeam> listOfDevTeam = _devTeamRepo.GetDevTeam();

            foreach (DevTeam t in listOfDevTeam)
            {
                Console.WriteLine($"Team Name: {t.TeamName}\n" +
                    $"EmployeeID: {t.TeamID}");
            }
            Console.WriteLine("\nEnter the ID of the team you want to delete:");
            int devTeamID = GetID();

            // call the delete method
            bool wasDeleted = _devTeamRepo.RemoveDevTeamFromList(devTeamID);

            // If the want was deleted, say so
            if (wasDeleted == true)
            {
                Console.WriteLine("The team was deleted");
            }
            else
            {
                Console.WriteLine("Team could not be deleted");
            }
            //otherwise, say it wasnt deleted

        }
        //add developer to team
        private void AddMembertoDevTeam()
        {
            Console.Clear();
            DisplayAllDevelopers();
            DisplayAllDevTeams();
            Console.WriteLine("Please Enter a TeamID: ");
            int teamID = GetID();
            Console.WriteLine("Please enter the ID of the developer you want to add ");
            int devID = GetID();
            Developer d = _developerRepo.GetDeveloperByID(devID);
            bool added = _devTeamRepo.AddDeveloperToTeam(teamID, d);
            if(added == true)
            {
                Console.WriteLine("Developer has been added to " + teamID.ToString());
            }
            else
            {
                Console.WriteLine("Developer was not added");
            }
        
        }
        //Add multiple developers
        public void AddMultipleMemberstoDevTeam()
        {
            Console.Clear();
            DisplayAllDevelopers();
            DisplayAllDevTeams();
            bool complete = false;
            Console.WriteLine("Add developers to team 0 to quit");
            Console.WriteLine("Please enter the TeamID: ");
            int teamID = GetID();
            if (teamID == 0)
            {
                complete = true;
            }
            while(!complete)
            {
                string team = "Please enter the ID of the dev you want to add to team " + teamID.ToString() + "type 0 to exit";
                Console.WriteLine(team);
                int devID = GetID();
                if (devID == 0)
                { break; }
                Developer d = _developerRepo.GetDeveloperByID(devID);
                bool added = _devTeamRepo.AddDeveloperToTeam(teamID, d);
                if (added == true)
                {
                    Console.Clear();
                    DisplayAllDevelopers();
                    DisplayAllDevTeams();
                }
                else
                {
                    Console.WriteLine("Please enter a valid developer number");
                    complete = true;
                }
                
            } 


        }


        //remove developer from team
        private void RemoveDeveloperFromTeam()
        {
            Console.Clear();
            DisplayAllDevelopers();
            DisplayAllDevTeams();
            Console.WriteLine("Please enter the team ID for the team you want to remove a member from: ");
            int teamID = GetID();
            Console.WriteLine("Please enter the DevID for the person you want to remove");
            int devID = GetID();
            Developer d = _developerRepo.GetDeveloperByID(devID);
            bool removed = _devTeamRepo.RemoveDeveloperFromTeam(teamID, d);
            if (removed == true)
            {
                Console.WriteLine("Developer Removed");
            }
            else
            {
                Console.WriteLine("Developer not removed");
            }

        }

        // number of licenses needed
        private void GetNumberOfLicenses()
        {
            Console.Clear();
            Console.WriteLine($"The number of licenses needed are {_developerRepo.GetCountForPluralSight()}. ");
        }
            
        
        
        //Seed Method
            private void SeedDeveloperContentList()
        {
            Developer andrew = new Developer("Andrew", 123456, true);
            Developer billy = new Developer("Billy", 456789, false);
            Developer steven = new Developer("Steven", 456788, false);

            _developerRepo.AddContenttoList(andrew);
            _developerRepo.AddContenttoList(billy);
            _developerRepo.AddContenttoList(steven);
        }
        public void CreateInitialTeams()
        {
            DevTeam a = new DevTeam("Pandas", 1234);
            DevTeam b = new DevTeam("Snow Leopards", 5678);
            _devTeamRepo.AddNewTeam(a);
            _devTeamRepo.AddNewTeam(b);
        }

        //Get ID
        public int GetID()
        {
            string input = Console.ReadLine();
            int inputAsInt = int.Parse(input);
            return inputAsInt;
        }
    }
}
