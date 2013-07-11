using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronkXMLEditor
{
    public class matrix_coord
    {
        public int x;
        public int y;

        public matrix_coord(int sx, int sy)
        {
            x = sx;
            y = sy;
        }

        public override string ToString()
        {
            return "X: " + x.ToString() + " Y: " + y.ToString();
        }

        public string compressedString()
        {
            return "X:" + x.ToString() + " Y:" + y.ToString();
        }
    }
}
