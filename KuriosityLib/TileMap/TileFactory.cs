using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace KuriosityXLib.TileMap
{
    class TileFactory
    {
        List<Tile> designs = new List<Tile>();
        Texture2D spriteMap;
        int curDesign = 0;

        public TileFactory(Texture2D spriteMap){
            designs.Add(new Tile(0,0,new Rectangle(0,0,32,32),spriteMap));
            this.spriteMap = spriteMap;
        }

        public int AddTile()
        {
            designs.Add(new Tile(0,0,new Rectangle(0,0,32,32),spriteMap));
            curDesign ++;
            return curDesign;
        }

        //Base Sprite

        public void SetBaseSprite(Rectangle sprite, int tile)
        {
            designs[tile].baseText = sprite;
        }

        public void SetBaseSprite(Rectangle sprite)
        {
            designs[curDesign].baseText = sprite;
        }

        public void SetBaseSprite(int x, int y, int tile)
        {
            designs[tile].baseText = new Rectangle(x, y, 32, 32);
        }
        public void SetBaseSprite(int x, int y)
        {
            designs[curDesign].baseText = new Rectangle(x, y, 32, 32);
        }

        //Accent Sprite

        public void SetAccentSprite(Rectangle sprite, int tile)
        {
            designs[tile].accentText = sprite;
        }

        public void SetAccentSprite(Rectangle sprite)
        {
            designs[curDesign].accentText = sprite;
        }

        public void SetAccentSprite(int x, int y, int tile)
        {
            designs[tile].accentText = new Rectangle(x, y, 32, 32);
        }
        public void SetAccentSprite(int x, int y)
        {
            designs[curDesign].accentText = new Rectangle(x, y, 32, 32);
        }

        //Top Sprite

        public void SetTopSprite(Rectangle sprite, int tile)
        {
            designs[tile].topText = sprite;
        }

        public void SetTopSprite(Rectangle sprite)
        {
            designs[curDesign].topText = sprite;
        }

        public void SetTopSprite(int x, int y, int tile)
        {
            designs[tile].topText = new Rectangle(x, y, 32, 32);
        }
        public void SetTopSprite(int x, int y)
        {
            designs[curDesign].topText = new Rectangle(x, y, 32, 32);
        }

        //Passable

        public void SetPassible(bool passable, int tile)
        {
            designs[tile].Passible = passable;
        }

        public void SetPassible(bool passable)
        {
            designs[curDesign].Passible = passable;
        }


        //Get Tile
        public Tile getTile(int x, int y)
        {
            Tile ret = new Tile(x, y, new Rectangle(x, y, 32, 32), spriteMap);
            ret.baseText = designs[curDesign].baseText;
            ret.accentText = designs[curDesign].accentText;
            ret.topText = designs[curDesign].topText;
            ret.Passible = designs[curDesign].Passible;
            return ret;
        }

        public Tile getTile(int x, int y,int tile)
        {
            Tile ret = new Tile(x, y, new Rectangle(x, y, 32, 32), spriteMap);
            ret.baseText = designs[tile].baseText;
            ret.accentText = designs[tile].accentText;
            ret.topText = designs[tile].topText;
            ret.Passible = designs[tile].Passible;
            return ret;
        }
    }
}
