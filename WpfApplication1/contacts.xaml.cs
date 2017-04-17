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
    /// Interaction logic for contacts.xaml
    /// </summary>
    public partial class contacts : Window
    {
        Window win;
        int userId;
        Contact[] contactes;
        public contacts(Window win, int userId)
        {
            InitializeComponent();
            this.win = win;
            this.userId = userId;    
            this.Focusable = true;
            BDD bdd = new BDD();
            contactes = bdd.SelectContacts(userId);
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();
            try
            {
                for (int i = 0; i < 3; i++)
                {
                    item = new ListViewItem();

                    item.Content = contactes[i].Nom;
                    item.Uid = i.ToString();
                    item.Name = "user" + (i + 1).ToString();
                    item.Padding = new Thickness(10);
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    item.BorderThickness = new Thickness(0);
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                    listeContactes.Items.Add(item);
                }
            }
            catch( Exception ex) { }
           

        }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            win.Close();
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

        private void minimizeWindow(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void versHome(object sender, MouseButtonEventArgs e)
        {
            Window win = new home(this,userId);
            win.Show();
            this.Close();
        }

       
       

        private void UpdateContact(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem i = (ListViewItem)listeContactes.SelectedItem;
            try
            {
                nom.Text = contactes[int.Parse(i.Uid)].Nom;
                telephone.Text = contactes[int.Parse(i.Uid)].Nom;
                adresse.Text = contactes[int.Parse(i.Uid)].Adresse ;
                email.Text = contactes[int.Parse(i.Uid)].Email ;
                site.Text = contactes[int.Parse(i.Uid)].Siteweb;
            }
            catch (Exception ex) { }
        }

        private void modifierContacte(object sender, RoutedEventArgs e)
        {
            modif.Visibility = Visibility.Hidden;
            nom.Visibility = Visibility.Hidden;
            adresse.Visibility = Visibility.Hidden;
            email.Visibility = Visibility.Hidden;
            telephone.Visibility = Visibility.Hidden;
            site.Visibility = Visibility.Hidden;

            confirm.Visibility = Visibility.Visible;
            nomChange.Visibility = Visibility.Visible;
            telephoneChange.Visibility = Visibility.Visible;
            emailChange.Visibility = Visibility.Visible;
            adresseCange.Visibility = Visibility.Visible;
            siteChange.Visibility = Visibility.Visible;

            nomChange.Text = nom.Text;
            adresseCange.Text = adresse.Text;
            telephoneChange.Text = telephone.Text;
            emailChange.Text = email.Text;
            siteChange.Text = site.Text;
        }



        private void confirmer(object sender, RoutedEventArgs e)
        {
            ListViewItem i = (ListViewItem)listeContactes.SelectedItem;
            Contact cntct = new Contact(int.Parse(i.Uid), nomChange.Text, adresseCange.Text, telephoneChange.Text, emailChange.Text, siteChange.Text);
            BDD bdd = new BDD();
            bdd.Update(cntct);
            contactes = bdd.SelectContacts(userId);
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();
            listeContactes.Items.Clear();
            try
            {
                for (int j = 0; j < contactes.Count() ; j++)
                {
                    item = new ListViewItem();
                    //if(j == int.Parse(i.Uid) ) item.IsSelected = true;
                    item.Content = contactes[j].Nom;
                    item.Uid = i.ToString();
                    item.Name = "user" + (j + 1).ToString();
                    item.Padding = new Thickness(10);
                    item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    item.BorderThickness = new Thickness(0);
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));

                    listeContactes.Items.Add(item);
                }
            }
            catch (Exception ex) { }

            try
            {
                nom.Text = contactes[int.Parse(i.Uid)].Nom;
                telephone.Text = contactes[int.Parse(i.Uid)].Nom;
                adresse.Text = contactes[int.Parse(i.Uid)].Adresse;
                email.Text = contactes[int.Parse(i.Uid)].Email;
                site.Text = contactes[int.Parse(i.Uid)].Siteweb;
            }
            catch (Exception ex) { }

            modif.Visibility = Visibility.Visible;
            nom.Visibility = Visibility.Visible;
            adresse.Visibility = Visibility.Visible;
            email.Visibility = Visibility.Visible;
            telephone.Visibility = Visibility.Visible;
            site.Visibility = Visibility.Visible;

            confirm.Visibility = Visibility.Hidden;
            nomChange.Visibility = Visibility.Hidden;
            telephoneChange.Visibility = Visibility.Hidden;
            emailChange.Visibility = Visibility.Hidden;
            adresseCange.Visibility = Visibility.Hidden;
            siteChange.Visibility = Visibility.Hidden;
        }

        private void backMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focusable = true;
        }
    }
}
