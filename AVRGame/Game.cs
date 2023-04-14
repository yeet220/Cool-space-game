using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.WebRequestMethods;
/*             
     ___           _______      ___      .___  ___.  _______    .______   ____    ____                                                             
    /   \         /  _____|    /   \     |   \/   | |   ____|   |   _  \  \   \  /   /                                                             
   /  ^  \       |  |  __     /  ^  \    |  \  /  | |  |__      |  |_)  |  \   \/   /                                                              
  /  /_\  \      |  | |_ |   /  /_\  \   |  |\/|  | |   __|     |   _  <    \_    _/                                                               
 /  _____  \     |  |__| |  /  _____  \  |  |  |  | |  |____    |  |_)  |     |  |                                                                 
/__/     \__\     \______| /__/     \__\ |__|  |__| |_______|   |______/      |__|                                                                 
                                                                                                                                                   
.___________. __  .______     ______   .______              _______.________      ___   .___________..___  ___.      ___      .______       __     
|           ||  | |   _  \   /  __  \  |   _  \            /       |       /     /   \  |           ||   \/   |     /   \     |   _  \     |  |    
`---|  |----`|  | |  |_)  | |  |  |  | |  |_)  |          |   (----`---/  /     /  ^  \ `---|  |----`|  \  /  |    /  ^  \    |  |_)  |    |  |    
    |  |     |  | |   _  <  |  |  |  | |      /            \   \      /  /     /  /_\  \    |  |     |  |\/|  |   /  /_\  \   |      /     |  |    
    |  |     |  | |  |_)  | |  `--'  | |  |\  \----.   .----)   |    /  /----./  _____  \   |  |     |  |  |  |  /  _____  \  |  |\  \----.|  |    
    |__|     |__| |______/   \______/  | _| `._____|   |_______/    /________/__/     \__\  |__|     |__|  |__| /__/     \__\ | _| `._____||__|    
                                                                                                                                                   
 __      ____    ____  ___      .___  ___.         _______.___________..______          ___      __    __  .______    _______                      
|  |     \   \  /   / /   \     |   \/   |        /       |           ||   _  \        /   \    |  |  |  | |   _  \  |   ____|                     
|  |      \   \/   / /  ^  \    |  \  /  |       |   (----`---|  |----`|  |_)  |      /  ^  \   |  |  |  | |  |_)  | |  |__                        
|  |       \_    _/ /  /_\  \   |  |\/|  |        \   \       |  |     |      /      /  /_\  \  |  |  |  | |   _  <  |   __|                       
|  `----.    |  |  /  _____  \  |  |  |  |    .----)   |      |  |     |  |\  \----./  _____  \ |  `--'  | |  |_)  | |  |____                      
|_______|    |__| /__/     \__\ |__|  |__|    |_______/       |__|     | _| `._____/__/     \__\ \______/  |______/  |_______|                     
                                                                                                                                                   
     ___      .__   __.  _______                                                                                                                   
    /   \     |  \ |  | |       \                                                                                                                  
   /  ^  \    |   \|  | |  .--.  |                                                                                                                 
  /  /_\  \   |  . `  | |  |  |  |                                                                                                                 
 /  _____  \  |  |\   | |  '--'  |                                                                                                                 
/__/     \__\ |__| \__| |_______/                                                                                                                  
                                                                                                                                                   
 _______       ___   ____    ____  __   _______      __  ___  __    __   __   __  ___                                                              
|       \     /   \  \   \  /   / |  | |       \    |  |/  / |  |  |  | |  | |  |/  /                                                              
|  .--.  |   /  ^  \  \   \/   /  |  | |  .--.  |   |  '  /  |  |  |  | |  | |  '  /                                                               
|  |  |  |  /  /_\  \  \      /   |  | |  |  |  |   |    <   |  |  |  | |  | |    <                                                                
|  '--'  | /  _____  \  \    /    |  | |  '--'  |   |  .  \  |  `--'  | |  | |  .  \                                                               
|_______/ /__/     \__\  \__/     |__| |_______/    |__|\__\  \______/  |__| |__|\__\                                                        
                                                                                                                                            


.______       __    __       _______.___________.    ________      ___       ______  __    __  .___________.      .___________.____    __    ____  _______  _______ .___________.____    ____ 
|   _  \     |  |  |  |     /       |           |   |       /     /   \     /      ||  |  |  | |           |      |           |\   \  /  \  /   / |   ____||   ____||           |\   \  /   / 
|  |_)  |    |  |  |  |    |   (----`---|  |----`   `---/  /     /  ^  \   |  ,----'|  |__|  | `---|  |----`      `---|  |----` \   \/    \/   /  |  |__   |  |__   `---|  |----` \   \/   /  
|      /     |  |  |  |     \   \       |  |           /  /     /  /_\  \  |  |     |   __   |     |  |               |  |       \            /   |   __|  |   __|      |  |       \_    _/   
|  |\  \----.|  `--'  | .----)   |      |  |          /  /----./  _____  \ |  `----.|  |  |  |     |  |               |  |        \    /\    /    |  |____ |  |____     |  |         |  |     
| _| `._____| \______/  |_______/       |__|         /________/__/     \__\ \______||__|  |__|     |__|               |__|         \__/  \__/     |_______||_______|    |__|         |__|     
                                                                                                                                                                                              

                   _,........_
               _.-'    ___    `-._
            ,-'      ,'   \       `.
 _,...    ,'      ,-'     |  ,""":`._.
/     `--+.   _,.'      _.',',|"|  ` \`
\_         `"'     _,-"'  | / `-'   l L\
  `"---.._      ,-"       | l       | | |
      /   `.   |          ' `.     ,' ; |
     j |   |           `._`"""' ,'  |__
     |      `--'____          `----'    .' `.
     |    _,-"""    `-.                 |    \
     l   /             `.               F     l
      `./     __..._     `.           ,'      |
        |  ,-"      `.    | ._     _.'        |
        . j           \   j   /`"""      __   |          ,"`.
         `|           | _,.__ |        ,'  `. |          |   |
          `-._       /-'     `L       .     , '          |   |
              F-...-'          `      |    , /           |   |
              |            ,----.     `...' /            |   |
              .--.        j      l        ,'             |   j
             j    L       |      |'-...--<               .  /
             `     |       . __,, _    ..  |              \/
              `-..'.._  __,-'     \  |  |/`._           ,'`
                  |   ""       .--`. `--,  ,-`..____..,'   |
                   L          /     \ _.  |   | \  .-.\    j
                  .'._        l     .\    `---' |  |  || ,'
                   .  `..____,-.._.'  `._       |  `--;"I'
                    `--"' `.            ,`-..._/__,.-1,'
                            `-.__  __,.'     ,' ,' _-'
                                 `'...___..`'--^--' 


*/

namespace AVRGame
{
    public class Game : GameLib.AVRGame
    {
        //start values 
        float x,y;
        float Meteor_x = 1, Meteor_y = 1;
        float save_Meteor_x, save_Meteor_y;
        float score, ScorePerSecond = 0.05f, elapsedTime;
        int displayScore;
        float distance_x, distance_y, distance, NoNozone;
        float death;
        bool pause;
        float health = 100, shield;
        float Powerup_speed = 1;
        bool IsHeld = false;
        //this allows me to use Psuedo randomness everywhere for everything
        Random xrnd = new Random();

        float[] spawn_x = { 960, 900, 800, 700, 600, 500, 400, 300, 200, 100, 0, -100, -200, -300, -400, -500, -600, -700, -800, -900, -960 };
        float[] spawn_y = { -500, -400, -300 };
        float[] speedMeteor_x = { -3, -2, -1, -0.9f, -0.5f, 0, 0.5f, 0.9f, 1, 2, 3 };
        float[] speedMeteor_y = { 0.5f, 0.9f, 1, 2, 3, 4, 5, 6 };
        float[] size = { 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };
        float[] growthspeed = {0};
        float[] spawn_num = { 0, 1, 2, 3, 4, 5, 6 };
        float[] spawn_Power_y = { -700, -800, -900, -1000, -1100, -1200, -1300, -1600, -1800, -1900, -2000 };
        float[] spawn_Power_x = { 700, 600, 500, 400, 300, 100, 0, -100, -300, -400, -500, -600, -700 };
        float[] type = { 0, 1 };


        SpriteFont Font;
        Texture2D Background;
        Texture2D plane;
        Texture2D meteor;
        Texture2D Health_pic;
        Texture2D Shield_pic;
        Song background_music;



        List<Plane> Planes = new List<Plane>();
        List<Meteor> Meteors = new List<Meteor>();
        List<Powerup> Powerups = new List<Powerup>();
        List<SoundEffect> soundEffects = new List<SoundEffect>();

        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public Game()
        {
           
            //player 
            Planes.Add(new Plane(new Vector2(0, 200), 20, Color.Yellow, 0.1f, 0));
           
            //meteor
            for(int i=0; i<7; i++) 
            {
                Meteors.Add(new Meteor(new Vector2(spawn_x[xrnd.Next(spawn_x.Length)], spawn_y[xrnd.Next(spawn_y.Length)]), size[xrnd.Next(size.Length)], Color.Red, speedMeteor_x[xrnd.Next(speedMeteor_x.Length)], speedMeteor_y[xrnd.Next(speedMeteor_y.Length)], growthspeed[xrnd.Next(growthspeed.Length)]));
            }

            //power ups
            for(int i=0; i<spawn_num[xrnd.Next(spawn_num.Length)]; i++)
            {
                Powerups.Add(new Powerup(new Vector2(spawn_Power_x[xrnd.Next(spawn_Power_x.Length)], spawn_Power_y[xrnd.Next(spawn_Power_y.Length)]), 20, 3, type[xrnd.Next(type.Length)])); 
            }

            //screen size
            this.ScreenWidth = 1920;
            this.ScreenHeight = 1080;
        }
       
        /// <summary>
        /// Initilizes the game.
        /// Create all your non-graphic content here
        /// </summary>
        protected override void __Initialize()
        {
            graphics.PreferredBackBufferHeight = this.ScreenHeight;
            graphics.PreferredBackBufferWidth = this.ScreenWidth;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Here you can load all the content you need.
        /// Example: Load textures, sounds or texture effects
        /// </summary>
        protected override void __LoadContent()
        {
            //spriteBatch = new SpriteBatch(GraphicsDevice);
            //[] ;
           
            Font = Content.Load<SpriteFont>("Epic font");
            Background = Content.Load<Texture2D>("Space");
            plane = Content.Load<Texture2D>("main_character");
            meteor = Content.Load<Texture2D>("Deathstar");
            Health_pic = Content.Load<Texture2D>("Fortnite medkit");
            Shield_pic = Content.Load<Texture2D>("Fortnite");
            background_music = Content.Load<Song>("Band_HeyYou_Piano_worldzd");
            soundEffects.Add(Content.Load<SoundEffect>("999-social-credit-siren"));

            MediaPlayer.Play(background_music);
            MediaPlayer.IsRepeating = true;            
        }
         
        /// <summary>
        /// Sometimes you need to unload content.
        /// This is called once if you exit the game
        /// </summary>
        protected override void __UnloadContent()
        {

        }

        /// <summary>
        /// Here you place your update logic.
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void __Update(GameTime gameTime)
        {
            // Music
            if (MediaPlayer.State == MediaState.Stopped)
                MediaPlayer.Play(background_music);
            else if (MediaPlayer.State == MediaState.Paused)
                MediaPlayer.Resume();
            if (MediaPlayer.Volume < 1)
                MediaPlayer.Volume += .0000001f;
      
            // Movement modifier for meteors
            Meteor_x *= 1.0001f;
            Meteor_y *= 1.001f;

            if (pause == false)
            {
                save_Meteor_x = Meteor_x;
                save_Meteor_y = Meteor_y;
            }


            // Poll for current keyboard state
            KeyboardState state = Keyboard.GetState();

            // Get the current state of Controller1
            GamePadState controllerstate = GamePad.GetState(PlayerIndex.One);

            // Enables closing game by pressing a button
            if (state.IsKeyDown(Keys.Escape) || controllerstate.IsButtonDown(Buttons.X))
            {
                this.Exit();
            }

            if(state.IsKeyDown(Keys.Space) && IsHeld == false)
            {
                IsHeld = true;
                pause =! pause;
                Pause();
            }

            if(state.IsKeyDown(Keys.Space) == false && IsHeld == true){
                IsHeld = false;
            }
            
            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.Right) || controllerstate.ThumbSticks.Left.X > 0.5f)
            {
                if (x < -10)
                {
                    x = -10;
                }
                x += 10;
            }
           
                
            if (state.IsKeyDown(Keys.Left) || controllerstate.ThumbSticks.Left.X < -0.5f)
            {
                if (x > 10)
                {
                    x = 10;
                }
                x -= 10;
            }
            

            if (state.IsKeyDown(Keys.Down) || controllerstate.ThumbSticks.Left.Y < -0.5f)
            {
                if (y < -10)
                {
                    y = -10;
                }
                y += 10;
            }
            


            if (state.IsKeyDown(Keys.Up) || controllerstate.ThumbSticks.Left.Y > 0.5f)
            {
                if (y > 10)
                {
                    y = 10;
                }
                y -= 10;
            }

            // cool space effect on movement
            if ((state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down) && state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Left)) || (controllerstate.ThumbSticks.Left.X < 0.5f && controllerstate.ThumbSticks.Left.X > -0.5f  && controllerstate.ThumbSticks.Left.Y < 0.5f && controllerstate.ThumbSticks.Left.Y < -0.5f))
            {
                x *= 0.98f ;
                y *= 0.98f ;
            }


            //**unused** changes size of class plane 
            if (state.IsKeyDown(Keys.W))
            {
                for (int i = 0; i < Meteors.Count; i++ )
                {
                    Planes[0].Grow(1);
                    Meteors[i].Grow(1);
                }
            }
            else if (state.IsKeyDown(Keys.S))
            {
                for (int i = 0; i < Meteors.Count; i++)
                {
                    Planes[0].Grow(-1);
                    Meteors[i].Grow(-1);
                }
            }

           
            //updates the location of objects
            for (int i = 0; i < Planes.Count; i++)
            {
                Planes[i].Update(x, y);
            }


            for (int i = 0; i < Meteors.Count; i++)
            {
                Meteors[i].Update(Meteor_x, Meteor_y);
            }

            for (int i = 0; i < Powerups.Count; i++)
            {
                Powerups[i].Update(Powerup_speed);
            }

            



            // Add the elapsed time since the last update to the timer
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Increase the score based on time elapsed
            score += ScorePerSecond * elapsedTime;
            displayScore = (int)Math.Round(score);
            

            //calculates if plane is in NoNozone of powerup
            for (int i = 0; i < Powerups.Count;i++)
            {
                distance_x = Planes[0].position.X - Powerups[i].position.X;
                distance_y = Planes[0].position.Y - Powerups[i].position.Y;
                distance = (int)(Math.Sqrt(((int)(distance_x) * distance_x) + ((int)(distance_y) * distance_y)));
                NoNozone = (int)Planes[0].radius + (int)Powerups[i].radius;
                if (NoNozone > distance)
                {
                    if (Powerups[i].type == 0 && health<100)
                    {
                        health += 25;
                    }
                    else if (Powerups[i].type == 1 && shield<150)
                    {
                        shield += 25;
                    }
                    Powerups[i].position.Y = spawn_Power_y[xrnd.Next(spawn_Power_y.Length)];
                }

            }

            //calcultes if plane is in NoNozone of meteor
            for (int i = 0; i < Meteors.Count; i++)
            {
                distance_x = Planes[0].position.X - Meteors[i].position.X;
                distance_y = Planes[0].position.Y - Meteors[i].position.Y;
                distance = (int)(Math.Sqrt(((int)(distance_x) * distance_x) + ((int)(distance_y) * distance_y)));
                NoNozone = (int)Planes[0].radius+(int)Meteors[i].radius;
                if (NoNozone > distance)
                {
                    if (shield>0) 
                    { 
                        shield -= 25;
                    }
                     else 
                    { 
                        health -= 25; 
                    }
                    Meteors[i].position.Y -= 1080;
                    Meteors[i].position.X = spawn_x[xrnd.Next(spawn_x.Length)];
                    Meteors[i].radius = size[xrnd.Next(size.Length)];
                    Meteors[i].speed_x = speedMeteor_x[xrnd.Next(speedMeteor_x.Length)];
                    Meteors[i].speed_y = speedMeteor_y[xrnd.Next(speedMeteor_y.Length)];
                }

                if (health == 0)
                {
                   if (death != 1)
                   {
                       On_Death();
                   }
                }

                
            }
            
           
            
        }


        /// <summary>
        /// Here you place your draw logic. This drawing is in the world space.
        /// The camera follows an object.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawGame(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //Refresh your frame, should not be deleted. Color can be changed.
            GraphicsDevice.Clear(Color.Black);


            //Begin your spritebatch.
            spriteBatch.Begin(rasterizerState: this.rasterizerState, transformMatrix: Camera.TransformMatrix);

            //draws space background
            spriteBatch.Draw(Background, new Rectangle(-960, -540, ScreenWidth, ScreenHeight), Color.White);
            //Place your world drawing logic here.
            for (int i = 0; i < Planes.Count; i++)
            {
                spriteBatch.Draw(plane, new Rectangle((int)(Planes[i].position.X - ((Planes[i].radius * 5) / 2)), (int)(Planes[i].position.Y - ((Planes[i].radius*5)/2)), (int)Planes[i].radius * 5, (int)Planes[i].radius * 5), Color.White);
            }
            
            for (int i = 0; i < Powerups.Count; i++)
            {
                if (Powerups[i].type == 0)
                {
                    spriteBatch.Draw(Health_pic, new Rectangle((int)(Powerups[i].position.X - ((Powerups[i].radius) * 4 / 2)), (int)(Powerups[i].position.Y - ((Powerups[i].radius) * 4 / 2)), (int)Powerups[i].radius * 4, (int)Powerups[i].radius * 4), Color.White);
                }
                else if (Powerups[i].type == 1)
                { 
                    spriteBatch.Draw(Shield_pic, new Rectangle((int)(Powerups[i].position.X - ((Powerups[i].radius)*4 / 2)), (int)(Powerups[i].position.Y - ((Powerups[i].radius)*4 / 2)), (int)Powerups[i].radius*4, (int)Powerups[i].radius*4), Color.White);
                }

            }

            for (int i = 0; i < Meteors.Count; i++)
            {
                spriteBatch.Draw(meteor, new Rectangle((int)(Meteors[i].position.X - ((Meteors[i].radius))), (int)(Meteors[i].position.Y - ((Meteors[i].radius))), (int)Meteors[i].radius * 2, (int)Meteors[i].radius * 2), Color.White);
            }

            

            

           
            if (death == 0)
            {
                //draws score on screen 
                spriteBatch.DrawString(Font, "Score: " + displayScore.ToString(), new Vector2(-860, -440), Color.White);
                // draws health on screen
                spriteBatch.DrawString(Font, "Health: " + health.ToString() + "%", new Vector2(-860, -340), Color.Green);
                // draws shield on screen
                spriteBatch.DrawString(Font, "shield: " + shield.ToString() + "%", new Vector2(-860, -240), Color.Blue);
            }
            else if (death == 1)
            {
                //draws score on screen 
                spriteBatch.Draw(Background, new Rectangle(-960, -540, ScreenWidth, ScreenHeight), Color.White);
                spriteBatch.DrawString(Font, "Score: " + displayScore.ToString(), new Vector2(-214, 108), Color.White, 0, new Vector2(0, 0), 2, SpriteEffects.None, 0);
            }
             
            
           


            //End the spritebatch
            spriteBatch.End();
        }
        
        public void On_Death() 
        {
            
            soundEffects[0].CreateInstance().Play();

            Planes[0].speed = 0;
            Meteor_x = 0;
            Meteor_y = 0;
            for (int i = 0; i < Powerups.Count; i++)
            {
                Powerups[i].speed = 0;
            }
            ScorePerSecond = 0;
            death = 1;



        }

        public void Pause()
        {
            if (pause == true)
            {
                Planes[0].speed = 0;
                Meteor_x = 0;
                Meteor_y = 0;
                for (int i = 0; i < Powerups.Count; i++)
                {
                    Powerups[i].speed = 0;
                }
                ScorePerSecond = 0;
            } 
            else if (pause == false) 
            {
                Planes[0].speed = 0.1F;
                Meteor_x = save_Meteor_x;
                Meteor_y = save_Meteor_y;
                for (int i = 0; i < Powerups.Count; i++)
                {
                    Powerups[i].speed = 3;
                }
                ScorePerSecond = 0.05f;
            }
        }



        /// <summary>
        /// This function is for drawing on the UI elements
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        protected override void __DrawUI(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin(rasterizerState: this.rasterizerState);

            
            spriteBatch.End();
        }

        //class that makes Meteors
        public class Meteor 
        { 

        
            public Vector2 position; 
            public float radius;
            public Color color;
            public float speed_x;
            public float speed_y;
            public float growthspeed;

            public Meteor(Vector2 position, float radius, Color color, float speed_x, float speed_y, float growthspeed)
            {
                this.position = position;
                this.radius = radius;
                this.color = color;
                this.speed_x = speed_x;
                this.speed_y = speed_y;
                this.growthspeed = growthspeed;
            }

            public void Update(float Meteor_x, float Meteor_y)
            {

                position.X += Meteor_x*speed_x;
                position.Y += Meteor_y*speed_y;


                if (position.X > 1060)
                {
                    position.X = -960;
                    position.Y = -690;
                }

                if (position.X < -1060)
                {
                    position.X = 960;
                    position.Y = -690;
                }

                if (position.Y > 640)
                {
                    position.Y = -790;
                }             
            }
            
            public void Grow(float growth)
            {
                if (radius < 1001 && radius > 9)
                {
                    radius += growth * growthspeed;
                }
                else if (radius > 1000)
                {
                    radius = 1000;
                    growth = 0;
                }

                else if (radius < 10)
                {
                    radius = 10;
                    growth = 0;
                }
            }
        }

        public class Powerup
        {
            public Vector2 position;
            public float radius;
            public float speed;
            public float type;

            public Powerup(Vector2 position, float radius, float speed, float type)
            {
                this.position = position;
                this.radius = radius;
                this.speed = speed;
                this.type = type;
            }

            public void Update(float Powerup_speed)  
            {
                position.Y += Powerup_speed * speed;

                if (position.Y > 640)
                {
                    position.Y = -1500;
                }


            }
        }



        //Class that makes Planes 
        public class Plane
            {
            public Vector2 position;
            public float radius;
            public Color color;
            public float speed;
            public float growthspeed;

            public Plane(Vector2 position, float radius, Color color, float speed, float growthspeed)
            {
                this.position = position;
                this.radius = radius;
                this.color = color;
                this.speed = speed;
                this.growthspeed = growthspeed;
            }
           
            //add update things here

            //movement of plane 
            public void Update(float x, float y)
            {

                position.X += x * speed;
                position.Y += y * speed;


                if (position.X > 960)
                {
                    position.X = 960;
                }

                if (position.X < -960)
                {
                    position.X = -960;
                }

                if (position.Y > 540)
                {
                    position.Y = 540;
                }

                if (position.Y < -540)
                {
                    position.Y = -540;
                }
            }

            
            //growth of planews
            public void Grow(float growth)
            {
                if (radius < 41 && radius > 9)
                {
                    radius += growth * growthspeed;
                }

                else if (radius > 40)
                {
                    radius = 40;
                    growth = 0;
                }

                else if (radius < 9)
                {
                    radius = 10;
                    growth = 0;
                }
            }

        }

       
    }
}
