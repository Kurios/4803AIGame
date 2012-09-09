using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.GameScreens
{
    public class MapScreen:BaseGameState
    {

        #region Fields
        Map map;
        Camera camera;
        Texture2D spriteMap;

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
            map.setSpriteMap(spriteMap);
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
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


