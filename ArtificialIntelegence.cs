using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms;

namespace ShadowcastDepths
{
    public class ArtificialIntelegence
    {        
        PathFinder pf;
        public ArtificialIntelegence()
        {
            
        }
        public Monster action(Monster monster, MapContainer currentMap)
        {            
            if ((Math.Abs(monster.Pos.X - Game.player.Pos.X) <= monster.Vision) && (Math.Abs(monster.Pos.Y - Game.player.Pos.Y) <= monster.Vision))
            {
               
                pf = new PathFinder(currentMap.grid);
                pf.Diagonals = false;
                List<PathFinderNode> pfn = pf.FindPath(monster.Pos, Game.player.Pos);
                if (pfn != null && pfn.Count > 1)
                {
                    if (currentMap.Map[pfn[1].X, pfn[1].Y].Hero)
                    {
                        Battle b = new Battle(Game.player, monster);                        
                        //monster.meleeAttack(Game.player);
                    }
                    else if (!(currentMap.Map[pfn[1].X, pfn[1].Y].HasMonster) && (!(currentMap.Map[pfn[1].X, pfn[1].Y].Hero)))
                    {
                        currentMap.Map[pfn[0].X, pfn[0].Y].HasMonster = false;
                        currentMap.Map[pfn[1].X, pfn[1].Y].HasMonster = true;
                        monster.Pos = new Point(pfn[1].X, pfn[1].Y);
                        currentMap.Map[pfn[1].X, pfn[1].Y].Monster = monster;
                    }
                }

                return monster;
            }
            return monster;
        }
    }

}