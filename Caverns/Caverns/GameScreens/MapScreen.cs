using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using KuriosityXLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Caverns.Char;
using KLib.NerualNet.emotionState;
using Microsoft.Xna.Framework.Input;
using MazeMaker;
using SocialSim.Agents;

namespace Caverns.GameScreens
{
    public class MapScreen:BaseGameState
    {

        #region Fields
        Map map;
        Camera camera;
        Texture2D spriteMap;
        PlayerChar pc;
        Effect pxShader;
        SpriteFont font;
        Girl girl;

        int playerhit = 0;

        eSpace espace;

        int selectedEmotion;

        RenderTarget2D ShaderRenderTarget;
        Texture2D ShaderTexture;

        #region Constructor

        public MapScreen(Game1 game, GameStateManager manager)
            : base(game, manager)
        {
            //map = new Map(game,new Vector2(32,32),100,100,spriteMap);
            camera = new Camera(game,map);
            espace = new eSpace(.2,.2,.2,.2,.2,.2,.2,.2);
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

            Texture2D blank = gameref.Content.Load<Texture2D>("characters/blank");

            map = Loader.CreateMap(gameref,spriteMap,System.IO.File.ReadAllLines("ForestMap01"));
            map = Loader.CreateMap(gameref, spriteMap, System.IO.File.ReadAllLines("village.map"));
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
            pxShader = gameref.Content.Load<Effect>("shaders/cavernShader");
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
 
            BlankChar blank1 = new BlankChar(blank, map, gameref, new Agent("Character"));
            blank1.Portrait = ashPort;
            blank1.Position = new Vector2(10, 10);
            map.characterList.Add(blank1);

            Kid2 kid2 = new Kid2(link, map, gameref);
            kid2.Portrait = linkPort;
            kid2.Falling = linkFalling;
            map.characterList.Add(kid2);

            Kid3 kid3 = new Kid3(neko, map, gameref);
            kid3.Portrait = nekoPort;
            map.characterList.Add(kid3);

            CaveIn caveIn = new CaveIn(link, map, gameref, caveMap);
            map.characterList.Add(caveIn);

            Waterfall waterfall = new Waterfall(spriteMap, caveMap, gameref);
            waterfall.Position = new Vector2(32 + 15, 32);
            //caveMap.characterList.Add(waterfall);

            Key key1 = new Key(keyText,caveMap,gameref);
            key1.Position = new Vector2(11, 11 + 32);
            caveMap.characterList.Add(key1);

            Key key2 = new Key(keyText, caveMap, gameref);
            key2.Position = new Vector2(22 + 32, 19 + 64);
            caveMap.characterList.Add(key2);

            pc = new PlayerChar(catLady, map, gameref, new Agent("Player"));
            pc.Position = new Vector2(20, 20);

            //Ghost g = new Ghost(ghostSprite, caveMap, gameref, pc);
            //g.Position = new Vector2(40, 40);
            //caveMap.characterList.Add(g);
            //caveMap.enemyList.Add(g);

            //map.characterList.Add(pc);
            map.characterList.Add(pc);
            camera.SetFocus(pc);
            //!!!
           // pc.Map = caveMap;
            //camera.setMap(caveMap);
           // map = caveMap;
            //!!!

            //cityMap.characterList.Add(pc);
            //camera.SetFocus(pc);
            //!!!
            //pc.Map = cityMap;
            //camera.setMap(cityMap);
            //map = cityMap;
            //!!!

            girl = new Girl(girlText, caveMap, gameref,pc);
            girl.Portrait = girlPort;
            girl.Position = new Vector2(1, 16);
            caveMap.characterList.Add(girl);

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
                if(selectedEmotion < 0 ) selectedEmotion = 7;
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
                girl.addEmotion(espace,100);
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
                girl.addEmotion(espace,100);
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
        public override void Draw(GameTime gameTime)
        {
            gameref.SpriteBatch.Begin();//SpriteSortMode.BackToFront,BlendState.AlphaBlend,SamplerState.PointClamp,DepthStencilState.Default,RasterizerState.CullCounterClockwise,pxShader);
            
            //gameref.SpriteBatch.Begin();
            base.Draw(gameTime);
            camera.Draw(gameTime);
            gameref.SpriteBatch.End();
            /*
            if (playerhit > 0) playerhit--;
            gameref.SpriteBatch.End();
            gameref.SpriteBatch.Begin();
            {
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
            }
            gameref.SpriteBatch.End();
        
             * 
             */ 
           }
             
        #endregion

        #endregion

        internal void playerHit()
        {
            girl.addEmotion(new eSpace(1, 0, 0, 0, 0, 0, 0, 0), 100);
            playerhit += 15;
        }
    }
}


