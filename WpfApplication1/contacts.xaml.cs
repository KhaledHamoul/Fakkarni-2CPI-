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
        Contact[] contactes = new Contact[30];
        BDD bdd = new BDD() ;

        public contacts(Window win, int userId)
        {
            InitializeComponent();
            this.win = win;
            this.userId = userId;    
            this.Focusable = true;
            contactes = bdd.SelectContacts(userId).ToArray();
           
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();
            try
            {
                for (int i = 0; i < contactes.Count() ; i++)
                {
                    item = new ListViewItem();
                   // MessageBox.Show(contactes[0].Nom + "   " + contactes[1].Nom + "   " + contactes[2].Nom);
                    item.Content = contactes[i].Nom;
                   // MessageBox.Show(item.Content.ToString());
                    item.Uid = i.ToString();
                    item.Name = "" ;
                    item.Padding = new Thickness(8);
                   /* item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    item.BorderThickness = new Thickness(0);
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));*/

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
                telephone.Text = contactes[int.Parse(i.Uid)].NumTel;
                adresse.Text = contactes[int.Parse(i.Uid)].Adresse ;
                email.Text = contactes[int.Parse(i.Uid)].Email ;
                site.Text = contactes[int.Parse(i.Uid)].Siteweb;
            }
            catch (Exception ex) { }
        }

        private void modifierContacte(object sender, RoutedEventArgs e)
        {
            modif.Visibility = Visibility.Hidden;
            ajouterContact.Visibility = Visibility.Hidden;
            nom.Visibility = Visibility.Hidden;
            adresse.Visibility = Visibility.Hidden;
            email.Visibility = Visibility.Hidden;
            telephone.Visibility = Visibility.Hidden;
            site.Visibility = Visibility.Hidden;

            confirm.Visibility = Visibility.Visible;
            supprimer.Visibility = Visibility.Visible;
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

            listeContactes.IsEnabled = false;
        }



        private void confirmer(object sender, RoutedEventArgs e)
        {
            ListViewItem i = (ListViewItem)listeContactes.SelectedItem;

            try
            {

               

            Contact cntct = new Contact(contactes[int.Parse(i.Uid)].Id, nomChange.Text.ToString(), adresseCange.Text.ToString(), telephoneChange.Text.ToString(), emailChange.Text.ToString(), siteChange.Text.ToString());
        
            bdd.Update(cntct);
            listeContactes.Items.Clear();
            contactes = null ;
            contactes = bdd.SelectContacts(userId).ToArray();
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();
           
                for (int j = 0; j < contactes.Count() ; j++)
                {
                    item = new ListViewItem();
                    if (j == int.Parse(i.Uid) ) item.IsSelected = true;
                    item.Content = contactes[j].Nom;                    
                    item.Uid = j.ToString();
                   // MessageBox.Show(item.Uid);
                    item.Name = "" ;
                    item.Padding = new Thickness(8);
                  /*  item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    item.BorderThickness = new Thickness(0);
                    item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));*/

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
            ajouterContact.Visibility = Visibility.Visible;
            nom.Visibility = Visibility.Visible;
            adresse.Visibility = Visibility.Visible;
            email.Visibility = Visibility.Visible;
            telephone.Visibility = Visibility.Visible;
            site.Visibility = Visibility.Visible;

            confirm.Visibility = Visibility.Hidden;
            supprimer.Visibility = Visibility.Hidden;
            nomChange.Visibility = Visibility.Hidden;
            telephoneChange.Visibility = Visibility.Hidden;
            emailChange.Visibility = Visibility.Hidden;
            adresseCange.Visibility = Visibility.Hidden;
            siteChange.Visibility = Visibility.Hidden;

            listeContactes.IsEnabled = true;
        }

        private void backMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Focusable = true;
        }

        private void versDocument(object sender, MouseButtonEventArgs e)
        {
            Window win = new home(this, userId);
            win.Show();
            this.Close();
        }

        private void ajouterContacte(object sender, RoutedEventArgs e)
        {
            ajouterContact.Visibility = Visibility.Hidden;
            modif.Visibility = Visibility.Hidden;
            nom.Visibility = Visibility.Hidden;
            adresse.Visibility = Visibility.Hidden;
            email.Visibility = Visibility.Hidden;
            telephone.Visibility = Visibility.Hidden;
            site.Visibility = Visibility.Hidden;

            ajouterContact_confirm.Visibility = Visibility.Visible;
            nomChange.Visibility = Visibility.Visible;
            telephoneChange.Visibility = Visibility.Visible;
            emailChange.Visibility = Visibility.Visible;
            adresseCange.Visibility = Visibility.Visible;
            siteChange.Visibility = Visibility.Visible;

            nomChange.Text = "";
            adresseCange.Text = "";
            telephoneChange.Text = "";
            emailChange.Text = "";
            siteChange.Text = "";

          //  listeContactes.UnselectAll();
            listeContactes.IsEnabled = false;

        }

        private void confirmAjoutContact(object sender, RoutedEventArgs e)
        {
            Contact cntct = new Contact(-1, nomChange.Text.ToString(), adresseCange.Text.ToString(), telephoneChange.Text.ToString(), emailChange.Text.ToString(), siteChange.Text.ToString());

            bdd.Insert(cntct, userId);
            listeContactes.Items.Clear();
            contactes = null;
            contactes = bdd.SelectContacts(userId).ToArray();
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();

            try
            {
                for (int j = 0; j < contactes.Count(); j++)
                {
                    item = new ListViewItem();
                    if (j == contactes.Count()-1) item.IsSelected = true;
                    item.Content = contactes[j].Nom;
                    item.Uid = j.ToString();
                    // MessageBox.Show(item.Uid);
                    item.Name = "";
                    item.Padding = new Thickness(8);
                    /*  item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                      item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                      item.BorderThickness = new Thickness(0);
                      item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));*/

                    listeContactes.Items.Add(item);
                }
            }
            catch (Exception ex) { }

            try
            {
                nom.Text = contactes[contactes.Count()].Nom;
                MessageBox.Show(nom.Text);
                telephone.Text = contactes[contactes.Count()].Nom;
                adresse.Text = contactes[contactes.Count()].Adresse;
                email.Text = contactes[contactes.Count()].Email;
                site.Text = contactes[contactes.Count()].Siteweb;
            }
            catch (Exception ex) { }

            ajouterContact.Visibility = Visibility.Visible;
            modif.Visibility = Visibility.Visible;
            nom.Visibility = Visibility.Visible;
            adresse.Visibility = Visibility.Visible;
            email.Visibility = Visibility.Visible;
            telephone.Visibility = Visibility.Visible;
            site.Visibility = Visibility.Visible;

            ajouterContact_confirm.Visibility = Visibility.Hidden;
            nomChange.Visibility = Visibility.Hidden;
            telephoneChange.Visibility = Visibility.Hidden;
            emailChange.Visibility = Visibility.Hidden;
            adresseCange.Visibility = Visibility.Hidden;
            siteChange.Visibility = Visibility.Hidden;

            listeContactes.IsEnabled = true;
        }

        private void supprimerContacte(object sender, RoutedEventArgs e)
        {

            ListViewItem i = (ListViewItem)listeContactes.SelectedItem;

            try
            {

              bdd.DeleteContact(contactes[int.Parse(i.Uid)].Id);
            listeContactes.Items.Clear();
            contactes = null;
            contactes = bdd.SelectContacts(userId).ToArray();
            ListViewItem item = new ListViewItem();
            StackPanel stack = new StackPanel();

                for (int j = 0; j < contactes.Count(); j++)
                {
                    item = new ListViewItem();
                    if (j == 0) item.IsSelected = true;
                    item.Content = contactes[j].Nom;
                    item.Uid = j.ToString();
                    // MessageBox.Show(item.Uid);
                    item.Name = "";
                    item.Padding = new Thickness(8);
                    /*  item.Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                      item.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                      item.BorderThickness = new Thickness(0);
                      item.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));*/

                    listeContactes.Items.Add(item);
                }
            }
            catch (Exception ex) { }

            try
            {
                nom.Text = contactes[contactes.Count()].Nom;
                MessageBox.Show(nom.Text);
                telephone.Text = contactes[contactes.Count()].Nom;
                adresse.Text = contactes[contactes.Count()].Adresse;
                email.Text = contactes[contactes.Count()].Email;
                site.Text = contactes[contactes.Count()].Siteweb;
            }
            catch (Exception ex) { }

            modif.Visibility = Visibility.Visible;
            ajouterContact.Visibility = Visibility.Visible;
            nom.Visibility = Visibility.Visible;
            adresse.Visibility = Visibility.Visible;
            email.Visibility = Visibility.Visible;
            telephone.Visibility = Visibility.Visible;
            site.Visibility = Visibility.Visible;

            confirm.Visibility = Visibility.Hidden;
            supprimer.Visibility = Visibility.Hidden;
            nomChange.Visibility = Visibility.Hidden;
            telephoneChange.Visibility = Visibility.Hidden;
            emailChange.Visibility = Visibility.Hidden;
            adresseCange.Visibility = Visibility.Hidden;
            siteChange.Visibility = Visibility.Hidden;

            listeContactes.IsEnabled = true;


        }
    }
}
