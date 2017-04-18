using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class DocumentsWindow : Window
    {
        List<Document> liste;

        public DocumentsWindow()
        {
            InitializeComponent();
            initialiserListBox();
            cnctdUser.Content = App.Current.Resources["userName"].ToString();



        }

        private void drag(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void close(object sender, MouseButtonEventArgs e)
        {
            this.Close();
            
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

        private void versContact(object sender, MouseButtonEventArgs e)
        {
            Window win = new contacts(this,0);
            win.Show();
            this.Close();
        }

        private void versHome(object sender, MouseButtonEventArgs e)
        {
            Window win = new home(this, 0);
            win.Show();
            this.Close();
        }


        private void Apropos(object sender, MouseButtonEventArgs e)
        {
            Window win = new apropos();
            win.Show();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            titre.IsEnabled = true;
            url.IsEnabled = true;
            valider.Visibility = Visibility.Visible;
            modifier.Visibility = Visibility.Hidden;
            inserer.Visibility = Visibility.Hidden;
        }

        private void valider_Click(object sender, RoutedEventArgs e)
        {
            (new BDD()).Update(new Document(((Document) listDocuments.SelectedItem).Id,titre.Text,url.Text));
            titre.IsEnabled = false;
            url.IsEnabled = false;
            valider.Visibility = Visibility.Hidden;
            modifier.Visibility = Visibility.Visible;
            inserer.Visibility = Visibility.Visible;
        }

        private void inserer_Click(object sender, RoutedEventArgs e)
        {
            titre.IsEnabled = true;
            url.IsEnabled = true;
            titre.Text = "";
            url.Text = "";
            valider_insertion.Visibility = Visibility.Visible;
            modifier.Visibility = Visibility.Hidden;
            inserer.Visibility = Visibility.Hidden;
        }

        private void validerInsertion_Click(object sender, RoutedEventArgs e)
        {
            (new BDD()).Insert(new Document(0, titre.Text, url.Text),1);
            titre.IsEnabled = false;
            url.IsEnabled = false;
            valider.Visibility = Visibility.Hidden;
            modifier.Visibility = Visibility.Visible;
            inserer.Visibility = Visibility.Visible;
            initialiserListBox();
        }

        private void initialiserListBox()
        {
            BDD database = new BDD();
            liste = database.SelectDocuments(1);
            listDocuments.Items.Clear();
            try
            {
                foreach (Document d in liste)
                {

                    listDocuments.Items.Add(d);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            (new BDD()).DeleteDocument(((Document)listDocuments.SelectedItem).Id);
            initialiserListBox();
        }

        private void showMenu(object sender, MouseButtonEventArgs e)
        {
            userMenu.Visibility = Visibility.Visible;
        }

        private void hideMenu(object sender, MouseButtonEventArgs e)
        {
            userMenu.Visibility = Visibility.Hidden;
        }

        private void deconnexion(object sender, RoutedEventArgs e)
        {
            App.Current.Resources["userName"] = -1;
            App.Current.Resources["idUser"] = -1;
            MainWindow win = new MainWindow();
            this.Close();
            win.Show();
        }

        
    }
}

