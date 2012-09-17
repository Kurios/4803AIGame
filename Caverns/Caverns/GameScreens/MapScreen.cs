using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Caverns.Char;

namespace Caverns.GameScreens
{
    public class MapScreen:BaseGameState
    {

        #region Fields
        Map map;
        Camera camera;
        Texture2D spriteMap;
        PlayerChar pc;

        #region Constructor

        public MapScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            //map = new Map(game,new Vector2(32,32),100,100,spriteMap);
            camera = new Camera(game,map);
        }

        #endregion
        #region XNA Method Region
        
        protected override void LoadContent()
        {
            base.LoadContent();
            spriteMap = gameref.Content.Load<Texture2D>("tilemap/woodsLandForest");
            //map.setSpriteMap(spriteMap);
            Texture2D ash = gameref.Content.Load<Texture2D>("characters/Ash");
            Texture2D ashPort = gameref.Content.Load<Texture2D>("characters/portait/ash-ketchum");
            Texture2D link = gameref.Content.Load<Texture2D>("characters/Link");
            Texture2D linkPort = gameref.Content.Load<Texture2D>("characters/portait/Link (2)");
            Texture2D linkFalling = gameref.Content.Load<Texture2D>("characters/LinkFalling");
            Texture2D catLady = gameref.Content.Load<Texture2D>("characters/catLady");
            Texture2D neko = gameref.Content.Load<Texture2D>("characters/Rin");
            Texture2D nekoPort = gameref.Content.Load<Texture2D>("characters/portait/two");
            map = Loader.CreateMap(gameref,spriteMap,System.IO.File.ReadAllLines("ForestMap01"));
            Map caveMap = Loader.CreateMap(gameref,spriteMap,System.IO.File.ReadAllLines("CaveMap01"));
            camera.setMap(map);
            //Woman woman = new Woman(charTex, map,gameref);
            //woman.Position = new Vector2(10, 10);
            
            Kid1 kid1 = new Kid1(ash, map, gameref);
            kid1.Portrait = ashPort;
            map.characterList.Add(kid1);

            Kid2 kid2 = new Kid2(link, map, gameref);
            kid2.Portrait = linkPort;
            kid2.Falling = linkFalling;
            map.characterList.Add(kid2);

            Kid3 kid3 = new Kid3(neko, map, gameref);
            kid3.Portrait = nekoPort;
            map.characterList.Add(kid3);

            CaveIn caveIn = new CaveIn(link, map, gameref, caveMap);
            map.characterList.Add(caveIn);

            pc = new PlayerChar(catLady, map, Game);
            pc.Position = new Vector2(20, 20);
            map.characterList.Add(pc);
            caveMap.characterList.Add(pc);
            camera.SetFocus(pc);

        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            map.update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();
            base.Draw(gameTime);
            camera.Draw(gameTime);
            gameref.SpriteBatch.End();
        }
        #endregion

        #endregion
    }
}


