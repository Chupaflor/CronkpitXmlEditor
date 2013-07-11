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
    public partial class DungeonRoomEditorForm : Form
    {
        Bitmap roomPicture;
        Graphics roomGraphics;

        XmlDocument general_room_list;
        XmlNode target_node;
        string general_room_path;

        //Tiles
        tile_type[,] roomMatrix;
        //Anchors
        List<matrix_coord> hall_anchors;
        //Boss Spawns
        List<matrix_coord> boss_spawns;
        //Doodads
        string c_doodad_name;
        List<doodad_type> doodads;
        List<matrix_coord> doodad_coords;
        List<int> doodad_appearance_chances;
        //Enemies
        string c_monster_name;
        List<monster_type> monsters;
        List<matrix_coord> monster_coords;
        List<int> monster_appearance_chances;
        //Monster families
        string c_monster_family_name;
        List<monster_family_type> monster_families;
        List<matrix_coord> m_family_coords;
        List<int> m_family_appearance_chances;

        //Brush
        brush_mode current_brush_mode;
        //Tile brush control variables
        tile_type current_tile;
        Image current_tile_img;
        //Doodad brush control variables
        doodad_type current_doodad;
        Image current_doodad_img;
        //Monster brush control variables
        monster_type current_monster;
        Image current_monster_img;
        //Monster Family brush control variables
        monster_family_type c_monster_family;
        Image current_m_family_img;

        int roomheight;
        int roomwidth;

        private enum tile_type
        {
            Stone_Floor, Stone_Wall, Dirt_Floor, Dirt_Wall, Gravel,
            Shallow_Water, Deep_Water, Shallow_Blood, Deep_Blood, Void,
            Shallow_Sewage, Deep_Sewage, Entrance, Exit, Rubble_Floor
        };

        private enum doodad_type
        {
            Blood_Splatter, Armor_Suit, Destroyed_Armorsuit, Altar, Cage, Corpse_Pile,
            Bookshelf, Destroyed_Bookshelf, HallAnchor, Ironbar_Wall, Ironbar_Door, Boss_Spawn
        };

        private enum brush_mode
        {
            Tiles, Doodads, Monsters, Monster_Family, None
        };

        private enum monster_type
        {
            Armored_Skeleton, Boneyard, Gangrenous_Shambler, CorpseMimic, Ghost, GoldMimic, Grendel, GoreHound, GoreWolf, HollowKnight,
            Necromancer, RedKnight, Skeleton, VoidWraith, Zombie, ZombieFanatic, LesserRevenant, Rotting_Amalgam, WereGoreHound, Schrodingers_HK
        };

        private enum monster_family_type
        {
            Skeleton, Large_Undead, Mimic, Goredog, Grendel, Ghost, Necromancer, SpiritKnight, Spirit, Zombie
        };

        public DungeonRoomEditorForm(ref XmlDocument general_rooms, string general_paths)
        {
            InitializeComponent();

            roomwidth = 5;
            roomheight = 5;

            hall_anchors = new List<matrix_coord>();
            boss_spawns = new List<matrix_coord>();

            doodads = new List<doodad_type>();
            doodad_coords = new List<matrix_coord>();
            doodad_appearance_chances = new List<int>();

            monsters = new List<monster_type>();
            monster_coords = new List<matrix_coord>();
            monster_appearance_chances = new List<int>();

            monster_families = new List<monster_family_type>();
            m_family_coords = new List<matrix_coord>();
            m_family_appearance_chances = new List<int>();

            general_room_list = general_rooms;
            general_room_path = general_paths;

            current_brush_mode = brush_mode.None;

            general_room_list = general_rooms;
            general_room_path = general_paths;

            reset_picture_and_matrix();
        }

        private void mainPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.Location.X;
            int y = e.Location.Y;
            int x_matrix_position = x / 32;
            int y_matrix_position = y / 32;

            Rectangle drawing_rect = new Rectangle(x_matrix_position * 32, y_matrix_position * 32, 32, 32);
            //Make sure it's within the desired coordinate area.
            if (x_matrix_position < roomwidth && y_matrix_position < roomheight)
            {
                //Left click.
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    matrix_coord m_coord = new matrix_coord(x_matrix_position, y_matrix_position);

                    //Conditional branch depending on brush mode
                    //Tiles
                    if (current_brush_mode == brush_mode.Tiles)
                    {
                        roomMatrix[x_matrix_position, y_matrix_position] = current_tile;
                        roomGraphics.DrawImage(current_tile_img, drawing_rect);
                    }
                    //Doodads
                    else if (current_brush_mode == brush_mode.Doodads)
                    {
                        if (current_doodad == doodad_type.HallAnchor)
                        {
                            hall_anchors.Add(m_coord);
                            c_hallanchor_listbox.Items.Add(m_coord.ToString());
                        }
                        else if (current_doodad == doodad_type.Boss_Spawn)
                        {
                            boss_spawns.Add(m_coord);
                        }
                        else
                        {
                            doodads.Add(current_doodad);
                            doodad_coords.Add(m_coord);
                            doodad_appearance_chances.Add((int)doodad_chance_numeric.Value);
                            c_doodads_listBox.Items.Add(c_doodad_name + " " + m_coord.ToString() + " " + doodad_chance_numeric.Value.ToString() + "%");
                        }

                        roomGraphics.DrawImage(current_doodad_img, drawing_rect);
                    }
                    //Monsters
                    else if (current_brush_mode == brush_mode.Monsters)
                    {
                        monsters.Add(current_monster);
                        monster_coords.Add(m_coord);
                        monster_appearance_chances.Add((int)doodad_chance_numeric.Value);
                        c_monster_listbox.Items.Add(c_monster_name + " " + m_coord.ToString() + " " + doodad_chance_numeric.Value.ToString() + "%");
                        roomGraphics.DrawImage(current_monster_img, drawing_rect);
                    }
                    //Monster families
                    else if (current_brush_mode == brush_mode.Monster_Family)
                    {
                        monster_families.Add(c_monster_family);
                        m_family_coords.Add(m_coord);
                        m_family_appearance_chances.Add((int)doodad_chance_numeric.Value);
                        c_monster_listbox.Items.Add(c_monster_family.ToString() + " " + m_coord.ToString() + " " + doodad_chance_numeric.Value.ToString() + "%");
                        roomGraphics.DrawImage(current_m_family_img, drawing_rect);
                    }
                }
                //Right click.
                else
                {
                    roomMatrix[x_matrix_position, y_matrix_position] = current_tile;
                    roomGraphics.DrawImage(void_tile_brush.Image, drawing_rect);

                    int original_size = doodads.Count;
                    for (int i = 0; i < original_size; i++)
                        for (int j = 0; j < doodads.Count; j++)
                        {
                            if (doodad_coords[j].x == x_matrix_position && doodad_coords[j].y == y_matrix_position)
                            {
                                doodads.RemoveAt(j);
                                doodad_coords.RemoveAt(j);
                                doodad_appearance_chances.RemoveAt(j);
                                c_doodads_listBox.Items.RemoveAt(j);
                            }
                        }

                    original_size = monsters.Count;
                    for (int i = 0; i < original_size; i++)
                        for (int j = 0; j < monsters.Count; j++)
                        {
                            if (monster_coords[j].x == x_matrix_position && monster_coords[j].y == y_matrix_position)
                            {
                                monsters.RemoveAt(j);
                                monster_coords.RemoveAt(j);
                                monster_appearance_chances.RemoveAt(j);
                                c_monster_listbox.Items.RemoveAt(j);
                            }
                        }

                    original_size = hall_anchors.Count;
                    for(int i = 0; i < original_size; i++)
                        for (int j = 0; j < hall_anchors.Count; j++)
                        {
                            if (hall_anchors[j].x == x_matrix_position && hall_anchors[j].y == y_matrix_position)
                            {
                                hall_anchors.RemoveAt(j);
                                c_hallanchor_listbox.Items.RemoveAt(j);
                            }
                        }

                    roomMatrix[x_matrix_position, y_matrix_position] = tile_type.Void;
                }

                mainPictureBox.Invalidate();
            }
        }

        private void set_matrix_btn_Click(object sender, EventArgs e)
        {
            if (room_width_numeric.Value > 0 && room_height_numeric.Value > 0)
            {
                roomwidth = (int)room_width_numeric.Value;
                roomheight = (int)room_height_numeric.Value;

                reset_picture_and_matrix();
            }
        }

        private void reset_picture_and_matrix()
        {
            roomMatrix = new tile_type[roomwidth, roomheight];
            roomPicture = new Bitmap(roomwidth * 48, roomheight * 48);

            roomGraphics = Graphics.FromImage(roomPicture);
            mainPictureBox.Image = roomPicture;

            doodads.Clear();
            doodad_coords.Clear();
            doodad_appearance_chances.Clear();
            c_doodads_listBox.Items.Clear();

            monsters.Clear();
            monster_coords.Clear();
            monster_appearance_chances.Clear();
            c_monster_listbox.Items.Clear();

            monster_families.Clear();
            m_family_coords.Clear();
            m_family_appearance_chances.Clear();

            boss_spawns.Clear();

            for (int x = 0; x < roomwidth; x++)
                for (int y = 0; y < roomheight; y++)
                {
                    roomMatrix[x, y] = tile_type.Void;
                    roomGraphics.DrawImage(void_tile_brush.Image, new Rectangle(x * 32, y * 32, 32, 32));
                }

            mainPictureBox.Invalidate();
        }

        //Click events
        private void picture_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string tagData = pb.Tag.ToString();
            current_brush_mode = brush_mode.Tiles;
            current_tile_img = pb.Image;

            switch (tagData)
            {
                case "StoneFloor":
                    current_tile = tile_type.Stone_Floor;
                    break;
                case "StoneWall":
                    current_tile = tile_type.Stone_Wall;
                    break;
                case "Gravel":
                    current_tile = tile_type.Gravel;
                    break;
                case "DirtFloor":
                    current_tile = tile_type.Dirt_Floor;
                    break;
                case "DirtWall":
                    current_tile = tile_type.Dirt_Wall;
                    break;
                case "ShallowWater":
                    current_tile = tile_type.Shallow_Water;
                    break;
                case "DeepWater":
                    current_tile = tile_type.Deep_Water;
                    break;
                case "ShallowBlood":
                    current_tile = tile_type.Shallow_Blood;
                    break;
                case "VoidTile":
                    current_tile = tile_type.Void;
                    break;
                case "Shallow_Sewage":
                    current_tile = tile_type.Shallow_Sewage;
                    break;
                case "Deep_Sewage":
                    current_tile = tile_type.Deep_Sewage;
                    break;
                case "Entrance":
                    current_tile = tile_type.Entrance;
                    break;
                case "Exit":
                    current_tile = tile_type.Exit;
                    break;
                case "RubbleFloor":
                    current_tile = tile_type.Rubble_Floor;
                    break;
            }
        }

        private void doodad_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            c_doodad_name = pb.Tag.ToString();
            current_brush_mode = brush_mode.Doodads;
            current_doodad_img = pb.Image;

            switch (c_doodad_name)
            {
                case "BloodSplat":
                    current_doodad = doodad_type.Blood_Splatter;
                    break;
                case "Armor":
                    current_doodad = doodad_type.Armor_Suit;
                    break;
                case "DestroyedArmor":
                    current_doodad = doodad_type.Destroyed_Armorsuit;
                    break;
                case "Cage":
                    current_doodad = doodad_type.Cage;
                    break;
                case "Altar":
                    current_doodad = doodad_type.Altar;
                    break;
                case "CorpsePile":
                    current_doodad = doodad_type.Corpse_Pile;
                    break;
                case "Bookshelf":
                    current_doodad = doodad_type.Bookshelf;
                    break;
                case "DestroyedBookshelf":
                    current_doodad = doodad_type.Destroyed_Bookshelf;
                    break;
                case "HallAnchor":
                    current_doodad = doodad_type.HallAnchor;
                    break;
                case "Ironbar_Door":
                    current_doodad = doodad_type.Ironbar_Door;
                    break;
                case "Ironbar_Wall":
                    current_doodad = doodad_type.Ironbar_Wall;
                    break;
                case "BossSpawn":
                    current_doodad = doodad_type.Boss_Spawn;
                    break;
            }
        }

        private void monster_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            c_monster_name = pb.Tag.ToString();
            current_brush_mode = brush_mode.Monsters;
            current_monster_img = pb.Image;

            switch (c_monster_name)
            {
                case "Zombie":
                    current_monster = monster_type.Zombie;
                    break;
                case "ZombieFanatic":
                    current_monster = monster_type.ZombieFanatic;
                    break;
                case "GoreHound":
                    current_monster = monster_type.GoreHound;
                    break;
                case "GoreWolf":
                    current_monster = monster_type.GoreWolf;
                    break;
                case "Necromancer":
                    current_monster = monster_type.Necromancer;
                    break;
                case "Boneyard":
                    current_monster = monster_type.Boneyard;
                    break;
                case "ArmoredSkel":
                    current_monster = monster_type.Armored_Skeleton;
                    break;
                case "Skel":
                    current_monster = monster_type.Skeleton;
                    break;
                case "VoidWraith":
                    current_monster = monster_type.VoidWraith;
                    break;
                case "Ghost":
                    current_monster = monster_type.Ghost;
                    break;
                case "RedKnight":
                    current_monster = monster_type.RedKnight;
                    break;
                case "HollowKnight":
                    current_monster = monster_type.HollowKnight;
                    break;
                case "Schrodingers_HK":
                    current_monster = monster_type.Schrodingers_HK;
                    break;
                case "Gangrenous_Shambler":
                    current_monster = monster_type.Gangrenous_Shambler;
                    break;
                case "Rotting_Amalgam":
                    current_monster = monster_type.Rotting_Amalgam;
                    break;
                case "CorpseMimic":
                    current_monster = monster_type.CorpseMimic;
                    break;
                case "Lesser_Revenant":
                    current_monster = monster_type.LesserRevenant;
                    break;
                case "WereGoreHound":
                    current_monster = monster_type.WereGoreHound;
                    break;
            }
        }

        private void monster_family_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            c_monster_family_name = pb.Tag.ToString();
            current_brush_mode = brush_mode.Monster_Family;
            current_m_family_img = pb.Image;

            switch (c_monster_family_name)
            {
                case "Skeleton":
                    c_monster_family = monster_family_type.Skeleton;
                    break;
                case "Large_Undead":
                    c_monster_family = monster_family_type.Large_Undead;
                    break;
                case "Mimic":
                    c_monster_family = monster_family_type.Mimic;
                    break;
                case "Goredog":
                    c_monster_family = monster_family_type.Goredog;
                    break;
                case "Grendel":
                    c_monster_family = monster_family_type.Grendel;
                    break;
                case "Ghost":
                    c_monster_family = monster_family_type.Ghost;
                    break;
                case "Necromancer":
                    c_monster_family = monster_family_type.Necromancer;
                    break;
                case "SpiritKnight":
                    c_monster_family = monster_family_type.SpiritKnight;
                    break;
                case "Spirit":
                    c_monster_family = monster_family_type.Spirit;
                    break;
                case "Zombie":
                    c_monster_family = monster_family_type.Zombie;
                    break;
            }
        }

        //Compress room to XML
        private void compress_room_to_xml(XmlDocument target_doc, string target_path)
        {
            target_node = target_doc.SelectSingleNode("XnaContent/Asset");
            XmlNode roomNode = target_doc.CreateNode(XmlNodeType.Element, "Item", null);

            XmlNode roomCoordNode = target_doc.CreateElement("Coordinate");
            matrix_coord r_coord = new matrix_coord((int)floorx_numeric.Value, (int)floory_numeric.Value);
            roomCoordNode.InnerText = r_coord.compressedString();
            XmlNode roomTypeNode = target_doc.CreateElement("RoomType");
            if (room_type_listbox.SelectedIndex >= 0)
                roomTypeNode.InnerText = room_type_listbox.Items[room_type_listbox.SelectedIndex].ToString();
            else
                roomTypeNode.InnerText = "Specific";
            XmlNode roomGoldNode = target_doc.CreateElement("RoomGold");
            roomGoldNode.InnerText = room_gold_numeric.Value.ToString();
            XmlNode roomWidthNode = target_doc.CreateElement("RoomWidth");
            roomWidthNode.InnerText = roomwidth.ToString();
            XmlNode roomHeightNode = target_doc.CreateElement("RoomHeight");
            roomHeightNode.InnerText = roomheight.ToString();
            XmlNode roomHasDoorsNode = target_doc.CreateElement("RoomDoors");
            roomHasDoorsNode.InnerText = door_chkbox.Checked.ToString().ToLower();
            XmlNode roomDoorsLockedNode = target_doc.CreateElement("DoorsLocked");
            roomDoorsLockedNode.InnerText = door_locked_chkbox.Checked.ToString().ToLower();

            XmlNode overlapNode = target_doc.CreateElement("AllowOverlap");
            string overlap = "false";
            if(OverlapChkBox.Checked)
                overlap = "true";
            overlapNode.InnerText = overlap;

            XmlNode roomMatrixNode = target_doc.CreateElement("Room_Matrix");
            for (int y = 0; y < roomheight; y++)
            {
                string row = "";
                for (int x = 0; x < roomwidth; x++)
                {
                    row += tile_type_to_string(roomMatrix[x, y]) + " ";
                }
                XmlNode currentRowNode = target_doc.CreateElement("Item");
                currentRowNode.InnerText = row;
                roomMatrixNode.AppendChild(currentRowNode);
            }
            
            //Hall Anchors
            XmlNode roomHallAnchors = target_doc.CreateElement("Room_Hallway_Anchors");
            for (int i = 0; i < hall_anchors.Count; i++)
            {
                XmlNode currentAnchorNode = target_doc.CreateElement("Item");
                currentAnchorNode.InnerText = hall_anchors[i].compressedString();
                roomHallAnchors.AppendChild(currentAnchorNode);
            }

            //Handle Doodads.
            XmlNode roomDoodadsNode = target_doc.CreateElement("Room_Doodads");
            for (int i = 0; i < doodads.Count; i++)
            {
                XmlNode currentDoodadNode = target_doc.CreateElement("Item");
                currentDoodadNode.InnerText = doodad_type_to_string(doodads[i]);
                roomDoodadsNode.AppendChild(currentDoodadNode);
            }
            XmlNode roomDoodadCoordsNode = target_doc.CreateElement("Room_Doodad_Coordinates");
            for (int i = 0; i < doodad_coords.Count; i++)
            {
                XmlNode currentDoodadCoordNode = target_doc.CreateElement("Item");
                currentDoodadCoordNode.InnerText = doodad_coords[i].compressedString();
                roomDoodadCoordsNode.AppendChild(currentDoodadCoordNode);
            }
            XmlNode roomDoodadChancesNode = target_doc.CreateElement("Room_Doodad_Chances");
            for (int i = 0; i < doodad_appearance_chances.Count; i++)
            {
                XmlNode currentDoodadChanceNode = target_doc.CreateElement("Item");
                currentDoodadChanceNode.InnerText = doodad_appearance_chances[i].ToString();
                roomDoodadChancesNode.AppendChild(currentDoodadChanceNode);
            }

            //Monster families
            XmlNode roomMonFamiliesNode = target_doc.CreateElement("Monster_Families");
            for (int i = 0; i < monster_families.Count; i++)
            {
                XmlNode cMonsterFamilyNode = target_doc.CreateElement("Item");
                cMonsterFamilyNode.InnerText = monster_families[i].ToString();
                roomMonFamiliesNode.AppendChild(cMonsterFamilyNode);
            }
            XmlNode roomFamilyCoordNode = target_doc.CreateElement("Monster_Family_Coordinates");
            for (int i = 0; i < m_family_coords.Count; i++)
            {
                XmlNode cFamilyCoordNode = target_doc.CreateElement("Item");
                cFamilyCoordNode.InnerText =  m_family_coords[i].compressedString();
                roomFamilyCoordNode.AppendChild(cFamilyCoordNode);
            }
            XmlNode roomMonFamilyChance = target_doc.CreateElement("Monster_Family_Chances");
            for (int i = 0; i < m_family_appearance_chances.Count; i++)
            {
                XmlNode cFamilyChanceNode = target_doc.CreateElement("Item");
                cFamilyChanceNode.InnerText = m_family_appearance_chances[i].ToString();
                roomMonFamilyChance.AppendChild(cFamilyChanceNode);
            }

            //Monsters
            XmlNode roomMonstersNode = target_doc.CreateElement("Room_Monsters");
            for (int i = 0; i < monsters.Count; i++)
            {
                XmlNode currentMonsterNode = target_doc.CreateElement("Item");
                currentMonsterNode.InnerText = monster_type_to_string(monsters[i]);
                roomMonstersNode.AppendChild(currentMonsterNode);
            }
            XmlNode roomMonstersCoordsNode = target_doc.CreateElement("Room_Monster_Coordinates");
            for (int i = 0; i < monster_coords.Count; i++)
            {
                XmlNode currentMonsterCoordNode = target_doc.CreateElement("Item");
                currentMonsterCoordNode.InnerText = monster_coords[i].compressedString();
                roomMonstersCoordsNode.AppendChild(currentMonsterCoordNode);
            }
            XmlNode roomMonstersChancesNode = target_doc.CreateElement("Room_Monster_Chances");
            for (int i = 0; i < monster_appearance_chances.Count; i++)
            {
                XmlNode currentMonsterChanceNode = target_doc.CreateElement("Item");
                currentMonsterChanceNode.InnerText = monster_appearance_chances[i].ToString();
                roomMonstersChancesNode.AppendChild(currentMonsterChanceNode);
            }

            //Boss spawns
            XmlNode bossSpawnsNode = target_doc.CreateElement("Boss_Spawn_Coordinates");
            for (int i = 0; i < boss_spawns.Count; i++)
            {
                XmlNode c_boss_spawn_node = target_doc.CreateElement("Item");
                c_boss_spawn_node.InnerText = boss_spawns[i].compressedString();
                bossSpawnsNode.AppendChild(c_boss_spawn_node);
            }

            roomNode.AppendChild(roomCoordNode);
            roomNode.AppendChild(roomTypeNode);
            roomNode.AppendChild(roomGoldNode);
            roomNode.AppendChild(roomWidthNode);
            roomNode.AppendChild(roomHeightNode);
            roomNode.AppendChild(roomHasDoorsNode);
            roomNode.AppendChild(roomDoorsLockedNode);
            roomNode.AppendChild(overlapNode);
            roomNode.AppendChild(roomMatrixNode);
            roomNode.AppendChild(roomHallAnchors);
            roomNode.AppendChild(roomDoodadsNode);
            roomNode.AppendChild(roomDoodadCoordsNode);
            roomNode.AppendChild(roomDoodadChancesNode);
            roomNode.AppendChild(roomMonFamiliesNode);
            roomNode.AppendChild(roomFamilyCoordNode);
            roomNode.AppendChild(roomMonFamilyChance);
            roomNode.AppendChild(roomMonstersNode);
            roomNode.AppendChild(roomMonstersCoordsNode);
            roomNode.AppendChild(roomMonstersChancesNode);
            roomNode.AppendChild(bossSpawnsNode);

            target_node.AppendChild(roomNode);

            target_doc.Save(target_path);
            target_doc.Load(target_path);
        }

        //String return functions
        private string tile_type_to_string(tile_type target_type)
        {
            switch (target_type)
            {
                case tile_type.Deep_Water:
                    return "DWr";
                case tile_type.Dirt_Floor:
                    return "DF";
                case tile_type.Dirt_Wall:
                    return "DW";
                case tile_type.Gravel:
                    return "GV";
                case tile_type.Shallow_Water:
                    return "SWr";
                case tile_type.Stone_Floor:
                    return "SF";
                case tile_type.Stone_Wall:
                    return "SW";
                case tile_type.Shallow_Blood:
                    return "SB";
                case tile_type.Deep_Blood:
                    return "DB";
                case tile_type.Shallow_Sewage:
                    return "SSwr";
                case tile_type.Deep_Sewage:
                    return "DSwr";
                case tile_type.Entrance:
                    return "EN";
                case tile_type.Exit:
                    return "EX";
                case tile_type.Rubble_Floor:
                    return "RF";
            }

            return "V";
        }

        private string doodad_type_to_string(doodad_type target_type)
        {
            switch (target_type)
            {
                case doodad_type.Altar:
                    return "Altar";
                case doodad_type.Armor_Suit:
                    return "ArmorSuit";
                case doodad_type.Blood_Splatter:
                    return "BloodSplatter";
                case doodad_type.Cage:
                    return "Cage";
                case doodad_type.Corpse_Pile:
                    return "CorpsePile";
                case doodad_type.Destroyed_Armorsuit:
                    return "DestroyedArmorSuit";
                case doodad_type.Bookshelf:
                    return "Bookshelf";
                case doodad_type.Destroyed_Bookshelf:
                    return "DestroyedBookshelf";
                case doodad_type.Ironbar_Wall:
                    return "Ironbar_Wall";
                case doodad_type.Ironbar_Door:
                    return "Ironbar_Door";
            }

            return "NULL";
        }

        private string monster_type_to_string(monster_type target_type)
        {
            return target_type.ToString();
        }

        private void add2_all_btn_Click(object sender, EventArgs e)
        {
            compress_room_to_xml(general_room_list, general_room_path);
        }

        private void add2_flr_btn_Click(object sender, EventArgs e)
        {
            //Step 1. Make a file name. File name is dungeon selected _ floor _ floor #
            string c_path = dungeon_listbox.Items[dungeon_listbox.SelectedIndex].ToString().ToLower() + "_floor_" + floornumber_numeric.Value.ToString() + ".xml";
            XmlDocument c_floor_doc = new XmlDocument();
            //So necropolis floor 3 would be Necropolis_Floor_3
            //Step 2. Check to make sure that file name exists. If not, create it. If so, load it.
            if (!File.Exists(c_path))
            {
                XmlNode rootNode = c_floor_doc.CreateElement("XnaContent");
                c_floor_doc.AppendChild(rootNode);

                XmlNode assetNode = c_floor_doc.CreateElement("Asset");
                XmlAttribute assetAttribute = c_floor_doc.CreateAttribute("Type");
                assetAttribute.Value = "CKPLibrary.RoomDC[]";
                assetNode.Attributes.Append(assetAttribute);

                rootNode.AppendChild(assetNode);

                c_floor_doc.Save(c_path);
            }
            else
                c_floor_doc.Load(c_path);
            //Step 3. run compress_room_to_xml with the document and the path and you're good.
            compress_room_to_xml(c_floor_doc, c_path);
        }
    }
}
