using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.Entities;

namespace Jysk.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Cargo> R_Cargo { get; }
        IRepository<Category> R_Category { get; }
        IRepository<Client> R_Client { get; }
        IRepository<Delivery> R_Delivery { get; }
        IRepository<Employee> R_Employee { get; }
        IRepository<Manufacturer> R_Manufacturer { get; }
        IRepository<Order> R_Order { get; }
        IRepository<Product> R_Product { get; }
        IRepository<Review> R_Review { get; }
        IRepository<Storage> R_Storage { get; }
        IRepository<Store> R_Store { get; }
        IRepository<Supply> R_Supply { get; }
        IRepository<User> R_User { get; }
        IRepository<WorkHours> R_WorkHours { get; }
        IRepository<WriteOff> R_WriteOff { get; }

        Task Save();
    }
}
