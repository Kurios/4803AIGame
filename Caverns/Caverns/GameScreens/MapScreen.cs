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
            map = new Map(game,new Vector2(32,32),100,100,spriteMap);
            camera = new Camera(game,map);
        }

        #endregion
        #region XNA Method Region
        
        protected override void LoadContent()
        {
            base.LoadContent();
            spriteMap = gameref.Content.Load<Texture2D>("tilemap/woodsLandForest");
            //map.setSpriteMap(spriteMap);
            Texture2D charTex = gameref.Content.Load<Texture2D>("characters/catLady");
            map = Loader.CreateMap(gameref,spriteMap,System.IO.File.ReadAllLines("map"));
            Woman woman = new Woman(charTex, map);
            woman.Position = new Vector2(10, 10);
            map.characterList.Add(woman);
            pc = new PlayerChar(charTex, map, Game);
            pc.Position = new Vector2(20, 20);
            map.characterList.Add(pc);
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


