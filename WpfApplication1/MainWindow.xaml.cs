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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Utilisateur> users;
        public MainWindow()
        {
            InitializeComponent();
            this.Focusable = true;
            BDD bdd = new BDD();
            this.users = bdd.SelectUsers();
            ComboBoxItem item = new ComboBoxItem();

            try
            {
                for (int i = 0; i < users.Count; i++)
                {
                    item = new ComboBoxItem();
                    item.Content = users[i].Prenom + "  " + users[i].Nom;
                    item.Uid = users[i].Id.ToString();
                    item.Name = "user" + (i + 1).ToString();
                    item.Tag = i.ToString();
                    activeUser.Items.Add(item);
                }
            } catch (Exception ex) { }




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
            closeBtnBack.Fill = new SolidColorBrush(Color.FromArgb(0,0,0,0));
            iconClose.Visibility = Visibility.Visible;
            iconCloseHover.Visibility = Visibility.Hidden;
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void dragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized; 
        }

        private void newSessionMouseEnter(object sender, MouseEventArgs e)
        {
            newSessionBtn.Visibility = Visibility.Hidden;
            newSessionBtnHover.Visibility = Visibility.Visible;
        }

        private void newSessionMouseLeave(object sender, MouseEventArgs e)
        {
            newSessionBtn.Visibility = Visibility.Visible;
            newSessionBtnHover.Visibility = Visibility.Hidden;
            
        }

        private void gotoInscriptionWindow(object sender, MouseButtonEventArgs e)
        {
            Window win;
           // win.Show();
            this.Close();
        }

        

        private void backMouseDown(object sender, MouseButtonEventArgs e)
        {
            back.Focus();
            if ( passWord.Password == "") mdpLabel.Visibility = Visibility.Visible ;
        }

        private void mdpGotFocus(object sender, RoutedEventArgs e)
        {
            mdpLabel.Visibility = Visibility.Hidden;
        }



        /* private void passWdMouseEnter(object sender, MouseEventArgs e)
         {
             Color color = (Color)ColorConverter.ConvertFromString("#ff0000");
             passWord.BorderThickness = new SolidColorBrush(color);
         }*/


        public bool authentifier(int id, string password)
        {
            BDD database = new BDD();
            List<Utilisateur> users = database.SelectUsers();
            if(users.Contains( new Utilisateur(id,"","",password,-1))) return true;
            else return true;
        }


        private void connexion(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (authentifier(int.Parse(((ComboBoxItem)activeUser.SelectedItem).Uid), passWord.Password))
                {
                    App.Current.Resources["idUser"] = int.Parse(((ComboBoxItem)activeUser.SelectedItem).Uid);
                    App.Current.Resources["userName"] = ((ComboBoxItem)activeUser.SelectedItem).Content.ToString();
                    home home = new home(this, 6);// int.Parse(((ComboBoxItem)activeUser.SelectedItem).Uid));
                    home.Show();
                    this.Close();
                }
                else MessageBox.Show("Mot de passe erroné ");
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Veuillez entrer le nom d'utilisateur.");
            }
        }

       
       

      
        private void change_selected_user(object sender, SelectionChangedEventArgs e)
        {
            App.Current.Resources["avatar"] = this.users[int.Parse(((ComboBoxItem)activeUser.SelectedItem).Tag.ToString())].avatar;
            string url = @"img\Person" + App.Current.Resources["avatar"].ToString() + ".png";
            profilPhoto.Source = new BitmapImage(new Uri(url, UriKind.Relative));
           
        }
    }



    
}
