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

        int roomheight;
        int roomwidth;

        private enum tile_type
        {
            Stone_Floor, Stone_Wall, Dirt_Floor, Dirt_Wall, Gravel,
            Shallow_Water, Deep_Water, Shallow_Blood, Deep_Blood, Void
        };

        private enum doodad_type
        {
            Blood_Splatter, Armor_Suit, Destroyed_Armorsuit, Altar, Cage, Corpse_Pile,
            Bookshelf, Destroyed_Bookshelf
        };

        private enum brush_mode
        {
            Tiles, Doodads, Monsters, None
        };

        private enum monster_type
        {
            Zombie, Zombie_Fanatic, Gore_Hound, Gore_Wolf, Skeleton, Armored_Skeleton, Ghost,
            Void_Wraith, Necromancer, Hollow_Knight, Red_Knight, Boneyard
        };

        public DungeonRoomEditorForm(ref XmlDocument general_rooms, string general_paths)
        {
            InitializeComponent();

            roomwidth = 5;
            roomheight = 5;

            doodads = new List<doodad_type>();
            doodad_coords = new List<matrix_coord>();
            doodad_appearance_chances = new List<int>();

            monsters = new List<monster_type>();
            monster_coords = new List<matrix_coord>();
            monster_appearance_chances = new List<int>();

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

            if (x_matrix_position < roomwidth && y_matrix_position < roomheight)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    matrix_coord m_coord = new matrix_coord(x_matrix_position, y_matrix_position);

                    if (current_brush_mode == brush_mode.Tiles)
                    {
                        roomMatrix[x_matrix_position, y_matrix_position] = current_tile;
                        roomGraphics.DrawImage(current_tile_img, new Rectangle(x_matrix_position * 32, y_matrix_position * 32, 32, 32));
                    }
                    else if (current_brush_mode == brush_mode.Doodads)
                    {
                        doodads.Add(current_doodad);
                        doodad_coords.Add(m_coord);
                        doodad_appearance_chances.Add((int)doodad_chance_numeric.Value);
                        c_doodads_listBox.Items.Add(c_doodad_name + " " + m_coord.ToString() + " " + doodad_chance_numeric.Value.ToString() + "%");
                        roomGraphics.DrawImage(current_doodad_img, new Rectangle(x_matrix_position * 32, y_matrix_position * 32, 32, 32));
                    }
                    else if (current_brush_mode == brush_mode.Monsters)
                    {
                        monsters.Add(current_monster);
                        monster_coords.Add(m_coord);
                        monster_appearance_chances.Add((int)doodad_chance_numeric.Value);
                        c_monster_listbox.Items.Add(c_monster_name + " " + m_coord.ToString() + " " + doodad_chance_numeric.Value.ToString() + "%");
                        roomGraphics.DrawImage(current_monster_img, new Rectangle(x_matrix_position * 32, y_matrix_position * 32, 32, 32));
                    }
                }
                else
                {
                    roomMatrix[x_matrix_position, y_matrix_position] = current_tile;
                    roomGraphics.DrawImage(void_tile_brush.Image, new Rectangle(x_matrix_position * 32, y_matrix_position * 32, 32, 32));

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
                        for (int j = 0; j < original_size; j++)
                        {
                            if (monster_coords[j].x == x_matrix_position && monster_coords[j].y == y_matrix_position)
                            {
                                monsters.RemoveAt(j);
                                monster_coords.RemoveAt(j);
                                monster_appearance_chances.RemoveAt(j);
                                c_monster_listbox.Items.RemoveAt(j);
                            }
                        }
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

            for (int x = 0; x < roomwidth; x++)
                for (int y = 0; y < roomheight; y++)
                {
                    roomMatrix[x, y] = tile_type.Void;
                    roomGraphics.DrawImage(void_tile_brush.Image, new Rectangle(x * 32, y * 32, 32, 32));
                }

            mainPictureBox.Invalidate();
        }

        private void picture_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            string tagData = pb.Tag.ToString();
            current_brush_mode = brush_mode.Tiles;

            switch (tagData)
            {
                case "StoneFloor":
                    current_tile = tile_type.Stone_Floor;
                    current_tile_img = stn_floor_brush.Image;
                    break;
                case "StoneWall":
                    current_tile = tile_type.Stone_Wall;
                    current_tile_img = stn_wall_brush.Image;
                    break;
                case "Gravel":
                    current_tile = tile_type.Gravel;
                    current_tile_img = gravel_brush.Image;
                    break;
                case "DirtFloor":
                    current_tile = tile_type.Dirt_Floor;
                    current_tile_img = dirt_floor_brush.Image;
                    break;
                case "DirtWall":
                    current_tile = tile_type.Dirt_Wall;
                    current_tile_img = dirt_wall_brush.Image;
                    break;
                case "ShallowWater":
                    current_tile = tile_type.Shallow_Water;
                    current_tile_img = shallow_water_brush.Image;
                    break;
                case "DeepWater":
                    current_tile = tile_type.Deep_Water;
                    current_tile_img = deep_water_brush.Image;
                    break;
                case "ShallowBlood":
                    current_tile = tile_type.Shallow_Blood;
                    current_tile_img = shallow_blood_brush.Image;
                    break;
                case "VoidTile":
                    current_tile = tile_type.Void;
                    current_tile_img = void_tile_brush.Image;
                    break;
            }
        }

        private void doodad_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            c_doodad_name = pb.Tag.ToString();
            current_brush_mode = brush_mode.Doodads;

            switch (c_doodad_name)
            {
                case "BloodSplat":
                    current_doodad = doodad_type.Blood_Splatter;
                    current_doodad_img = blood_splatter_brush.Image;
                    break;
                case "Armor":
                    current_doodad = doodad_type.Armor_Suit;
                    current_doodad_img = armor_suit_brush.Image;
                    break;
                case "DestroyedArmor":
                    current_doodad = doodad_type.Destroyed_Armorsuit;
                    current_doodad_img = destroyed_armor_brush.Image;
                    break;
                case "Cage":
                    current_doodad = doodad_type.Cage;
                    current_doodad_img = cage_brush.Image;
                    break;
                case "Altar":
                    current_doodad = doodad_type.Altar;
                    current_doodad_img = altar_brush.Image;
                    break;
                case "CorpsePile":
                    current_doodad = doodad_type.Corpse_Pile;
                    current_doodad_img = corpse_pile_brush.Image;
                    break;
                case "Bookshelf":
                    current_doodad = doodad_type.Bookshelf;
                    current_doodad_img = bookshelf_brush.Image;
                    break;
                case "DestroyedBookshelf":
                    current_doodad = doodad_type.Destroyed_Bookshelf;
                    current_doodad_img = destroyed_bookshelf_brush.Image;
                    break;
            }
        }

        private void monster_brush_picture_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            c_monster_name = pb.Tag.ToString();
            current_brush_mode = brush_mode.Monsters;

            switch (c_monster_name)
            {
                case "Zombie":
                    current_monster = monster_type.Zombie;
                    current_monster_img = zombie_brush.Image;
                    break;
                case "ZombieFanatic":
                    current_monster = monster_type.Zombie_Fanatic;
                    current_monster_img = zombie_fanatic_brush.Image;
                    break;
                case "GoreHound":
                    current_monster = monster_type.Gore_Hound;
                    current_monster_img = gore_hound_brush.Image;
                    break;
                case "GoreWolf":
                    current_monster = monster_type.Gore_Wolf;
                    current_monster_img = gore_wolf_brush.Image;
                    break;
                case "Necromancer":
                    current_monster = monster_type.Necromancer;
                    current_monster_img = necro_brush.Image;
                    break;
                case "Boneyard":
                    current_monster = monster_type.Boneyard;
                    current_monster_img = boneyard_brush.Image;
                    break;
                case "ArmoredSkel":
                    current_monster = monster_type.Armored_Skeleton;
                    current_monster_img = arm_skel_brush.Image;
                    break;
                case "Skel":
                    current_monster = monster_type.Skeleton;
                    current_monster_img = skel_brush.Image;
                    break;
                case "VoidWraith":
                    current_monster = monster_type.Void_Wraith;
                    current_monster_img = void_wraith_brush.Image;
                    break;
                case "Ghost":
                    current_monster = monster_type.Ghost;
                    current_doodad_img = ghost_brush.Image;
                    break;
                case "RedKnight":
                    current_monster = monster_type.Red_Knight;
                    current_monster_img = red_knight_brush.Image;
                    break;
                case "HollowKnight":
                    current_monster = monster_type.Hollow_Knight;
                    current_monster_img = hollow_knight_brush.Image;
                    break;
            }
        }

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
                roomTypeNode.InnerText = "Generic";
            XmlNode roomGoldNode = target_doc.CreateElement("RoomGold");
            roomGoldNode.InnerText = room_gold_numeric.Value.ToString();
            XmlNode roomWidthNode = target_doc.CreateElement("RoomWidth");
            roomWidthNode.InnerText = roomwidth.ToString();
            XmlNode roomHeightNode = target_doc.CreateElement("RoomHeight");
            roomHeightNode.InnerText = roomheight.ToString();

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

            roomNode.AppendChild(roomCoordNode);
            roomNode.AppendChild(roomTypeNode);
            roomNode.AppendChild(roomGoldNode);
            roomNode.AppendChild(roomWidthNode);
            roomNode.AppendChild(roomHeightNode);
            roomNode.AppendChild(roomMatrixNode);
            roomNode.AppendChild(roomDoodadsNode);
            roomNode.AppendChild(roomDoodadCoordsNode);
            roomNode.AppendChild(roomDoodadChancesNode);
            roomNode.AppendChild(roomMonstersNode);
            roomNode.AppendChild(roomMonstersCoordsNode);
            roomNode.AppendChild(roomMonstersChancesNode);

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
            }

            return "NULL";
        }

        private string monster_type_to_string(monster_type target_type)
        {
            switch (target_type)
            {
                case monster_type.Armored_Skeleton:
                    return "ArmoredSkel";
                case monster_type.Boneyard:
                    return "Boneyard";
                case monster_type.Ghost:
                    return "Ghost";
                case monster_type.Gore_Hound:
                    return "GoreHound";
                case monster_type.Gore_Wolf:
                    return "GoreWolf";
                case monster_type.Hollow_Knight:
                    return "HollowKnight";
                case monster_type.Red_Knight:
                    return "RedKnight";
                case monster_type.Necromancer:
                    return "Necromancer";
                case monster_type.Skeleton:
                    return "Skeleton";
                case monster_type.Void_Wraith:
                    return "VoidWraith";
                case monster_type.Zombie:
                    return "Zombie";
                case monster_type.Zombie_Fanatic:
                    return "ZombieFanatic";
            }

            return "NULL";
        }

        private void add2_all_btn_Click(object sender, EventArgs e)
        {
            compress_room_to_xml(general_room_list, general_room_path);
        }
    }

    public class matrix_coord
    {
        public int x;
        public int y;

        public matrix_coord(int sx, int sy)
        {
            x = sx;
            y = sy;
        }

        public override string ToString()
        {
            return "X: " + x.ToString() + " Y: " + y.ToString();
        }

        public string compressedString()
        {
            return "X:"+x.ToString() + " Y:" + y.ToString();
        }
    }
}
