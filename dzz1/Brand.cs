using System;

namespace dzz1
{
    /// <summary>
    /// Класс описывает бренд автомобиля
    /// </summary>
    public class Brand
    {
        
        public int Id { get; set; }

       
        public string Name { get; set; }

        public string Country { get; set; }

        
        public bool IsForeign
        {
            get
            {
                return Country != "Россия";
            }
        }

        /// <summary>
        /// Возвращает краткую информацию о бренде
        /// </summary>
        public string GetInfo()
        {
            return Name + " (" + Country + ")";
        }
    }
}