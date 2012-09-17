using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KuriosityXLib.TileMap;
using Microsoft.Xna.Framework.Graphics;
using KuriosityXLib.Dialogs;
using Microsoft.Xna.Framework;

namespace Caverns.Char
{
    class Girl : DialogCharacter
    {
        int timeItt = 0;

        //0 DOWN
        //1 LEFT
        //2 RIGHT
        //3 UP
        int facing = 2;

        int lastTime = 0;
        Random r = new Random();
        Game1 gameref;

        //bool runAway;
        int stepsToRun = 120;

        TimeSpan timer = new TimeSpan();

        public Girl(Texture2D sprite, Map map, Game1 game)
            : base(sprite, map)
        {
            this.PhysicalContact += FoundMe;
            this.gameref = game;
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

            this.Position = new Vector2(7, 64 + 27);
        }

        private void FoundMe(Object sender, EventArgs e)
        {
            this.PhysicalContact -= FoundMe;
            facing = 1;
            gameref.DialogScreen.CallDialog(this, (DialogCharacter)sender);
            
        }

        public override void update(GameTime time)
        {
            //timeItt = (int)Math.Floor(1 / (float)(time.ElapsedGameTime.Milliseconds * 4));
            timer += time.ElapsedGameTime;
            TimeSpan eightSecond = new TimeSpan(1250000);
            if (timer > eightSecond)
            {
                timer -= eightSecond;


                if (facing == 1)
                {
                    timeItt++;
                    if (timeItt > 3) timeItt = 0;
                    Position = Position + new Vector2(-1, 0);
                    
                    stepsToRun--;
                }
            }
            //lastTime = time.TotalGameTime.Seconds;
        }

        public override Rectangle getBoundingRect()
        {
            return new Rectangle((int)Position.X - 1, (int)Position.Y - 1, 1, 2);
        }
        public override void draw(SpriteBatch spriteBatch, Point offset)
        {
            //spriteBatch.Draw(Sprite, new Rectangle((getBoundingRect().X - offset.X) * 32, (getBoundingRect().Y-offset.Y) * 32, getBoundingRect().Width * 32, getBoundingRect().Height * 32), new Rectangle(32,32,32,32), Color.Black);

            spriteBatch.Draw(Sprite, new Rectangle((int)(Position.X - offset.X) * 32 - (32 + 16), (int)(Position.Y - offset.Y) * 32 - 32, 56, 80), new Rectangle(65 * timeItt, 96 * facing, 65, 96), Color.White);

        }
    }
}
