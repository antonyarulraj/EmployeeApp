using EmployeeApp.Data;
using EmployeeApp.Services;
using EmployeeApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Middleware
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _dbContext;
        private IEmployeeRepository _employee;
        private IAddressRepository _address;

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_dbContext);
                }

                return _employee;
            }
        }

        public IAddressRepository Address
        {
            get
            {
                if (_address == null)
                {
                    _address = new AddressRepository(_dbContext);
                }

                return _address;
            }
        }

        public RepositoryWrapper(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
