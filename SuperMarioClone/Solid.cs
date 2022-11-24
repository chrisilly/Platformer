using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioClone
{
    internal class Solid : GameObject
    {
        public static List<Solid> solidList { get; set; }

        public Solid(Rectangle size) : base(size)
        {
            color = Color.Green;
        }
    }
}
