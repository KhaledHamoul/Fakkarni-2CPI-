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
using static WpfApplication1.Structs;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for WeeklyView.xaml
    /// </summary>
    public partial class WeeklyView : Page
    {
      

        private DateTime[] Week = new DateTime[7];
        private DayCell[,] DayCells = new DayCell[24, 9];
        private HourCell[,] hourCells = new HourCell[24, 1];
        private Dictionary<Label, GraphicAppointement> graphicAppointements = new Dictionary<Label, GraphicAppointement>();
        private GraphicAppointement selectedAppointement;
        private GraphicAppointement previousSelectedAppointement;
        private DayCell selectedCell;
        private DayCell previousSelectedCell;
        private bool selectedAnAppointement;
        public DateTime currentDay;
        private TimeClass timeClassInstance;
        ContextMenu cm;
        MenuItem eventItem;
        MenuItem taskItem;
        public bool canClose;
        //private EventModif eventModifInstance;

        public WeeklyView()
        {
            InitializeComponent();
            //eventModifInstance = new EventModif();
            cm = new ContextMenu();
            cm.Items.Clear();
            cm.Items.Add(new MenuItem());
            cm.Items.Add(new MenuItem());
            eventItem = (MenuItem)cm.Items[0];
            taskItem = (MenuItem)cm.Items[1];
            eventItem.Header = "Ajouter evenement";
            eventItem.Click += Add_Event;
            taskItem.Header = "Ajouter tache";
            taskItem.Click += Add_Task; ;
            timeClassInstance = new TimeClass();
            InitCells();
        }

        private void Add_Task(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("" + currentDay.Day);
        }

        private void Add_Event(object sender, RoutedEventArgs e)
        {
            Point eventModifLocation = selectedCell.backGround.PointToScreen(new Point(-7, 0));
            //eventModifInstance.Left = eventModifLocation.X;
            //eventModifInstance.Top = eventModifLocation.Y;
            //eventModifInstance.currentDay = currentDay;
            //eventModifInstance.Show();
        }

        private void InitCells()
        {
            InitHourCells();
            for (int i = 0; i < 24; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    DayCells[i, j - 1].backGround = new Rectangle();
                    DayCells[i, j - 1].backGround.Fill = Brushes.AliceBlue;
                    DayCells[i, j - 1].backGround.MouseDown += ClickedOnDayCell;
                    DayCells[i, j - 1].backGround.MouseEnter += HighlightDayCell;
                    DayCells[i, j - 1].backGround.MouseLeave += UnHighLightDayCell;
                    DayCells[i, j - 1].borders = new Rectangle();
                    DayCells[i, j - 1].borders.Stroke = Brushes.MidnightBlue;
                    DayCells[i, j - 1].borders.StrokeThickness = 0.5f;
                    DayCells[i, j - 1].addAppointement = new Image();
                    DayCells[i, j - 1].addAppointement.Width = 30;
                    DayCells[i, j - 1].addAppointement.Height = 30;
                    DayCells[i, j - 1].addAppointement.MouseLeftButtonUp += Add_Appointement;
                    DayCells[i, j - 1].addAppointement.ContextMenu = cm;
                    try
                    {
                        DayCells[i, j - 1].addAppointement.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/add.ico"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    DayCells[i, j - 1].addAppointement.VerticalAlignment = VerticalAlignment.Center;
                    DayCells[i, j - 1].addAppointement.HorizontalAlignment = HorizontalAlignment.Center;
                    DayCells[i, j - 1].addAppointement.Visibility = Visibility.Hidden;
                    Grid.SetRow(DayCells[i, j - 1].backGround, i + 1);
                    Grid.SetColumn(DayCells[i, j - 1].backGround, j);
                    Grid.SetRow(DayCells[i, j - 1].borders, i + 1);
                    Grid.SetColumn(DayCells[i, j - 1].borders, j);
                    Grid.SetRow(DayCells[i, j - 1].addAppointement, i + 1);
                    Grid.SetColumn(DayCells[i, j - 1].addAppointement, j);
                    myGrid.Children.Add(DayCells[i, j - 1].backGround);
                    myGrid.Children.Add(DayCells[i, j - 1].borders);
                    myGrid.Children.Add(DayCells[i, j - 1].addAppointement);
                }
            }
            selectedCell = DayCells[0, 0];
        }

        private void UnHighLightDayCell(object sender, MouseEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            DayCell highLightedCell = DayCells[row - 1, column - 1];
            if (!selectedCell.Equals(highLightedCell))
            {
                highLightedCell.borders.Stroke = Brushes.MidnightBlue;
                highLightedCell.borders.StrokeThickness = 0.5f;
            }
        }

        private void HighlightDayCell(object sender, MouseEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            DayCell highLightedCell = DayCells[row - 1, column - 1];
            if (!selectedCell.Equals(highLightedCell))
            {
                highLightedCell.borders.Stroke = Brushes.Red;
                highLightedCell.borders.StrokeThickness = 1.5f;
            }
        }

        private void Add_Appointement(object sender, MouseButtonEventArgs e)
        {
            selectedCell.addAppointement.ContextMenu.IsOpen = true;
        }

        private void ClickedOnDayCell(object sender, MouseButtonEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            currentDay = Week[column - 1];
            previousSelectedCell = selectedCell;
            selectedCell = DayCells[row - 1, column - 1];
            selectedCell.borders.StrokeThickness = 1.5f;
            selectedCell.borders.Stroke = Brushes.Red;
            if (!selectedCell.Equals(previousSelectedCell))
            {
                previousSelectedCell.borders.Stroke = Brushes.MidnightBlue;
                previousSelectedCell.borders.StrokeThickness = 0.5f;
                previousSelectedCell.addAppointement.Visibility = Visibility.Hidden;
            }
            if (e.ChangedButton == MouseButton.Right)
            {
                selectedCell.addAppointement.Visibility = Visibility.Visible;
            }
        }

        private void InitHourCells()
        {
            for (int i = 0; i < 24; i++)
            {
                hourCells[i, 0].backGround = new Rectangle();
                hourCells[i, 0].backGround.Fill = Brushes.AliceBlue;
                hourCells[i, 0].borders = new Rectangle();
                hourCells[i, 0].borders.Stroke = Brushes.MidnightBlue;
                hourCells[i, 0].borders.StrokeThickness = 0.5f;
                hourCells[i, 0].hour = currentDay;
                hourCells[i, 0].hourDisplay = new TextBlock();
                hourCells[i, 0].hourDisplay.Text = timeClassInstance.hoursOfDayString[i + 1];
                hourCells[i, 0].hourDisplay.VerticalAlignment = VerticalAlignment.Center;
                hourCells[i, 0].hourDisplay.HorizontalAlignment = HorizontalAlignment.Center;
                hourCells[i, 0].hourDisplay.FontSize = 14;
                Grid.SetRow(hourCells[i, 0].backGround, i + 1);
                Grid.SetColumn(hourCells[i, 0].backGround, 0);
                Grid.SetRow(hourCells[i, 0].borders, i + 1);
                Grid.SetColumn(hourCells[i, 0].borders, 0);
                Grid.SetRow(hourCells[i, 0].hourDisplay, i + 1);
                Grid.SetColumn(hourCells[i, 0].hourDisplay, 0);
                myGrid.Children.Add(hourCells[i, 0].backGround);
                myGrid.Children.Add(hourCells[i, 0].borders);
                myGrid.Children.Add(hourCells[i, 0].hourDisplay);
            }
        }


        void InitWeek(DateTime day)
        {
            int dayIndex = timeClassInstance.daysOfWeek[day.DayOfWeek];
            for (int i = 1; i <= 7; i++)
            {
                Week[i - 1] = day.AddDays(i - dayIndex);
            }
        }

        public void DisplayWeek(DateTime week)
        {
            ClearAppointements();
            InitWeek(week);
            for (int i = 0; i < 7; i++)
            {
                if (appointementController.availableAppointements.ContainsKey(Week[i]))
                {
                    DisplayAppointement(Week[i], i + 1);
                }
            }
        }

        private void DisplayAppointement(DateTime day, int dayColumnIndex)
        {
            if (appointementController.availableAppointements.ContainsKey(day))
            {
                foreach (Appointement appointement in appointementController.availableAppointements[day])
                {
                    GraphicAppointement gAppointement = new GraphicAppointement();
                    gAppointement.appointementDesignation = new Label();
                    gAppointement.appointementDesignation.MouseDown += new MouseButtonEventHandler(CellClick);
                    gAppointement.appointementDesignation.Content = "" + appointement.designation;
                    gAppointement.appointementDesignation.FontSize = 18;
                    gAppointement.appointementDesignation.HorizontalContentAlignment = HorizontalAlignment.Center;
                    gAppointement.appointementDesignation.VerticalContentAlignment = VerticalAlignment.Center;
                    Panel.SetZIndex(gAppointement.appointementDesignation, 1);
                    gAppointement.borders = new Rectangle();
                    gAppointement.borders.Fill = Brushes.CadetBlue;
                    gAppointement.borders.Stroke = Brushes.MidnightBlue;
                    gAppointement.borders.StrokeThickness = 0.5f;
                    Panel.SetZIndex(gAppointement.borders, 0);
                    gAppointement.modify = new Image();
                    try
                    {
                        gAppointement.modify.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/modify2.png"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    gAppointement.modify.HorizontalAlignment = HorizontalAlignment.Right;
                    gAppointement.modify.VerticalAlignment = VerticalAlignment.Top;
                    gAppointement.modify.MouseDown += new MouseButtonEventHandler(ModifieEvent);
                    gAppointement.modify.Height = 25;
                    gAppointement.modify.Width = 25;
                    gAppointement.modify.Margin = new Thickness(0, 5, 5, 0);
                    gAppointement.modify.Visibility = Visibility.Hidden;
                    Panel.SetZIndex(gAppointement.modify, 1);
                    gAppointement.delete = new Image();
                    try
                    {
                        gAppointement.delete.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/delete1.ico"));
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    gAppointement.delete.HorizontalAlignment = HorizontalAlignment.Left;
                    gAppointement.delete.VerticalAlignment = VerticalAlignment.Top;
                    gAppointement.delete.MouseDown += new MouseButtonEventHandler(DeleteEvent);
                    gAppointement.delete.Height = 20;
                    gAppointement.delete.Width = 20;
                    gAppointement.delete.Margin = new Thickness(5, 5, 0, 0);
                    gAppointement.delete.Visibility = Visibility.Hidden;
                    Panel.SetZIndex(gAppointement.delete, 1);
                    gAppointement.appointement = appointement;
                    /// to adjust event in the grid
                    DateTime adjustedDateDebut;
                    DateTime adjustedDateEnd;
                    if (appointement.dateDebut.Minute <= 30)
                    {
                        adjustedDateDebut = appointement.dateDebut;
                    }
                    else
                    {
                        adjustedDateDebut = (appointement.dateDebut).AddHours(1);
                    }
                    if (appointement.dateFin.Minute <= 30)
                    {
                        adjustedDateEnd = appointement.dateFin;
                    }
                    else
                    {
                        adjustedDateEnd = (appointement.dateFin).AddHours(1);
                    }
                    int rowSpan = timeClassInstance.hoursOfDayInt[adjustedDateEnd.Hour] - timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour];
                    if (rowSpan <= 0) rowSpan = 1;
                    Grid.SetColumn(gAppointement.appointementDesignation, dayColumnIndex);
                    Grid.SetRow(gAppointement.appointementDesignation, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetRowSpan(gAppointement.appointementDesignation, rowSpan);
                    Grid.SetColumn(gAppointement.borders, dayColumnIndex);
                    Grid.SetRow(gAppointement.borders, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetRowSpan(gAppointement.borders, rowSpan);
                    Grid.SetColumn(gAppointement.modify, dayColumnIndex);
                    Grid.SetRow(gAppointement.modify, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetColumn(gAppointement.delete, dayColumnIndex);
                    Grid.SetRow(gAppointement.delete, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    myGrid.Children.Add(gAppointement.modify);
                    myGrid.Children.Add(gAppointement.appointementDesignation);
                    myGrid.Children.Add(gAppointement.borders);
                    myGrid.Children.Add(gAppointement.delete);
                    graphicAppointements.Add(gAppointement.appointementDesignation, gAppointement);
                    selectedAppointement = gAppointement;
                }
            }
        }

        private void ClearAppointements()
        {
            foreach (GraphicAppointement gAppointement in graphicAppointements.Values)
            {
                myGrid.Children.Remove(gAppointement.appointementDesignation);
                myGrid.Children.Remove(gAppointement.modify);
                myGrid.Children.Remove(gAppointement.delete);
                myGrid.Children.Remove(gAppointement.borders);
            }
            graphicAppointements.Clear();
        }

        private void CellClick(object sender, MouseButtonEventArgs e)
        {
            selectedAnAppointement = true;
            Label graphicAppoint = (Label)sender;
            previousSelectedAppointement = selectedAppointement;
            selectedAppointement = graphicAppointements[graphicAppoint];
            selectedAppointement.modify.Visibility = Visibility.Visible;
            selectedAppointement.delete.Visibility = Visibility.Visible;
            selectedAppointement.borders.Stroke = Brushes.Red;
            selectedAppointement.borders.StrokeThickness = 1.5f;
            selectedAppointement.appointementDesignation.Content = "Selected " + selectedAppointement.appointement.designation;
            if (!selectedAppointement.Equals(previousSelectedAppointement))
            {
                previousSelectedAppointement.modify.Visibility = Visibility.Hidden;
                previousSelectedAppointement.delete.Visibility = Visibility.Hidden;
                previousSelectedAppointement.borders.Stroke = Brushes.MidnightBlue;
                previousSelectedAppointement.borders.StrokeThickness = 0.5f;
                previousSelectedAppointement.appointementDesignation.Content = previousSelectedAppointement.appointement.designation;
            }
        }

        private void PreviousWeek(object sender, MouseButtonEventArgs e)
        {
            currentDay = currentDay.AddDays(-7);
            ClearAppointements();
            DisplayWeek(currentDay);
        }

        private void NextWeek(object sender, MouseButtonEventArgs e)
        {
            currentDay = currentDay.AddDays(7);
            ClearAppointements();
            DisplayWeek(currentDay);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                Visibility = Visibility.Hidden;
            }
        }
        private void ModifieEvent(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("" + selectedAppointement.appointement.designation);
        }

        private void ClickedOnWindows(object sender, MouseButtonEventArgs e)
        {
            if (!selectedAnAppointement)
            {
                try
                {
                    selectedAppointement.modify.Visibility = Visibility.Hidden;
                    selectedAppointement.delete.Visibility = Visibility.Hidden;
                    selectedAppointement.borders.Stroke = Brushes.MidnightBlue;
                    selectedAppointement.borders.StrokeThickness = 0.5f;
                    selectedAppointement.appointementDesignation.Content = selectedAppointement.appointement.designation;
                }
                catch (Exception exep)
                {
                }

            }
            selectedAnAppointement = false;
        }

        private void DeleteEvent(object sender, MouseButtonEventArgs e)
        {
            if (selectedAppointement.appointement.GetType().Name == "Evenement")
            {
                MonthView.BDDInstance.DeleteEvenement(selectedAppointement.appointement.id);
            }
            else
            {
                MonthView.BDDInstance.DeleteTache(selectedAppointement.appointement.id);
            }
            DateTime appointementDate = selectedAppointement.appointement.dateDebut;
            DateTime adjustedDay = new DateTime(appointementDate.Year, appointementDate.Month, appointementDate.Day, 0, 0, 0);
            appointementController.availableAppointements[adjustedDay].Remove(selectedAppointement.appointement);
            if (appointementController.availableAppointements[adjustedDay].Count == 0)
            {
                appointementController.availableAppointements.Remove(adjustedDay);
            }
            DisplayWeek(currentDay);
        }
    }
}
