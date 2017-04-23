using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Vacance
    {
        private int id;
        private string designation;
        private DateTime date;

        

        public Vacance(int id , string designation,DateTime date)
        {
            this.Id = id;
            this.Designation = designation;
            this.Date = date;  
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Designation
        {
            get
            {
                return designation;
            }

            set
            {
                designation = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }
}
