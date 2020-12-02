using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsuranceRepository
{
    public class DevTeamRepo //REPO
    {
        private readonly List<DevTeam> _listofDevTeams = new List<DevTeam>();

        //Create
        public void AddDevTeam(string teamName, int teamID)
        {
            DevTeam devTeam = new DevTeam(teamName, teamID);
            _listofDevTeams.Add(devTeam);
        }
        public void AddNewTeam (DevTeam dev)
        {
            _listofDevTeams.Add(dev);
        }
        public bool AddDeveloperToTeam(int teamID,Developer dev)
        {
            DevTeam team = GetDevTeamByID(teamID);

            if (team != null)
            {
                team.AddToDeveloperTeam(dev);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddDevelopersToTeam(int teamID, List<Developer> developers)
        {
            DevTeam team = GetDevTeamByID(teamID);
            if (team != null)
            {
                foreach(Developer d in developers)
                {
                    team.AddToDeveloperTeam(d);
                }
            }
        }


        //Read

        public List<DevTeam> GetDevTeam()
        {
            return _listofDevTeams;
        }

        //Update
        public bool UpdateExistingDevTeam(int orgiginalTeamID, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeamByID(orgiginalTeamID);
            if (oldDevTeam != null)
            {
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.TeamID = newDevTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveDevTeamFromList(int devTeamID)
        {
            DevTeam devTeam = GetDevTeamByID(devTeamID);

            if( devTeam == null)
            {
                return false;
            }

            int initialCount = _listofDevTeams.Count;
            _listofDevTeams.Remove(devTeam);
            
            if( initialCount > _listofDevTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveDeveloperFromTeam(int teamID, Developer dev)
        {
            DevTeam team = GetDevTeamByID(teamID);
            bool devRemoved = false;

            if(team != null)
            {
                devRemoved = team.RemoveFromDeveloperTeam(dev);
            }

            return devRemoved;
        }

        //Helper Methods
        public DevTeam GetDevTeamByID(int devTeamID)
        {
            foreach (DevTeam devTeam in _listofDevTeams)
            {
                if (devTeam.TeamID == devTeamID)
                {
                    return devTeam;
                }
            }
            return null;
        }
    }
}
