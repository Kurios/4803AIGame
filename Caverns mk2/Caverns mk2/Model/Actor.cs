using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LuaInterface;

namespace Caverns_mk2.Model
{
    class Actor
    {

        private static Lua LuaVM = new Lua();

        public Object[] Update(String LuaCall)
        {
            return LuaVM.DoString(LuaCall);
        }
    }
}
