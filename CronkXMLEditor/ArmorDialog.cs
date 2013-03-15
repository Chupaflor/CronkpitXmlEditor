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
    public partial class ArmorDialog : Form
    {
        public ArmorDialog(int AbVal, int InsVal, int PadVal, int RigVal, int HardVal)
        {
            InitializeComponent();
            SlashingDefVal.Value = (HardVal * 4) + (RigVal * 2);
            PiercingDefVal.Value = (HardVal * 4) + (PadVal * 2);
            CrushingDefVal.Value = (RigVal * 4) + (PadVal * 2);
            FireDefVal.Value = (AbVal * 4) + (RigVal * 2);
            FrostDefVal.Value = (PadVal * 4) + (InsVal * 2);
            ElectricDefVal.Value = (InsVal * 4) + (PadVal * 2);
            AcidDefVal.Value = (InsVal * 4) + (AbVal * 2);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
