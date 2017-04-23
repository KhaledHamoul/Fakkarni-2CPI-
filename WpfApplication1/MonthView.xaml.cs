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
    /// Interaction logic for MonthView.xaml
    /// </summary>
   

    public struct Cell
    {
        public Rectangle backGround;
        public Rectangle borders;
        public TextBlock day;
        public DateTime datetime;
        public Image deleteAppointement;
        public Image addAppointement;
        public Image showWeek;
        public Image showDay;
        public Image appointementFlag;
    }


    public partial class MonthView : Page
    {
        #region GlobaleVariables
        public static MonthView mainWindowInstance;
        public Cell[,] cells = new Cell[6, 7];
        private Cell selectedCell;
        private Cell previousSelectedCell;
        public TimeClass timeClassInstance;
        public DateTime currentMonth;
        //private EventModif eventModifInstance = new EventModif();
       // private DailyView dailyViewInstance = new DailyView();
       // private DayView dayViewInstance = new DayView();
        public static BDD BDDInstance = new BDD();
        private ToolTip mainTip;
        ContextMenu cm;
        MenuItem eventItem;
        MenuItem taskItem;
        #endregion


        public MonthView()
        {
            InitializeComponent();
            InitialiseGlobaleVariables();
            InitialiseCells();
            InitialiseAppointements();
            currentMonth = DateTime.Today;
            DisplayMonth(currentMonth);
        }


        private void InitialiseGlobaleVariables()
        {
            mainWindowInstance = this;
            BDDInstance = new BDD();
            timeClassInstance = new TimeClass();
            mainTip = new ToolTip();
            cm = new ContextMenu();
            cm.Items.Clear();
            cm.Items.Add(new MenuItem());
            cm.Items.Add(new MenuItem());
            eventItem = (MenuItem)cm.Items[0];
            taskItem = (MenuItem)cm.Items[1];
            eventItem.Header = "Ajouter evenement";
            eventItem.Click += AddEvent;
            taskItem.Header = "Ajouter tache";
            taskItem.Click += AddTask;
        }

        private void AddEvent(object sender, RoutedEventArgs e)
        {
            /// CalculatePosition to set the event Window
            Point eventModifLocation = selectedCell.backGround.PointToScreen(new Point(-7, 0));
           // eventModifInstance.Left = eventModifLocation.X;
           // eventModifInstance.Top = eventModifLocation.Y;
           // eventModifInstance.currentDay = selectedCell.datetime;
          //  eventModifInstance.Show();
        }

        private void AddTask(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("AddTask");
        }

        private void InitialiseCells()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    cells[i, j].backGround = new Rectangle();
                    cells[i, j].backGround.MouseUp += new MouseButtonEventHandler(CellClick);
                    cells[i, j].backGround.MouseEnter += new MouseEventHandler(MouseEnterCell);
                    cells[i, j].backGround.MouseLeave += new MouseEventHandler(MouseLeaveCell);
                    cells[i, j].borders = new Rectangle();
                    cells[i, j].day = new TextBlock();
                    cells[i, j].deleteAppointement = new Image();
                    cells[i, j].deleteAppointement.MouseLeftButtonUp += new MouseButtonEventHandler(DeleteAppointement);
                    cells[i, j].deleteAppointement.MouseEnter += new MouseEventHandler(DeleteToolTip);
                    try
                    {
                        cells[i, j].deleteAppointement.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/delete1.ico"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    cells[i, j].deleteAppointement.Visibility = Visibility.Hidden;
                    cells[i, j].deleteAppointement.VerticalAlignment = VerticalAlignment.Top;
                    cells[i, j].deleteAppointement.HorizontalAlignment = HorizontalAlignment.Left;
                    cells[i, j].deleteAppointement.Height = 20f;
                    cells[i, j].deleteAppointement.Width = 20f;
                    cells[i, j].deleteAppointement.Margin = new Thickness(5, 5, 0, 0);
                    cells[i, j].addAppointement = new Image();
                    cells[i, j].addAppointement.ContextMenu = cm;
                    cells[i, j].addAppointement.MouseLeftButtonUp += new MouseButtonEventHandler(AddAppointement);

                    cells[i, j].addAppointement.MouseEnter += new MouseEventHandler(AddAppointementToolTip);
                    try
                    {
                        cells[i, j].addAppointement.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/add.ico"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    cells[i, j].addAppointement.Visibility = Visibility.Hidden;
                    cells[i, j].addAppointement.VerticalAlignment = VerticalAlignment.Top;
                    cells[i, j].addAppointement.HorizontalAlignment = HorizontalAlignment.Right;
                    cells[i, j].addAppointement.Height = 20f;
                    cells[i, j].addAppointement.Width = 20f;
                    cells[i, j].addAppointement.Margin = new Thickness(0, 5, 5, 0);
                    cells[i, j].showWeek = new Image();
                    cells[i, j].showWeek.MouseLeftButtonUp += new MouseButtonEventHandler(ShowWeek);
                    cells[i, j].showWeek.MouseEnter += new MouseEventHandler(ShowWeekToolTip);
                    try
                    {
                        cells[i, j].showWeek.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/day5.png"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    cells[i, j].showWeek.Visibility = Visibility.Hidden;
                    cells[i, j].showWeek.VerticalAlignment = VerticalAlignment.Bottom;
                    cells[i, j].showWeek.HorizontalAlignment = HorizontalAlignment.Right;
                    cells[i, j].showWeek.Height = 20;
                    cells[i, j].showWeek.Width = 20;
                    cells[i, j].showWeek.Margin = new Thickness(0, 0, 5, 5);
                    cells[i, j].showDay = new Image();
                    cells[i, j].showDay.MouseLeftButtonUp += new MouseButtonEventHandler(ShowDay);
                    cells[i, j].showDay.MouseEnter += new MouseEventHandler(ShowDayToolTip);
                    try
                    {
                        cells[i, j].showDay.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/DayView.png"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    cells[i, j].showDay.Visibility = Visibility.Hidden;
                    cells[i, j].showDay.VerticalAlignment = VerticalAlignment.Bottom;
                    cells[i, j].showDay.HorizontalAlignment = HorizontalAlignment.Left;
                    cells[i, j].showDay.Height = 20;
                    cells[i, j].showDay.Width = 20;
                    cells[i, j].showDay.Margin = new Thickness(5, 0, 0, 5);
                    cells[i, j].appointementFlag = new Image();
                    try
                    {
                        cells[i, j].appointementFlag.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/red_flag.png"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    cells[i, j].appointementFlag.Visibility = Visibility.Hidden;
                    cells[i, j].appointementFlag.VerticalAlignment = VerticalAlignment.Top;
                    cells[i, j].appointementFlag.HorizontalAlignment = HorizontalAlignment.Right;
                    cells[i, j].appointementFlag.Height = 20f;
                    cells[i, j].appointementFlag.Width = 20f;
                    cells[i, j].appointementFlag.Margin = new Thickness(0, 5, 5, 0);
                    cells[i, j].appointementFlag.MouseEnter += new MouseEventHandler(FlagToolTip);
                    Grid.SetRow(cells[i, j].backGround, i + 1);
                    Grid.SetColumn(cells[i, j].backGround, j);
                    Grid.SetRow(cells[i, j].borders, i + 1);
                    Grid.SetColumn(cells[i, j].borders, j);
                    Grid.SetRow(cells[i, j].day, i + 1);
                    Grid.SetColumn(cells[i, j].day, j);
                    Grid.SetRow(cells[i, j].deleteAppointement, i + 1);
                    Grid.SetColumn(cells[i, j].deleteAppointement, j);
                    Grid.SetRow(cells[i, j].addAppointement, i + 1);
                    Grid.SetColumn(cells[i, j].addAppointement, j);
                    Grid.SetRow(cells[i, j].showWeek, i + 1);
                    Grid.SetColumn(cells[i, j].showWeek, j);
                    Grid.SetRow(cells[i, j].showDay, i + 1);
                    Grid.SetColumn(cells[i, j].showDay, j);
                    Grid.SetRow(cells[i, j].appointementFlag, i + 1);
                    Grid.SetColumn(cells[i, j].appointementFlag, j);
                    MyGrid.Children.Add(cells[i, j].backGround);
                    MyGrid.Children.Add(cells[i, j].borders);
                    MyGrid.Children.Add(cells[i, j].day);
                    MyGrid.Children.Add(cells[i, j].deleteAppointement);
                    MyGrid.Children.Add(cells[i, j].addAppointement);
                    MyGrid.Children.Add(cells[i, j].showWeek);
                    MyGrid.Children.Add(cells[i, j].showDay);
                    MyGrid.Children.Add(cells[i, j].appointementFlag);
                }
            }
            selectedCell = cells[0, 0];
        }

        private void InitialiseAppointements()
        {
            foreach (Appointement appointement in BDDInstance.SelectEvents(1))
            {
                appointementController.AddAppointement(appointement);
            }
            foreach (Appointement appointement in BDDInstance.SelectTasks(1))
            {
                appointementController.AddAppointement(appointement);
            }
        }

        public void DisplayMonth(DateTime month)
        {
            DisplayDateTitle(month);
            DateTime firstOfMonth = StarterOfMonth(month);
            int firstOfMonthIndex = timeClassInstance.daysOfWeek[firstOfMonth.DayOfWeek];
            firstOfMonth = firstOfMonth.AddDays(-firstOfMonthIndex + 1);
            int cpt = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    DateTime nextDate = firstOfMonth.AddDays(cpt);
                    if (nextDate.Month != month.Month)
                    {
                        cells[i, j].backGround.Fill = new SolidColorBrush(Color.FromRgb(92, 151, 191));
                        cells[i, j].day.FontSize = 14;
                    }
                    else
                    {
                        cells[i, j].backGround.Fill = new SolidColorBrush(Color.FromRgb(107, 185, 240));
                        cells[i, j].day.FontSize = 18;
                    }
                    int day = int.Parse(nextDate.ToString("dd"));
                    cells[i, j].day.FontStyle = FontStyles.Normal;
                    cells[i, j].day.Margin = new Thickness(2, 2, 0, 0);
                    cells[i, j].day.HorizontalAlignment = HorizontalAlignment.Left;
                    cells[i, j].day.VerticalAlignment = VerticalAlignment.Top;
                    cells[i, j].day.Text = "" + day;
                    cells[i, j].datetime = nextDate;
                    cells[i, j].borders.StrokeThickness = 0.5f;
                    cells[i, j].borders.Stroke = new SolidColorBrush(Color.FromRgb(34, 49, 63));
                    cells[i, j].deleteAppointement.Visibility = Visibility.Hidden;
                    cells[i, j].addAppointement.Visibility = Visibility.Hidden;
                    cells[i, j].showWeek.Visibility = Visibility.Hidden;
                    cells[i, j].showDay.Visibility = Visibility.Hidden;
                    cells[i, j].appointementFlag.Visibility = Visibility.Hidden;
                    if (cells[i, j].datetime == selectedCell.datetime)
                    {
                        selectedCell = cells[i, j];
                        selectedCell.borders.StrokeThickness = 1.5f;
                        selectedCell.day.FontStyle = FontStyles.Italic;
                        selectedCell.day.VerticalAlignment = VerticalAlignment.Center;
                        selectedCell.day.HorizontalAlignment = HorizontalAlignment.Center;
                        selectedCell.day.Margin = new Thickness(0, 0, 0, 0);
                    }
                    if (appointementController.availableAppointements.ContainsKey(cells[i, j].datetime))
                    {
                        cells[i, j].appointementFlag.Visibility = Visibility.Visible;
                    }
                    cpt++;
                }
            }
        }

        private DateTime StarterOfMonth(DateTime month)
        {
            return new DateTime(month.Year, month.Month, 1);
        }

        private void DisplayDateTitle(DateTime date)
        {
            monthTitle.Text = timeClassInstance.monthsOfYear[date.Month];
            yearTitle.Text = date.ToString("yyyy");
        }


        private void CellClick(object sender, MouseButtonEventArgs e)
        {
            UIElement cell = (UIElement)sender;
            int row = Grid.GetRow(cell);
            int column = Grid.GetColumn(cell);
            previousSelectedCell = selectedCell;
            selectedCell = cells[row - 1, column];
            previousSelectedCell.borders.StrokeThickness = 0.5f;
            previousSelectedCell.borders.Stroke = new SolidColorBrush(Color.FromRgb(34, 49, 63));
            previousSelectedCell.day.FontStyle = FontStyles.Normal;
            previousSelectedCell.day.VerticalAlignment = VerticalAlignment.Top;
            previousSelectedCell.day.HorizontalAlignment = HorizontalAlignment.Left;
            previousSelectedCell.day.Margin = new Thickness(2, 2, 0, 0);
            previousSelectedCell.deleteAppointement.Visibility = Visibility.Hidden;
            previousSelectedCell.addAppointement.Visibility = Visibility.Hidden;
            previousSelectedCell.showWeek.Visibility = Visibility.Hidden;
            previousSelectedCell.showDay.Visibility = Visibility.Hidden;
            if (appointementController.availableAppointements.ContainsKey(previousSelectedCell.datetime))
            {
                previousSelectedCell.appointementFlag.Visibility = Visibility.Visible;
            }
            selectedCell.borders.StrokeThickness = 1.5f;
            selectedCell.borders.Stroke = new SolidColorBrush(Color.FromRgb(34, 49, 63));
            selectedCell.day.FontStyle = FontStyles.Italic;
            selectedCell.day.VerticalAlignment = VerticalAlignment.Center;
            selectedCell.day.HorizontalAlignment = HorizontalAlignment.Center;
            selectedCell.day.Margin = new Thickness(0, 0, 0, 0);
            if (e.ChangedButton == MouseButton.Right)
            {
                selectedCell.deleteAppointement.Visibility = Visibility.Visible;
                selectedCell.addAppointement.Visibility = Visibility.Visible;
                selectedCell.showWeek.Visibility = Visibility.Visible;
                selectedCell.showDay.Visibility = Visibility.Visible;
                selectedCell.appointementFlag.Visibility = Visibility.Hidden;
            }
        }

        private void MouseEnterCell(object sender, MouseEventArgs e)
        {
            UIElement cell = (UIElement)sender;
            int row = Grid.GetRow(cell);
            int column = Grid.GetColumn(cell);
            if (!selectedCell.Equals(cells[row - 1, column]))
            {
                cells[row - 1, column].borders.Stroke = Brushes.Red;
                cells[row - 1, column].borders.StrokeThickness = 1.5f;
            }
        }

        private void MouseLeaveCell(object sender, MouseEventArgs e)
        {
            UIElement cell = (UIElement)sender;
            int row = Grid.GetRow(cell);
            int column = Grid.GetColumn(cell);
            if (!selectedCell.Equals(cells[row - 1, column]))
            {
                cells[row - 1, column].borders.Stroke = new SolidColorBrush(Color.FromRgb(34, 49, 63));
                cells[row - 1, column].borders.StrokeThickness = 0.5f;
            }
        }

        private void FlagToolTip(object sender, MouseEventArgs e)
        {
            UIElement cell = (UIElement)sender;
            int row = Grid.GetRow(cell);
            int column = Grid.GetColumn(cell);
            SetFlagTipContent(cells[row - 1, column].datetime);
            cells[row - 1, column].appointementFlag.ToolTip = mainTip;
        }

        private void DeleteToolTip(object sender, MouseEventArgs e)
        {
            mainTip.Content = "Supprimer toutes les taches/evenements dans ce jour";
            selectedCell.deleteAppointement.ToolTip = mainTip;
        }

        private void AddAppointementToolTip(object sender, MouseEventArgs e)
        {
            mainTip.Content = "Ajouter un tache/evenement a ce jour";
            selectedCell.addAppointement.ToolTip = mainTip;
        }

        private void ShowWeekToolTip(object sender, MouseEventArgs e)
        {
            mainTip.Content = "Afficher la semaine correspondante a ce jour";
            selectedCell.showWeek.ToolTip = mainTip;
        }
        private void ShowDayToolTip(object sender, MouseEventArgs e)
        {
            mainTip.Content = "Afficher les evenements/taches du jour";
            selectedCell.showWeek.ToolTip = mainTip;
        }

        private void SetFlagTipContent(DateTime date)
        {
            int evenementIndex = 0;
            int tacheIndex = 0;
            String toolTipContent;
            if (appointementController.availableAppointements.ContainsKey(date))
            {
                foreach (Appointement appointement in appointementController.availableAppointements[date])
                {
                    if (appointement.GetType().Name == "Evenement")
                    {
                        evenementIndex++;
                    }
                    else
                    {
                        tacheIndex++;
                    }
                }
                if (evenementIndex == 0 && tacheIndex != 0)
                {
                    toolTipContent = "" + tacheIndex + " Taches";
                }
                else if (tacheIndex == 0 && evenementIndex != 0)
                {
                    toolTipContent = "" + evenementIndex + " Evenement";
                }
                else
                {
                    toolTipContent = "" + tacheIndex + "Taches , et " + evenementIndex + " Evenements";
                }
                mainTip.Content = toolTipContent;
            }
        }

        private void NextMonth(object sender, MouseButtonEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            DisplayMonth(currentMonth);
        }

        private void PrevMonth(object sender, MouseButtonEventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            DisplayMonth(currentMonth);
        }

        private void PrevYear(object sender, MouseButtonEventArgs e)
        {
            currentMonth = currentMonth.AddYears(-1);
            DisplayMonth(currentMonth);
        }

        private void NextYear(object sender, MouseButtonEventArgs e)
        {
            currentMonth = currentMonth.AddYears(1);
            DisplayMonth(currentMonth);
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            //eventmodifinstance.canclose = true;
            //eventmodifinstance.close();
            //dailyviewinstance.canclose = true;
            //dailyviewinstance.close();
            Application.Current.Shutdown();
        }

        private void DeleteAppointement(object sender, MouseButtonEventArgs e)
        {
            if (appointementController.availableAppointements.ContainsKey(selectedCell.datetime))
            {
                for (int i = appointementController.availableAppointements[selectedCell.datetime].Count - 1; i >= 0; i--)
                {
                    Appointement appointement = appointementController.availableAppointements[selectedCell.datetime][i];
                    if (appointement.GetType().Name == "Evenement")
                    {
                        BDDInstance.DeleteEvenement(appointement.id);
                    }
                    else
                    {
                        BDDInstance.DeleteTache(appointement.id);
                    }
                }
                appointementController.availableAppointements[selectedCell.datetime].Clear();
                appointementController.availableAppointements.Remove(selectedCell.datetime);
                DisplayMonth(currentMonth);
            }
            else
            {
                MessageBox.Show("Aucune Tache/Evenement a supprimer");
            }
        }

        private void ShowWeek(object sender, MouseButtonEventArgs e)
        {
            //dailyViewInstance.currentDay = selectedCell.datetime;
            //dailyViewInstance.DisplayWeek(dailyViewInstance.currentDay);
            //dailyViewInstance.Show();
        }

        private void ShowDay(object sender, MouseButtonEventArgs e)
        {
          //  dayViewInstance.currentDay = selectedCell.datetime;
           // dayViewInstance.DisplayDay(dayViewInstance.currentDay);
            //dayViewInstance.Show();
        }

        private void AddAppointement(object sender, MouseButtonEventArgs e)
        {
            selectedCell.addAppointement.ContextMenu.IsOpen = true;
        }
    }
}
