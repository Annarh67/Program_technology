using System;

namespace dzz1
{
    /// <summary>
    /// Класс описывает менеджера автосалона
    /// </summary>
    public class Manager
    {
        
        public int Id { get; set; }

        
        public string FullName { get; set; }

        
        public string Phone { get; set; }

       
        public int Experience { get; set; }

      
        public bool IsExperienced
        {
            get
            {
                return Experience > 3;
            }
        }

        /// <summary>
        /// Возвращает краткую информацию о менеджере
        /// </summary>
        public string GetInfo()
        {
            
            return FullName + " (" + Experience + " лет опыта)";
        }
    }
}