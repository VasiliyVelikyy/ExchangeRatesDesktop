using ExchangeRates.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRates.ViewModel
{
    public class DrawnViewModel 
    {
        public IList<Segment> Segments { get; set; }

        public Point[] Points { get; set; }


        public DrawnViewModel()
        {
            Points = new Point[]
        {
            new Point { X = 0, Y = 10 },
            new Point { X = 10, Y = 30 },
            new Point { X = 20, Y = 20 },
        };

          //  Segments = new List<Segment>(Points.Zip(Points.Skip(1), (a, b) => new Segment { From = a, To = b }));
        }

    }
}
