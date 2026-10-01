using dzz1;
using System;
using System.Collections.Generic;

namespace dzz1
{
    /// <summary>
    /// Репозиторий хранит тестовые данные в памяти программы
    /// </summary>
    public class InMemoryRepository
    {
        
        private List<Brand> _brands;

        
        private List<Manager> _managers;

       
        private List<Car> _cars;

        /// <summary>
        /// Конструктор заполняет репозиторий тестовыми данными
        /// </summary>
        public InMemoryRepository()
        {
           
            _brands = new List<Brand>
            {
                new Brand
                {
                    Id = 1,
                    Name = "Toyota",
                    Country = "Япония"
                },

                new Brand
                {
                    Id = 2,
                    Name = "BMW",
                    Country = "Германия"
                },

                new Brand
                {
                    Id = 3,
                    Name = "Lada",
                    Country = "Россия"
                },

                new Brand
                {
                    Id = 4,
                    Name = "Kia",
                    Country = "Южная Корея"
                },

                new Brand
                {
                    Id = 5,
                    Name = "Ford",
                    Country = "США"
                }
            };

            
            _managers = new List<Manager>
            {
                new Manager
                {
                    Id = 1,
                    FullName = "Петров П.П.",
                    Phone = "+7 900 111-11-11",
                    Experience = 5
                },

                new Manager
                {
                    Id = 2,
                    FullName = "Иванов И.И.",
                    Phone = "+7 900 222-22-22",
                    Experience = 2
                },

                new Manager
                {
                    Id = 3,
                    FullName = "Сидоров С.С.",
                    Phone = "+7 900 333-33-33",
                    Experience = 4
                },

                new Manager
                {
                    Id = 4,
                    FullName = "Смирнов А.А.",
                    Phone = "+7 900 444-44-44",
                    Experience = 1
                },

                new Manager
                {
                    Id = 5,
                    FullName = "Кузнецов К.К.",
                    Phone = "+7 900 555-55-55",
                    Experience = 7
                }
            };

           
            _cars = new List<Car>
            {
                new Car
                {
                    Id = 1,
                    Model = "Camry",
                    BrandId = 1,
                    ManagerId = 1,
                    Price = 3000000m,
                    Year = 2023
                },

                new Car
                {
                    Id = 2,
                    Model = "Corolla",
                    BrandId = 1,
                    ManagerId = 2,
                    Price = 2000000m,
                    Year = 2023
                },

                new Car
                {
                    Id = 3,
                    Model = "X5",
                    BrandId = 2,
                    ManagerId = 3,
                    Price = 7500000m,
                    Year = 2022
                },

                new Car
                {
                    Id = 4,
                    Model = "Vesta",
                    BrandId = 3,
                    ManagerId = 4,
                    Price = 1800000m,
                    Year = 2024
                },

                new Car
                {
                    Id = 5,
                    Model = "Sportage",
                    BrandId = 4,
                    ManagerId = 5,
                    Price = 3500000m,
                    Year = 2021
                }
            };
        }

        /// <summary>
        /// Возвращает список брендов
        /// </summary>
        public List<Brand> GetBrands()
        {
            return _brands;
        }

        /// <summary>
        /// Возвращает список менеджеров
        /// </summary>
        public List<Manager> GetManagers()
        {
            return _managers;
        }

        /// <summary>
        /// Возвращает список автомобилей
        /// </summary>
        public List<Car> GetCars()
        {
            return _cars;
        }
    }
}