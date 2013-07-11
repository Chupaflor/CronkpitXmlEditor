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
    public partial class SpawnTableEditorForm : Form
    {
        public enum Monster_Family { Skeleton, Large_Undead, Mimic, Goredog, Grendel, Ghost, Necromancer, SpiritKnight, Spirit, Zombie };
        public enum Monster_Type
        {
            Armored_Skeleton, Boneyard, CorpseMimic, Ghost, GoldMimic, Grendel, GoreHound, GoreWolf, HollowKnight, Necromancer,
            RedKnight, Skeleton, VoidWraith, Zombie, ZombieFanatic, LesserRevenant, WereGoreHound, Gangrenous_Shambler, Rotting_Amalgam
        };
        public enum Dungeons { Necropolis };

        XmlDocument necropolis_spawntables;
        string necropolis_spawnpath;

        List<KeyValuePair<Monster_Family, Monster_Type>> monster_family_assocs;
        //Lists of all items as they appear in the listbox.
        List<Monster_Family> monster_family_list;
        List<Monster_Type> single_monster_list;
        List<Dungeons> dungeon_list;

        //These get cleared.
        List<KeyValuePair<int, Monster_Family>> monster_family_spawnChance;
        List<KeyValuePair<int, Monster_Type>> monster_single_spawnChance;

        public SpawnTableEditorForm(ref XmlDocument necro_spawntable, string necro_spawntable_path)
        {
            InitializeComponent();

            necropolis_spawntables = necro_spawntable;
            necropolis_spawnpath = necro_spawntable_path;

            monster_family_assocs = new List<KeyValuePair<Monster_Family, Monster_Type>>();
            monster_family_spawnChance = new List<KeyValuePair<int, Monster_Family>>();
            monster_single_spawnChance = new List<KeyValuePair<int, Monster_Type>>();
            monster_family_list = new List<Monster_Family>();
            single_monster_list = new List<Monster_Type>();
            dungeon_list = new List<Dungeons>();

            necropolis_spawntables.Load(necropolis_spawnpath);

            build_all_lists();
        }

        private void build_all_lists()
        {
            //Build the KVP list for monsters / families
            //All skeleton family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Skeleton, Monster_Type.Armored_Skeleton));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Skeleton, Monster_Type.Skeleton));

            //All Large_Undead family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Large_Undead, Monster_Type.Boneyard));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Large_Undead, Monster_Type.Gangrenous_Shambler));

            //All Mimic family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Mimic, Monster_Type.CorpseMimic));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Mimic, Monster_Type.GoldMimic));

            //All Goredog family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Goredog, Monster_Type.GoreHound));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Goredog, Monster_Type.GoreWolf));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Goredog, Monster_Type.WereGoreHound));

            //All Grendel family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Grendel, Monster_Type.Grendel));

            //All Ghost family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Ghost, Monster_Type.Ghost));

            //All Necromancer family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Necromancer, Monster_Type.Necromancer));

            //All SpiritKnight family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.SpiritKnight, Monster_Type.HollowKnight));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.SpiritKnight, Monster_Type.RedKnight));

            //All Spirit family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Spirit, Monster_Type.VoidWraith));

            //All Zombie family monsters
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Zombie, Monster_Type.Zombie));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Zombie, Monster_Type.ZombieFanatic));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Zombie, Monster_Type.LesserRevenant));
            monster_family_assocs.Add(new KeyValuePair<Monster_Family, Monster_Type>(Monster_Family.Zombie, Monster_Type.Rotting_Amalgam));

            //Build the list for monsters
            single_monster_list.Add(Monster_Type.Armored_Skeleton);
            single_monster_list.Add(Monster_Type.Boneyard);
            single_monster_list.Add(Monster_Type.Gangrenous_Shambler);
            single_monster_list.Add(Monster_Type.CorpseMimic);
            single_monster_list.Add(Monster_Type.Ghost);
            single_monster_list.Add(Monster_Type.GoldMimic);
            single_monster_list.Add(Monster_Type.GoreHound);
            single_monster_list.Add(Monster_Type.GoreWolf);
            single_monster_list.Add(Monster_Type.WereGoreHound);
            single_monster_list.Add(Monster_Type.HollowKnight);
            single_monster_list.Add(Monster_Type.Necromancer);
            single_monster_list.Add(Monster_Type.RedKnight);
            single_monster_list.Add(Monster_Type.Skeleton);
            single_monster_list.Add(Monster_Type.VoidWraith);
            single_monster_list.Add(Monster_Type.Zombie);
            single_monster_list.Add(Monster_Type.ZombieFanatic);
            single_monster_list.Add(Monster_Type.LesserRevenant);
            single_monster_list.Add(Monster_Type.Rotting_Amalgam);

            //Build the list for families
            monster_family_list.Add(Monster_Family.Skeleton);
            monster_family_list.Add(Monster_Family.Large_Undead);
            monster_family_list.Add(Monster_Family.Mimic);
            monster_family_list.Add(Monster_Family.Goredog);
            monster_family_list.Add(Monster_Family.Grendel);
            monster_family_list.Add(Monster_Family.Ghost);
            monster_family_list.Add(Monster_Family.Necromancer);
            monster_family_list.Add(Monster_Family.SpiritKnight);
            monster_family_list.Add(Monster_Family.Spirit);
            monster_family_list.Add(Monster_Family.Zombie);

            //Build the list for dungeons.
            dungeon_list.Add(Dungeons.Necropolis);
        }

        private void item_2_tbl_btn_Click(object sender, EventArgs e)
        {
            int chance = (int)spawn_chance_numeric.Value;
            //Start with the assumption that we add the value to the table.
            //if we find that the value is already there, adjust the % chance instead.
            if (single_monster_listbox.SelectedIndex > -1)
            {
                Monster_Type m_type = single_monster_list[single_monster_listbox.SelectedIndex];

                bool add_to_table = true;
                for(int i = 0; i < monster_single_spawnChance.Count; i++)
                    if(m_type == monster_single_spawnChance[i].Value)
                    {
                        add_to_table = false;
                        monster_single_spawnChance[i] = new KeyValuePair<int,Monster_Type>(chance, m_type);
                    }
                
                //At this point, we know whether or not we've found a duplicate entry. If we have...
                if (add_to_table)
                {
                    //First find out if the family can spawn.
                    //To do that - first find out the family that the monster is from.

                    //This is a bogus value. It's because the value is guaranteed to be set in the next section
                    //And we want to throw an exception if it's not.
                    Monster_Family m_family = (Monster_Family)(-1);
                    for (int i = 0; i < monster_family_assocs.Count; i++)
                    {
                        if (monster_family_assocs[i].Value == m_type)
                            m_family = monster_family_assocs[i].Key;
                    }
                    //Then we try and find out if the monster's family has a chance to spawn
                    bool can_add = false;
                    if (monster_in_family(m_family, m_type))
                        can_add = true;

                    //Then add it to the list.
                    if (can_add)
                    {
                        monster_single_spawnChance.Add(new KeyValuePair<int, Monster_Type>(chance, m_type));
                        calculate_overall_spawnchances();
                    }
                }
            }
            else if (monster_family_listbox.SelectedIndex > -1)
            {
                Monster_Family m_family = monster_family_list[monster_family_listbox.SelectedIndex];
                bool add_to_table = true;
                for (int i = 0; i < monster_family_spawnChance.Count; i++)
                    if (m_family == monster_family_spawnChance[i].Value)
                    {
                        add_to_table = false;
                        monster_family_spawnChance[i] = new KeyValuePair<int, Monster_Family>(chance, m_family);
                    }

                if (add_to_table)
                {
                    //Add the family to the list.
                    monster_family_spawnChance.Add(new KeyValuePair<int, Monster_Family>(chance, m_family));
                    family_spawnchance_listbox.Items.Add(m_family.ToString() + " - " + chance.ToString() + "%");
                }
            }
        }

        private void monster_family_listbox_Click(object sender, EventArgs e)
        {
            single_monster_listbox.SelectedIndex = -1;
        }

        private void single_monster_listbox_Click(object sender, EventArgs e)
        {
            monster_family_listbox.SelectedIndex = -1;
        }

        private void family_spawnchance_listbox_Click(object sender, EventArgs e)
        {
            mspawn_byfamily_listbox.Items.Clear();
            mspawn_byfamily_listbox.SelectedIndex = -1;

            Monster_Family target_family = monster_family_spawnChance[family_spawnchance_listbox.SelectedIndex].Value;
            for (int i = 0; i < monster_single_spawnChance.Count; i++)
            {
                if (monster_in_family(target_family, monster_single_spawnChance[i].Value))
                    mspawn_byfamily_listbox.Items.Add(monster_single_spawnChance[i].Value.ToString() + " - " + monster_single_spawnChance[i].Key.ToString() + "%");
            }
        }

        private void calculate_overall_spawnchances()
        {
            spawnchance_listbox.Items.Clear();
            for (int i = 0; i < monster_family_spawnChance.Count; i++)
            {
                Monster_Family target_family = monster_family_spawnChance[i].Value;
                double target_spawn_chance = (double)monster_family_spawnChance[i].Key / 100;
                for (int j = 0; j < monster_single_spawnChance.Count; j++)
                {
                    Monster_Type target_monster = monster_single_spawnChance[j].Value;
                    if(monster_in_family(target_family, target_monster))
                    {
                        double monster_spawn_chance = (double)monster_single_spawnChance[j].Key / 100;
                        double overall_monster_spawn_chance = (target_spawn_chance * monster_spawn_chance) * 100;

                        spawnchance_listbox.Items.Add(target_monster.ToString() + " - " + overall_monster_spawn_chance.ToString() + "%");
                    }
                }
            }
        }

        private bool monster_in_family(Monster_Family m_family, Monster_Type m_type)
        {
            for (int i = 0; i < monster_family_assocs.Count; i++)
                if (monster_family_assocs[i].Key == m_family &&
                   monster_family_assocs[i].Value == m_type)
                    return true;
            return false;
        }

        private void compress_to_xmlDoc(XmlDocument targetDocument, string targetPath)
        {
            //Make 4 different lists<>, monster families/chances and single monsters/chances.
            XmlNode targetNode = targetDocument.SelectSingleNode("XnaContent/Asset");
            XmlNode tableNode = targetDocument.CreateElement("Item");

            XmlNode floorNumberNode = targetDocument.CreateElement("FloorNumber");
            floorNumberNode.InnerText = floor_number_numeric.Value.ToString();

            //Families first
            XmlNode monsterFamilyNode = targetDocument.CreateElement("Monster_Families");
            string spawn_chances = "";
            for (int i = 0; i < monster_family_spawnChance.Count; i++)
            {
                spawn_chances += monster_family_spawnChance[i].Key.ToString() + " ";
                XmlNode monsterFamilyNodeItem = targetDocument.CreateElement("Item");
                monsterFamilyNodeItem.InnerText = monster_family_spawnChance[i].Value.ToString();
                monsterFamilyNode.AppendChild(monsterFamilyNodeItem);
            }
            spawn_chances = spawn_chances.Trim();
            XmlNode monsterFamilyChanceNode = targetDocument.CreateElement("Family_Spawnchance");
            monsterFamilyChanceNode.InnerText = spawn_chances;

            //Then single monsters
            XmlNode singleMonsterNode = targetDocument.CreateElement("Single_Monsters");
            spawn_chances = "";
            for (int i = 0; i < monster_single_spawnChance.Count; i++)
            {
                spawn_chances += monster_single_spawnChance[i].Key.ToString() + " ";
                XmlNode monsterSpawnItem = targetDocument.CreateElement("Item");
                monsterSpawnItem.InnerText = monster_single_spawnChance[i].Value.ToString();
                singleMonsterNode.AppendChild(monsterSpawnItem);
            }
            spawn_chances = spawn_chances.Trim();
            XmlNode singleMonsterChanceNode = targetDocument.CreateElement("Monster_Spawnchance");
            singleMonsterChanceNode.InnerText = spawn_chances;

            tableNode.AppendChild(floorNumberNode);
            tableNode.AppendChild(monsterFamilyNode);
            tableNode.AppendChild(monsterFamilyChanceNode);
            tableNode.AppendChild(singleMonsterNode);
            tableNode.AppendChild(singleMonsterChanceNode);

            targetNode.AppendChild(tableNode);

            targetDocument.Save(targetPath);
            targetDocument.Load(targetPath);
        }

        private void tbl_2_file_btn_Click(object sender, EventArgs e)
        {
            if (dungeon_listbox.SelectedIndex > -1)
            {
                Dungeons target_dungeon = dungeon_list[dungeon_listbox.SelectedIndex];
                switch (target_dungeon)
                {
                    case Dungeons.Necropolis:
                        compress_to_xmlDoc(necropolis_spawntables, necropolis_spawnpath);
                        break;
                }
            }
            //Otherwise do nothing.
        }

        private void clear_tbl_btn_Click(object sender, EventArgs e)
        {
            monster_family_spawnChance.Clear();
            monster_single_spawnChance.Clear();
            family_spawnchance_listbox.Items.Clear();
            mspawn_byfamily_listbox.Items.Clear();
            spawnchance_listbox.Items.Clear();
        }
    }
}
