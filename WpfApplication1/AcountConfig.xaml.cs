using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AcountConfig.xaml
    /// </summary>
    public partial class AcountConfig : Window
    {
        
        public static List<BitmapImage> listImages = new List<BitmapImage>();
        private int indexImages;
        Utilisateur user;
        Boolean mdp_chnge = false;

        public AcountConfig()
        {
            InitializeComponent();
            Initialisation();
            BDD bdd = new BDD();
            user = bdd.SelectUser(int.Parse(App.Current.Resources["idUser"].ToString()));
            nom.Text = user.Nom;
            prenom.Text = user.Prenom; 
            string url = @"img\Person" + App.Current.Resources["avatar"].ToString() + ".png";
            PhotoDeProfile.Source = new BitmapImage(new Uri(url, UriKind.Relative));
            indexImages = int.Parse(App.Current.Resources["avatar"].ToString())-1;

        }

        private void Initialisation()
        {
            listImages.Add(new BitmapImage(new Uri(@"img\Person1.png", UriKind.Relative)));
            listImages.Add(new BitmapImage(new Uri(@"img\Person2.png", UriKind.Relative)));
            listImages.Add(new BitmapImage(new Uri(@"img\Person3.png", UriKind.Relative)));
            listImages.Add(new BitmapImage(new Uri(@"img\Person4.png", UriKind.Relative)));
            listImages.Add(new BitmapImage(new Uri(@"img\Person5.png", UriKind.Relative)));
            listImages.Add(new BitmapImage(new Uri(@"img\Person6.png", UriKind.Relative)));
        }

        private void mouseEnterMinimize(object sender, MouseEventArgs e)
        {
            Color color1 = (Color)ColorConverter.ConvertFromString("#ffffff");
            minimizeBtn.Fill = new SolidColorBrush(color1);
            minimizeBtn.Opacity = 100;
            minimizeHover.Visibility = Visibility.Visible;
            minimize.Visibility = Visibility.Hidden;

        }

        private void mouseLeaveMinimize(object sender, MouseEventArgs e)
        {
            minimizeBtn.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            minimize.Visibility = Visibility.Visible;
            minimizeHover.Visibility = Visibility.Hidden;

        }

        private void mouseEnter(object sender, MouseEventArgs e)
        {
            Color color = (Color)ColorConverter.ConvertFromString("#ffffff");
            closeBtnBack.Fill = new SolidColorBrush(color);
            closeBtnBack.Opacity = 100;
            iconClose.Visibility = Visibility.Hidden;
            iconCloseHover.Visibility = Visibility.Visible;
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            closeBtnBack.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            iconClose.Visibility = Visibility.Visible;
            iconCloseHover.Visibility = Visibility.Hidden;
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void Drag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }



        private void PreviousImage(object sender, MouseButtonEventArgs e)
        {
            indexImages--;
            if (indexImages < 0)
            {
                indexImages = 5;
            }
            PhotoDeProfile.Source = listImages[indexImages];
        }

        private void NextImage(object sender, MouseButtonEventArgs e)
        {
            indexImages++;
            if (indexImages > 5)
            {
                indexImages = 0;
            }
            PhotoDeProfile.Source = listImages[indexImages];
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Window win = new home(this,user.Id);
            win.Show();
            this.Close();
        }



        private void confirmer_Click(object sender, RoutedEventArgs e)
        {
            String n = nom.Text.ToUpper();
            String p = prenom.Text.ToUpper();
            String mdp = user.Mot_de_passe;
            String confirm = user.Mot_de_passe;
            if (mdp_chnge)
            {
                    mdp = new_mdp.Password;
                    confirm = new_mdpc.Password;
            }
            
            if ((n != "") && (p != "") && (mdp != "") && (confirm != ""))
            {
                BDD database = new BDD();
                if ((ancien_mdp.Password != user.Mot_de_passe)&&(mdp_chnge)) MessageBox.Show("L'ancien passeword est incorrect !");

                else if (mdp.CompareTo(confirm) == 0)
                {
                        user.Nom = n;
                        user.Prenom = p;
                        user.Mot_de_passe = mdp.ToUpper();
                        user.avatar = indexImages + 1 ;
                        database.Update(user);
                        App.Current.Resources["userName"] = user.ToString();
                        App.Current.Resources["avatar"] = indexImages + 1;
                        Window win = new home(this, user.Id);
                        win.Show();
                        this.Close();
                    
                }
                else
                {
                    MessageBox.Show("Mot de passes non identiques");
                }

            }
            else MessageBox.Show("Veuillez remplir tout les champs !");


        }

        private void back_mouse_down(object sender, MouseButtonEventArgs e)
        {
            Fenetre.Focus();
            if (nom.Text == "") nom_lab.Visibility = Visibility.Visible;
            if (prenom.Text == "") prenom_lab.Visibility = Visibility.Visible;
            if ((new_mdp.Password == "")&& (mdp_chnge)) mdp_lab.Visibility = Visibility.Visible;
            if ((new_mdpc.Password == "")&& (mdp_chnge)) mdpc_lab.Visibility = Visibility.Visible;
            if ((ancien_mdp.Password == "")&& (mdp_chnge)) ancien_mdp_lab.Visibility = Visibility.Visible;
        }

        private void nomfocus(object sender, RoutedEventArgs e)
        {
            nom_lab.Visibility = Visibility.Hidden;
            
            if (prenom.Text == "") prenom_lab.Visibility = Visibility.Visible;
            if ((new_mdp.Password == "")&& (mdp_chnge)) mdp_lab.Visibility = Visibility.Visible;
            if ((new_mdpc.Password == "") && (mdp_chnge)) mdpc_lab.Visibility = Visibility.Visible;
            if ((ancien_mdp.Password == "")&& (mdp_chnge)) ancien_mdp_lab.Visibility = Visibility.Visible;

        }

        private void prenomfocus(object sender, RoutedEventArgs e)
        {
            prenom_lab.Visibility = Visibility.Hidden;

            if (nom.Text == "") nom_lab.Visibility = Visibility.Visible;
            if ((new_mdp.Password == "")&& (mdp_chnge)) mdp_lab.Visibility = Visibility.Visible;
            if ((new_mdpc.Password == "")&& (mdp_chnge)) mdpc_lab.Visibility = Visibility.Visible;
            if ((ancien_mdp.Password == "")&& (mdp_chnge)) ancien_mdp_lab.Visibility = Visibility.Visible;

        }

        private void ancienFocus(object sender, RoutedEventArgs e)
        {
            ancien_mdp_lab.Visibility = Visibility.Hidden;

            if (nom.Text == "") nom_lab.Visibility = Visibility.Visible;
            if (prenom.Text == "") prenom_lab.Visibility = Visibility.Visible;
            if ((new_mdp.Password == "")&& (mdp_chnge)) mdp_lab.Visibility = Visibility.Visible;
            if ((new_mdpc.Password == "")&& (mdp_chnge)) mdpc_lab.Visibility = Visibility.Visible;
        }

        private void mdpFocus(object sender, RoutedEventArgs e)
        {
            mdp_lab.Visibility = Visibility.Hidden;

            if (nom.Text == "") nom_lab.Visibility = Visibility.Visible;
            if (prenom.Text == "") prenom_lab.Visibility = Visibility.Visible;
            if ((new_mdpc.Password == "")&& (mdp_chnge)) mdpc_lab.Visibility = Visibility.Visible;
            if ((ancien_mdp.Password == "")&& (mdp_chnge)) ancien_mdp_lab.Visibility = Visibility.Visible;
        }

        private void mdpcFocus(object sender, RoutedEventArgs e)
        {
            mdpc_lab.Visibility = Visibility.Hidden;

            if (nom.Text == "") nom_lab.Visibility = Visibility.Visible;
            if (prenom.Text == "") prenom_lab.Visibility = Visibility.Visible;
            if ((new_mdp.Password == "")&& (mdp_chnge)) mdp_lab.Visibility = Visibility.Visible;
            if ((ancien_mdp.Password == "")&& (mdp_chnge)) ancien_mdp_lab.Visibility = Visibility.Visible;
        }



        private void mdp_modif_click(object sender, RoutedEventArgs e)
        {
            mdp_modif_btn.Visibility = Visibility.Hidden;
            new_mdp.Visibility = Visibility.Visible;
            new_mdpc.Visibility = Visibility.Visible;
            ancien_mdp.Visibility = Visibility.Visible;
            ancien_mdp_lab.Visibility = Visibility.Visible;
            mdp_lab.Visibility = Visibility.Visible;
            mdpc_lab.Visibility = Visibility.Visible;

            mdp_chnge = true;

        }

        private void supprimer_cmpt(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette session ?", "Suppression de la session");


            if (result == MessageBoxResult.OK)
            {
                BDD b = new BDD();
                b.DeleteUtilisateur(user.Id);
                MessageBox.Show("supprimer avec succes");
                Window win = new MainWindow();
                win.Show();
                this.Close();
            }

        }  
       
    }
}


