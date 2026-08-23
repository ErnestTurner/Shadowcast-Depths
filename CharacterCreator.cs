using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ShadowcastDepths
{
    public class CharacterCreator
    {
        private string name;
        private int strength = 10;
        private int health = 10;
        private int vision = 2;
        private int constitution = 10;

        public int Constitution
        {
            get { return constitution; }           
        }
        private int attributePoints = 10;

        public CharacterCreator()
        {
            getName();
            while (selectAttributes()) ;            
        }
        public int Vision
        {
            get { return vision; }            
        }
        public int Health
        {
            get { return health ; }
        }

        public int Strength
        {
            get { return strength; }
        }

        public string Name
        {
            get { return name; }
        }

        private bool selectAttributes()
        {
            bool more = true;
            Console.Clear();
            Console.WriteLine(name + " has the following attributes: ");
            Console.WriteLine("Strength      " + strength);
            Console.WriteLine("Health        " + health);
            Console.WriteLine("Vision        " + vision);
            Console.WriteLine("Constitution  " + Constitution);
            Console.WriteLine("You have " + attributePoints + " left to add.");
            Console.WriteLine("What is your option?  ");
            Console.WriteLine("1. Add to Strength");
            Console.WriteLine("2. Add to Health");
            Console.WriteLine("3. Add to Vision");
            Console.WriteLine("4. Add to Constitution"); 
            Console.WriteLine("5. Remove from Strength");
            Console.WriteLine("6. Remove from Health");
            Console.WriteLine("7. Remove from Vision");
            Console.WriteLine("8. Remove from Constitution"); 
            Console.WriteLine("9. Finsh");
            more = processInput(more);
            return more;
        }

        private bool processInput(bool more)
        {
            int result;
            if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out result))
            {
                switch (result)
                {
                    case 1:
                        {
                            if (attributePoints > 0)
                            {
                                strength++;
                                attributePoints--;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (attributePoints > 0)
                            {
                                health++;
                                attributePoints--;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (attributePoints > 0)
                            {
                                vision++;
                                attributePoints--;
                            }
                            break;
                        }
                    case 4:
                        {
                            if (attributePoints > 0)
                            {
                                constitution++;
                                attributePoints--;
                            }
                            break;
                        }
                    case 5:
                        {
                            if (strength > 1)
                            {
                                strength--;
                                attributePoints++;
                            }
                            break;
                        }
                    case 6:
                        {
                            if (health > 1)
                            {
                                health--;
                                attributePoints++;
                            }
                            break;
                        }
                    case 7:
                        {
                            if (vision > 1)
                            {
                                vision--;
                                attributePoints++;
                            }
                            break;
                        }
                    case 8:
                        {
                            if (Constitution > 1)
                            {
                                constitution--;
                                attributePoints++;
                            }
                            break;
                        }
                    case 9:
                        {
                            more = false;
                            break;
                        }
                }
            }
            return more;
        }
    
        public void getName()
        {
            Console.Clear();
            Console.Write("What shall your name be?  ");
            name = Console.ReadLine().ToString();
        }
    }
}
