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
    /// Interaction logic for Calandrier.xaml
    /// </summary>
    public partial class Calandrier : Window
    {

        int userId;
        WeeklyView weekView = new WeeklyView();
        MonthView monthView = new MonthView();
        DailyView dayView = new DailyView();

        public Calandrier()
        {
            InitializeComponent();
            this.userId = int.Parse(App.Current.Resources["idUser"].ToString());
            cnctdUser.Content = App.Current.Resources["userName"].ToString();
            string url = @"img\Person" + App.Current.Resources["avatar"].ToString() + ".png";
            avatar.Source = new BitmapImage(new Uri(url, UriKind.Relative));

            weekView.currentDay = DateTime.Today;
            weekView.DisplayWeek(weekView.currentDay);
            dayView.currentDay = DateTime.Today;
            dayView.DisplayDay(dayView.currentDay);

            calandar_frame.NavigationService.Navigate(monthView);
            day.Opacity = 1;
            month.Opacity = 0.7;
            week.Opacity = 1;


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
            contacts win = new contacts(this, userId);
            win.Show();
            this.Close();
        }

        private void versDocument(object sender, MouseButtonEventArgs e)
        {
            DocumentsWindow win = new DocumentsWindow();
            win.Show();
            this.Close();
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

        private void useConfig(object sender, RoutedEventArgs e)
        {
            AcountConfig win = new AcountConfig();
            win.Show();
            this.Close();
        }

        private void afficher_jours(object sender, RoutedEventArgs e)
        {           
            calandar_frame.NavigationService.Navigate(dayView);
            day.Opacity = 0.7;
            month.Opacity = 1;
            week.Opacity = 1;
        }

        private void afficher_semaines(object sender, RoutedEventArgs e)
        {
            calandar_frame.NavigationService.Navigate(weekView);
            day.Opacity = 1;
            month.Opacity = 1;
            week.Opacity = 0.7;
        }

        private void afficher_mois(object sender, RoutedEventArgs e)
        {
            calandar_frame.NavigationService.Navigate(monthView);
            day.Opacity = 1;
            month.Opacity = 0.7;
            week.Opacity = 1;
        }

        private void versHome(object sender, MouseButtonEventArgs e)
        {
            Window win = new home(this, 0);
            win.Show();
            this.Close();
        }
    }
}
