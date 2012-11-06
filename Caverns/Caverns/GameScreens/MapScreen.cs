using Caverns.Char;
using KLib.NerualNet.emotionState;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using MazeMaker;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Caverns.GameScreens
{
    public class MapScreen : BaseGameState
    {
        #region Fields

        public Effect charShader;
        public PlayerChar pc;
        private RenderTarget2D buffer;
        private Camera camera;
        private eSpace espace;
        private SpriteFont font;
        private Ghost ghost;
        private Girl girl;
        private Map map;
        private int playerhit = 0;
        private Effect pxShader;
        private int selectedEmotion;
        private RenderTarget2D ShaderRenderTarget;
        private Texture2D ShaderTexture;
        private Texture2D spriteMap;
        private Texture2D white;

        #region Constructor

        public MapScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            //map = new Map(game,new Vector2(32,32),100,100,spriteMap);
            camera = new Camera(game, map);
            espace = new eSpace(.2, .2, .2, .2, .2, .2, .2, .2);
        }

        #endregion Constructor

        #region XNA Method Region

        public override void Draw(GameTime gameTime)
        {
            //RenderTarget2D buffer = new RenderTarget2D(gameref.GraphicsDevice, gameref.GraphicsDevice.DisplayMode.Width, gameref.GraphicsDevice.DisplayMode.Height);
            //buffer.GraphicsDevice.SetRenderTarget(buffer);
            gameref.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, pxShader);

            //gameref.SpriteBatch.Begin();
            base.Draw(gameTime);
            camera.Draw(gameTime);
            if (playerhit > 0) playerhit--;
            gameref.SpriteBatch.End();

            //buffer.GraphicsDevice.SetRenderTarget(null);
            gameref.SpriteBatch.Begin();
            gameref.SpriteBatch.Draw((Texture2D)buffer, buffer.Bounds, Color.White);
            {
                gameref.SpriteBatch.Draw(white, new Rectangle(590, 590, 400, 150), Color.Black);
                if (selectedEmotion == 0)
                    gameref.SpriteBatch.DrawString(font, "fear :" + (espace.Fear.ToString()), new Vector2(600, 600), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "fear :" + (espace.Fear.ToString()), new Vector2(600, 600), Color.Red);

                if (selectedEmotion == 1)
                    gameref.SpriteBatch.DrawString(font, "anger :" + (espace.Anger.ToString()), new Vector2(600, 610), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "anger :" + (espace.Anger.ToString()), new Vector2(600, 610), Color.Red);

                if (selectedEmotion == 2)
                    gameref.SpriteBatch.DrawString(font, "sadness :" + (espace.Sadness.ToString()), new Vector2(600, 620), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "sadness :" + (espace.Sadness.ToString()), new Vector2(600, 620), Color.Red);

                if (selectedEmotion == 3)
                    gameref.SpriteBatch.DrawString(font, "joy :" + (espace.Joy.ToString()), new Vector2(600, 630), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "joy :" + (espace.Joy.ToString()), new Vector2(600, 630), Color.Red);

                if (selectedEmotion == 4)
                    gameref.SpriteBatch.DrawString(font, "disgust :" + (espace.Disgust.ToString()), new Vector2(600, 640), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "disgust :" + (espace.Disgust.ToString()), new Vector2(600, 640), Color.Red);

                if (selectedEmotion == 5)
                    gameref.SpriteBatch.DrawString(font, "trust :" + (espace.Trust.ToString()), new Vector2(600, 650), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "trust :" + (espace.Trust.ToString()), new Vector2(600, 650), Color.Red);

                if (selectedEmotion == 6)
                    gameref.SpriteBatch.DrawString(font, "anticipation :" + (espace.Anticipation.ToString()), new Vector2(600, 660), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "anticipation :" + (espace.Anticipation.ToString()), new Vector2(600, 660), Color.Red);

                if (selectedEmotion == 7)
                    gameref.SpriteBatch.DrawString(font, "supprise :" + (espace.Supprise.ToString()), new Vector2(600, 670), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "supprise :" + (espace.Supprise.ToString()), new Vector2(600, 670), Color.Red);

                gameref.SpriteBatch.Draw(white, new Rectangle(90, 590, 400, 150), Color.Black);
                if (selectedEmotion == 0)
                    gameref.SpriteBatch.DrawString(font, "fear :" + (ghost.eSpace.Fear.ToString()), new Vector2(100, 600), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "fear :" + (ghost.eSpace.Fear.ToString()), new Vector2(100, 600), Color.Red);

                if (selectedEmotion == 1)
                    gameref.SpriteBatch.DrawString(font, "anger :" + (ghost.eSpace.Anger.ToString()), new Vector2(100, 610), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "anger :" + (ghost.eSpace.Anger.ToString()), new Vector2(100, 610), Color.Red);

                if (selectedEmotion == 2)
                    gameref.SpriteBatch.DrawString(font, "sadness :" + (ghost.eSpace.Sadness.ToString()), new Vector2(100, 620), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "sadness :" + (ghost.eSpace.Sadness.ToString()), new Vector2(100, 620), Color.Red);

                if (selectedEmotion == 3)
                    gameref.SpriteBatch.DrawString(font, "joy :" + (ghost.eSpace.Joy.ToString()), new Vector2(100, 630), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "joy :" + (ghost.eSpace.Joy.ToString()), new Vector2(100, 630), Color.Red);

                if (selectedEmotion == 4)
                    gameref.SpriteBatch.DrawString(font, "disgust :" + (ghost.eSpace.Disgust.ToString()), new Vector2(100, 640), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "disgust :" + (ghost.eSpace.Disgust.ToString()), new Vector2(100, 640), Color.Red);

                if (selectedEmotion == 5)
                    gameref.SpriteBatch.DrawString(font, "trust :" + (ghost.eSpace.Trust.ToString()), new Vector2(100, 650), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "trust :" + (ghost.eSpace.Trust.ToString()), new Vector2(100, 650), Color.Red);

                if (selectedEmotion == 6)
                    gameref.SpriteBatch.DrawString(font, "anticipation :" + (ghost.eSpace.Anticipation.ToString()), new Vector2(100, 660), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "anticipation :" + (ghost.eSpace.Anticipation.ToString()), new Vector2(100, 660), Color.Red);

                if (selectedEmotion == 7)
                    gameref.SpriteBatch.DrawString(font, "supprise :" + (ghost.eSpace.Supprise.ToString()), new Vector2(100, 670), Color.Goldenrod);
                else
                    gameref.SpriteBatch.DrawString(font, "supprise :" + (ghost.eSpace.Supprise.ToString()), new Vector2(100, 670), Color.Red);

                gameref.SpriteBatch.DrawString(font, "Framerate: " + (1 / gameTime.ElapsedGameTime.TotalSeconds).ToString(), new Vector2(600, 690), Color.Red);
            }
            gameref.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            map.update(gameTime);
            espace = girl.eSpace;
            if (InputHandler.KeyPressed(Keys.Add))
            {
                selectedEmotion++;
                if (selectedEmotion > 7) selectedEmotion = 0;
            }

            if (InputHandler.KeyPressed(Keys.Subtract))
            {
                selectedEmotion--;
                if (selectedEmotion < 0) selectedEmotion = 7;
            }
            if (InputHandler.KeyPressed(Keys.Divide))
            {
                switch (selectedEmotion)
                {
                    case 0: espace.Fear -= 1; break;
                    case 1: espace.Anger -= 1; break;
                    case 2: espace.Sadness -= 1; break;
                    case 3: espace.Joy -= 1; break;
                    case 4: espace.Disgust -= 1; break;
                    case 5: espace.Trust -= 1; break;
                    case 6: espace.Anticipation -= 1; break;
                    case 7: espace.Supprise -= 1; break;
                }
                girl.addEmotion(espace, 100);
            }
            if (InputHandler.KeyPressed(Keys.Multiply))
            {
                switch (selectedEmotion)
                {
                    case 0: espace.Fear += 1; break;
                    case 1: espace.Anger += 1; break;
                    case 2: espace.Sadness += 1; break;
                    case 3: espace.Joy += 1; break;
                    case 4: espace.Disgust += 1; break;
                    case 5: espace.Trust += 1; break;
                    case 6: espace.Anticipation += 1; break;
                    case 7: espace.Supprise += 1; break;
                }
                girl.addEmotion(espace, 100);
            }

            pxShader.Parameters["Fear"].SetValue((float)espace.Fear);
            pxShader.Parameters["Anger"].SetValue((float)espace.Anger);
            pxShader.Parameters["Sadness"].SetValue((float)espace.Sadness);
            pxShader.Parameters["Joy"].SetValue((float)espace.Joy);
            pxShader.Parameters["Disgust"].SetValue((float)espace.Disgust);
            pxShader.Parameters["Supprise"].SetValue((float)espace.Supprise);
            pxShader.Parameters["PlayerPos"].SetValue(new Vector2((int)(pc.Position.X - camera.Position.X) * 32 - (16), (int)(pc.Position.Y - camera.Position.Y) * 32));
            pxShader.Parameters["SecondPos"].SetValue(new Vector2((int)(girl.Position.X - camera.Position.X) * 32 - (16), (int)(girl.Position.Y - camera.Position.Y) * 32));
            pxShader.Parameters["PlayerHit"].SetValue(playerhit);
        }

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

            white = gameref.Content.Load<Texture2D>("backgrounds/white");
            map = Loader.CreateMap(gameref, spriteMap, System.IO.File.ReadAllLines("ForestMap01"));

            //MAZE STUFF ADDED HERE.
            Maze maze = new Maze(2, 3); //Dimensions: #cols, #rows
            maze.generateMazePrim(0, 0);    //Generates Prim's Maze.  (Starting col, Starting row).
            Map caveMap = MazeLoader.createMap(gameref, spriteMap, maze);    //Create the map

            //MAZE STUFF DONE.

            //Map caveMap = Loader.CreateMap(gameref,spriteMap,System.IO.File.ReadAllLines("CaveMap01"));

            font = gameref.Content.Load<SpriteFont>("font/system");
            Texture2D keyText = gameref.Content.Load<Texture2D>("characters/Item Key01");
            Texture2D girlText = gameref.Content.Load<Texture2D>("characters/Parsee");
            Texture2D girlPort = gameref.Content.Load<Texture2D>("characters/portait/animeGirl1");
            Texture2D ghostSprite = gameref.Content.Load<Texture2D>("characters/FF6GhostSprites");

            //PixelShader shit
            buffer = new RenderTarget2D(gameref.GraphicsDevice, gameref.GraphicsDevice.DisplayMode.Width, gameref.GraphicsDevice.DisplayMode.Height);
            pxShader = gameref.Content.Load<Effect>("shaders/cavernShader");
            charShader = gameref.Content.Load<Effect>("shaders/charShader");
            camera.setMap(map);

            pxShader.Parameters["Viewport"].SetValue(new Vector2(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height));
            /*
            Matrix projection = Matrix.CreateOrthographicOffCenter(0, gameref.GraphicsDevice.PresentationParameters.BackBufferWidth, gameref.GraphicsDevice.PresentationParameters.BackBufferHeight, 0, 0, 1);
            Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0);

            pxShader.World = Matrix.Identity;
            pxShader.View = Matrix.Identity;
            pxShader.Projection = halfPixelOffset * projection;

            pxShader.TextureEnabled = true;
            pxShader.VertexColorEnabled = true;
            */

            ShaderRenderTarget = new RenderTarget2D(gameref.GraphicsDevice,
                gameref.GraphicsDevice.PresentationParameters.BackBufferWidth,
                gameref.GraphicsDevice.PresentationParameters.BackBufferHeight);

            ShaderTexture = new Texture2D(gameref.GraphicsDevice, ShaderRenderTarget.Width, ShaderRenderTarget.Height, false,
               ShaderRenderTarget.Format);

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

            //Waterfall waterfall = new Waterfall(spriteMap, caveMap, gameref);
            //waterfall.Position = new Vector2(32 + 15, 32);
            //caveMap.characterList.Add(waterfall);

            //Key key1 = new Key(keyText,caveMap,gameref);
            //key1.Position = new Vector2(11, 11 + 32);
            //caveMap.characterList.Add(key1);

            //Key key2 = new Key(keyText, caveMap, gameref);
            //key2.Position = new Vector2(22 + 32, 19 + 64);
            //caveMap.characterList.Add(key2);

            pc = new PlayerChar(catLady, map, Game);
            pc.Position = new Vector2(20, 20);

            //map.characterList.Add(pc);
            caveMap.characterList.Add(pc);
            camera.SetFocus(pc);

            //!!!
            pc.Map = caveMap;
            camera.setMap(caveMap);
            map = caveMap;

            //!!!

            girl = new Girl(girlText, caveMap, gameref, pc);
            girl.Portrait = girlPort;
            girl.Position = new Vector2(22, 16);
            while (!map.canMove((int)girl.Position.X, (int)girl.Position.Y, girl)) girl.Position = Vector2.Subtract(girl.Position, Vector2.UnitY);
            caveMap.characterList.Add(girl);

            ghost = new Ghost(ghostSprite, caveMap, gameref, girl);
            ghost.Position = new Vector2(40, 40);
            caveMap.characterList.Add(ghost);
            caveMap.enemyList.Add(ghost);
        }

        #endregion XNA Method Region

        #endregion Fields

        internal void playerHit()
        {
            girl.addEmotion(new eSpace(1, 0, 0, 0, 0, 0, 0, 0), 100);
            playerhit += 15;
        }
    }
}