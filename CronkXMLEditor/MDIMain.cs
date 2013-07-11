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

        //General floor documents.
        XmlDocument necro_floorDoc = new XmlDocument();
        XmlDocument gpeak_floorDoc = new XmlDocument();
        XmlDocument frunm_floorDoc = new XmlDocument();
        XmlDocument sunkn_floorDoc = new XmlDocument();

        //General room list:
        XmlDocument general_room_list = new XmlDocument();
        
        //Spawn table documents:
        XmlDocument necro_spawnDoc = new XmlDocument();

        string wDocPath;
        string aDocPath;
        string pDocPath;
        string sDocPath;
        string descDocPath;
        string petaer_promptsPath;
        string ziktofel_promptsPath;
        string halephon_promptsPath;
        string falsael_promptsPath;
        string necro_floorpath;
        string gpeak_floorpath;
        string frunm_floorpath;
        string sunkn_floorpath;
        string general_roompath;
        string necro_spawnpath;

        string[] pathList = new string[15];

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
            necro_floorpath = basepath + "\\necropolis_floors.xml";
            gpeak_floorpath = basepath + "\\gelidpeak_floors.xml";
            frunm_floorpath = basepath + "\\flamerunner_floors.xml";
            sunkn_floorpath = basepath + "\\sunkencit_floors.xml";
            general_roompath = basepath + "\\general_rooms.xml";
            necro_spawnpath = basepath + "\\necro_spawntables.xml";

            pathList[0] = wDocPath;
            pathList[1] = aDocPath;
            pathList[2] = pDocPath;
            pathList[3] = sDocPath;
            pathList[4] = descDocPath;
            pathList[5] = petaer_promptsPath;
            pathList[6] = ziktofel_promptsPath;
            pathList[7] = halephon_promptsPath;
            pathList[8] = falsael_promptsPath;
            pathList[9] = necro_floorpath;
            pathList[10] = gpeak_floorpath;
            pathList[11] = frunm_floorpath;
            pathList[12] = sunkn_floorpath;
            pathList[13] = general_roompath;
            pathList[14] = necro_spawnpath;

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
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            assetAttribute.Value = "CKPLibrary.FloorThemeDC[]";
                            break;
                        case 13:
                            assetAttribute.Value = "CKPLibrary.RoomDC[]";
                            break;
                        case 14:
                            assetAttribute.Value = "CKPLibrary.SpawnTableDC[]";
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
            //Floors.
            necro_floorDoc.Load(necro_floorpath);
            gpeak_floorDoc.Load(gpeak_floorpath);
            frunm_floorDoc.Load(frunm_floorpath);
            sunkn_floorDoc.Load(sunkn_floorpath);
            //Rooms
            general_room_list.Load(general_roompath);
            //Spawn tables
            necro_spawnDoc.Load(necro_spawnpath);
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

        private void dungeonThemeDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DungeonDesignerForm dungeonDesigner = new DungeonDesignerForm(ref necro_floorDoc, necro_floorpath,
                                                                          ref gpeak_floorDoc, gpeak_floorpath,
                                                                          ref frunm_floorDoc, frunm_floorpath,
                                                                          ref sunkn_floorDoc, sunkn_floorpath);
            dungeonDesigner.MdiParent = this;
            dungeonDesigner.Show();
        }

        #endregion        

        private void dungeonRoomDesignerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DungeonRoomEditorForm roomDesigner = new DungeonRoomEditorForm(ref general_room_list, general_roompath);
            roomDesigner.MdiParent = this;
            roomDesigner.Show();
        }

        private void spawnTableEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpawnTableEditorForm spawnDesigner = new SpawnTableEditorForm(ref necro_spawnDoc, necro_spawnpath);
            spawnDesigner.MdiParent = this;
            spawnDesigner.Show();
        }

        private void featureSpecifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeatureSpecificerForm featureSpecs = new FeatureSpecificerForm();
            featureSpecs.MdiParent = this;
            featureSpecs.Show();
        }
    }
}
