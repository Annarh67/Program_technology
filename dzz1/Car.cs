using System;

namespace dzz1
{
    /// <summary>
    /// Класс описывает автомобиль
    /// </summary>
    public class Car
    {
      
        public int Id { get; set; }

        
        public string Model { get; set; }

        public int BrandId { get; set; }

        
        public int ManagerId { get; set; }

        public decimal Price { get; set; }

       
        public int Year { get; set; }


        public bool IsNew
        {
            get
            {
                return Year >= 2023;
            }
        }

        /// <summary>
        /// Рассчитывает стоимость автомобиля с учетом амортизации
        /// Каждый год стоимость уменьшается на 10%
        /// </summary>
        public decimal GetDepreciation(int years)
        {
            if (years <= 0)
            {
                return Price;
            }

           
            if (years > 10)
            {
                return 0;
            }

            return Price * (1 - 0.1m * years);
        }

        /// <summary>
        /// Возвращает краткую информацию об автомобиле
        /// </summary>
        public string GetInfo()
        {
            
            return Model + " (" + Year + ", " + Price + " руб.)";
        }
    }
}