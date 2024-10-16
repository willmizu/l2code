using AutoMoqCore;
using Bogus;
using L2code.Domain.Models;
using L2code.Domain.Request;
using Xunit;

namespace L2code.Application.Tests
{
    #region CollectionDefinition

    [CollectionDefinition(nameof(AuthenticationServiceCollection))]
    public class AuthenticationServiceCollection : ICollectionFixture<FixtureService>
    { }

    [CollectionDefinition(nameof(ProcessOrderServiceCollection))]
    public class ProcessOrderServiceCollection : ICollectionFixture<FixtureService>
    { }

    #endregion CollectionDefinition

    public class FixtureService : IDisposable
    {
        public ProcessOrderService GetProcessOrderService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<ProcessOrderService>();

            var service = mocker.Resolve<ProcessOrderService>();

            return service;
        }

        public AuthenticationService GetAuthenticationService()
        {
            var mocker = new AutoMoqer();
            mocker.Create<AuthenticationService>();

            var service = mocker.Resolve<AuthenticationService>();

            return service;
        }

        public OrderRequest CreateOrderRequest()
        {
            return new Faker<OrderRequest>()
                .CustomInstantiator(f => new OrderRequest
                {
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            OrderId = 1,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "PS5", Measures = new Measures { Height = 40, Width = 10, Length = 25 } },
                                new Product { ProductId = "Volante", Measures = new Measures { Height = 40, Width = 30, Length = 30 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 2,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "JoyStick", Measures = new Measures { Height = 15, Width = 20, Length = 10 } },
                                new Product { ProductId = "Fifa 24", Measures = new Measures { Height = 10, Width = 30, Length = 10 } },
                                new Product { ProductId = "Call of duty", Measures = new Measures { Height = 30, Width = 15, Length = 10 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 3,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Headset", Measures = new Measures { Height = 25, Width = 15, Length = 20 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 4,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Mouse Gamer", Measures = new Measures { Height = 5, Width = 8, Length = 12 } },
                                new Product { ProductId = "Teclado Mecanico", Measures = new Measures { Height = 4, Width = 45, Length = 15 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 5,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Cadeira gamer", Measures = new Measures { Height = 120, Width = 60, Length = 70 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 6,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Mesa Gamer", Measures = new Measures { Height = 47, Width = 60, Length = 80 } },
                                new Product { ProductId = "Webcam", Measures = new Measures { Height = 17, Width = 10, Length = 5 } },
                                new Product { ProductId = "Microfone", Measures = new Measures { Height = 25, Width = 10, Length = 10 } },
                                new Product { ProductId = "Monitor", Measures = new Measures { Height = 50, Width = 60, Length = 20 } },
                                new Product { ProductId = "Notebook", Measures = new Measures { Height = 2, Width = 35, Length = 25 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 7,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Jogo de Cabos", Measures = new Measures { Height = 5, Width = 15, Length = 10 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 8,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Controle xbox", Measures = new Measures { Height = 10, Width = 15, Length = 10 } },
                                new Product { ProductId = "Carregador", Measures = new Measures { Height = 3, Width = 8, Length = 8 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 9,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Tablet", Measures = new Measures { Height = 1, Width = 25, Length = 17 } }
                            }
                        },
                        new Order
                        {
                            OrderId = 10,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "HD Externo", Measures = new Measures { Height = 2, Width = 8, Length = 12 } },
                                new Product { ProductId = "Pendrive", Measures = new Measures { Height = 1, Width = 2, Length = 5 } }
                            }
                        }
                    }
                });
        }

        public OrderRequest CreateOrderRequestProductNotFitInAvailableBoxes()
        {
            return new Faker<OrderRequest>()
                .CustomInstantiator(f => new OrderRequest
                {
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            OrderId = 5,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Cadeira gamer", Measures = new Measures { Height = 120, Width = 60, Length = 70 } }
                            }
                        },
                    }
                });
        }

        public OrderRequest CreateOrderRequestOrderInTwoBoxes()
        {
            return new Faker<OrderRequest>()
                .CustomInstantiator(f => new OrderRequest
                {
                    Orders = new List<Order>
                    {
                        new Order
                        {
                            OrderId = 6,
                            Products = new List<Product>
                            {
                                new Product { ProductId = "Mesa Gamer", Measures = new Measures { Height = 47, Width = 60, Length = 80 } },
                                new Product { ProductId = "Webcam", Measures = new Measures { Height = 17, Width = 10, Length = 5 } },
                                new Product { ProductId = "Microfone", Measures = new Measures { Height = 25, Width = 10, Length = 10 } },
                                new Product { ProductId = "Monitor", Measures = new Measures { Height = 50, Width = 60, Length = 20 } },
                                new Product { ProductId = "Notebook", Measures = new Measures { Height = 2, Width = 35, Length = 25 } }
                            }
                        },
                    }
                });
        }

        public User GenerateUser()
        {
            return new Faker<User>()
                .CustomInstantiator(f => new User
                {
                    Username = "l2code",
                    Password = "l2code"
                });
        }

        public User GenerateUserfail()
        {
            return new Faker<User>()
                .CustomInstantiator(f => new User
                {
                    Username = "nonexistentuser",
                    Password = "passwordFail"
                });
        }

        public void Dispose()
        {
        }
    }
}