using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    public class Appointement
    {
        public int id;
        public string designation;
        public string priorite;
        public DateTime dateDebut;
        public DateTime dateFin;
        public List<Document> documents;
    }
}
