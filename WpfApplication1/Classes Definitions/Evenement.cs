using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Evenement
    {
        private int id;
        private string designation;
        private string priorite;
        private DateTime date;
        private string lieu;
        private Document document;

        public Evenement(int id, string designation,string priorite, DateTime date, string lieu)
        {
            this.Id = id;
            this.Designation = designation;
            this.Priorite = priorite;
            this.Date = date;
            this.Lieu = lieu;
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

        public string Lieu
        {
            get
            {
                return lieu;
            }

            set
            {
                lieu = value;
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

        public string Priorite
        {
            get
            {
                return priorite;
            }

            set
            {
                priorite = value;
            }
        }

        internal Document Document
        {
            get
            {
                return document;
            }

            set
            {
                document = value;
            }
        }


    }
}
