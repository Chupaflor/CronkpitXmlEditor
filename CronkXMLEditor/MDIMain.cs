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
    public partial class MDIMain : Form
    {
        XmlDocument weaponDoc = new XmlDocument();
        XmlDocument armorDoc = new XmlDocument();
        XmlDocument potionDoc = new XmlDocument();
        XmlDocument scrollDoc = new XmlDocument();
        XmlDocument descDoc = new XmlDocument();
        XmlDocument petaer_prompts = new XmlDocument();
        XmlDocument ziktofel_prompts = new XmlDocument();
        XmlDocument halephon_prompts = new XmlDocument();
        XmlDocument falsael_prompts = new XmlDocument();

        string wDocPath;
        string aDocPath;
        string pDocPath;
        string sDocPath;
        string descDocPath;
        string petaer_promptsPath;
        string ziktofel_promptsPath;
        string halephon_promptsPath;
        string falsael_promptsPath;

        string[] pathList = new string[9];

        private void MDIMain_Load(object sender, EventArgs e)
        {
            string basepath = Application.StartupPath;
            wDocPath = basepath + "\\weapons.xml";
            aDocPath = basepath + "\\armors.xml";
            pDocPath = basepath + "\\potions.xml";
            sDocPath = basepath + "\\scrolls.xml";
            descDocPath = basepath + "\\classdescriptions.xml";
            petaer_promptsPath = basepath + "\\petaer_prompts.xml";
            ziktofel_promptsPath = basepath + "\\ziktofel_prompts.xml";
            halephon_promptsPath = basepath + "\\halephon_prompts.xml";
            falsael_promptsPath = basepath + "\\falsael_prompts.xml";

            pathList[0] = wDocPath;
            pathList[1] = aDocPath;
            pathList[2] = pDocPath;
            pathList[3] = sDocPath;
            pathList[4] = descDocPath;
            pathList[5] = petaer_promptsPath;
            pathList[6] = ziktofel_promptsPath;
            pathList[7] = halephon_promptsPath;
            pathList[8] = falsael_promptsPath;

            for (int i = 0; i < pathList.Count(); i++)
            {
                if (!File.Exists(pathList[i]))
                {
                    XmlDocument xDoc = new XmlDocument();
                    XmlNode rootNode = xDoc.CreateElement("XnaContent");
                    xDoc.AppendChild(rootNode);

                    XmlNode assetNode = xDoc.CreateElement("Asset");
                    XmlAttribute assetAttribute = xDoc.CreateAttribute("Type");
                    switch (i)
                    {
                        case 0:
                            assetAttribute.Value = "CKPLibrary.WeaponDC[]";
                            break;
                        case 1:
                            assetAttribute.Value = "CKPLibrary.ArmorDC[]";
                            break;
                        case 2:
                            assetAttribute.Value = "CKPLibrary.PotionDC[]";
                            break;
                        case 3:
                            assetAttribute.Value = "CKPLibrary.ScrollDC[]";
                            break;
                        case 4:
                            assetAttribute.Value = "CKPLibrary.ClassDescDC[]";
                            break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                            assetAttribute.Value = "CKPLibrary.ShopPromptDC[]";
                            break;
                    }
                    assetNode.Attributes.Append(assetAttribute);

                    rootNode.AppendChild(assetNode);

                    xDoc.Save(pathList[i]);
                }
            }

            weaponDoc.Load(wDocPath);
            armorDoc.Load(aDocPath);
            potionDoc.Load(pDocPath);
            scrollDoc.Load(sDocPath);
            descDoc.Load(descDocPath);
            petaer_prompts.Load(petaer_promptsPath);
            ziktofel_prompts.Load(ziktofel_promptsPath);
            halephon_prompts.Load(halephon_promptsPath);
            falsael_prompts.Load(falsael_promptsPath);
        }

        public MDIMain()
        {
            InitializeComponent();
        }

        #region tool strip menu functions

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void itemWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemEditForm itemEditForm = new ItemEditForm(ref weaponDoc, wDocPath,
                                                         ref armorDoc, aDocPath,
                                                         ref potionDoc, pDocPath,
                                                         ref scrollDoc, sDocPath);
            itemEditForm.MdiParent = this;
            itemEditForm.Show();
        }

        private void shopPromptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromptEditForm promptEditForm = new PromptEditForm(ref petaer_prompts, petaer_promptsPath,
                                                               ref ziktofel_prompts, ziktofel_promptsPath,
                                                               ref halephon_prompts, halephon_promptsPath,
                                                               ref falsael_prompts, falsael_promptsPath);
            promptEditForm.MdiParent = this;
            promptEditForm.Show();
        }

        private void classDescriptionEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassDescEditor cDescEditor = new ClassDescEditor(ref descDoc, descDocPath);
            cDescEditor.MdiParent = this;
            cDescEditor.Show();
        }

        #endregion   
    }
}
