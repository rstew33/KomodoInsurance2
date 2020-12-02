using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepository
{
    public class DevTeam //POCO
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        private List<Developer> listOfDevelopers = new List<Developer>(); //listofDevelopers for Team

        public DevTeam() { }

        public DevTeam(string teamName, int teamID)
        {
            TeamName = teamName;
            TeamID = teamID; 
        }
        public List<Developer> GetDevelopers()
        {
            return listOfDevelopers;
        }
        public void AddToDeveloperTeam(Developer dev)
        {
            listOfDevelopers.Add(dev);
        }

        public bool RemoveFromDeveloperTeam(Developer dev)
        {
            bool onTeam = FindDeveloperOnTeam(dev);
            if (onTeam)
            {
                listOfDevelopers.Remove(dev);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool FindDeveloperOnTeam(Developer dev)
        {
            foreach(Developer d in listOfDevelopers)
            {
                if (d.DevID == dev.DevID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
