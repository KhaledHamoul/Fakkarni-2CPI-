using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Tache : Appointement
    {
        public string etat;

        public Tache(int id, string designation , string priorite,DateTime date,DateTime dateFin, string etat)
        {
            this.id = id ;
            this.designation = designation ;
            this.priorite = priorite ;
            this.dateDebut = date ;
            this.dateFin = dateFin;
            this.etat = etat ;
        }
       

        public void addDocument(Document d)
        {
            documents.Add(d);
        }
    }
}
