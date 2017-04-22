using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class NouvelleSession : Window
    {
        public static List<BitmapImage> listImages = new List<BitmapImage>();
        private int indexImages;
        public NouvelleSession()
        {
            Initialisation();
            InitializeComponent();
        }
        private void Initialisation()
        {
            indexImages = 0;
            listImages.Add(new BitmapImage(new Uri(@"img\Person1.png",UriKind.Relative)));
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

        private void WindowFocus(object sender, MouseButtonEventArgs e)
        {
            Fenetre.Focus();
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
            if (indexImages > 5 )
            {
                indexImages = 0;
            }
            PhotoDeProfile.Source = listImages[indexImages];
        }

        private void annuler_Click(object sender, RoutedEventArgs e)
        {
            Window win = new MainWindow();
            win.Show();
            this.Close();
        }

       

        private void confirmer_Click(object sender, RoutedEventArgs e)
        {
            String n = nom.Text.ToUpper();
            String p = prenom.Text.ToUpper();
            String mdp = motDePass.Password;
            String confirm = confirmerMDP.Password;
            if ((n != "") && (p != "") && (mdp != "") && (confirm != ""))
            {
                BDD database = new BDD();
                List<Utilisateur> list = new List<Utilisateur>();
                list = database.SelectUsers();
                if (mdp.CompareTo(confirm) == 0)
                {
                    Utilisateur u = new Utilisateur(0, n, p, mdp, indexImages+1);
                    if (list.Contains(u))
                    {
                        MessageBox.Show("Utilisateur existant");
                    }
                    else
                    {
                        database.Insert(u);
                       u = database.SelectUser(u);
                        App.Current.Resources["userName"] = u.ToString();
                        App.Current.Resources["avatar"] = indexImages+1 ;
                        Window win = new home(this,u.Id);
                        win.Show();
                        this.Close();
                    }
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
        }
    }
}
