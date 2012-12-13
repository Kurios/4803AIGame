using System;
using System.Collections.Generic;
using KLib.NerualNet.emotionState;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    internal class Ghost : DialogCharacter
    {
        public float DistanceToPlayer = 0;
        public Boolean flee = false;
        public float LastPlayerDistance = 0;
        public LinkedList<double> newSquares = new LinkedList<double>();
        public double TileFindingSpeed = 0;
        private bool alive = false;
        private int counter = 0;
        private EmotionState emotionstate;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        private int facing = 2;

        private Game1 gameref;
        private int hit;
        private int hp = 3;
        private int lastTime = 0;
        private Random r = new Random();
        private Effect shader;

        //bool runAway;
        private int stepsToRun = 120;

        private Girl targetChar;
        private List<Vector2> targetSquares = new List<Vector2>();
        private int tilesFound = 0;
        private int timeItt = 0;
        private TimeSpan timer = new TimeSpan();

        public Ghost(Texture2D sprite, Map map, Game1 game, Girl targetChar)
            : base(sprite, map)
        {
            this.gameref = game;
            this.targetChar = targetChar;

            this.Position = new Vector2(7, 64 + 27);

            this.emotionstate = new EmotionState(new eSpace(-.2, -.2, .4, .3, -.1, .3, 0, 0));
            this.emotionstate.setStability(.02);

            PhysicalContact += hitMe;

            shader = gameref.Content.Load<Effect>("shaders/cavernShader");

            emotionstate = new EmotionState();
        }

        public eSpace eSpace
        {
            get { return emotionstate.eSpace; }
        }

        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //foreach (Vector2 v in targetSquares)
            //{
            //    //Console.WriteLine(v);
            //    spriteBatch.Draw(Sprite, new Rectangle((((int)v.X) - offset.X) * 32, (((int)v.Y) - offset.Y) * 32, 32, 32), new Rectangle(32, 32, 10, 10), Color.Black);
            //}
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 10, 10), Color.White);
            spriteBatch.End();
            shader.Parameters["Joy"].SetValue((float)eSpace.Joy);
            shader.Parameters["Sadness"].SetValue((float)eSpace.Sadness);
            shader.Parameters["Fear"].SetValue((float)eSpace.Fear);
            shader.Parameters["Anger"].SetValue((float)eSpace.Anger);
            shader.Parameters["PlayerHit"].SetValue(hit);
            gameref.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise, shader);

            if (alive)
                if (flee)
                    spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32, 56, 80), new Rectangle(30 * timeItt, 50 * 0, 30, 50), Color.Red);
                else
                    spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32, 56, 80), new Rectangle(30 * timeItt, 50 * 0, 30, 50), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 1, 2);
        }

        public override void update(GameTime time)
        {
            //The G key turns on/off the ghost.
            if (InputHandler.KeyPressed(Microsoft.Xna.Framework.Input.Keys.G)) alive = !alive;

            if (alive)
            {
                if (emotionstate.eSpace.Fear > .2) flee = true;
                else flee = false;

                LastPlayerDistance = DistanceToPlayer;
                DistanceToPlayer = Vector2.Distance(Position, targetChar.Position);
                double curTime = time.TotalGameTime.TotalSeconds;

                //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
                timer += time.ElapsedGameTime;
                TimeSpan eightSecond = new TimeSpan(3000000);

                emotionstate.addEmotion(Emotion.Disgust, 1);
                emotionstate.addEmotion(Emotion.Apathy, 100);
                emotionstate.addEmotion(Emotion.Rage, 100);
                emotionstate.addEmotion(Emotion.Anticipation, (int)Math.Round(targetChar.TileFindingSpeed * 2));
                emotionstate.addEmotion(Emotion.Trust, (int)Math.Round((double)(targetChar.tilesFound * 10) / (double)Map.totalTiles));
                emotionstate.addEmotion(Emotion.Joy, targetChar.moveSpeed * 3);
                emotionstate.ponder();

                if (timer > eightSecond)
                {
                    timer -= eightSecond;
                    counter++;

                    //emotionstate.addEmotion(Emotion.Disgust, counter);
                    //if (facing == 1)
                    //{
                    //    timeItt++;
                    //   if (timeItt > 3) timeItt = 0;

                    //    Position = Position + new Vector2(-1, 0);
                    /*
                    moves.AddFirst(curTime);
                    if (Map.pcMove((int)proposedMove.X, (int)proposedMove.Y))
                    {
                        tilesFound++;
                        newSquares.AddFirst(curTime);
                    }
                     * */

                    //     stepsToRun--;
                    // }
                    int moveType = WhereIWantToWalkTo();
                    Vector2 proposedMove = new Vector2();
                    if (moveType == 4)
                    {
                        //facing = (int)facingDirection.DOWN;
                        proposedMove = Position + new Vector2(0, 1);
                    }
                    else if (moveType == 1)
                    {
                        //facing = (int)facingDirection.UP;
                        proposedMove = Position + new Vector2(0, -1);
                    }
                    else if (moveType == 3)
                    {
                        facing = (int)facingDirection.LEFT;
                        proposedMove = Position + new Vector2(-1, 0);
                    }
                    else if (moveType == 2)
                    {
                        facing = (int)facingDirection.RIGHT;
                        proposedMove = Position + new Vector2(1, 0);
                    }

                    if (flee) proposedMove = Vector2.Negate(proposedMove);

                    //if (Map.canMove((int)proposedMove.X, (int)proposedMove.Y, this))
                    {
                        Position = proposedMove;
                        timeItt++;
                        if (timeItt > 3) timeItt = 0;

                        //if (Map.pcMove((int)proposedMove.X, (int)proposedMove.Y))
                        //{
                        //    tilesFound++;
                        //    newSquares.AddFirst(curTime);
                        //}
                    }
                }

                LinkedList<double> toBeDeletedTiles = new LinkedList<double>();
                foreach (double m in newSquares)
                {
                    if (m < (curTime - 4)) toBeDeletedTiles.AddFirst(m);
                }
                foreach (double m in toBeDeletedTiles)
                {
                    newSquares.Remove(m);
                }
                TileFindingSpeed = newSquares.Count / 4;

                if (hit > 0) hit--;

                //lastTime = time.TotalGameTime.Seconds;
            }
        }

        internal void addEmotion(KLib.NerualNet.emotionState.eSpace espace, int p)
        {
            emotionstate.addEmotion(espace, p);
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            /*
            this.PhysicalContact -= FoundMe;
            facing = 1;
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
            */
        }

        private void hitMe(Object sender, EventArgs e)
        {
            emotionstate.addEmotion(Emotion.Fear, 10000);
            hit += 30;
        }

        private int WhereIWantToWalkTo()
        {
            /*
            //Vector2 ret = new Vector2(Position.X,Position.Y);

            double targetAngle = Math.PI / 2 + Math.PI / 2 * emotionstate.eSpace.Anticipation;
            double distance = 0 + 9 * emotionstate.eSpace.Fear;

            targetSquares = new List<Vector2>();
            /*

            //compute targets
            /*
            if (flee)
            {
                //PlayerChar target = gameref.MapScreen.pc;
                switch (target.facing)
                {
                    case 1:
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Cos(targetAngle) * distance), (float)(target.Position.Y + Math.Sin(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Cos(targetAngle) * distance), (float)(target.Position.Y - Math.Sin(targetAngle) * distance + 1)));
                        break;//Left
                    case 2:
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Cos(targetAngle) * distance), (float)(target.Position.Y - Math.Sin(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Cos(targetAngle) * distance), (float)(target.Position.Y + Math.Sin(targetAngle) * distance + 1)));
                        break;

                    case 0:
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Sin(targetAngle) * distance), (float)(target.Position.Y - Math.Cos(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(target.Position.X - Math.Sin(targetAngle) * distance), (float)(target.Position.Y - Math.Cos(targetAngle) * distance + 1)));
                        break;

                    case 3:
                        targetSquares.Add(new Vector2((float)(target.Position.X - Math.Sin(targetAngle) * distance), (float)(target.Position.Y + Math.Cos(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(target.Position.X + Math.Sin(targetAngle) * distance), (float)(target.Position.Y + Math.Cos(targetAngle) * distance + 1)));
                        break;
                }
            }
            else
            {
                switch (targetChar.facing)
                {
                    case 1:
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Cos(targetAngle) * distance), (float)(targetChar.Position.Y + Math.Sin(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Cos(targetAngle) * distance), (float)(targetChar.Position.Y - Math.Sin(targetAngle) * distance + 1)));
                        break;//Left
                    case 2:
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Cos(targetAngle) * distance), (float)(targetChar.Position.Y - Math.Sin(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Cos(targetAngle) * distance), (float)(targetChar.Position.Y + Math.Sin(targetAngle) * distance + 1)));
                        break;

                    case 0:
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Sin(targetAngle) * distance), (float)(targetChar.Position.Y - Math.Cos(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X - Math.Sin(targetAngle) * distance), (float)(targetChar.Position.Y - Math.Cos(targetAngle) * distance + 1)));
                        break;

                    case 3:
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X - Math.Sin(targetAngle) * distance), (float)(targetChar.Position.Y + Math.Cos(targetAngle) * distance + 1)));
                        targetSquares.Add(new Vector2((float)(targetChar.Position.X + Math.Sin(targetAngle) * distance), (float)(targetChar.Position.Y + Math.Cos(targetAngle) * distance + 1)));
                        break;
                }
            }
            */

            //check for reachable targets

            //Vector2 result = new Vector2();

            double case0 = double.MaxValue;
            double case1 = double.PositiveInfinity;
            double case2 = double.PositiveInfinity;
            double case3 = double.PositiveInfinity;
            double case4 = double.PositiveInfinity;

            //case0 - No Movement
            //if (Map.canMove((int)Position.X, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case0 = Math.Min(case0, Vector2.DistanceSquared(Position, element));
                }
            }

            //case1 - Move Down (y+)
            //if (Map.canMove((int)Position.X, (int)Position.Y + 1, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case1 = Math.Min(case1, Vector2.DistanceSquared(Vector2.Add(Position, Vector2.UnitY), element));
                }
            }

            //case2 - Move Left (x-)
            //if (Map.canMove((int)Position.X - 1, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case2 = Math.Min(case2, Vector2.DistanceSquared(Vector2.Subtract(Position, Vector2.UnitX), element));
                }
            }

            //case3 - Move Right (x+)
            //if (Map.canMove((int)Position.X + 1, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case3 = Math.Min(case3, Vector2.DistanceSquared(Vector2.Add(Position, Vector2.UnitX), element));
                }
            }

            //case4 - Move Up (y-)
            //if (Map.canMove((int)Position.X, (int)Position.Y - 1, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case4 = Math.Min(case4, Vector2.DistanceSquared(Vector2.Subtract(Position, Vector2.UnitY), element));
                }
            }
            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", case0, case1, case2, case3, case4);
            if (case0 >= case1 & case0 >= case2 & case0 >= case3 & case0 >= case4)
                return 0;
            else if (case1 >= case2 & case1 >= case3 & case1 >= case4)
                return 1;
            else if (case2 >= case3 & case2 >= case4)
                return 2;
            else if (case3 >= case4)
                return 3;
            else
                return 4;
             */
            return 0;
        }
    }
}