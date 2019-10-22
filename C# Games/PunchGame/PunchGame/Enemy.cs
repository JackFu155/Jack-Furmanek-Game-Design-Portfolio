using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PunchGame
{
    class Enemy
    {
        protected string name;
        protected int health;

        public Enemy()
        {
            name = "";
            health = 0;
        }
        public Enemy(string name, int health)
        {
            this.name = name;
            this.health = health;
        }

        public string Name { get { return name; } }
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }


        public int TakeDamage(int damage)
        {
            health -= damage;
            return health;
        }
    }
}
