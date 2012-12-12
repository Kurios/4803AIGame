using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caverns_mk2.Model
{
    /// <summary>
    /// Ok, this class is special...
    /// 
    /// Its a wrapper class for the WorldNode Class... in fact, a WorldNode is a world, but  this is the public side of things per-say...
    ///
    /// Its also the root node. And the constructor of sorts.
    /// </summary>
    internal class World : WorldNode
    {

        public World()
            : base("root",null)
        {

        }

    }
}
