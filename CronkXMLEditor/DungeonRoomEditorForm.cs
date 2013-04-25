using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CronkXMLEditor
{
    public partial class DungeonRoomEditorForm : Form
    {
        Bitmap roomPicture;
        Graphics roomGraphics;
        room_matrix_coordinate[,] roomMatrix;

        private enum tile_type
        {
            Stone_Floor, Stone_Wall, Dirt_Floor, Dirt_Wall, Gravel,
            Shallow_Water, Deep_Water
        };


        public DungeonRoomEditorForm()
        {
            InitializeComponent();

            roomPicture = new Bitmap(500, 500);
            roomGraphics = Graphics.FromImage(roomPicture);
            mainPictureBox.Image = roomPicture;
            mainPictureBox.Invalidate();
        }

        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            roomGraphics.DrawImage(pictureBox1.Image, new Rectangle(e.Location, new System.Drawing.Size(32,32)));
            label8.Text = "X: " + e.Location.X.ToString() + " Y: " + e.Location.Y.ToString();

            mainPictureBox.Invalidate();
        }
    }

    public class room_matrix_coordinate
    {
        public int x;
        public int y;

        public room_matrix_coordinate(int i_x, int i_y)
        {
            x = i_x;
            y = i_y;
        }
    }
}
