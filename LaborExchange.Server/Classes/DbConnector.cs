﻿using System;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using LaborExchange.Commons;
using Microsoft.EntityFrameworkCore;

namespace LaborExchange.Server
{
    public class DbConnector
    {
        private LaborExchangeDbContext _dbContext;
        private static DbConnector _instance;
        public static DbConnector Instance => _instance ??= new DbConnector();

        public DbConnector()
        {
            _dbContext = new LaborExchangeDbContext(
                new DbContextOptionsBuilder<LaborExchangeDbContext>()
                    .UseFirebird(new FbConnection("ServerType=0;User=SYSDBA;Password=masterkey;DataSource=localhost;Database=C:/Programming/DB/LABOREXCHANGE.FDB")).Options);
        }

        public DbConnector Init()
        {
            return Instance;
        }

        public User GetUser(string login, string password)
        {
            return _dbContext.USERS.Where(u => u.LOGIN == login && u.PASSWORD == password)
                .Select(
                    u =>
                        new User()
                        {
                            Login = u.LOGIN,
                            Password = u.PASSWORD,
                            Email = u.EMAIL,
                            UserId = u.ID,
                            UserType = (UserType) u.USER_TYPE
                        }).FirstOrDefault();
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