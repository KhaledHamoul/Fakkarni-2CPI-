using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Utilisateur
    {
        private int id;
        private string nom;
        private string prenom;
        private string mot_de_passe;
        private Activite[] activites;
        private Contact [] contacts;
        private Evenement [] evenements;
        private Vacance [] vacances;

        public Utilisateur(int id, string nom, string prenom, string mot_de_passe)
        {
            this.nom = nom;
            this.id = id;
            this.prenom = prenom;
            this.Mot_de_passe = mot_de_passe;

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

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                prenom = value;
            }
        }

        public string Mot_de_passe
        {
            get
            {
                return mot_de_passe;
            }

            set
            {
                mot_de_passe = value;
            }
        }
    }

}
