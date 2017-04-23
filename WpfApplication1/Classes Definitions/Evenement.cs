using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Evenement : Appointement
    {
        public string lieu;

        public Evenement(int id, string designation,string priorite, DateTime dateDebut,DateTime dateFin, string lieu)
        {
            this.id = id;
            this.designation = designation;
            this.priorite = priorite;
            this.dateDebut = dateDebut;
            this.dateFin = dateFin;
            this.lieu = lieu;
        }

       

        public void addDocument(Document d)
        {
            documents.Add(d);
        }

    }
}
