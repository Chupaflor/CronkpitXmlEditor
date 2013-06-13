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
    public partial class ItemEditForm : Form
    {
        XmlDocument weaponDoc;
        XmlDocument armorDoc;
        XmlDocument potionDoc;
        XmlDocument scrollDoc;

        string wDocPath;
        string aDocPath;
        string pDocPath;
        string sDocPath;

        string[] pathList = new string[4];

        XmlNode targetNode;
        static string dup_errmsg = "Cannot add duplicate ID number.";

        public ItemEditForm(ref XmlDocument wDoc, string wDocP,
                            ref XmlDocument aDoc, string aDocP,
                            ref XmlDocument pDoc, string pDocP,
                            ref XmlDocument sDoc, string sDocP)
        {
            weaponDoc = wDoc;
            wDocPath = wDocP;
            armorDoc = aDoc;
            aDocPath = aDocP;
            potionDoc = pDoc;
            pDocPath = pDocP;
            scrollDoc = sDoc;
            sDocPath = sDocP;
            InitializeComponent();
        }

        private void AddPotion_Click(object sender, EventArgs e)
        {
            targetNode = potionDoc.SelectSingleNode("XnaContent/Asset");
            XmlNode potionNode = potionDoc.CreateNode(XmlNodeType.Element, "Item", null);

            add_universal_properties(potionDoc, potionNode);

            XmlNode potionType = potionDoc.CreateElement("PotionType");
            potionType.InnerText = PotionType.Items[PotionType.SelectedIndex].ToString();
            XmlNode potionPower = potionDoc.CreateElement("PotionPotency");
            potionPower.InnerText = PotionPotency.Value.ToString();

            potionNode.AppendChild(potionType);
            potionNode.AppendChild(potionPower);

            bool isDup = is_duplicate((int)ItemIDNO.Value);

            if (!isDup)
                process_final_node(potionDoc, pDocPath, potionNode);
            else
                errorProv.SetError(AddPotion, dup_errmsg);
        }

        private void AddArmor_Click(object sender, EventArgs e)
        {
            targetNode = armorDoc.SelectSingleNode("XnaContent/Asset");
            XmlNode armorNode = armorDoc.CreateNode(XmlNodeType.Element, "Item", null);

            add_universal_properties(armorDoc, armorNode);

            XmlNode armorAbValNode = armorDoc.CreateElement("AbVal");
            armorAbValNode.InnerText = ArmorAbValue.Value.ToString();
            XmlNode armorInsValNode = armorDoc.CreateElement("InsVal");
            armorInsValNode.InnerText = ArmorInsValue.Value.ToString();
            XmlNode armorPadValNode = armorDoc.CreateElement("PadVal");
            armorPadValNode.InnerText = ArmorPadValue.Value.ToString();
            XmlNode armorRigValNode = armorDoc.CreateElement("RigVal");
            armorRigValNode.InnerText = ArmorRigValue.Value.ToString();
            XmlNode armorHardValNode = armorDoc.CreateElement("HardVal");
            armorHardValNode.InnerText = ArmorHdValue.Value.ToString();
            XmlNode armorIntegValNode = armorDoc.CreateElement("Integrity");
            armorIntegValNode.InnerText = ArmorInteg.Value.ToString();
            XmlNode armorTypeNode = armorDoc.CreateElement("ArmorType");
            if (ArmorOverArmor.Checked)
                armorTypeNode.InnerText = "Overarmor";
            else if (ArmorUnderArmor.Checked)
                armorTypeNode.InnerText = "Underarmor";
            else if (ArmorHelmet.Checked)
                armorTypeNode.InnerText = "Helmet";

            armorNode.AppendChild(armorAbValNode);
            armorNode.AppendChild(armorInsValNode);
            armorNode.AppendChild(armorPadValNode);
            armorNode.AppendChild(armorRigValNode);
            armorNode.AppendChild(armorHardValNode);
            armorNode.AppendChild(armorIntegValNode);
            armorNode.AppendChild(armorTypeNode);

            bool isDup = is_duplicate((int)ItemIDNO.Value);
            if (!isDup)
                process_final_node(armorDoc, aDocPath, armorNode);
            else
                errorProv.SetError(AddArmor, dup_errmsg); 
        }

        private void AddWeapon_Click(object sender, EventArgs e)
        {
            targetNode = weaponDoc.SelectSingleNode("XnaContent/Asset");
            XmlNode weaponNode = weaponDoc.CreateNode(XmlNodeType.Element, "Item", null);

            add_universal_properties(weaponDoc, weaponNode);

            XmlNode weaponTypeNode = weaponDoc.CreateElement("WeaponType");
            weaponTypeNode.InnerText = WeaponType.Items[WeaponType.SelectedIndex].ToString();
            XmlNode weaponHandNode = weaponDoc.CreateElement("Hands");
            weaponHandNode.InnerText = WeaponHands.Value.ToString();
            XmlNode weaponMinDmgNode = weaponDoc.CreateElement("MinDamage");
            weaponMinDmgNode.InnerText = WeaponMinDmg.Value.ToString();
            XmlNode weaponMaxDmgNode = weaponDoc.CreateElement("MaxDamage");
            weaponMaxDmgNode.InnerText = WeaponMaxDmg.Value.ToString();
            XmlNode weaponRangeNode = weaponDoc.CreateElement("WeaponRange");
            weaponRangeNode.InnerText = WeaponRange.Value.ToString();

            weaponNode.AppendChild(weaponTypeNode);
            weaponNode.AppendChild(weaponHandNode);
            weaponNode.AppendChild(weaponMinDmgNode);
            weaponNode.AppendChild(weaponMaxDmgNode);
            weaponNode.AppendChild(weaponRangeNode);

            bool isDup = is_duplicate((int)ItemIDNO.Value);

            if (!isDup)
                process_final_node(weaponDoc, wDocPath, weaponNode);
            else
                errorProv.SetError(AddWeapon, dup_errmsg);
        }

        private void AddScroll_Click(object sender, EventArgs e)
        {
            targetNode = scrollDoc.SelectSingleNode("XnaContent/Asset");
            XmlNode scrollNode = scrollDoc.CreateNode(XmlNodeType.Element, "Item", null);

            add_universal_properties(scrollDoc, scrollNode);

            XmlNode scrollAOETypeNode = scrollDoc.CreateElement("AOEType");
            scrollAOETypeNode.InnerText = ScrollAOEType.Items[ScrollAOEType.SelectedIndex].ToString();
            XmlNode scrollTierNode = scrollDoc.CreateElement("ScrollTier");
            scrollTierNode.InnerText = ScrollTier.Value.ToString();
            XmlNode scrollManaCostNode = scrollDoc.CreateElement("ManaCost");
            scrollManaCostNode.InnerText = ScrollManaCost.Value.ToString();
            XmlNode scrollRangeNode = scrollDoc.CreateElement("ScrollRange");
            scrollRangeNode.InnerText = ScrollRange.Value.ToString();
            XmlNode scrollAOESizeNode = scrollDoc.CreateElement("AOESize");
            scrollAOESizeNode.InnerText = ScrollAOESize.Value.ToString();
            XmlNode scrollMinDmgNode = scrollDoc.CreateElement("MinDamage");
            scrollMinDmgNode.InnerText = ScrollMinDmg.Value.ToString();
            XmlNode scrollMaxDmgNode = scrollDoc.CreateElement("MaxDamage");
            scrollMaxDmgNode.InnerText = ScrollMaxDmg.Value.ToString();
            XmlNode scrollDmgTypeNode = scrollDoc.CreateElement("DamageType");
            scrollDmgTypeNode.InnerText = ScrollDmgTyp.Items[ScrollDmgTyp.SelectedIndex].ToString();
            XmlNode scrollDestroyWallsNode = scrollDoc.CreateElement("DestroysWalls");
            string destroywalltxt = "";
            if (ScrollDestroysWalls.Checked)
                destroywalltxt = "true";
            else
                destroywalltxt = "false";
            scrollDestroyWallsNode.InnerText = destroywalltxt;
            XmlNode scrollMeleeSpellNode = scrollDoc.CreateElement("MeleeSpell");
            string meleespelltxt = "";
            if (ScrollMeleeSpell.Checked)
                meleespelltxt = "true";
            else
                meleespelltxt = "false";
            scrollMeleeSpellNode.InnerText = meleespelltxt;
            XmlNode scrollBoltBouncesNode = scrollDoc.CreateElement("ChainImpacts");
            scrollBoltBouncesNode.InnerText = ScrollChainImpacts.Value.ToString();
            XmlNode scrollPrjTypeNode = scrollDoc.CreateElement("SpellProjectile");
            scrollPrjTypeNode.InnerText = ScrollProjType.Items[ScrollProjType.SelectedIndex].ToString();
            XmlNode scrollSpecAnimNode = scrollDoc.CreateElement("SpecialAnimation");
            scrollSpecAnimNode.InnerText = ScrollSpecAnim.Items[ScrollSpecAnim.SelectedIndex].ToString();
            XmlNode scrollBuffDebuffNode = scrollDoc.CreateElement("SpellSpecialEffect");
            scrollBuffDebuffNode.InnerText = ScrollBuffDebuff.Items[ScrollBuffDebuff.SelectedIndex].ToString();
            XmlNode scrollBuffDebuffDurationNode = scrollDoc.CreateElement("SpecialEffectDuration");
            scrollBuffDebuffDurationNode.InnerText = ScrollBuffDuration.Value.ToString();

            scrollNode.AppendChild(scrollAOETypeNode);
            scrollNode.AppendChild(scrollTierNode);
            scrollNode.AppendChild(scrollManaCostNode);
            scrollNode.AppendChild(scrollRangeNode);
            scrollNode.AppendChild(scrollAOESizeNode);
            scrollNode.AppendChild(scrollMinDmgNode);
            scrollNode.AppendChild(scrollMaxDmgNode);
            scrollNode.AppendChild(scrollDmgTypeNode);
            scrollNode.AppendChild(scrollDestroyWallsNode);
            scrollNode.AppendChild(scrollMeleeSpellNode);
            scrollNode.AppendChild(scrollBoltBouncesNode);
            scrollNode.AppendChild(scrollPrjTypeNode);
            scrollNode.AppendChild(scrollSpecAnimNode);
            scrollNode.AppendChild(scrollBuffDebuffNode);
            scrollNode.AppendChild(scrollBuffDebuffDurationNode);

            bool isDup = is_duplicate((int)ItemIDNO.Value);

            if (!isDup)
                process_final_node(scrollDoc, sDocPath, scrollNode);
            else
                errorProv.SetError(AddScroll, dup_errmsg);
        }

        private void CalcArmorDef_Click(object sender, EventArgs e)
        {
            ArmorDialog adiag = new ArmorDialog((int)ArmorAbValue.Value,
                                                (int)ArmorInsValue.Value,
                                                (int)ArmorPadValue.Value,
                                                (int)ArmorRigValue.Value,
                                                (int)ArmorHdValue.Value);
            adiag.Show();
        }

        //Non-button functions that are repeated in button functions.
        //Non-returning or boolean functions

        private bool is_duplicate(int IDnum)
        {
            List<XmlNodeList> full_nodelist = new List<XmlNodeList>();

            full_nodelist.Add(weaponDoc.SelectNodes("XnaContent/Asset/Item/IDNumber"));
            full_nodelist.Add(armorDoc.SelectNodes("XnaContent/Asset/Item/IDNumber"));
            full_nodelist.Add(potionDoc.SelectNodes("XnaContent/Asset/Item/IDNumber"));
            full_nodelist.Add(scrollDoc.SelectNodes("XnaContent/Asset/Item/IDNumber"));

            bool isDup = false;
            for (int i = 0; i < full_nodelist.Count; i++)
            {
                foreach (XmlNode n in full_nodelist[i])
                {
                    int IDno = 0;
                    Int32.TryParse(n.InnerText, out IDno);
                    if (ItemIDNO.Value == IDno)
                        isDup = true;
                }
            }
            return isDup;
        }

        private void clear_all_inputs()
        {
            //Universal properties
            ItemIDNO.Value = 0;
            ItemCost.Value = 0;
            ItemName.Clear();
            ItemTier.Value = 0;
            ItemClasses.ClearSelected();

            //Potion properties
            PotionType.SelectedIndex = -1;
            PotionPotency.Value = 0;

            //Armor properties
            ArmorAbValue.Value = 0;
            ArmorPadValue.Value = 0;
            ArmorRigValue.Value = 0;
            ArmorInsValue.Value = 0;
            ArmorHdValue.Value = 0;
            ArmorInteg.Value = 0;
            ArmorOverArmor.Checked = false;
            ArmorUnderArmor.Checked = false;
            ArmorHelmet.Checked = false;

            //Weapon properties
            WeaponHands.Value = 1;
            WeaponMaxDmg.Value = 0;
            WeaponMinDmg.Value = 0;
            WeaponRange.Value = 1;
            WeaponType.ClearSelected();

            //Scroll properties
        }

        //Functions dedicated to processing XmlNodes
        private XmlNode add_universal_properties(XmlDocument targetDoc, XmlNode baseNode)
        {
            XmlNode itemID = targetDoc.CreateElement("IDNumber");
            itemID.InnerText = ItemIDNO.Value.ToString();
            XmlNode itemCost = targetDoc.CreateElement("Cost");
            itemCost.InnerText = ItemCost.Value.ToString();
            XmlNode itemName = targetDoc.CreateElement("Name");
            itemName.InnerText = ItemName.Text;
            XmlNode itemTier = targetDoc.CreateElement("ItemTier");
            itemTier.InnerText = ItemTier.Value.ToString();
            XmlNode itemAvail = targetDoc.CreateElement("ValidClasses");
            string validClasses = "";
            for (int i = 0; i < ItemClasses.CheckedItems.Count; i++)
                validClasses += ItemClasses.CheckedItems[i].ToString() + " ";
            itemAvail.InnerText = validClasses;

            baseNode.AppendChild(itemID);
            baseNode.AppendChild(itemCost);
            baseNode.AppendChild(itemName);
            baseNode.AppendChild(itemTier);
            baseNode.AppendChild(itemAvail);

            return baseNode;
        }

        private void process_final_node(XmlDocument targetDoc, string targetPath, XmlNode finalNode)
        {
            errorProv.Clear();
            targetNode.AppendChild(finalNode);

            clear_all_inputs();
            targetDoc.Save(targetPath);
            targetDoc.Load(targetPath);
        }

        private void save_all_xmlDocs()
        {
            weaponDoc.Save(wDocPath);
            armorDoc.Save(aDocPath);
            potionDoc.Save(pDocPath);
            scrollDoc.Save(sDocPath);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            save_all_xmlDocs();
        }
    }
}
