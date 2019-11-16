using EmployeeApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Middleware
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employee { get; }
        IAddressRepository Address { get; }
        void Save();
    }
}
