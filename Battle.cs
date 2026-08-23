using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{

    class Battle
    {
        Player player;
        Monster monster;

        public Battle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
            beginBattle();
        }

        private void beginBattle()
        {
            while (monster.HealthPoints > 0 && player.HealthPoints > 0)
            {
                drawScreen();
                processKeyPress(Console.ReadKey());
                drawScreenFlash();
            }

        }

        private void drawScreenFlash()
        {
            Console.Clear();
            Console.WriteLine("     " + player.Name + "    " + "Health : " + player.HealthPoints + "   Strenght : " + player.Strength + "  Constitution : " + player.Constitution + "   Vision: " + player.Vision + " pos:" + player.Pos.X + "," + player.Pos.Y + "depth : " + MapContainer.depth);
            Console.WriteLine("      Level : " + player.CharacterLevel + "    Experience : " + player.Experience + "    NextLevel : " + player.NextLevel);//status bar of sorts for top of screen 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(monster.battleApperance);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n    You have encontered " + monster.Name);
            Console.WriteLine("\n1. Attack  2. Flee");
            Console.WriteLine(Game.statusMessage);
            Game.statusMessage = "";
            System.Threading.Thread.Sleep(1000);
        }

        private void drawScreen()
        {
            Console.Clear();
            Console.WriteLine("     " + player.Name + "    " + "Health : " + player.HealthPoints + "   Strenght : " + player.Strength + "  Constitution : " + player.Constitution + "   Vision: " + player.Vision + " pos:" + player.Pos.X + "," + player.Pos.Y + "depth : " + MapContainer.depth);
            Console.WriteLine("      Level : " + player.CharacterLevel + "    Experience : " + player.Experience + "    NextLevel : " + player.NextLevel);//status bar of sorts for top of screen 
            Console.Write(monster.battleApperance);
            Console.WriteLine("\n    You have encontered " + monster.Name);
            Console.WriteLine("\n1. Attack  2. Flee");
            Console.WriteLine(Game.statusMessage);
            Game.statusMessage = "";
        }

        private void processKeyPress(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.D1:
                    {
                        monster.meleeAttack(player);
                        player.meleeAttack(monster);
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        monster.meleeAttack(player);
                        break;
                    }
            }
        }
    }
}

