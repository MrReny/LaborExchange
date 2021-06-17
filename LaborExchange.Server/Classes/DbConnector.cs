﻿using System;
using System.Linq;
using FirebirdSql.Data.FirebirdClient;
using LaborExchange.Commons;
using LaborExchange.DataBaseModel;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace LaborExchange.Server
{
    public class DbConnector
    {
        /// <summary>
        ///  Логгер.
        /// </summary>
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        //TODO НОЛЬ БЕЗОПАСНОСТИ
        private LaborExchangeDbContext _dbContext=> new LaborExchangeDbContext(
            new DbContextOptionsBuilder<LaborExchangeDbContext>()
                .UseFirebird(new FbConnection("ServerType=0;User=SYSDBA;" +
                                              "Password=masterkey;" +
                                              "DataSource=localhost;" +
                                              "Database=C:/Programming/DB/LABOREXCHANGE.FDB")).Options);
        private static DbConnector _instance;
        public static DbConnector Instance => _instance ??= new DbConnector();

        public DbConnector()
        {

        }

        public DbConnector Init()
        {
            return Instance;
        }

        public User GetUser(string login, string password)
        {
            try
            {
                using (_dbContext)
                    return _dbContext.USERS
                        .Include(u => u.Employee)
                        .ThenInclude(e => e.PASSPORT)
                        .Include(u => u.Employer)
                        .ThenInclude(e => e.Jobs)
                        .Where(u => u.LOGIN == login && u.PASSWORD == password)
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
            catch (Exception e)
            {
                _logger.Error(e);
                return null;
            }
        }

        public bool AddUser(User user)
        {
            //TODO Password is insecure
            try
            {
                using (_dbContext)
                {
                    var u = _dbContext.USERS.Add(new USER()
                    {
                        EMAIL = user.Email,
                        ID = user.UserId,
                        LOGIN = user.Login,
                        PASSWORD = user.Password
                    });
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Employee[] GetEmployees()
        {
            try
            {
                using (_dbContext)
                    return _dbContext.EMPLOYEES
                        .Include(e => e.PASSPORT)
                        .Select(e => e.ToTransportType())
                        .ToArray();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return Array.Empty<Employee>();
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                using (_dbContext)
                    _dbContext.EMPLOYEES.Add(EMPLOYEE.FromTransportType(employee));
            }
            catch (Exception e)
            {
                _logger.Error(e);
                //TODO Logging
            }
        }

        public void AddEmployer(Employer employer)
        {
            try
            {
                var e = EMPLOYER.FromTransportType(employer);
                using (_dbContext)
                    _dbContext.EMPLOYERS.Add(e);
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public Job[] GetJobs()
        {
            try
            {
                using (_dbContext)
                    return _dbContext.JOB_VACANCIES
                        .Include(j => j.EMPLOYER)
                        .Where(j => j.SATISFIED == 0)
                        .Select(j => j.ToTransportType())
                        .ToArray();
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return Array.Empty<Job>();
            }
        }

        public void AddJobs(Job job)
        {
            try
            {
                using (_dbContext)
                    _dbContext.Add(JOB_VACANCY.FromTransportType(job));
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }
        }

        public JobOffer[] FindOffers(int employeeId, int jobId)
        {
            try
            {
                using (_dbContext)
                {
                    if (employeeId != 0)
                        return _dbContext.JOB_OFFERS
                            .Where((j) => j.EMPLOYEE_ID == employeeId)
                            .Select(j => j.ToTransportType())
                            .ToArray();
                    if (jobId != 0)
                        return _dbContext.JOB_OFFERS
                            .Where((j) => j.JOB_ID == jobId)
                            .Select(j => j.ToTransportType())
                            .ToArray();

                    return _dbContext.JOB_OFFERS
                        .Select(j => j.ToTransportType())
                        .ToArray();
                }

            }
            catch (Exception e)
            {
                _logger.Error(e);
                return Array.Empty<JobOffer>();
            }
        }

        public bool AddOffer(JobOffer offer)
        {
            try
            {
                using (_dbContext)
                {
                    var id = _dbContext.JOB_OFFERS.Last().ID + 1;
                    offer.Id = id;
                    _dbContext.JOB_OFFERS.Add(JOB_OFFER.FromTransportType(offer));
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }


        public bool FinishOffer(JobOffer offer)
        {
            try
            {
                using (_dbContext)
                {
                    _dbContext.JOB_OFFERS.Update(JOB_OFFER.FromTransportType(offer));
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e);
                return false;
            }
        }
    }
}