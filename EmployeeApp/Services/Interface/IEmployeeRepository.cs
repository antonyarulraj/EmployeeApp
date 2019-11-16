using EmployeeApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services.Interface
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
    }
}
