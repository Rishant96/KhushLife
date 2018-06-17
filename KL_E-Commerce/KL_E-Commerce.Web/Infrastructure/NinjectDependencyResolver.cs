using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KL_E_Commerce.Domain.Entities;
using KL_E_Commerce.Domain.Abstract;
using Moq;
using Ninject;

namespace KL_E_Commerce.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
            
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Vendor vendor = new Vendor { Id = "Mock Vendor" };
            Store store = new Store { Id = 1, VendorId = "Mock Vendor", Vendor = vendor };

            var cat1 = new Category("Electronics") {
                Id = 1,
                Attributes = new List<Domain.Entities.Utilities.Attribute>
                {
                    new Domain.Entities.Utilities.Attribute() { Id = 1, Name = "Platform", CategoryId = 1 },
                }
            };

            var cat2 = new Category("Apparels")
            {
                Id = 2,
                Attributes = new List<Domain.Entities.Utilities.Attribute>
                {
                    new Domain.Entities.Utilities.Attribute() { Id = 2, Name = "Style", CategoryId = 2 },
                }
            };

            var cat3 = new Category("Smartphones")
            {
                Id = 3,
                Attributes = new List<Domain.Entities.Utilities.Attribute>
                {
                    new Domain.Entities.Utilities.Attribute() { Id = 3, Name = "Screen Size", CategoryId = 3 },
                    new Domain.Entities.Utilities.Attribute() { Id = 4, Name = "Battery Size", CategoryId = 3 },
                    new Domain.Entities.Utilities.Attribute() { Id = 5, Name = "SoC", CategoryId = 3 },
                }
            };

            var cat4 = new Category("Laptops")
            {
                Id = 4,
                Attributes = new List<Domain.Entities.Utilities.Attribute>
                {
                    new Domain.Entities.Utilities.Attribute() { Id = 6, Name = "CPU", CategoryId = 4 },
                    new Domain.Entities.Utilities.Attribute() { Id = 7, Name = "GPU", CategoryId = 4 },
                    new Domain.Entities.Utilities.Attribute() { Id = 8, Name = "RAM", CategoryId = 4 },
                    new Domain.Entities.Utilities.Attribute() { Id = 9, Name = "Storage", CategoryId = 4 },
                }
            };

            IEnumerable<Category> categories = new Category[] {
                cat1, cat2, cat3, cat4,
            };

            var prod1 = new Product("Samsung A5 2017", 3)
            {
                Id = 1,
                StockedStores = new Domain.Entities.Utilities.StockedInStore[]
                    {
                        new Domain.Entities.Utilities.StockedInStore
                        {
                            Id = 1,
                            ProductId = 1,
                            StoreId = 1,
                            Stock = 10,
                            VendorId = "Mock Vendor",
                            Status = Domain.Entities.Utilities.ProductStatus.InStock,
                            Price = 149.50f,
                        },
                    },
            };
            prod1.setSpecifications(new List<Domain.Entities.Utilities.Specification>
            {
                new Domain.Entities.Utilities.Specification
                {
                    Id = 1,
                    ProductId = 1,
                    IsVariable = false,
                    SpecOptions = new List<Domain.Entities.Utilities.SpecOption>
                    {
                        new Domain.Entities.Utilities.SpecOption
                        {
                            Id = 1,
                            Name = "Android",
                            IsSelected = true,
                            SpecificationId = 1,
                            Value = "Android",
                        }
                    }
                },
                new Domain.Entities.Utilities.Specification
                {
                    Id = 2,
                    ProductId = 1,
                    IsVariable = false,
                    SpecOptions = new List<Domain.Entities.Utilities.SpecOption>
                    {
                        new Domain.Entities.Utilities.SpecOption
                        {
                            Id = 2,
                            Name = "5.2 Inches",
                            IsSelected = true,
                            SpecificationId = 2,
                            Value = 5.2f,
                        }
                    }
                },
                new Domain.Entities.Utilities.Specification
                {
                    Id = 3,
                    ProductId = 1,
                    IsVariable = false,
                    SpecOptions = new List<Domain.Entities.Utilities.SpecOption>
                    {
                        new Domain.Entities.Utilities.SpecOption
                        {
                            Id = 3,
                            Name = "3000 mAH",
                            IsSelected = true,
                            SpecificationId = 3,
                            Value = 3000,
                        }
                    }
                },
                new Domain.Entities.Utilities.Specification
                {
                    Id = 4,
                    ProductId = 1,
                    IsVariable = false,
                    SpecOptions = new List<Domain.Entities.Utilities.SpecOption>
                    {
                        new Domain.Entities.Utilities.SpecOption
                        {
                            Id = 4,
                            Name = "Exynos 7880",
                            IsSelected = true,
                            SpecificationId = 4,
                            Value = "Exynos_7880",
                        }
                    }
                },
            });

            var prod2 = new Product("Razer Blade 15 2018", 4)
            {
                Id = 2,
                StockedStores = new Domain.Entities.Utilities.StockedInStore[]
                    {
                        new Domain.Entities.Utilities.StockedInStore
                        {
                            Id = 2,
                            ProductId = 2,
                            StoreId = 1,
                            Stock = 15,
                            VendorId = "Mock Vendor",
                            Status = Domain.Entities.Utilities.ProductStatus.InStock,
                            Price = 2499.50f,
                        },
                    },
            };
            prod2.setSpecifications(
                new List<Domain.Entities.Utilities.Specification>
                {
                    new Domain.Entities.Utilities.Specification
                    {
                        Id = 5,
                        IsVariable = false,
                        ProductId = 2,
                        SpecOptions = new List<Domain.Entities.Utilities.SpecOption>
                        {
                            new Domain.Entities.Utilities.SpecOption
                            {
                                Id = 5,
                                IsSelected = true,
                                SpecificationId = 5,
                                Name = "Windows 10",
                                Value = "Windows_10_RS4"
                            },
                        }
                    },
                    new Domain.Entities.Utilities.Specification
                    {
                        Id = 6,
                        IsVariable = true,

                    },
                    new Domain.Entities.Utilities.Specification
                    {

                    },
                    new Domain.Entities.Utilities.Specification
                    {

                    },
                    new Domain.Entities.Utilities.Specification
                    {

                    },

                }
            );

            List<Product> products = new List<Product>
            {
                
            };

            Cart cart = new Cart {
                Id = 1,
                CartItems = new List<Domain.Entities.Utilities.CartItem>(),
                Status = CartStatus.Empty,
            };

            Mock<IDataProvider> mock = new Mock<IDataProvider>();
            mock.Setup(m => m.Vendor).Returns(vendor);
            mock.Setup(m => m.Store).Returns(store);
            mock.Setup(m => m.Categories).Returns(categories);
            mock.Setup(m => m.Products).Returns(products);
            mock.Setup(m => m.Cart).Returns(cart);
        }
    }
}