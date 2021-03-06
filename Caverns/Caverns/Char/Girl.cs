﻿using System;
using System.Collections.Generic;
using KLib.NerualNet.emotionState;
using KuriosityXLib;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Caverns.Char
{
    internal class Girl : DialogCharacter
    {
        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        public int facing = 2;

        public LinkedList<double> newSquares = new LinkedList<double>();
        public double TileFindingSpeed = 0;
        public int tilesFound = 0;
        private bool canSeeGhost = false;
        private int counter = 0;
        private EmotionState emotionstate;
        private Game1 gameref;
        private int hit;
        private int lastTime = 0;
        private Random r = new Random();
        private Effect shader;

        //bool runAway;
        private int stepsToRun = 120;

        private PlayerChar targetChar;
        private List<Vector2> targetSquares = new List<Vector2>();
        private int timeItt = 0;
        private TimeSpan timer = new TimeSpan();

        public Girl(Texture2D sprite, Map map, Game1 game, PlayerChar targetChar)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
            this.targetChar = targetChar;

            this.Position = new Vector2(7, 64 + 27);

            this.emotionstate = new EmotionState(new eSpace(-.2, -.2, .4, .3, -.1, .3, 0, 0));
            eSpace.Fear = -.2;
            eSpace.Anger = -.2;
            eSpace.Sadness = .4;
            eSpace.Joy = .3;
            eSpace.Disgust = -.1;
            eSpace.Trust = .3;
            addEmotion(eSpace, 100);

            shader = gameref.Content.Load<Effect>("shaders/cavernShader");

            /*
            DialogState state = new DialogState(0, "Eeek! You found me!");
            state.addResponse("Ok...",1);
            state.addResponse("Go Away Kitty...",2);
            state.addResponse("Meow meow meow mix.. !",2);
            state.addResponse("I found who?", 3);
            state.addResponse("Lets get out of here.", 4);
            state.addResponse("Yes I did", 5);
            this.Dialog.addState(state);
            state = new DialogState(1, "Lets get out of here");
            state.addResponse("Good idea",-1);
            state.addResponse("But I dont wanna!",11);
            this.Dialog.addState(state);
            state = new DialogState(2, "Ummm... who you callin kitty. Freak.");
            state.addResponse("Thats what she said", 6);
            state.addResponse("Sorry, slip of tounge. Moving on...", 7);
            state.addResponse("Well then what are you?", 3);
            state.addResponse("Your ears sure are pointy\n enough for it.", 8);
            this.Dialog.addState(state);
            state = new DialogState(3, "Me. Why are you asking that?");
            state.addResponse("Because I can",8);
            state.addResponse("Your answers suck", 9);
            state.addResponse("Because I'm a dick", 10);
            state.addResponse("*meow*", 2);
            this.Dialog.addState(state);
            state = new DialogState(4, "Good idea. Follow me!");
            state.addResponse("ok!",-1);
            state.addResponse("*me0w*", 2);
            this.Dialog.addState(state);
            state = new DialogState(5, "So what now?");
            state.addResponse("Pie",12);
            state.addResponse("Rawr",13);
            state.addResponse("lets go",4);
            this.Dialog.addState(state);
            state = new DialogState(6, "Your mom");
            state.addResponse("Kitty!",2);
            state.addResponse("Your Dad", 14);
            state.addResponse("Umm... ", 1);
            this.Dialog.addState(state);
            state = new DialogState(7, "So says the freak");
            state.addResponse("Says the one with the cat", 14);
            state.addResponse("Owww", 1);
            this.Dialog.addState(state);
            state = new DialogState(8, "Dick");
            state.addResponse("I am", 10);
            state.addResponse("Change of Subject, lets leave.", 4);
            state.addResponse("You know who else wants one?", 6);
            this.Dialog.addState(state);
            state = new DialogState(9, "Says the one asking these shitty ass questions");
            state.addResponse("Cant help it, Im scripted", 15);
            state.addResponse("Says the one... Kitty!", 2);
            state.addResponse("Ill stop the questions if you\n show me the way out?", 4);
            this.Dialog.addState(state);
            state = new DialogState(10, "Well you sure aint got one!");
            state.addResponse("Burrrn",6);
            state.addResponse("Says the kitty.", 2);
            state.addResponse("New Topic, leave?", 4);
            this.Dialog.addState(state);
            state = new DialogState(11, "Too Bad!");
            state.addResponse("Awwww", 5);
            state.addResponse("Pie", 12);
            this.Dialog.addState(state);
            state = new DialogState(12, "Pie? Where?");
            state.addResponse("Thats what she said", 8);
            state.addResponse("I ate it", 8);
            state.addResponse("The Mad Robot said to eat it.", 7);
            this.Dialog.addState(state);
            state = new DialogState(13, "Ooh! Tigers!");
            state.addResponse("And Kitties!", 2);
            state.addResponse("Another good reasion to put some\n distance between us and\n this cavern.", 4);
            this.Dialog.addState(state);
            state = new DialogState(14,"Your gross");
            state.addResponse("No you are", 7);
            state.addResponse("But I dont wanna be!", 10);
            this.Dialog.addState(state);
            state = new DialogState(15, "Then pick the right answer!");
            state.addResponse("AlphaNumeric!", 8);
            state.addResponse("Lets go...", 2);
            this.Dialog.addState(state);
             */

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
            //Console.WriteLine(v);
            //    spriteBatch.Draw(Sprite, new Rectangle((((int)v.X) - offset.X) * 32, (((int)v.Y) - offset.Y) * 32, 32, 32), new Rectangle(32, 32, 10, 10), Color.Black);
            //}
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y - offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32, 32, 10, 10), Color.White);
            spriteBatch.End();
            gameref.SpriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullNone, shader);
            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32, (int)(Position.Y - offset.Y) * 32, 56, 80), new Rectangle(65 * timeItt, 96 * facing, 65, 96), Color.White);
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X, (int)Position.Y, 1, 2);
        }

        public override void update(GameTime time)
        {
            if (InputHandler.KeyPressed(Microsoft.Xna.Framework.Input.Keys.I))
            {
                eSpace.Fear = -.2;
                eSpace.Anger = -.2;
                eSpace.Sadness = .4;
                eSpace.Joy = .3;
                eSpace.Disgust = -.1;
                eSpace.Trust = .3;
            }
            double curTime = time.TotalGameTime.TotalSeconds;

            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timer += time.ElapsedGameTime;
            TimeSpan eightSecond = new TimeSpan(1000000);

            foreach (Ghost c in Map.enemyList)
            {
                if (canSeeEnemies())
                    if (c.flee)
                    {
                        emotionstate.addEmotion(Emotion.Hope, 10);
                        if (c.DistanceToPlayer > c.LastPlayerDistance)
                            emotionstate.addEmotion(Emotion.Joy, 10);
                        else
                            emotionstate.addEmotion(Emotion.Rage, 10);
                    }
                    else
                    {
                        emotionstate.addEmotion(Emotion.Panic, 4);
                        if (c.DistanceToPlayer > c.LastPlayerDistance)
                            emotionstate.addEmotion(Emotion.Anger, 50);
                        else
                            emotionstate.addEmotion(Emotion.Pride, 4);
                    }
            }

            emotionstate.addEmotion(Emotion.Disgust, 1);
            emotionstate.addEmotion(Emotion.Apathy, 100);
            emotionstate.addEmotion(Emotion.Anticipation, (int)Math.Round(targetChar.TileFindingSpeed * 2));
            emotionstate.addEmotion(Emotion.Trust, (int)Math.Round((double)(targetChar.tilesFound * 100) / (double)Map.totalTiles));
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
                    facing = (int)facingDirection.DOWN;
                    proposedMove = Position + new Vector2(0, 1);
                }
                else if (moveType == 1)
                {
                    facing = (int)facingDirection.UP;
                    proposedMove = Position + new Vector2(0, -1);
                }
                else if (moveType == 3)
                {
                    facing = (int)facingDirection.LEFT;
                    proposedMove = Position + new Vector2(-1, 0);
                }
                else if (moveType == 2)
                {
                    facing = 2;
                    proposedMove = Position + new Vector2(1, 0);
                }

                if (Map.canMove((int)proposedMove.X, (int)proposedMove.Y, this))
                {
                    Position = proposedMove;
                    timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    if (Map.pcMove((int)proposedMove.X, (int)proposedMove.Y))
                    {
                        tilesFound++;
                        newSquares.AddFirst(curTime);
                    }
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

            //lastTime = time.TotalGameTime.Seconds;
            shader.Parameters["Fear"].SetValue((float)eSpace.Fear);
            shader.Parameters["Anger"].SetValue((float)eSpace.Anger);
            shader.Parameters["PlayerHit"].SetValue(hit);
        }

        internal void addEmotion(KLib.NerualNet.emotionState.eSpace espace, int p)
        {
            emotionstate.addEmotion(espace, p);
        }

        private bool canSeeEnemies()
        {
            foreach (Character e in Map.enemyList)
            {
                if (Vector2.Distance(Position, e.Position) < 13)
                {
                    if (Map.canSee(Position.X, Position.Y, e.Position.X, e.Position.Y))
                    {
                        emotionstate.addEmotion(Emotion.Surprise, 100);
                        return true;
                    }
                }
            }
            return false;
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            /*
            this.PhysicalContact -= FoundMe;
            facing = 1;
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
            */
        }

        private int WhereIWantToWalkTo()
        {
            //Vector2 ret = new Vector2(Position.X,Position.Y);

            double targetAngle = Math.PI / 2 + Math.PI / 2 * emotionstate.eSpace.Anticipation;
            double distance = 9 - 7 * emotionstate.eSpace.Trust;

            targetSquares = new List<Vector2>();

            //compute targets
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

            //check for reachable targets

            //Vector2 result = new Vector2();

            double case0 = double.MaxValue;
            double case1 = double.PositiveInfinity;
            double case2 = double.PositiveInfinity;
            double case3 = double.PositiveInfinity;
            double case4 = double.PositiveInfinity;

            //case0 - No Movement
            if (Map.canMove((int)Position.X, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case0 = Math.Min(case0, Vector2.DistanceSquared(Position, element));
                }
            }

            //case1 - Move Down (y+)
            if (Map.canMove((int)Position.X, (int)Position.Y + 1, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case1 = Math.Min(case1, Vector2.DistanceSquared(Vector2.Add(Position, Vector2.UnitY), element));
                }
            }

            //case2 - Move Left (x-)
            if (Map.canMove((int)Position.X - 1, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case2 = Math.Min(case2, Vector2.DistanceSquared(Vector2.Subtract(Position, Vector2.UnitX), element));
                }
            }

            //case3 - Move Right (x+)
            if (Map.canMove((int)Position.X + 1, (int)Position.Y, this))
            {
                foreach (Vector2 element in targetSquares)
                {
                    case3 = Math.Min(case3, Vector2.DistanceSquared(Vector2.Add(Position, Vector2.UnitX), element));
                }
            }

            //case4 - Move Up (y-)
            if (Map.canMove((int)Position.X, (int)Position.Y - 1, this))
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
        }
    }
}