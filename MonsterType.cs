using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    public static class MonsterType
    {
        public static Monster imp
        {
            get
            {
                Monster m = new Monster("imp", 6, 10, 10, 10);
                return m;
            }            
        }

        public static Monster rat
        {
            get
            {
                Monster m = new Monster("rat", 3, 7, 5, 20);
                return m;
            }
        }
        public static Monster randomMonster()
        {
            Random r = new Random();
            switch(r.Next(1,3))
            {
                case 1:
                    {
                        return rat;
                    }
                case 2:
                    {
                        return imp;
                    }
                default:
                    {
                        return rat;
                    }
            }           
            
        }
    }
}
