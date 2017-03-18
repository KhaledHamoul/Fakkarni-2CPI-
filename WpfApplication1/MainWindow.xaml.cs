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
        public MainWindow()
        {
            InitializeComponent();
            this.Focusable = true;
            BDD bdd = new BDD();
            List<Utilisateur> user = bdd.SelectUsers();
            ComboBoxItem item = new ComboBoxItem();
            int i = 0;
           
           while (user[i] != null)
            {      
                item = new ComboBoxItem();
                item.Content =  user[i].Prenom + "  " + user[i].Nom;
                item.Name = "user"+(i+1).ToString();
                activeUser.Items.Add(item);
                i++;
            }

           // MessageBox.Show(bdd.autentification(user[0].Nom, user[0].Prenom)[0]);
            

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
            Window win = new home(this);
            win.Show();
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
            if (users.Contains(new Utilisateur(id, "", "", password))) return true;
            else return false;
        }

       

        private void connexion_Click(object sender, MouseButtonEventArgs e)
        {
            if (authentifier(int.Parse(((ComboBoxItem)activeUser.SelectedItem).Uid), passWord.Password)) MessageBox.Show("Connection Success");
            else MessageBox.Show("Wrong Password");
        }
    }

}
