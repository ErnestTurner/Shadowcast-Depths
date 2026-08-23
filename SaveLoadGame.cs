using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ShadowcastDepths
{
    static class  SaveLoadGame
    {
        
        public static void load(Game g)
        {
            
            string fileToLoad;
            Console.Clear();
            Console.WriteLine("Which game should be loaded?");
            string[] filePaths = Directory.GetFiles(Dir.AssemblyDirectory + "\\saveGame", "*.txt");//creates a string array containing .txt files in the saveGame folder.
            for( int i = 0; i < filePaths.Length; i++)
            {
                Console.WriteLine((i + 1) + ".  " + filePaths[i].Remove(0,(Dir.AssemblyDirectory.Length +9))); //Displays the files, numbered, while removing all but the file name. 
            }
            Console.Write("what is your choice? ");            
            bool noValidAnswer = true;
            while(noValidAnswer) //loops until a valid file is selected. 
            {
                int number;
                string choice = Console.ReadLine();
                int.TryParse(choice, out number);
                if(number > 0 && number <= filePaths.Length)
                {
                    fileToLoad = filePaths[number-1];
                    loadGame(fileToLoad, g);//this method will load the game
                    noValidAnswer = false;
                }                
            }
            return;    
        }

        public static void saveGame(Player player, MapContainer currentMap)
        {
            string saveString = "";
            saveString += player.report();
            saveString += currentMap.report();
            StreamWriter s = new StreamWriter(Dir.AssemblyDirectory + "\\savegame\\" + player.Name + ".txt");
            s.WriteLine(saveString);
            s.Close();
        }

        public static void loadGame(string fileToLoad, Game g)
        {
        //    Player p;
        //    MapContainer m;
        //    char seperator = '*';
        //    StreamReader s = new StreamReader(fileToLoad);
        //    string loadString = s.ReadLine();
        //    string[] loadArray = loadString.Split(seperator);
        //    //p = new Player(loadArray[0], int.Parse(loadArray[1]), int.Parse(loadArray[2]), int.Parse(loadArray[3]));   save and load feature is broken
        //    //p.Pos = new Point(int.Parse(loadArray[4]),int.Parse(loadArray[5]));

        //    m = new MapContainer(loadArray[6],loadArray[7], loadArray[8]);
        //    g.load(p, m);            
        }
    }
}
