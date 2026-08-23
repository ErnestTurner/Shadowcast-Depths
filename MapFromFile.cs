using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowcastDepths
{
    public class MapFromFile
    {
        
        public char[,] getMapFromFile()
        {
            char[,] map; //an array to store a map            
            System.IO.StreamReader file =   new System.IO.StreamReader(Dir.AssemblyDirectory + "\\maps\\map1.txt"); //opens the file to be read
            int row = int.Parse(file.ReadLine()); // first line of the file should contain the number of rows
            int column = int.Parse(file.ReadLine());// second line of file should contain the number of columns
            map = new char[row, column]; //initialize map to the provided row, column size
            for(int i = 0; i < row; i++) //this will iterate through the lines of the file, corresponding to rows of the map
            {
                string rowTxt = file.ReadLine();
                for(int x = 0; x < column; x++) // This will iterate through the chars contained in the string of text that makes up the row. each char represents a column or cell. 
                {
                    map[i, x] = rowTxt[x]; //sets the char to the corresponding cell of our 2d array
                }
            }            
            file.Close(); //closes the file now we are finished with it
            return map; // returns the now retrieved map. 
        }
    }    
}
