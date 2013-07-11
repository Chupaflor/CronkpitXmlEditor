using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace CronkXMLEditor
{
    public partial class DungeonDesignerForm : Form
    {
        XmlDocument necro_floors;
        XmlDocument gpeak_floors;
        XmlDocument flamerunner_floors;
        XmlDocument sunkencit_floors;

        string necro_floors_path;
        string gpeak_floors_path;
        string flamerunner_floors_path;
        string sunkencit_floors_path;

        public DungeonDesignerForm(ref XmlDocument necFloors, string necPath,
                                   ref XmlDocument gelidFloors, string gelidPath,
                                   ref XmlDocument flameFloors, string flamePath,
                                   ref XmlDocument sunkenFloors, string sunkenPath)
        {
            necro_floors = necFloors;
            gpeak_floors = gelidFloors;
            flamerunner_floors = flameFloors;
            sunkencit_floors = sunkenFloors;

            necro_floors_path = necPath;
            gpeak_floors_path = gelidPath;
            flamerunner_floors_path = flamePath;
            sunkencit_floors_path = sunkenPath;

            InitializeComponent();
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            if (roomtype_listbox.SelectedIndex >= 0)
            {
                string baseString = roomQuant_numeric.Value.ToString() + " " +
                                    roomtype_listbox.Items[roomtype_listbox.SelectedIndex].ToString();
                crooms_listbox.Items.Add(baseString);
            }
        }

        private void remove_btn_Click(object sender, EventArgs e)
        {
            int target_index = crooms_listbox.Items.Count - 1;
            crooms_listbox.Items.RemoveAt(target_index);
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            crooms_listbox.Items.Clear();
        }

        private void append_btn_Click(object sender, EventArgs e)
        {
            XmlDocument target_document = null;
            string target_path = "";

            if (dungeon_listbox.SelectedIndex >= 0)
            {
                string c_dungeon = dungeon_listbox.Items[dungeon_listbox.SelectedIndex].ToString();
                switch (c_dungeon)
                {
                    case "Necropolis":
                        target_document = necro_floors;
                        target_path = necro_floors_path;
                        break;
                    case "Gelid Peaks":
                        target_document = gpeak_floors;
                        target_path = gpeak_floors_path;
                        break;
                    case "Flamerunner Mine":
                        target_document = flamerunner_floors;
                        target_path = flamerunner_floors_path;
                        break;
                    case "Sunken Citadel":
                        target_document = sunkencit_floors;
                        target_path = sunkencit_floors_path;
                        break;
                }

                XmlNode targetNode = target_document.SelectSingleNode("XnaContent/Asset");

                XmlNode floorNumberNode = target_document.CreateElement("FloorNumber");
                floorNumberNode.InnerText = floor_numeric.Value.ToString();
                XmlNode roomListNode = target_document.CreateElement("Roomlist");
                for (int i = 0; i < crooms_listbox.Items.Count; i++)
                {
                    XmlNode next_item = target_document.CreateElement("Item");
                    next_item.InnerText = crooms_listbox.Items[i].ToString();
                    roomListNode.AppendChild(next_item);
                }
                XmlNode specificRoomNode = target_document.CreateElement("SpecificRooms");
                specificRoomNode.InnerText = specific_rooms_chkbox.Checked.ToString();
                XmlNode randomRoomNode = target_document.CreateElement("RandomRooms");
                randomRoomNode.InnerText = random_rooms_chkbox.Checked.ToString();
                XmlNode specificFeatureNode = target_document.CreateElement("SpecificFeatures");
                specificFeatureNode.InnerText = specific_features_chkbox.Checked.ToString();

                XmlNode floorConfigNode = target_document.CreateElement("Item");
                floorConfigNode.AppendChild(floorNumberNode);
                floorConfigNode.AppendChild(roomListNode);
                floorConfigNode.AppendChild(specificRoomNode);

                targetNode.AppendChild(floorConfigNode);

                target_document.Save(target_path);
                target_document.Load(target_path);
            }
        }
    }
}
