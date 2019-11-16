using EmployeeApp.Data;
using EmployeeApp.Data.Models;
using EmployeeApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Services
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationDbContext db) : base(db)
        {

        }
    }
}
