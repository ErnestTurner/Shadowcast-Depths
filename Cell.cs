using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    public class Cell
    {
        private bool hasMonster;
        private string monsterType;
        private bool hero = false;
        private string type;
        private char apperance;
        private Monster monster = null;
        private bool hasSeen = false;
        public bool HasSeen
        {
            get { return hasSeen; }
            set { hasSeen = value; }
        }

        public char Apperance
        {
            get {
                if (hero)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return '@';
                }
                if(HasMonster)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    return monster.appearance;
                }
                if (type == CellType.downStairs.Type || type == CellType.upStairs.Type)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                
                return apperance;
            }
            set { apperance = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public Cell()
        {

        }

        public override bool Equals(object obj)
        {
            Cell cell2 = (Cell)obj;
            return this.Type == cell2.Type;
        }

        public static bool operator ==(Cell cell1, Cell cell2)
        {
            return cell1.Type == cell2.Type;
        }

        public static bool operator !=(Cell cell1, Cell cell2)
        {
            return cell1.Type != cell2.Type;
        }


        public bool Hero
        {
            get
            {
                return hero;
            }
            set
            {
                hero = value;
            }
        }

        public bool HasMonster
        {
            get
            {
                return hasMonster;
            }
            set
            {
                hasMonster = value;
            }
        }

        public string MonsterType
        {
            get
            {
                return monsterType;
            }
            set
            {
                monsterType = value;
            }
        }

        public Monster Monster
        {
            get
            {
                return monster;
            }
            set
            {
                monster = value;
            }
        }
    }
}
