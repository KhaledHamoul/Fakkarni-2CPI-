using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            BDD database = new BDD();
            DateTime d = new DateTime(2012, 03, 05, 10, 15, 20);

            /*
            Utilisateur[] user = new Utilisateur[5];
            for (int i=0;i<5;i++)
            {
                user[i] = new Utilisateur(0, "Bara", "Mohammed", "moh");
                database.Insert(user[i]);
            }
            
            
            Activite[] activite = new Activite[10];
            for (int i=0;i<10;i++)
            {
                activite[i] = new Activite(0, "Analyse", "Scolaire");
                database.Insert(activite[i], 2);
            }


            Tache[] tache = new Tache[10];
            for (int i=0;i<10;i++)
            {
                tache[i] = new Tache(0, "Cours", "m", d, "notyet");
                database.Insert(tache[i], 2, 2);
            }

            Evenement[] evenement = new Evenement[10];
            for (int i=0;i<10;i++)
            {
                evenement[i] = new Evenement(0, "Meeting", "h", d, "ESI");
                database.Insert(evenement[i], 3);
            }

            Vacance[] vacance = new Vacance[10];
            for (int i=0;i<10;i++)
            {
                vacance[i] = new Vacance(0, "Moharram", d);
                database.Insert(vacance[i], 3);
            }

            Document[] document = new Document[5];
            for (int i=0;i<5;i++)
            {
                document[i] = new Document(0, "POO", "Desktop");
                database.Insert(document[i], 5);
            }

            Contact[] contact = new Contact[10];
            for (int i=0;i<10;i++)
            {
                contact[i] = new Contact(0, "Ali", "Oued Smar", "0673383488", "", "");
                database.Insert(contact[i], 4);
            }*/
            

            Console.ReadLine();
        }
    }
}
