using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Common
{
    public struct Rectangle
    {
        public Rectangle(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public int x;
        public int y;
        public int w;
        public int h;
    }
    
    public class HeaderInfo
    {
        public HeaderInfo() { }
        public HeaderInfo(int number, Rectangle rectangle)
        {
            this.Number = number;
            this.Rectangle = rectangle;
        }
        public int Number { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}
