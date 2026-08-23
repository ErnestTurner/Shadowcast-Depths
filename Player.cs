using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowcastDepths
{
    public class Player : Character
    {

        public static int VisionDistance;
        

        public Player(string name, int strenght, int health, int vision, int constitution)
            : base(name, strenght, health, vision, constitution)
        {
            VisionDistance = vision;
        }

        public Player()
            : base()
        {
            // TODO: Complete member initialization
        }

       

        public void move(ConsoleKeyInfo keyPressed, MapContainer map)
        {            
            switch (keyPressed.Key)// Moves the player in the correct direction.             
            {
                case ConsoleKey.UpArrow:
                    {
                        if(isValidMove(Pos.X -1, Pos.Y, map))
                        {
                            if (map.Map[Pos.X - 1, Pos.Y].HasMonster)
                            {
                                Battle battle = new Battle(this, map.Map[Pos.X - 1, Pos.Y].Monster);
                                //this.meleeAttack(map.Map[Pos.X - 1, Pos.Y].Monster);
                            }
                            else
                            {
                                map.Map[Pos.X, Pos.Y].Hero = false;
                                --Pos.X;
                                map.Map[Pos.X, Pos.Y].Hero = true;
                            }
                        }                      
                        return;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (isValidMove(Pos.X + 1, Pos.Y, map))
                        {
                            if (map.Map[Pos.X + 1, Pos.Y].HasMonster)
                            {
                                Battle battle = new Battle(this, map.Map[Pos.X + 1, Pos.Y].Monster);

                                //this.meleeAttack(map.Map[Pos.X + 1, Pos.Y].Monster);
                            }
                            else
                            {
                                map.Map[Pos.X, Pos.Y].Hero = false;
                                ++Pos.X;
                                map.Map[Pos.X, Pos.Y].Hero = true;
                            }
                        }                  
                        return;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        if (isValidMove(Pos.X, Pos.Y - 1, map))
                        {
                            if (map.Map[Pos.X  , Pos.Y-1].HasMonster)
                            {
                                Battle battle = new Battle(this, map.Map[Pos.X, Pos.Y - 1].Monster);

                                //this.meleeAttack(map.Map[Pos.X, Pos.Y-1].Monster);
                            }
                            else
                            {
                                map.Map[Pos.X, Pos.Y].Hero = false;
                                --Pos.Y;
                                map.Map[Pos.X, Pos.Y].Hero = true;
                            }
                        }                  
                        return;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (isValidMove(Pos.X, Pos.Y + 1, map))
                        {
                            if (map.Map[Pos.X , Pos.Y +1].HasMonster)
                            {
                                Battle battle = new Battle(this, map.Map[Pos.X, Pos.Y +1].Monster);

                               // this.meleeAttack(map.Map[Pos.X, Pos.Y+1].Monster);
                            }
                            else
                            {
                                map.Map[Pos.X, Pos.Y].Hero = false;
                                ++Pos.Y;
                                map.Map[Pos.X, Pos.Y].Hero = true;
                            }
                        }                  
                        return;
                    }
                default:
                    {
                        return;
                    }
            }
        }
        public bool isValidMove(int x, int y, MapContainer map)// Checks to make sure the hero does not go out of bounds.
        {
            
            bool validMove = false;
            if(map.Map[x,y].Type == CellType.floor.Type || map.Map[x,y].Type == CellType.unlockedDoor.Type || map.Map[x,y].Type == CellType.downStairs.Type || map.Map[x,y].Type == CellType.upStairs.Type)
            {
                validMove = true;
            }
            return validMove; 
             
        }
        override public void destroy()
        {
            Console.Clear();
            Console.WriteLine(" Game Over ");
            Game.gameOn = false;
        }
    }
}
