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
    public partial class FeatureSpecificerForm : Form
    {
        public FeatureSpecificerForm()
        {
            InitializeComponent();
        }

        private KeyValuePair<XmlDocument, string> load_document()
        {
            //Step 1. Make a file name. File name is dungeon selected _ floor _ floor #
            string c_path = dungeon_listbox.Items[dungeon_listbox.SelectedIndex].ToString().ToLower() + "_features_" + floor_depth_numeric.Value.ToString() + ".xml";
            XmlDocument c_floor_doc = new XmlDocument();
            //So necropolis floor 3 would be Necropolis_Floor_3
            //Step 2. Check to make sure that file name exists. If not, create it. If so, load it.
            if (!File.Exists(c_path))
            {
                XmlNode rootNode = c_floor_doc.CreateElement("XnaContent");
                c_floor_doc.AppendChild(rootNode);

                XmlNode assetNode = c_floor_doc.CreateElement("Asset");
                XmlAttribute assetAttribute = c_floor_doc.CreateAttribute("Type");
                assetAttribute.Value = "CKPLibrary.FeatureDC[]";
                assetNode.Attributes.Append(assetAttribute);

                rootNode.AppendChild(assetNode);

                c_floor_doc.Save(c_path);
            }
            else
                c_floor_doc.Load(c_path);

            return new KeyValuePair<XmlDocument,string>(c_floor_doc, c_path);
        }

        private XmlNode create_base_node(XmlDocument target_doc, string feature_type)
        {
            XmlNode base_feature_node = target_doc.CreateElement("Item");

            XmlNode feature_typ_node = target_doc.CreateElement("FeatureType");
            feature_typ_node.InnerText = feature_type;

            XmlNode river_typ_node = target_doc.CreateElement("RiverType");
            river_typ_node.InnerText = river_type_listbox.Items[river_type_listbox.SelectedIndex].ToString();

            XmlNode start_coord_node = target_doc.CreateElement("Start_Coord");
            start_coord_node.InnerText = new matrix_coord((int)start_x_numeric.Value, (int)start_y_numeric.Value).compressedString();

            XmlNode end_coord_node = target_doc.CreateElement("End_Coord");
            end_coord_node.InnerText = new matrix_coord((int)end_x_numeric.Value, (int)end_y_numeric.Value).compressedString();

            base_feature_node.AppendChild(feature_typ_node);
            base_feature_node.AppendChild(river_typ_node);
            base_feature_node.AppendChild(start_coord_node);
            base_feature_node.AppendChild(end_coord_node);

            return base_feature_node;
        }

        private void add_node_and_save(XmlDocument target_doc, string target_path, XmlNode target_node)
        {
            XmlNode doc_rootnode = target_doc.SelectSingleNode("XnaContent/Asset");

            doc_rootnode.AppendChild(target_node);

            target_doc.Save(target_path);
        }

        private void add_river_btn_Click(object sender, EventArgs e)
        {
            if (river_type_listbox.SelectedIndex >= 0 && dungeon_listbox.SelectedIndex >= 0)
            {
                KeyValuePair<XmlDocument, string> xdoc_KVP = load_document();
                XmlDocument xdoc = xdoc_KVP.Key;

                XmlNode river_node = create_base_node(xdoc, "River");

                XmlNode banks_thk_node = xdoc.CreateElement("River_Shore_Thickness");
                banks_thk_node.InnerText = rocksbanks_thk_numeric.Value.ToString();

                XmlNode shallow_thk_node = xdoc.CreateElement("River_Shallows_Thickness");
                shallow_thk_node.InnerText = shoreshallow_thk_numeric.Value.ToString();

                XmlNode deep_thk_node = xdoc.CreateElement("River_Depths_Thickness");
                deep_thk_node.InnerText = shallowdeep_thk_numeric.Value.ToString();

                XmlNode room_thk_node = xdoc.CreateElement("Lake_Room_Thickness");
                room_thk_node.InnerText = "-1";

                XmlNode shore_thk_node = xdoc.CreateElement("Lake_Shore_Thickness");
                shore_thk_node.InnerText = "-1";

                XmlNode shallows_thk_node = xdoc.CreateElement("Lake_Shallows_Thickness");
                shallows_thk_node.InnerText = "-1";

                river_node.AppendChild(banks_thk_node);
                river_node.AppendChild(shallow_thk_node);
                river_node.AppendChild(deep_thk_node);
                river_node.AppendChild(room_thk_node);
                river_node.AppendChild(shore_thk_node);
                river_node.AppendChild(shallows_thk_node);

                add_node_and_save(xdoc_KVP.Key, xdoc_KVP.Value, river_node);
            }
        }

        private void add_lake_btn_Click(object sender, EventArgs e)
        {
            if (dungeon_listbox.SelectedIndex >= 0)
            {
                river_type_listbox.SelectedIndex = 0;

                KeyValuePair<XmlDocument, string> xdoc_KVP = load_document();
                XmlDocument xdoc = xdoc_KVP.Key;

                XmlNode lake_node = create_base_node(xdoc, "Lake");

                XmlNode banks_thk_node = xdoc.CreateElement("River_Shore_Thickness");
                banks_thk_node.InnerText = "-1";

                XmlNode shallow_thk_node = xdoc.CreateElement("River_Shallows_Thickness");
                shallow_thk_node.InnerText = "-1";

                XmlNode deep_thk_node = xdoc.CreateElement("River_Depths_Thickness");
                deep_thk_node.InnerText = "-1";

                XmlNode room_thk_node = xdoc.CreateElement("Lake_Room_Thickness");
                room_thk_node.InnerText = rocksbanks_thk_numeric.Value.ToString();

                XmlNode shore_thk_node = xdoc.CreateElement("Lake_Shore_Thickness");
                shore_thk_node.InnerText = shoreshallow_thk_numeric.Value.ToString();

                XmlNode shallows_thk_node = xdoc.CreateElement("Lake_Shallows_Thickness");
                shallows_thk_node.InnerText = shallowdeep_thk_numeric.Value.ToString();

                lake_node.AppendChild(banks_thk_node);
                lake_node.AppendChild(shallow_thk_node);
                lake_node.AppendChild(deep_thk_node);
                lake_node.AppendChild(room_thk_node);
                lake_node.AppendChild(shore_thk_node);
                lake_node.AppendChild(shallows_thk_node);

                add_node_and_save(xdoc_KVP.Key, xdoc_KVP.Value, lake_node);
            }
        }
    }
}
