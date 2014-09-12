using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjaGaiDemake
{
    public class Screen
    {
        //public List<BoundingRect> collisionAreas;
        public List<EnvironmentSolid> objs;
        public List<Enemy> enemies;
        public List<Powerup> powerups;
        public Screen()
        {
            //collisionAreas = new List<BoundingRect>();
            objs = new List<EnvironmentSolid>();
            enemies = new List<Enemy>();
            powerups = new List<Powerup>();
        }
    }
}
