using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> plist = new List<Point>();
            Point p1 = new Point(20, 20, '-');
            plist.Add(p1);

            p1.Draw();
        }
    }
}
