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
    public partial class PromptEditForm : Form
    {
        XmlDocument petaer_promptDoc;
        XmlDocument ziktofel_promptDoc;
        XmlDocument halephon_promptDoc;
        XmlDocument falsael_promptDoc;

        string petaer_promptPath;
        string ziktofel_promptPath;
        string halephon_promptPath;
        string falsael_promptPath;

        XmlDocument targetDocument;
        string targetPath;

        public PromptEditForm(ref XmlDocument pPrompts, string pPromptsPath,
                              ref XmlDocument zPrompts, string zPromptsPath,
                              ref XmlDocument hPrompts, string hPromptsPath,
                              ref XmlDocument fPrompts, string fPromptsPath)
        {
            petaer_promptDoc = pPrompts;
            petaer_promptPath = pPromptsPath;
            ziktofel_promptDoc = zPrompts;
            ziktofel_promptPath = zPromptsPath;
            halephon_promptDoc = hPrompts;
            halephon_promptPath = hPromptsPath;
            falsael_promptDoc = fPrompts;
            falsael_promptPath = fPromptsPath;

            InitializeComponent();
        }

        private void ShopPromptClearAll_Click(object sender, EventArgs e)
        {
            ShopPromptCurPrompt.Items.Clear();
        }

        private void ShopPromptClearRecent_Click(object sender, EventArgs e)
        {
            ShopPromptCurPrompt.Items.RemoveAt(ShopPromptCurPrompt.Items.Count - 1);
        }

        private void ShopPromptAddLine_Click(object sender, EventArgs e)
        {
            if(ShopPromptCurPrompt.Items.Count < 11)
                ShopPromptCurPrompt.Items.Add(ShopPromptNextLine.Text);
        }

        private void ShopPromptAppendPrompt_Click(object sender, EventArgs e)
        {
            switch (ShopPromptCharSel.Items[ShopPromptCharSel.SelectedIndex].ToString())
            {
                case "Petaer":
                    targetDocument = petaer_promptDoc;
                    targetPath = petaer_promptPath;
                    break;
                case "Ziktofel":
                    targetDocument = ziktofel_promptDoc;
                    targetPath = ziktofel_promptPath;
                    break;
                case "Halephon":
                    targetDocument = halephon_promptDoc;
                    targetPath = halephon_promptPath;
                    break;
                case "Falsael":
                    targetDocument = falsael_promptDoc;
                    targetPath = falsael_promptPath;
                    break;
            }

            XmlNode targetNode = targetDocument.SelectSingleNode("XnaContent/Asset");

            XmlNode PromptNode = targetDocument.CreateElement("Item");

            XmlNode ShopSectionNode = targetDocument.CreateElement("Shop_Section");
            ShopSectionNode.InnerText = ShopPromptShopSection.Items[ShopPromptShopSection.SelectedIndex].ToString();
            XmlNode ThePrompt = targetDocument.CreateElement("Prompt_Text");
            for (int i = 0; i < ShopPromptCurPrompt.Items.Count; i++)
            {
                XmlNode nextLine = targetDocument.CreateElement("Item");
                nextLine.InnerText = ShopPromptCurPrompt.Items[i].ToString();
                ThePrompt.AppendChild(nextLine);
            }

            PromptNode.AppendChild(ShopSectionNode);
            PromptNode.AppendChild(ThePrompt);

            targetNode.AppendChild(PromptNode);

            targetDocument.Save(targetPath);
            targetDocument.Load(targetPath);
        }
    }
}
