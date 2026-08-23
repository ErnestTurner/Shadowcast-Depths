using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    
        public class MapContainer
        {
            private  List<Monster> monsters = new List<Monster>();
            public byte[,] grid;
            public byte[,] fovGrid;
            FOVRecurse fov;
            
            
            
            public  List<Monster> Monsters
            {
                get { return monsters; }
                set { monsters = value; }
            }
            private Cell[,] map;
            public Cell[,] Map
            {
                get { return map; }
                set { map = value; }
            }

            private Point size = new Point(100, 100);

            public Point Size
            {
                get { return size; }
                set { size = value; }
            }
            bool firstFeature = true;
            private int veiwRegion = 20;
            

            public MapContainer()//creates a new random map
            {
                
                Console.Clear();
                Console.Write("Generating Map");
                firstFeature = true;                
                map = new Cell[size.X, size.Y];
                fillMapWithWall();
                for (int i = 0; i < 200; i++)
                {
                    Console.Write(".");
                    addFeature();                    
                }
                addStairs();
                for (int i = 0; i < 20; i++)
                {
                    addMonster();
                }
                grid = new byte[Size.X, Size.Y];
                fovGrid = new byte[Size.X, Size.Y];

                for (int x = 0; x < Size.X; x++)
                {
                    for (int y = 0; y < Size.Y; y++)
                    {
                        grid[x, y] = (Map[x, y].Type == CellType.floor.Type) ? (byte)1 : (byte)0;
                        fovGrid[x, y] = (Map[x, y].Type == CellType.floor.Type) ? (byte)0 : (byte)1;
                    }
                }
                
            }           

            public MapContainer(string sx, string sy, string mapString)//loads a saved map from a saved game. Accepts a string which parses to an int Size, and a string which contains contains the symbols for the map
            {
                this.size.X = int.Parse(sx);
                this.size.Y = int.Parse(sy);
                firstFeature = false;
                map = new Cell[size.X, size.Y];
                for(int x = 0; x < size.X; x++)
                {
                    for(int y = 0; y < size.Y; y++)
                    {
                        switch(mapString[x*size.Y + y])
                        {
                            case '#':
                                {
                                    map[x, y] = CellType.wall;
                                    break;
                                }
                            case '.':
                                {
                                    map[x, y] = CellType.floor;
                                    break;
                                }
                            case '@':
                                {
                                    map[x, y] = CellType.floor;
                                    map[x, y].Hero = true;
                                        break;
                                }
                            case '<':
                                {
                                    map[x, y] = CellType.downStairs;
                                    break;
                                }
                            case '>':
                                {
                                    map[x, y] = CellType.upStairs;
                                    break;
                                }

                        }
                    }
                }
                
            }
            private void addStairs()
            {
                
                Random r = new Random();
                for (int i = 0; i < 3; i++)
                {
                    bool notPlaced = true;
                    while (notPlaced)
                    {
                        Point p = new Point(r.Next(1, Size.X - 1), r.Next(1, Size.Y - 1));
                        if (map[p.X, p.Y].Type == CellType.floor.Type)
                        {
                            map[p.X, p.Y] = CellType.downStairs;
                            notPlaced = false;
                        }
                    }
                }
                map[Size.X / 2, Size.Y / 2] = CellType.upStairs;
            }
            private void fillMapWithWall()
            {
                for (int x = 0; x < Size.X; x++)
                {
                    for (int y = 0; y < Size.Y; y++)
                    {
                        Map[x, y] = CellType.wall;
                    }
                }
            }

            private void addFeature()
            {

                Point p = new Point(Size.X / 2, Size.Y / 2);
                bool notValid = true;
                Random r = new Random();
                if (firstFeature)
                {
                    Cell[,] f = MapFeature.singleFloor;
                    while (notValid)
                    {
                        p = new Point(Size.X / 2, Size.Y / 2);
                        checkFeaturePlacementDown(ref p, ref notValid, r, f);
                    }

                    placeFeatureDown(p, f);
                    firstFeature = false;
                }
                else
                {
                    bool down = true;
                    Cell[,] f = MapFeature.randomFeature;
                    bool notValidPoint = true;
                    while (notValidPoint)
                    {

                        p = new Point(r.Next(1, Size.X - 1), r.Next(1, Size.Y - 1));
                        if (map[p.X, p.Y] == CellType.wall && (map[p.X - 1, p.Y] == CellType.floor || map[p.X, p.Y - 1] == CellType.floor))
                        {
                            notValidPoint = false;
                            checkFeaturePlacementDown(ref p, ref notValidPoint, r, f);
                            down = true;
                        }
                        else
                        {
                            if (map[p.X, p.Y] == CellType.wall && (map[p.X + 1, p.Y] == CellType.floor || map[p.X, p.Y + 1] == CellType.floor))
                            {
                                notValidPoint = false;
                                checkFeaturePlacementUp(ref p, ref notValidPoint, r, f);
                                down = false;
                            }
                        }
                    }
                    if (down)
                    {
                        placeFeatureDown(p, f);
                    }
                    else
                    {
                        placeFeatureUp(p, f);
                    }
                }
            }

            private void placeFeatureUp(Point p, Cell[,] f)
            {
                for (int x = p.X - (f.GetUpperBound(0) + 1); x < p.X; x++)
                {
                    for (int y = p.Y - (f.GetUpperBound(1) + 1); y < p.Y; y++)
                    {
                        Map[x + 1, y + 1] = f[p.X - (x + 1), p.Y - (y + 1)];
                    }
                }
            }

            private void placeFeatureDown(Point p, Cell[,] f)
            {
                for (int x = p.X; x < p.X + f.GetUpperBound(0) + 1; x++)
                {
                    for (int y = p.Y; y < p.Y + f.GetUpperBound(1) + 1; y++)
                    {
                        Map[x, y] = f[x - p.X, y - p.Y];
                    }
                }
            }
            private void checkFeaturePlacementDown(ref Point p, ref bool notValid, Random r, Cell[,] f)
            {
                if (p.X + f.GetUpperBound(0) >= Size.X || p.Y + f.GetUpperBound(1) >= Size.Y)
                { notValid = true; }
                else
                {
                    for (int x = p.X; x < p.X + f.GetUpperBound(0) + 1; x++)
                    {
                        for (int y = p.Y; y < p.Y + f.GetUpperBound(1) + 1; y++)
                        {
                            if (Map[x, y] == CellType.wall && (x < Size.X - 1 && y < Size.Y - 1))
                            {
                                notValid = false;
                            }
                            else
                            {
                                notValid = true;
                                return;
                            }
                        }
                    }
                }
            }
            private void checkFeaturePlacementUp(ref Point p, ref bool notValid, Random r, Cell[,] f)
            {
                if (p.X - (f.GetUpperBound(0) + 1) <= 0 || p.Y - (f.GetUpperBound(1) + 1) <= 0)
                { notValid = true; }
                else
                {
                    for (int x = p.X - (f.GetUpperBound(0) + 1); x < p.X; x++)
                    {
                        for (int y = p.Y - (f.GetUpperBound(1) + 1); y < p.Y; y++)
                        {
                            if (Map[x, y] == CellType.wall && (x < Size.X - 1 && y < Size.Y - 1) && (x > 1 && y > 1))
                            {
                                notValid = false;
                            }
                            else
                            {
                                notValid = true;
                                return;
                            }
                        }
                    }
                }
            }



            public void drawMap(Player p) 
            {
                FieldOfView(p);
                
                for (int x = p.Pos.X - veiwRegion -1; x < p.Pos.X + veiwRegion -1; x++)
                {
                    for (int y = p.Pos.Y - veiwRegion -1; y < p.Pos.Y + veiwRegion -1; y++)
                    {
                        if (x >= 0 && x < Size.X && y >= 0 && y < Size.Y)
                        {
                            if (isVisible(x, y, fov))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Map[x, y].Apperance);
                                Map[x, y].HasSeen = true;
                            }
                            else
                            {
                                if (Map[x, y].HasSeen)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.Write(Map[x, y].Apperance);
                                }
                                else
                                {
                                    Console.Write(" ");
                                }
                            }
                        }
                    }
                
                        if (x < p.Pos.X + veiwRegion && x > p.Pos.X - veiwRegion)
                        {
                            Console.Write("\n");
                        }
                    
                }                   
                return;                
            }

            

            private void FieldOfView(Object p)
            {
                Player player = p as Player;
                fov = new FOVRecurse(new Point(this.map.GetUpperBound(0), this.map.GetUpperBound(1)), this.fovGrid, Player.VisionDistance);
                fov.Player = player.Pos;
                fov.GetVisibleCells();
            }

            private bool isVisible(int x, int y, FOVRecurse fov)
            {
                bool visible = false;
                Point top = new Point(x - 1, y);
                Point topleft = new Point(x - 1, y-1);
                Point topright = new Point(x - 1, y+1);
                Point bottom = new Point(x + 1, y);
                Point bottomleft = new Point(x + 1, y-1);
                Point bottomright = new Point(x + 1, y+1);
                 Point left = new Point(x, y-1);
                 Point right = new Point(x, y+1);               

                 Point[] testPoint = new Point[] { top, topleft, topright, bottom, bottomleft, bottomright, left, right };
                foreach(Point p in testPoint)
                {
                    if(fov.VisiblePoints.Contains(p))
                    {
                        visible = true;
                    }
                }
                return visible;
            }

            public string report()
            {
                string saveString = "";
                saveString += Size.X.ToString() + '*';
                saveString += Size.Y.ToString() + '*';
                for(int x = 0; x < map.GetUpperBound(0)+1; x++)
                {
                    for (int y = 0; y < map.GetUpperBound(1)+1; y++)
                    {
                        saveString += map[x, y].Apperance;
                    }
                }
                return saveString;
            }

            public void addMonster()
            {
                Random rand = new Random();
                Point monsterPos = new Point(0,0);
                bool notValidPos = true;
                Monster m = MonsterType.randomMonster();
                while(notValidPos)
                {
                    monsterPos = new Point(rand.Next(1, Size.X - 1), rand.Next(1, Size.Y - 1));
                    if(map[monsterPos.X,monsterPos.Y].Type == CellType.floor.Type && map[monsterPos.X,monsterPos.Y].HasMonster == false)
                    {
                        notValidPos = false;
                    }
                }
                map[monsterPos.X, monsterPos.Y].HasMonster = true;
                map[monsterPos.X, monsterPos.Y].MonsterType = m.Name;
                map[monsterPos.X, monsterPos.Y].Monster = m;
                map[monsterPos.X, monsterPos.Y].Monster.Pos = monsterPos;
                Monsters.Add(m);
            }



            public static int depth { get; set; }
        }   
}
