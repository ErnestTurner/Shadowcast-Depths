using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowcastDepths
{
    static class MapFeature
        {

        public static Cell[,] smallRoomWithDoor
        {
            get
            {
                Cell[,] c =     {{CellType.wall,CellType.wall,CellType.wall,CellType.wall,CellType.wall,CellType.wall,CellType.wall},
                                {CellType.wall,CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor,CellType.wall},
                                {CellType.wall,CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor,CellType.wall},
                               {CellType.wall,CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor,CellType.wall},
                               {CellType.wall,CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor,CellType.wall},
                                {CellType.wall,CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor,CellType.wall},
                                {CellType.wall,CellType.wall,CellType.wall,CellType.unlockedDoor,CellType.wall,CellType.wall,CellType.wall}};
                return c;
            }
        }

         
            public static Cell[,] smallRoom
            {
                get
                {
                    Cell[,] c =     {{CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor},
                                {CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor},
                               {CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor},
                               {CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor},
                                {CellType.floor, CellType.floor,CellType.floor, CellType.floor, CellType.floor}};
                    return c;
                }
            }



            public static Cell[,] shortHallHorizonatal
            {
                get
                {
                    Cell[,] c = { { CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor } };
                    return c;
                }
            }

            public static Cell[,] shortHallVertical
            {
                get
                {
                    Cell[,] c =  {{CellType.floor},
                                 {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                 {CellType.floor}};
                    return c;
                }
            }

            public static Cell[,] singleFloor
            {
                get
                {
                    Cell[,] c = { { CellType.floor } };

                    return c;
                }
            }

            public static Cell[,] longHorizontalHall
            {
                get
                {
                    Cell[,] c = {{ CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor, CellType.floor }};

                    return c;
                }
            }

            public static Cell[,] longVerticalHall
            {
                get
                {
                    Cell[,] c =  {{CellType.floor},
                                 {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                 {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                 {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                  {CellType.floor},
                                 {CellType.floor},                                  
                                 {CellType.floor}};
                    return c;
                }
            }

            public static Cell[,] randomFeature
            {
                get
                {
                    Cell[,] c;
                    Random r = new Random();
                    switch (r.Next(1, 6))
                    {
                        case 6:
                            {
                                c = smallRoomWithDoor;
                                break;
                            }
                        case 5:
                            {
                                c = longVerticalHall;
                                break;
                            }
                        case 4:
                            {
                                c = longHorizontalHall;
                                break;
                            }
                        case 3:
                            {
                                c = smallRoom;
                                break;
                            }
                            
                        case 2:
                            {
                                //c = shortHallHorizonatal;
                                c = longHorizontalHall;
                                break;
                            }
                        case 1:
                            {
                                //c = shortHallVertical;
                                c = longVerticalHall;
                                break;
                            }

                        default:
                            {
                                c = singleFloor;
                                break;
                            }
                    }                     
                    return c;
                }
            }
        }
    
}
