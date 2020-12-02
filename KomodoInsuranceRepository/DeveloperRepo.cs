using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepository
{
    public class DeveloperRepo
    {
        public List<Developer> _listOfDevelopers = new List<Developer>();

        //Create
        public void AddContenttoList(Developer developer)
        {
            _listOfDevelopers.Add(developer);
        }

        //Read
        public List<Developer> GetContentList()
        {
            return _listOfDevelopers;
        }

        //Update
        public bool UpdateExistingDeveloper(int originalDevID, Developer newDeveloper)
        {
            //Find the content
            Developer oldDeveloper = GetDeveloperByID(originalDevID);

            //Update the content
            if( oldDeveloper != null)
            {
                oldDeveloper.DevID = newDeveloper.DevID;
                oldDeveloper.DevName = newDeveloper.DevName;
                oldDeveloper.PluralSight = newDeveloper.PluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool RemoveDeveloperFromList(int devID)
        {
            Developer developer = GetDeveloperByID(devID);

            if( developer == null)
            {
                return false;
            }

            int initialCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if( initialCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Helper Method
        public Developer GetDeveloperByID(int devID)
        {
            foreach(Developer developer in _listOfDevelopers)
            {
                if(developer.DevID == devID)
                {
                    return developer;
                }
            }
            return null;
        }

        //Pluralsight
        public int GetCountForPluralSight()
        {
            int count = 0;
            foreach(Developer d in _listOfDevelopers)
            {
                if (d.PluralSight == false)
                    count++;
            }
            return count;
        }

    }
}
