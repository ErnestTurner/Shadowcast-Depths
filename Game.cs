using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace ShadowcastDepths
{

    public class Game
    {
        public static string statusMessage;
        public static Player player;       
        public static MapContainer currentMap;
        public static bool gameOn { get; set; }     
       
        public Game()
        {
            Console.SetWindowSize(Console.LargestWindowWidth-1, Console.LargestWindowHeight-1);
            int windowWidth = Console.WindowWidth-1;
            int windowHeight = Console.WindowHeight-1;
            Console.SetBufferSize(windowWidth+10, windowHeight+10);
            Console.SetWindowSize(windowWidth/2,windowHeight);
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (loadScreen())//either start a new  game, or load a saved one 
            {
                startGame();
            }
            else
            {
                startGame();
                //SaveLoadGame.load(this);
            } 
            while (gameRun()) ;// This method should return true as long as the game is going to continue to play. gameRun initiates all the main functions of the the body of the game. 
        }

        private bool loadScreen()
        {
            //choose to start a new game, or load a saved one
            bool newGame = true; 
            //Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Would you like to: \n 1.  Start a new game \n 2. Load a saved game \n");
            Console.Write("Well? ");
            bool noValidResponse = true;
            while(noValidResponse)
            {
                ConsoleKey key = Console.ReadKey().Key;
                switch(key)
                {
                    case ConsoleKey.D1:
                        noValidResponse = false;
                        break;
                    case ConsoleKey.D2:
                        noValidResponse = false;
                        newGame=false;
                        break;
                }
            }
            return newGame;           
        }

        private bool gameRun()
        {                
            gameOn = true;//returns true if the game is to continue            
            ConsoleKeyInfo keyPressed;//stores the key pressed 
            drawScreen();//the screen is formated and displayed 
            keyPressed = Console.ReadKey(); //gets input from the keyboard
                                            // ThreadPool.SetMaxThreads(1, 0);
                                            // ThreadPool.QueueUserWorkItem(new WaitCallback(monsterAction), player);
            monsterAction(player);
            player.regenerate();
            if (keyPressed.Key == ConsoleKey.Q) // if q the game quits, otherwise, processes key for futher action.
            {
                gameOn = false;
            }
            else
            {
                processKeyPress(keyPressed);                
            }
            return gameOn;
        }

        private static void monsterAction(object a)
        {
            List<Point> newMonsterLocation = new List<Point>();
            for (int i = 0; i < currentMap.Monsters.Count; i++) //iterates through all monsters on the map                
            {
                if (!(currentMap.Map[currentMap.Monsters[i].Pos.X, currentMap.Monsters[i].Pos.Y].Monster.HealthPoints <= 0)) //checks to see if the monster is alive
                {
                    currentMap.Monsters[i].regenerate();
                    currentMap.Monsters[i] = currentMap.Map[currentMap.Monsters[i].Pos.X, currentMap.Monsters[i].Pos.Y].Monster.Ai.action(currentMap.Map[currentMap.Monsters[i].Pos.X, currentMap.Monsters[i].Pos.Y].Monster, currentMap);//performs the monsters action
                }
            }
        }       
        
        private void processKeyPress(ConsoleKeyInfo keyPressed)
        {
            switch (keyPressed.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.DownArrow:
                case ConsoleKey.LeftArrow:
                case ConsoleKey.RightArrow:// all arrow keys processed in the player.move() method
                    {
                        player.move(keyPressed, currentMap);
                        if (currentMap.Map[player.Pos.X, player.Pos.Y].Type == CellType.downStairs.Type)
                        {
                            MapContainer.depth++;
                            currentMap = new MapContainer();
                            player.Pos = new Point(currentMap.Size.X / 2, currentMap.Size.Y / 2);
                            currentMap.Map[currentMap.Size.X / 2, currentMap.Size.Y / 2].Hero = true;
                            break;
                        }
                        if (currentMap.Map[player.Pos.X, player.Pos.Y].Type == CellType.upStairs.Type) // if the player steps on a stairway generate a new map
                        {
                            MapContainer.depth--;
                            currentMap = new MapContainer();
                            player.Pos = new Point(currentMap.Size.X / 2, currentMap.Size.Y / 2);
                            currentMap.Map[currentMap.Size.X / 2, currentMap.Size.Y / 2].Hero = true;                            
                        }
                        break;
                    }
                case ConsoleKey.S: // s key inititates save game
                    {
                        //SaveLoadGame.saveGame(player, currentMap); (save function is broken)
                        break;
                    }               
            }
        }

        private void drawScreen()
        {
            Console.Clear();            
            Console.WriteLine("     " + player.Name + "    " + "Health : " + player.HealthPoints + "   Strenght : " + player.Strength + "  Constitution : " + player.Constitution + "   Vision: " + player.Vision + " pos:" +player.Pos.X + ","+ player.Pos.Y  + "depth : " + MapContainer.depth);
            Console.WriteLine("      Level : " + player.CharacterLevel + "    Experience : " + player.Experience + "    NextLevel : " + player.NextLevel);//status bar of sorts for top of screen            
            currentMap.drawMap(player);//the drawMap function of Map returns a string formated to properly display the map to the screen
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Choose an action: move= Arrow Keys  Save State= S   Quit= Q" );//prompt for input
            Console.WriteLine(statusMessage);
            statusMessage = "";
        }
        public void startGame()
        {            
            //This method sets up everything for the game to begin. 
            CharacterCreator cc = new CharacterCreator();// The CharacterCreator allows the user to set the intital values of his character
            currentMap = new MapContainer(); 
            player = new Player(cc.Name, cc.Strength, cc.Health, cc.Vision, cc.Constitution);// the selected states are used to instanciate a player object
            player.Pos = new Point(currentMap.Size.X/2,currentMap.Size.Y/2);//sets players inital starting place           
            currentMap.Map[player.Pos.X, player.Pos.Y].Hero = true;           
        }

        public void load(Player p, MapContainer m)
        {
            player = p;
            currentMap = m;
        }        
    }
}