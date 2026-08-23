using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowcastDepths
{
    public class Monster : Character
    {
        private ArtificialIntelegence ai;

        

        public ArtificialIntelegence Ai
        {
            get { return ai; }
            set { ai = value; }
        }

        public char appearance
        {
            get
            {
                switch( Name)
                {
                    case "imp":
                        {
                            return 'i';
                        }
                    case "rat":
                        {
                            return 'r';
                        }
                    default:
                        {
                            return 'd';
                        }
                }
            }
        }

        public string battleApperance
        {
            get
            {
                switch(Name)
                {
                    case "imp":
                        {
                            return @"                                     ,
       ,  .   (          )          -.\ |
       | / .- |\        /|         _  \'/
        \'/   | \.-""-./ |          \_) ;-'
     `'-; (_/ ;   _  _   ;           ) /
         \ (   \ (.\/.) /    .-.    / |
          \ \   \ \/\/ /-._.'   \   | |
           \ \   \ .. /_         \  | |
            \ \   |  |__)     |\  \ | |
             \ `'`|==| _ | \  \| |
              \,-'|==| \      |  \    |
                   \/ '.    /   `\ /
                          |   |     `   ,
                          |   |         )\
                __.....__ /    |        /  \
              /`              \        `//`
              |  \`-....- '\    `-.____.' /
              |  |        /   /`'-----'`
              |  |        |  |
              | /         |  |
       .------' \         /  /
      (((--------'        \  |
                           | \
                           | |
                           | |
                           | /
                          /  )
                         /   |
                        (-(-('";
                        }
                    case "rat":
                        {
                            return @"                                              .-
                                             (
                                              \
                .-.  .-.                       |
               (-. \/.- )  _..---''''' -.      /
                '.  `  '--'             `\__.:
                 / dd /           /     / --'
             '-.|   _.;            \    (
             - ' `--`-.)\  |-..____.-;-.  >
                     / / /      `--' .' /
         .'.'_ /           `--'
                  `` ``";
                        }
                    default:
                        {
                            return @"       ___    ___ 
      '-._\__/_.-'-;_, 
          O\/O       /_, 
       _.-'_  )-,      /_, 
      /_.-'| /\==)       /_, 
      `   /| | \/ /\  .-   /_, 
       _.' L/_.' /==\/       /_, 
      {{{-' {{{-'/\=/    _.'  .' 
                (  `\   <\    \    , 
                _>  _>   )`.   '._/|  
         jgs   {{{-{{{--'   `-.___/";
                        }
                }
            }
        }

        public Monster(string name, int strength, int health, int vision, int constitution): base(name, strength, health, vision, constitution)
        {
            Random rand = new Random();
            ai = new ArtificialIntelegence();
            Experience = (strength + health + vision + constitution) / 10;
            CharacterLevel = rand.Next(MapContainer.depth-3, MapContainer.depth+3);
            CharacterLevel = CharacterLevel > 0 ? CharacterLevel : 1;
            for(int  i = 1; i < CharacterLevel; i++)
            {
                boostStats();
            }
        }
      
        public Monster()
        {
            // TODO: Complete member initialization
        }       
        
        override public void destroy()
        {
            Game.currentMap.Map[Pos.X, Pos.Y].HasMonster = false;
        }        
    }
}
