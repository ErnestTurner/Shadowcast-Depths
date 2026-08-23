using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShadowcastDepths
{
    public class Character
    {
        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        private int maxHealthPoints;
        public int MaxHealthPoints
        {
            get { return maxHealthPoints; }
            set { maxHealthPoints = value; }
        }

        private int healthPoints;
        public int HealthPoints
        {
            get { return healthPoints; }
            set { healthPoints = value; }
        }

        private int strength;
        public int Strength
        {
            get { return strength; }
            set { strength = value; }
        }

        private int vision;
        public int Vision
        {
            get { return vision; }
            set { vision = value; }
        }

        private int constitution;
        public int Constitution
        {
            get { return constitution; }
            set { constitution = value; }
        }        

        private  Point pos;
        public  Point Pos 
        {
            get 
            {
                return pos;                
            }
            set
            {
                pos = value;
            }
        }

        private int characterLevel = 1;
        public int CharacterLevel
        {
            get { return characterLevel; }
            set { characterLevel = value; }
        }

        private int experience = 0;
        public int Experience
        {
            get { return experience; }
            set { experience = value; }
        }

        private int nextLevel = 10;
        public int NextLevel
        {
            get { return nextLevel; }
            set { nextLevel = value; }
        }

        public int regenerationPoints = 0;

        private int maxStrength;
        public int MaxStrength
        {
            get { return maxStrength; }
            set { maxStrength = value; }
        }

        private int maxVision;
        public int MaxVision
        {
            get { return maxVision; }
            set { maxVision = value; }
        }

        private int maxConstitution;
        public int MaxConstitution
        {
            get { return maxConstitution; }
            set { maxConstitution = value; }
        }
    
        public Character(string name, int strenght, int health, int vision, int constitution)
        {            
            this.name = name;
            this.maxStrength = strenght;
            this.strength = strenght;
            this.maxHealthPoints = health;
            this.healthPoints = health;
            this.maxVision = vision;
            this.vision = vision;
            this.maxConstitution = constitution;
            this.constitution = constitution;
        }

        public Character()
        {
            
        }


        public void meleeAttack(Character target)
        {
            Console.Beep(90, 100);
            Random r = new Random();
            int damage = r.Next(this.Strength - 6, this.Strength);
            if (damage < 0)
            {
                damage = 0;
            }
            Game.statusMessage+=("\n" + this.Name + " attacked " + target.Name + " for " + damage + " damage");
            target.HealthPoints -= damage;
            if(target.HealthPoints <= 0)
            {
                gainExperience(target);
                target.destroy();
                Game.statusMessage+= ("\n" +this.Name + " has destroyed " + target.Name);
            }
        }

        private void gainExperience(Character target)
        {
            experience += ((target.MaxConstitution + target.MaxHealthPoints + target.MaxStrength + target.MaxVision)/6);
            while(experience>nextLevel)
            {
                nextLevel += (int)((nextLevel *2)/1.2) ;
                CharacterLevel++;
                boostStats();
            }
        }

        public void boostStats()
        {
            Random r = new Random();
            double rand = r.Next(1, MaxStrength) / 5;
            MaxStrength += (int)Math.Round(rand);
            strength = MaxStrength;
            rand = r.Next(1, MaxHealthPoints) / 5;
            MaxHealthPoints += (int)Math.Round(rand);
            rand = r.Next(1, MaxConstitution) / 5;
            MaxConstitution += (int)Math.Round(rand);
            constitution = MaxConstitution;
        }

        virtual public void destroy()
        {
        }

        public void regenerate()
        {
            if (healthPoints < MaxHealthPoints)
            {
                regenerationPoints += Constitution;
                if (regenerationPoints > 40)
                {
                    regenerationPoints -= 40;
                    healthPoints += 1;
                }
            }            
        }

        

        public string report()
        {
            //formats a string with the characters name, health, strenght, and position for writing a save game file.
            char separator = '*';
            string characterReport = "";
            characterReport += this.Name + separator + this.Strength + separator + this.HealthPoints + separator + this.Vision + separator + Pos.X + separator + Pos.Y + separator;
            return characterReport;           
        }
    }
}
