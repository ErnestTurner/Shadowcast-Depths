using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    static class CellType
    {
        public static Cell wall
        {
            get
            {
                Cell c = new Cell();
                c.Type = "wall";
                c.Apperance = '#';
                return c;
            }

        }

        public static Cell floor
        {
            get
            {
                Cell c = new Cell();
                c.Type = "floor";
                c.Apperance = ' ';
                return c;
            }
        }
        public static Cell lockedDoor
        {
            get
            {
                Cell c = new Cell();
                c.Type = "lockedDoor";
                c.Apperance = '%';
                return c;
            }
        }

        public static Cell unlockedDoor
        {
            get
            {
                Cell c = new Cell();
                c.Type = "unlockedDoor";
                c.Apperance = '/';
                return c;
            }
        }

        public static Cell downStairs
        {
            get
            {
                Cell c = new Cell();
                c.Type = "downStairs";
                c.Apperance = '<';
                return c;
            }
        }

        public static Cell upStairs
        {
            get
            {
                Cell c = new Cell();
                c.Type = "upStairs";
                c.Apperance = '>';
                return c;
            }
        }

        public static Cell determineCellType(char p)
        {
            switch (p)
            {
                case '#':
                    {
                        return wall;                        
                    }
                case '.':
                    {
                        return floor;
                    }
                default:
                    {
                        return wall;                        
                    }
            }

        }

       
    }
}

