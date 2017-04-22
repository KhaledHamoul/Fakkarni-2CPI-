using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace WpfApplication1
{
    class BDD
    {
        private SqlConnection connection;

        public BDD()
        {
            string connectionString;     
            connectionString = global::WpfApplication1.Properties.Settings.Default.DatabaseConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error opening connection.\n "+ex.Message);
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void Execute(SqlCommand cmd)
        {
            try
            {
                
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Execute success");
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);           
            }
            this.CloseConnection();
        }


        public void Insert(Activite a, int idUser)
        {
            string query = "INSERT INTO activities VALUES ('" + a.Designation + "','" + a.Type + "'," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void Insert(Tache t, int idUser, int idActivite)
        {
            string query = "INSERT INTO tasks VALUES ('" + t.Designation + "','" + t.Priorite + "','" + t.Date.Year + "-" + t.Date.Month + "-" + t.Date.Day + " " + t.Date.TimeOfDay + "','" + t.Etat + "'," + idActivite + ", DEFAULT ," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Insert(Evenement e, int idUser)
        {
            string query = "INSERT INTO events VALUES ('" + e.Designation + "','" + e.Priorite + "','" + e.Date.Year + "-" + e.Date.Month + "-" + e.Date.Day + " " + e.Date.TimeOfDay + "','" + e.Lieu + "',DEFAULT," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Insert(Contact c, int idUser)
        {
            string query = "INSERT INTO contacts VALUES ('" + c.Nom + "','" + c.Adresse + "','" + c.NumTel + "','" + c.Email + "','" + c.Siteweb + "'," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Insert(Document d, int idUser)
        {
            string query = "INSERT INTO documents VALUES ('" + d.Titre + "','" + d.Emplacement + "'," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Insert(Vacance h, int idUser)
        {
            string query = "INSERT INTO holidays VALUES ('" + h.Designation + "','" + h.Date.Year + "-" + h.Date.Month + "-" + h.Date.Day + "'," + idUser + ");";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Insert(Utilisateur u)
        {
            string query = "INSERT INTO users VALUES ('" + u.Nom + "','" + u.Prenom + "','" + u.Mot_de_passe + "','" + u.avatar + "');";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }



        public void DeleteActivite(int id)
        {
            string query = "DELETE  FROM activities WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteTache(int id)
        {
            string query = "DELETE  FROM tasks WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteEvenement(int id)
        {
            string query = "DELETE  FROM events WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteContact(int id)
        {
            string query = "DELETE  FROM contacts WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteDocument(int id)
        {
            string query = "DELETE  FROM documents WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteVacance(int id)
        {
            string query = "DELETE  FROM holidays WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }

        public void DeleteUtilisateur(int id)
        {
            string query = "DELETE  FROM users WHERE id=" + id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }

        }




        public List<Activite> SelectActivities(int userID)
        {
            string query = "SELECT * FROM activities WHERE id_user =" + userID + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Activite> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Activite>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Activite(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        i++;
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Tache> SelectTasks(int userId, int ActiviteId)
        {
            string query = "SELECT * FROM tasks WHERE id_user =" + userId + " AND id_activity=" + ActiviteId + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Tache> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Tache>();
                    while (reader.Read())
                    {
                        Tache t = new Tache(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                        try
                        {
                            t.Documents = SelectTaskDocuments(userId,reader.GetInt32(6));
                        }
                        catch (System.Data.SqlTypes.SqlNullValueException)
                        {
                            MessageBox.Show("No Document");
                        }
                        finally
                        {
                            tab.Add(t);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error :" + ex.Message);
                }


                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public Document SelectDocument(int docId)
        {
            string query = "SELECT * FROM documents WHERE id =" + docId + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Document d = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())  d = new Document(docId, reader.GetString(1), reader.GetString(2));

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
                return d;
            }
            else return null;
        }

        public List<Document> SelectDocuments(int userID)
        {
            string query = "SELECT * FROM documents WHERE id_user =" + userID + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Document> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Document>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Document(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        i++;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Document> SelectTaskDocuments(int userID,int taskId)
        {
            string query = "SELECT documents.id , documents.designation , documents.url FROM task_has_documents WHERE id_task= " + taskId + " INNER JOIN documents WHERE id_user =" + userID + " ON tasks_has_documents.id_document=documents.id;";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Document> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Document>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Document(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        i++;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Document> SelectEventDocuments(int userID, int eventId)
        {
            string query = "SELECT documents.id , documents.designation , documents.url FROM events_has_documents WHERE id_event= " + eventId + " INNER JOIN documents WHERE id_user =" + userID + " ON events_has_documents.id_document=events.id;";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Document> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Document>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Document(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                        i++;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }


                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Contact> SelectContacts(int userID)
        {
            string query = "SELECT * FROM contacts WHERE id_user =" + userID + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Contact> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Contact>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Contact(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
                        i++;
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Evenement> SelectEvents(int userID)
        {
            string query = "SELECT * FROM events WHERE id_user =" + userID + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Evenement> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Evenement>();
                    while (reader.Read())
                    {
                        Evenement e = new Evenement(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3), reader.GetString(4));
                        try
                        {
                            e.Documents = SelectEventDocuments(userID,reader.GetInt32(6));
                        }
                        catch (System.Data.SqlTypes.SqlNullValueException)
                        {
                            MessageBox.Show("No Document");
                        }
                        finally
                        {
                            tab.Add(e);
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Vacance> SelectHolidays(int userID)
        {
            string query = "SELECT * FROM holidays WHERE id_user =" + userID + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Vacance> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Vacance>();
                    int i = 0;
                    while (reader.Read())
                    {
                        tab.Add(new Vacance(reader.GetInt32(0), reader.GetString(1), reader.GetDateTime(2)));
                        i++;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.CloseConnection();
                return tab;
            }
            else return null;
        }

        public List<Utilisateur> SelectUsers()
        {
            string query = "SELECT * FROM users ;";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                List<Utilisateur> tab = null;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    tab = new List<Utilisateur>();
                    while (reader.Read())
                    {
                        tab.Add(new Utilisateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.CloseConnection();
                return tab;
            }
            else return null;
        }


        public Utilisateur SelectUser(Utilisateur u)
        {
            string query = "SELECT * FROM users WHERE nom = '" + u.Nom + "' AND prenom = '" + u.Prenom + "' AND password = '" + u.Mot_de_passe + "' ;";   
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Utilisateur user;
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    return user = new Utilisateur(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                    
                }
                catch (SqlException ex)
                {
                    return null;
                }
                this.CloseConnection();                
            }
            else return null;
        }


        public void Update(Activite a)
        {
            string query = "UPDATE activities SET designation = '" + a.Designation + "' , type='" + a.Type + "' WHERE id=" + a.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Contact c)
        {
            string query = "UPDATE contacts SET nom =  '" + c.Nom + "' , adresse =  '" + c.Adresse + "' , numTel = '" + c.NumTel + "' , email =  '" + c.Email + "' , website =  '" + c.Siteweb + "'  WHERE id=" + c.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Tache a)
        {
            string query = "UPDATE tasks SET designation='" + a.Designation + "' , priority='" + a.Priorite + "' , date='" + a.Date.Year + "-" + a.Date.Month + "-" + a.Date.Day + " " + a.Date.TimeOfDay + "' , state='" + a.Etat + "' WHERE id=" + a.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Vacance v)
        {
            string query = "UPDATE holidays SET designation =  " + v.Designation + " , date =  " + v.Date + " WHERE id=" + v.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Utilisateur u)
        {
            string query = "UPDATE users SET nom =  '" + u.Nom + "' , prenom='" + u.Prenom + "' , password =  '" + u.Mot_de_passe + "' , avatar ='"+ u.avatar + "' WHERE id=" + u.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Evenement a)
        {
            string query = "UPDATE tasks SET designation =  '" + a.Designation + "' , priority='" + a.Priorite + "' , date = '" + a.Date.Year + "-" + a.Date.Month + "-" + a.Date.Day + " " + a.Date.TimeOfDay + "' , state = '" + a.Lieu + "' WHERE id=" + a.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }

        public void Update(Document a)
        {
            string query = "UPDATE documents SET designation = '" + a.Titre + "' , url='" + a.Emplacement + "' WHERE id=" + a.Id + ";";
            if (this.OpenConnection() == true)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                Execute(cmd);
                this.CloseConnection();
            }
        }


    }



}
