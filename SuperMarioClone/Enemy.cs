using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class Enemy : Actor
    {
        public Enemy(Rectangle size) : base(size)
        {
            color = Color.Red;
        }
    }
}
