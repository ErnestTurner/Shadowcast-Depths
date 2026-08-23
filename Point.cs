using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    public class Point
    {
        private int x;
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        private int y;
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            Point point2 = (Point)obj;
            return (this.x == point2.x && this.y == point2.y);
        }

        public static bool operator ==(Point point1, Point point2)
        {
            return (point1.x == point2.x && point1.y == point2.y);
        }

        public static bool operator !=(Point point1, Point point2)
        {
            return (point1.x == point2.x && point1.y == point2.y);
        }
    }
}
