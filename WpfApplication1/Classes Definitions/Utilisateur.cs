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
        public int avatar { get; set; }
        private Activite[] activites;
        private Contact [] contacts;
        private Evenement [] evenements;
        private Vacance [] vacances;

        public override string ToString()
        {
            return nom+" "+prenom;
        }

        public int CompareTo(object o)
        {
            Utilisateur u = ((Utilisateur)o);
            return nom.CompareTo(u.nom) * prenom.CompareTo(u.Prenom);
        }

        public Utilisateur(int id, string nom, string prenom, string mot_de_passe,int avatar)
        {
            this.nom = nom;
            this.id = id;
            this.prenom = prenom;
            this.mot_de_passe = mot_de_passe;
            this.avatar = avatar;

        }

        public override bool Equals(object o)
        {
            if (((Utilisateur)o).Id == this.id && ((Utilisateur)o).Mot_de_passe.Equals(this.mot_de_passe)) return true;
            else return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
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
