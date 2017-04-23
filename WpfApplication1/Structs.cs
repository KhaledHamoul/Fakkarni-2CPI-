using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace WpfApplication1
{
    public class Structs
    {
        public struct DayCell
        {
            public Rectangle backGround;
            public Rectangle borders;
            public Image addAppointement;
        }

        public struct HourCell
        {
            public Rectangle backGround;
            public Rectangle borders;
            public DateTime hour;
            public TextBlock hourDisplay;
        }

        public struct GraphicAppointement
        {
            public Label appointementDesignation;
            public Rectangle borders;
            public Image modify;
            public Image delete;
            public Appointement appointement;
        }
    }
}
