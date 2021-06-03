using System;
using LaborExchange.Commons;

namespace LaborExchange.Server
{
    public class DbConnector
    {
        private static DbConnector _instance;
        public static DbConnector Instance => _instance ??= new DbConnector();

        public User GetUser(string login, string password)
        {
            throw new InvalidOperationException();
        }

        public bool AddUser(User user)
        {
            throw new InvalidOperationException();
        }

        public Employee[] GetEmployees()
        {
            throw new InvalidOperationException();
        }

        public void AddEmployee(Employee employee)
        {
            throw new InvalidOperationException();
        }

        public void AddEmployer(Employer employer)
        {
            throw new InvalidOperationException();
        }

        public Job[] GetJobs()
        {
            throw new InvalidOperationException();
        }

        public void AddJobs(Job employee)
        {
            throw new InvalidOperationException();
        }

        public bool AddOffer(JobOffer offer)
        {
            throw new InvalidOperationException();
        }

        public JobOffer[] FindOffers(int employeeId, int jobId)
        {
            throw new InvalidOperationException();
        }

        public bool FinishOffer(JobOffer offer)
        {
            throw new InvalidOperationException();
        }
    }
}