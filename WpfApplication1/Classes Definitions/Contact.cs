using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Contact
    {
        private int id;
        private string nom;
        private string adresse;
        private string numTel;
        private string email;
        private string siteweb;

       

        

        public Contact (int id,string nom , string adresse ,string numTel, string email , string siteweb)
        {
            this.Id = id ;
            this.Nom = nom ;
            this.Adresse = adresse;
            this.Email = email ;
            this.NumTel = numTel ;
            this.Siteweb = siteweb ; 
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

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }

        public string Adresse
        {
            get
            {
                return adresse;
            }

            set
            {
                adresse = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string NumTel
        {
            get
            {
                return numTel;
            }

            set
            {
                numTel = value;
            }
        }

        public string Siteweb
        {
            get
            {
                return siteweb;
            }

            set
            {
                siteweb = value;
            }
        }
    }
}
