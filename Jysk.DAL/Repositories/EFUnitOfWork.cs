using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jysk.DAL.EF;
using Jysk.DAL.Entities;
using Jysk.DAL.Interfaces;

namespace Jysk.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private JyskContext db;
        private CargoRepository cargoRepository;
        private CategoryRepository categoryRepository;
        private ClientRepository clientRepository;
        private DeliveryRepository deliveryRepository;
        private EmployeeRepository employeeRepository;
        private ManufacturerRepository manufacturerRepository;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private ReviewRepository reviewRepository;
        private StorageRepository storageRepository;
        private StoreRepository storeRepository;
        private SupplyRepository supplyRepository;
        private UserRepository userRepository;
        private WorkHoursRepository workHoursRepository;
        private WriteOffRepository writeOffRepository;

        public EFUnitOfWork(JyskContext context)
        {
            db = context;
        }

        public IRepository<Cargo> R_Cargo
        {
            get
            {
                if (cargoRepository == null)
                {
                    cargoRepository = new CargoRepository(db);
                }
                return cargoRepository;
            }
        }
        public IRepository<Category> R_Category
        {
            get
            {
                if (categoryRepository == null)
                {
                    categoryRepository = new CategoryRepository(db);
                }
                return categoryRepository;
            }
        }
        public IRepository<Client> R_Client
        {
            get
            {
                if(clientRepository == null)
                {
                    clientRepository = new ClientRepository(db);
                }
                return clientRepository;
            }
        }
        public IRepository<Delivery> R_Delivery
        {
            get
            {
                if(deliveryRepository == null)
                {
                    deliveryRepository = new DeliveryRepository(db);
                }
                return deliveryRepository;
            }
        }
        public IRepository<Employee> R_Employee
        {
            get
            {
                if(employeeRepository == null)
                {
                    employeeRepository = new EmployeeRepository(db);
                }
                return employeeRepository;
            }
        }
        public IRepository<Manufacturer> R_Manufacturer
        {
            get
            {
                if(manufacturerRepository == null)
                {
                    manufacturerRepository = new ManufacturerRepository(db);
                }
                return manufacturerRepository;
            }
        }
        public IRepository<Order> R_Order
        {
            get
            {
                if(orderRepository == null)
                {
                    orderRepository = new OrderRepository(db);
                }
                return orderRepository;
            }
        }
        public IRepository<Product> R_Product
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(db);
                }
                return productRepository;
            }
        }
        public IRepository<Review> R_Review
        {
            get
            {
                if(reviewRepository == null)
                {
                    reviewRepository = new ReviewRepository(db);
                }
                return reviewRepository;
            }
        }
        public IRepository<Storage> R_Storage
        {
            get
            {
                if(storageRepository == null)
                {
                    storageRepository = new StorageRepository(db);
                }
                return storageRepository;
            }
        }
        public IRepository<Store> R_Store
        {
            get
            {
                if(storeRepository == null)
                {
                    storeRepository = new StoreRepository(db);
                }
                return storeRepository;
            }
        }
        public IRepository<Supply> R_Supply
        {
            get
            {
                if(supplyRepository == null)
                {
                    supplyRepository = new SupplyRepository(db);
                }
                return supplyRepository;
            }
        }
        public IRepository<User> R_User
        {
            get
            {
                if(userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }
        public IRepository<WorkHours> R_WorkHours
        {
            get
            {
                if (workHoursRepository == null)
                {
                    workHoursRepository = new WorkHoursRepository(db);
                }
                return workHoursRepository;
            }
        }
        public IRepository<WriteOff> R_WriteOff
        {
            get
            {
                if(writeOffRepository == null)
                {
                    writeOffRepository = new WriteOffRepository(db);
                }
                return writeOffRepository;
            }
        }
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}
