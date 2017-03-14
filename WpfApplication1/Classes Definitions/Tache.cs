using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Tache 
    {
        private int id;
        private string designation;
        private string priorite;
        private DateTime date;
        private string etat;
        private Document document;

       
        public Tache(int id, string designation , string priorite,DateTime date, string etat)
        {
            this.Id = id ;
            this.Designation = designation ;
            this.Priorite = priorite ;
            this.Date = date ;
            this.Etat = etat ;
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

        public string Etat
        {
            get
            {
                return etat;
            }

            set
            {
                etat = value;
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
