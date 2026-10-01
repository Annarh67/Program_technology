using dzz1;
using System;
using System.Collections.Generic;

namespace dzz1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Brand> brands;
            List<Manager> managers;
            List<Car> cars;

         
            Console.WriteLine("Выберите источник данных:");
            Console.WriteLine("1 - InMemoryRepository");
            Console.WriteLine("2 - CsvRepository");

            string choice = Console.ReadLine();

           
            switch (choice)
            {
                case "1":
                  
                    InMemoryRepository memoryRepository =
                        new InMemoryRepository();

                    brands = memoryRepository.GetBrands();
                    managers = memoryRepository.GetManagers();
                    cars = memoryRepository.GetCars();

                    Console.WriteLine();
                    Console.WriteLine(
                        "Выбран источник: InMemoryRepository");
                    break;

                case "2":
                   
                    CsvRepository csvRepository =
                        new CsvRepository("data");

                    brands = csvRepository.GetBrands();
                    managers = csvRepository.GetManagers();
                    cars = csvRepository.GetCars();

                    Console.WriteLine();
                    Console.WriteLine(
                        "Выбран источник: CsvRepository");
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    return;
            }

            Console.WriteLine();

            
            
          

            Manager? foundManager =
                FindManager("Camry", cars, managers);

            if (foundManager != null)
            {
                Console.WriteLine(
                    "1. FindManager(\"Camry\"): "
                    + foundManager.GetInfo());
            }
            else
            {
                Console.WriteLine(
                    "1. FindManager(\"Camry\"): null");
            }


           
            Car? foundCar = null;

            foreach (Car car in cars)
            {
                if (car.Model == "Camry")
                {
                    foundCar = car;
                    break;
                }
            }

            if (foundCar != null)
            {
                Brand? foundBrand =
                    FindBrand(foundCar, brands);

                if (foundBrand != null)
                {
                    Console.WriteLine(
                        "2. FindBrand(car \"Camry\"): "
                        + foundBrand.GetInfo());
                }
                else
                {
                    Console.WriteLine(
                        "2. FindBrand(car \"Camry\"): null");
                }
            }
            else
            {
                Console.WriteLine(
                    "2. FindBrand(car \"Camry\"): null");
            }
            
            decimal totalPrice =
                GetTotalPrice(cars);

            Console.WriteLine(
                "3. GetTotalPrice: "
                + totalPrice
                + " руб.");

          

            List<Car> toyotaCars =
                GetCarsByBrandSortedByPrice(
                    "Toyota",
                    brands,
                    cars);

            Console.Write(
                "4. GetCarsByBrandSortedByPrice(\"Toyota\"): ");

            for (int i = 0; i < toyotaCars.Count; i++)
            {
                Console.Write(
                    toyotaCars[i].Model
                    + " ("
                    + toyotaCars[i].Price
                    + ")");

               
                if (i < toyotaCars.Count - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
           
            Console.WriteLine("5. PrintAllCars:");

            PrintAllCars(
                cars,
                brands,
                managers);

            Console.WriteLine();      
           

            Manager? unknownManager =
                FindManager(
                    "Неизвестная модель",
                    cars,
                    managers);

            if (unknownManager == null)
            {
                Console.WriteLine(
                    "Не найдено: FindManager(\"Неизвестная модель\") -> null");
            }
            else
            {
                Console.WriteLine(
                    unknownManager.GetInfo());
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Ищет менеджера автомобиля по модели автомобиля
        /// Если автомобиль или менеджер не найден,
        /// возвращает null.
        /// </summary>
        static Manager? FindManager(
            string carModel,
            List<Car> cars,
            List<Manager> managers)
        {
          
            Car? foundCar = null;

            foreach (Car car in cars)
            {
                if (car.Model == carModel)
                {
                    foundCar = car;
                    break;
                }
            }

          
            if (foundCar == null)
            {
                return null;
            }

           
            foreach (Manager manager in managers)
            {
                if (manager.Id == foundCar.ManagerId)
                {
                    return manager;
                }
            }

          
            return null;
        }

        /// <summary>
        /// Ищет бренд указанного автомобиля
        /// Если бренд не найден, возвращает null
        /// </summary>
        static Brand? FindBrand(
            Car car,
            List<Brand> brands)
        {
           
            foreach (Brand brand in brands)
            {
                if (brand.Id == car.BrandId)
                {
                    return brand;
                }
            }

           
            return null;
        }

        /// <summary>
        /// Вычисляет общую стоимость всех автомобилей
        /// Если список пустой, возвращает 0
        /// </summary>
        static decimal GetTotalPrice(
            List<Car> cars)
        {
            
            decimal totalPrice = 0;
            foreach (Car car in cars)
            {
                totalPrice =
                    totalPrice + car.Price;
            }

            return totalPrice;
        }

        /// <summary>
        /// Возвращает автомобили указанного бренда
        /// отсортированные по цене по возрастанию
        /// </summary>
        static List<Car> GetCarsByBrandSortedByPrice(
            string brandName,
            List<Brand> brands,
            List<Car> cars)
        {
            int brandId = -1;

            foreach (Brand brand in brands)
            {
                if (brand.Name == brandName)
                {
                    brandId = brand.Id;
                    break;
                }
            }

            List<Car> result =
                new List<Car>();

            
        
            if (brandId == -1)
            {
                return result;
            }

            
            foreach (Car car in cars)
            {
                if (car.BrandId == brandId)
                {
                    result.Add(car);
                }
            }

           
            for (int i = 0;
                 i < result.Count - 1;
                 i++)
            {
                for (int j = 0;
                     j < result.Count - 1 - i;
                     j++)
                {
                    if (result[j].Price
                        > result[j + 1].Price)
                    {
                        
                        Car temp = result[j];

                        result[j] = result[j + 1];

                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Выводит все автомобили вместе
        /// с менеджером и брендом автомобиля
        static void PrintAllCars(
            List<Car> cars,
            List<Brand> brands,
            List<Manager> managers)
        {
            
            foreach (Car car in cars)
            {
                
                Brand? brand =
                    FindBrand(car, brands);

                
                Manager? manager = null;

                
                foreach (Manager currentManager
                         in managers)
                {
                    if (currentManager.Id
                        == car.ManagerId)
                    {
                        manager =
                            currentManager;

                        break;
                    }
                }

                
                string managerName = "-";
                string brandName = "-";

                if (manager != null)
                {
                    managerName =
                        manager.FullName;
                }

                if (brand != null)
                {
                    brandName =
                        brand.Name;
                }

                
                Console.WriteLine(
                    "\""
                    + car.GetInfo()
                    + "\" — менеджер "
                    + managerName
                    + ", бренд \""
                    + brandName
                    + "\"");
            }
        }
    }
}