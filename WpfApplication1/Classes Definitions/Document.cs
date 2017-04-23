using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
   public class Document
    {
        private int id ;
        private string titre;
        private string emplacement;

       
        public Document(int id, string titre, string emplacement)
        {
            this.Id = id;
            this.Titre = titre;
            this.Emplacement = emplacement;
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

        public string Titre
        {
            get
            {
                return titre;
            }

            set
            {
                titre = value;
            }
        }

        public string Emplacement
        {
            get
            {
                return emplacement;
            }

            set
            {
                emplacement = value;
            }
        }

    }
}
