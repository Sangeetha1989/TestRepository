using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _21_WCF_Assigment_1_Task2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] GetJobOpenings()
        {
            string[] JobOpenings = new string[] { ".Net", "Java", "Python", "VB", "Typescript", "Angular" };
            return JobOpenings;
        }

        public string[] GetJobOpeningsByRole(string value)
        {
            string[] JobOpenings = new string[] { };
            switch (value.ToUpper())
            {
                case "DEVELOPER":
                    {
                        JobOpenings = new string[] { ".Net", "Java", "Python", "VB", "Typescript", "Angular" };
                        break;
                    }
                case "LEAD":
                    {
                        JobOpenings = new string[] { "Team Lead", "Dept Lead" };
                        break;
                    }
                case "MANAGER":
                    {
                        JobOpenings = new string[] { "Dept Manager", "Branch Manager" };
                        break;
                    }
                default:
                    {
                        JobOpenings = new string[] { "No Job Opening for your Role" };
                        break;
                    }
            }
            return JobOpenings;
        }

    }
}
