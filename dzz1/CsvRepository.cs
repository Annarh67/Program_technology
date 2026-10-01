using dzz1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace dzz1
{
    /// <summary>
    /// Репозиторий загружает данные из CSV-файлов
    /// </summary>
    public class CsvRepository
    {
       
        private string _basePath;

        /// <summary>
        /// Конструктор получает путь к папке с CSV-файлами
        /// </summary>
        public CsvRepository(string basePath)
        {
            _basePath = basePath;
        }

        /// <summary>
        /// Загружает список брендов из файла brands.csv
        /// </summary>
        public List<Brand> GetBrands()
        {
           
            List<Brand> brands = new List<Brand>();

            string filePath = Path.Combine(_basePath, "brands.csv");

        
            string[] lines = File.ReadAllLines(
                filePath,
                Encoding.UTF8);

           
            if (lines.Length < 2)
            {
                return brands;
            }

            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Length == 0)
                {
                    continue;
                }

                
                string[] parts = lines[i].Split(',');

               
                if (parts.Length < 3)
                {
                    continue;
                }

                
                Brand brand = new Brand
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Country = parts[2]
                };

               
                brands.Add(brand);
            }

            return brands;
        }

        /// <summary>
        /// Загружает список менеджеров из файла managers.csv
        /// </summary>
        public List<Manager> GetManagers()
        {
            
            List<Manager> managers = new List<Manager>();

           
            string filePath = Path.Combine(_basePath, "managers.csv");

           
            string[] lines = File.ReadAllLines(
                filePath,
                Encoding.UTF8);

            
            if (lines.Length < 2)
            {
                return managers;
            }

            
            for (int i = 1; i < lines.Length; i++)
            {
                if (lines[i].Length == 0)
                {
                    continue;
                }

                
                string[] parts = lines[i].Split(',');

                
                if (parts.Length < 4)
                {
                    continue;
                }

                
                Manager manager = new Manager
                {
                    Id = int.Parse(parts[0]),
                    FullName = parts[1],
                    Phone = parts[2],
                    Experience = int.Parse(parts[3])
                };

               
                managers.Add(manager);
            }

            return managers;
        }

        /// <summary>
        /// Загружает список автомобилей из файла cars.csv
        /// </summary>
        public List<Car> GetCars()
        {
            
            List<Car> cars = new List<Car>();

            
            string filePath = Path.Combine(_basePath, "cars.csv");

            
            string[] lines = File.ReadAllLines(
                filePath,
                Encoding.UTF8);

            
            if (lines.Length < 2)
            {
                return cars;
            }

            
            for (int i = 1; i < lines.Length; i++)
            {
               
                if (lines[i].Length == 0)
                {
                    continue;
                }

               
                string[] parts = lines[i].Split(',');

                
                if (parts.Length < 6)
                {
                    continue;
                }

               
                Car car = new Car
                {
                    Id = int.Parse(parts[0]),
                    Model = parts[1],
                    BrandId = int.Parse(parts[2]),
                    ManagerId = int.Parse(parts[3]),
                    Price = decimal.Parse(parts[4]),
                    Year = int.Parse(parts[5])
                };

                
                cars.Add(car);
            }

            return cars;
        }
    }
}