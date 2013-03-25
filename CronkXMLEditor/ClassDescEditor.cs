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
    public partial class ClassDescEditor : Form
    {
        XmlDocument descDoc;
        string descDocPath;

        public ClassDescEditor(ref XmlDocument dDoc, string dDocP)  
        {
            descDoc = dDoc;
            descDocPath = dDocP;
            InitializeComponent();
        }

        //Button click functions.
        private void ClassRemoveLine_Click(object sender, EventArgs e)
        {
            ClassDescLines.Items.RemoveAt(ClassDescLines.Items.Count - 1);
        }

        private void ClassAddLine_Click(object sender, EventArgs e)
        {
            ClassDescLines.Items.Add(ClassDescNextLine.Text);
            ClassDescNextLine.Clear();
        }

        private void ClassDescAppend_Click(object sender, EventArgs e)
        {
            XmlNode targetNode = descDoc.SelectSingleNode("XnaContent/Asset");

            XmlNode DescNode = descDoc.CreateElement("Item");

            XmlNode DescClassNode = descDoc.CreateElement("Selected_Class");
            DescClassNode.InnerText = ClassDescClass.Items[ClassDescClass.SelectedIndex].ToString();
            XmlNode DescActualDesc = descDoc.CreateElement("Description");
            for (int i = 0; i < ClassDescLines.Items.Count; i++)
            {
                XmlNode nextLine = descDoc.CreateElement("Item");
                nextLine.InnerText = ClassDescLines.Items[i].ToString();
                DescActualDesc.AppendChild(nextLine);
            }

            DescNode.AppendChild(DescClassNode);
            DescNode.AppendChild(DescActualDesc);

            targetNode.AppendChild(DescNode);

            descDoc.Save(descDocPath);
            descDoc.Load(descDocPath);
        }
    }
}
