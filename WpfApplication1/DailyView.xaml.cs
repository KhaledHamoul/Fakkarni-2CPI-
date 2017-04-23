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
    /// Interaction logic for DailyView.xaml
    /// </summary>
    public partial class DailyView : Page
    {
        private struct DateTitle
        {
            public Rectangle background;
            public Label title;
        }
        private DayCell[,] cells = new DayCell[1, 24];
        private HourCell[,] hourCells = new HourCell[1, 24];
        private Dictionary<Label, GraphicAppointement> graphicAppointements = new Dictionary<Label, GraphicAppointement>();
        private GraphicAppointement selectedAppointement;
        private GraphicAppointement previousSelectedAppointement;
        private TimeClass timeClassInstance;
        private DateTitle dateTitle;
        private DayCell selectedCell;
        private DayCell previousSelectedCell;
        ContextMenu cm;
        MenuItem eventItem;
        MenuItem taskItem;
        public DateTime currentDay;
        private bool selectedAnAppointement;
        // EventModif eventModifInstance;


        public DailyView()
        {
            InitializeComponent();
            currentDay = DateTime.Today;
            InitGlobaleVariables();
            InitCells();
        }

        void InitGlobaleVariables()
        {
            timeClassInstance = new TimeClass();
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
            taskItem.Click += Add_Task;
        }


        private void InitialiseDateTitleAndSwapCell()
        {
            Rectangle swapCell = new Rectangle();
            swapCell.Stroke = Brushes.MidnightBlue;
            swapCell.StrokeThickness = 0.5f;
            dateTitle = new DateTitle();
            dateTitle.background = new Rectangle();
            dateTitle.background.Fill = Brushes.AliceBlue;
            dateTitle.background.Stroke = Brushes.MidnightBlue;
            dateTitle.background.StrokeThickness = 0.5f;
            dateTitle.title = new Label();
            dateTitle.title.HorizontalContentAlignment = HorizontalAlignment.Center;
            dateTitle.title.VerticalContentAlignment = VerticalAlignment.Center;
            dateTitle.title.FontSize = 18;
            Grid.SetColumn(swapCell, 0);
            Grid.SetRow(swapCell, 0);
            Grid.SetColumn(dateTitle.background, 0);
            Grid.SetRow(dateTitle.background, 1);
            Grid.SetColumn(dateTitle.title, 0);
            Grid.SetRow(dateTitle.title, 1);
            myGrid.Children.Add(swapCell);
            myGrid.Children.Add(dateTitle.background);
            myGrid.Children.Add(dateTitle.title);
        }

        private void InitCells()
        {
            InitHourCells();
            InitialiseDateTitleAndSwapCell();
            for (int i = 0; i < 24; i++)
            {
                cells[0, i].backGround = new Rectangle();
                cells[0, i].backGround.Fill = Brushes.AliceBlue;
                cells[0, i].backGround.MouseDown += ClickedOnCell;
                cells[0, i].backGround.MouseEnter += HighlightCell;
                cells[0, i].backGround.MouseLeave += UnHighLightCell;
                cells[0, i].borders = new Rectangle();
                cells[0, i].borders.Stroke = Brushes.MidnightBlue;
                cells[0, i].borders.StrokeThickness = 0.5f;
                cells[0, i].addAppointement = new Image();
                cells[0, i].addAppointement.Width = 30;
                cells[0, i].addAppointement.Height = 30;
                cells[0, i].addAppointement.MouseLeftButtonUp += Add_Appointement;
                cells[0, i].addAppointement.ContextMenu = cm;
                try
                {
                    cells[0, i].addAppointement.Source = new BitmapImage(new Uri("pack://application:,,,/" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + ";component/Salah_Icons/add.ico"));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                cells[0, i].addAppointement.VerticalAlignment = VerticalAlignment.Center;
                cells[0, i].addAppointement.HorizontalAlignment = HorizontalAlignment.Center;
                cells[0, i].addAppointement.Visibility = Visibility.Hidden;
                Grid.SetRow(cells[0, i].backGround, 1);
                Grid.SetColumn(cells[0, i].backGround, i + 1);
                Grid.SetRow(cells[0, i].borders, 1);
                Grid.SetColumn(cells[0, i].borders, i + 1);
                Grid.SetRow(cells[0, i].addAppointement, 1);
                Grid.SetColumn(cells[0, i].addAppointement, i + 1);
                myGrid.Children.Add(cells[0, i].backGround);
                myGrid.Children.Add(cells[0, i].borders);
                myGrid.Children.Add(cells[0, i].addAppointement);
            }
            selectedCell = cells[0, 0];
        }
        private void InitHourCells()
        {
            for (int i = 0; i < 24; i++)
            {
                hourCells[0, i].backGround = new Rectangle();
                hourCells[0, i].backGround.Fill = Brushes.AliceBlue;
                hourCells[0, i].borders = new Rectangle();
                hourCells[0, i].borders.Stroke = Brushes.MidnightBlue;
                hourCells[0, i].borders.StrokeThickness = 0.5f;
                hourCells[0, i].hour = currentDay;
                hourCells[0, i].hourDisplay = new TextBlock();
                hourCells[0, i].hourDisplay.Text = timeClassInstance.hoursOfDayString[i + 1];
                hourCells[0, i].hourDisplay.VerticalAlignment = VerticalAlignment.Center;
                hourCells[0, i].hourDisplay.HorizontalAlignment = HorizontalAlignment.Center;
                hourCells[0, i].hourDisplay.FontSize = 14;
                Grid.SetRow(hourCells[0, i].backGround, 0);
                Grid.SetColumn(hourCells[0, i].backGround, i + 1);
                Grid.SetRow(hourCells[0, i].borders, 0);
                Grid.SetColumn(hourCells[0, i].borders, i + 1);
                Grid.SetRow(hourCells[0, i].hourDisplay, 0);
                Grid.SetColumn(hourCells[0, i].hourDisplay, i + 1);
                myGrid.Children.Add(hourCells[0, i].backGround);
                myGrid.Children.Add(hourCells[0, i].borders);
                myGrid.Children.Add(hourCells[0, i].hourDisplay);
            }
        }

        private void DisplayDateTitle()
        {
            dateTitle.title.Content = timeClassInstance.daysInFrench[currentDay.DayOfWeek];
        }

        private void UnHighLightCell(object sender, MouseEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            DayCell highLightedCell = cells[row - 1, column - 1];
            if (!selectedCell.Equals(highLightedCell))
            {
                highLightedCell.borders.Stroke = Brushes.MidnightBlue;
                highLightedCell.borders.StrokeThickness = 0.5f;
            }
        }

        private void HighlightCell(object sender, MouseEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            DayCell highLightedCell = cells[row - 1, column - 1];
            if (!selectedCell.Equals(highLightedCell))
            {
                highLightedCell.borders.Stroke = Brushes.Red;
                highLightedCell.borders.StrokeThickness = 1.5f;
            }
        }
        private void ClickedOnCell(object sender, MouseButtonEventArgs e)
        {
            UIElement source = (UIElement)sender;
            int row = Grid.GetRow(source);
            int column = Grid.GetColumn(source);
            previousSelectedCell = selectedCell;
            selectedCell = cells[row - 1, column - 1];
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
        private void Add_Appointement(object sender, MouseButtonEventArgs e)
        {
            selectedCell.addAppointement.ContextMenu.IsOpen = true;
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

        public void DisplayDay(DateTime day)
        {
            ClearAppointements();
            DisplayDateTitle();
            DisplayAppointement(day);
        }

        private void DisplayAppointement(DateTime day)
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
                    int columnSpan = timeClassInstance.hoursOfDayInt[adjustedDateEnd.Hour] - timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour];
                    if (columnSpan <= 0) columnSpan = 1;
                    Grid.SetColumn(gAppointement.appointementDesignation, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetRow(gAppointement.appointementDesignation, 1);
                    Grid.SetColumnSpan(gAppointement.appointementDesignation, columnSpan);
                    Grid.SetColumn(gAppointement.borders, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetRow(gAppointement.borders, 1);
                    Grid.SetColumnSpan(gAppointement.borders, columnSpan);
                    Grid.SetColumn(gAppointement.modify, timeClassInstance.hoursOfDayInt[adjustedDateEnd.Hour - 1]);
                    Grid.SetRow(gAppointement.modify, 1);
                    Grid.SetColumn(gAppointement.delete, timeClassInstance.hoursOfDayInt[adjustedDateDebut.Hour]);
                    Grid.SetRow(gAppointement.delete, 1);
                    myGrid.Children.Add(gAppointement.modify);
                    myGrid.Children.Add(gAppointement.appointementDesignation);
                    myGrid.Children.Add(gAppointement.borders);
                    myGrid.Children.Add(gAppointement.delete);
                    graphicAppointements.Add(gAppointement.appointementDesignation, gAppointement);
                    selectedAppointement = gAppointement;
                }
            }
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
            DisplayDay(currentDay);
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            Visibility = Visibility.Hidden;
        }
    }

}
