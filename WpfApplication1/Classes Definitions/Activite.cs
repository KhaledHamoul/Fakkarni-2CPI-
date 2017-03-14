using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Activite
    {
        private int id;
        private string designation;
        private string type;


        public Activite(int id , string designation , string type)
        {
            this.id = id;
            this.designation = designation;
            this.Type = type;

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
        public string Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                this.id = value;
            }
        }
    }
}
