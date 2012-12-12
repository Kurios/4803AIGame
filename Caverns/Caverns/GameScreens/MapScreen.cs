using Caverns.Char;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using MazeMaker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.GameScreens
{
    public class MapScreen : BaseGameState
    {
        #region Fields

        private MapCamera camera;
        private Map map;

        #region Constructor

        public MapScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            camera = new MapCamera(game, map);
        }

        #endregion Constructor

        #region XNA Method Region

        public override void Draw(GameTime gameTime)
        {
            System.Console.Out.WriteLine("Write us a line... make us some pretties ");
            camera.Render(gameref.GraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            base.Update(gameTime);
            map.update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            //Load Textures
            Texture2D spriteMap = gameref.Content.Load<Texture2D>("tilemap/woodsLandForest");
            Texture2D ash = gameref.Content.Load<Texture2D>("characters/Ash");
            Texture2D ashPort = gameref.Content.Load<Texture2D>("characters/portait/ash-ketchum");
            Texture2D link = gameref.Content.Load<Texture2D>("characters/Link");
            Texture2D linkPort = gameref.Content.Load<Texture2D>("characters/portait/Link (2)");
            Texture2D linkFalling = gameref.Content.Load<Texture2D>("characters/LinkFalling");
            Texture2D catLady = gameref.Content.Load<Texture2D>("characters/catLady");
            Texture2D neko = gameref.Content.Load<Texture2D>("characters/Rin");
            Texture2D nekoPort = gameref.Content.Load<Texture2D>("characters/portait/two");
            SpriteFont font = gameref.Content.Load<SpriteFont>("font/system");
            Texture2D keyText = gameref.Content.Load<Texture2D>("characters/Item Key01");
            Texture2D girlText = gameref.Content.Load<Texture2D>("characters/Parsee");
            Texture2D girlPort = gameref.Content.Load<Texture2D>("characters/portait/animeGirl1");
            Texture2D ghostSprite = gameref.Content.Load<Texture2D>("characters/FF6GhostSprites");

            //Shaders
            Effect basicEffect = gameref.Content.Load<Effect>("shaders/Basic3DShader");

            //basicEffect.CurrentTechnique = basicEffect.Techniques["TexturedNoShading"];
            Effect pxShader = gameref.Content.Load<Effect>("shaders/cavernShader");
            Effect charShader = gameref.Content.Load<Effect>("shaders/charShader");

            //Generate Map
            map = Loader.CreateMap(gameref, spriteMap, System.IO.File.ReadAllLines("ForestMap01"));

            //Generate Maze
            Maze maze = new Maze(2, 3); //Dimensions: #cols, #rows
            maze.generateMazePrim(0, 0);    //Generates Prim's Maze.  (Starting col, Starting row).
            Map caveMap = MazeLoader.createMap(gameref, spriteMap, maze);    //Create the map

            camera.setMap(map);

            //pxShader.Parameters["Viewport"].SetValue(new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));

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

            //Waterfall waterfall = new Waterfall(spriteMap, caveMap, gameref);
            //waterfall.Position = new Vector2(32 + 15, 32);
            //caveMap.characterList.Add(waterfall);

            //Key key1 = new Key(keyText,caveMap,gameref);
            //key1.Position = new Vector2(11, 11 + 32);
            //caveMap.characterList.Add(key1);

            //Key key2 = new Key(keyText, caveMap, gameref);
            //key2.Position = new Vector2(22 + 32, 19 + 64);
            //caveMap.characterList.Add(key2);

            PlayerChar pc = new PlayerChar(catLady, map, Game);
            pc.Position = new Vector2(20, 20);

            //map.characterList.Add(pc);
            caveMap.characterList.Add(pc);
            camera.SetFocus(pc);

            //!!!
            pc.Map = caveMap;
            camera.setMap(caveMap);
            map = caveMap;

            //!!!

            Girl girl = new Girl(girlText, caveMap, gameref, pc);
            girl.Portrait = girlPort;
            girl.Position = new Vector2(22, 16);
            while (!map.canMove((int)girl.Position.X, (int)girl.Position.Y, girl)) girl.Position = Vector2.Subtract(girl.Position, Vector2.UnitY);
            caveMap.characterList.Add(girl);

            Ghost ghost = new Ghost(ghostSprite, caveMap, gameref, girl);
            ghost.Position = new Vector2(40, 40);
            caveMap.characterList.Add(ghost);
            caveMap.enemyList.Add(ghost);
        }

        #endregion XNA Method Region

        #endregion Fields

        internal void playerHit()
        {
        }
    }
}