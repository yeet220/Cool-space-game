using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        float x;
        float y;
        float Meteor_x = 1;
        float Meteor_y = 1;
        float score;
        int displayScore;
        float ScorePerSecond = 0.05f;
        float elapsedTime;
        float distance_x;
        float distance_y;
        float distance;
        float NoNozone;
        



        SpriteFont Font;
        Texture2D Background;
        Texture2D plane;



        List<Plane> Planes = new List<Plane>();
        List<Meteor> Meteors = new List<Meteor>();

        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public Game()
        {

            Random xrnd = new Random();

            float[] spawn_x = {900, 800, 700, 600, 500, 400, 300, 200, 100, 0, -100, -200, -300, -400, -500, -600, -700, -800, -900 };
            Random  yrnd = new Random();
            float[] spawn_y = { -500, -400, -300 };
            float[] speedMeteor_x = {-3, -2, -1, -0.9f, -0.5f, 0, 0.5f, 0.9f, 1, 2, 3};
            float[] speedMeteor_y = { 0.5f, 0.9f, 1, 2, 3, 4, 5, 6 };
            float[] size = { 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100 };



            Planes.Add(new Plane(new Vector2(0, 200), 20, Color.Yellow, 0.1f, 0));
           
            for(int i=0; i<7; i++) {
                Meteors.Add(new Meteor(new Vector2(spawn_x[xrnd.Next(spawn_x.Length)], spawn_y[yrnd.Next(spawn_y.Length)]), size[xrnd.Next(size.Length)], Color.Red, speedMeteor_x[xrnd.Next(speedMeteor_x.Length)], speedMeteor_y[xrnd.Next(speedMeteor_y.Length)]));
            }
            this.ScreenWidth = 1800;
            this.ScreenHeight = 1000;
        }
       
        /// <summary>
        /// Initilizes the game.
        /// Create all your non-graphic content here
        /// </summary>
        protected override void __Initialize()
        {


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
            // Movement modifier for meteors
            Meteor_x *= 1.00001f;
            Meteor_y *= 1.0001f;

            // Poll for current keyboard state
            KeyboardState state = Keyboard.GetState();

            //enables closing game by prssing a button
            if (state.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.Right))
            {
                if (x < -10)
                {
                    x = -10;
                }
                x += 10;
            }
           
                
            if (state.IsKeyDown(Keys.Left))
            {
                if (x > 10)
                {
                    x = 10;
                }
                x -= 10;
            }
            

            if (state.IsKeyDown(Keys.Down))
            {
                if (y < -10)
                {
                    y = -10;
                }
                y += 10;
            }
            


            if (state.IsKeyDown(Keys.Up))
            {
                if (y > 10)
                {
                    y = 10;
                }
                y -= 10;
            }

            if (state.IsKeyUp(Keys.Up) && state.IsKeyUp(Keys.Down) && state.IsKeyUp(Keys.Right) && state.IsKeyUp(Keys.Left))
            {
                x *= 0.98f ;
                y *= 0.98f ;
            }


            //**unused** changes size of class plane 
            if (state.IsKeyDown(Keys.W))
            {
                for (int i = 0; i < Planes.Count; i++)
                {
                    Planes[i].Grow(1);
                }
            }
            if (state.IsKeyDown(Keys.S))
            {
                for (int i = 0; i < Planes.Count; i++)
                {
                    Planes[i].Grow(-1);
                }
            }

           
            //updates the location of classes
            for (int i = 0; i < Planes.Count; i++)
            {
                Planes[i].Update(x, y);
            }

            for (int i = 0; i < Meteors.Count; i++)
            {
                Meteors[i].Update(Meteor_x, Meteor_y);
            }



            // Add the elapsed time since the last update to the timer
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Increase the score based on time elapsed
            score += ScorePerSecond * elapsedTime;
            displayScore = (int)Math.Round(score);
            // Call the base Update method base.Update(gameTime);

            for (int i = 0; i < Meteors.Count; i++)
            {
                distance_x = Planes[0].position.X - Meteors[i].position.X;
                distance_y = Planes[0].position.Y - Meteors[i].position.Y;
                distance = (int)(Math.Sqrt(((int)(distance_x) * distance_x) + ((int)(distance_y) * distance_y)));
                NoNozone = (int)Planes[0].radius+(int)Meteors[i].radius;
                if (NoNozone > distance) 
                {
                    Planes[0].speed = 0;
                    x = 0;
                    y = 0;
                    Meteor_x = 0;
                    Meteor_y = 0;
                    ScorePerSecond = 0;
                };
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
            spriteBatch.Draw(Background, new Rectangle(-900, -500, ScreenWidth, ScreenHeight), Color.White);

            //draws score on screen 
            spriteBatch.DrawString(Font, "Score: " + displayScore.ToString(), new Vector2(-800, -450), Color.White);


            //Place your world drawing logic here.
            for (int i = 0; i < Planes.Count; i++)
            {
                spriteBatch.Draw(plane, new Rectangle((int)(Planes[i].position.X - ((Planes[i].radius * 5) / 2)), (int)(Planes[i].position.Y - ((Planes[i].radius*5)/2)), (int)Planes[i].radius * 5, (int)Planes[i].radius * 5), Color.White);
            }


            for (int i= 0; i < Meteors.Count; i++)
            {
                spriteBatch.DrawCircle(Meteors[i].position, Meteors[i].radius, Meteors[i].color);
            }

            



            //End the spritebatch
            spriteBatch.End();
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

            public Meteor(Vector2 position, float radius, Color color, float speed_x, float speed_y)
            {
                this.position = position;
                this.radius = radius;
                this.color = color;
                this.speed_x = speed_x;
                this.speed_y = speed_y;
            }

            public void Update(float Meteor_x, float Meteor_y)
            {

                position.X += Meteor_x*speed_x;
                position.Y += Meteor_y*speed_y;


                if (position.X > 1000)
                {
                    position.X = -900;
                    position.Y = -650;
                }

                if (position.X < -1000)
                {
                    position.X = 900;
                    position.Y = -650;
                }

                if (position.Y > 600)
                {
                    position.Y = -650;
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


                if (position.X > 900)
                {
                    position.X = 900;
                }

                if (position.X < -900)
                {
                    position.X = -900;
                }

                if (position.Y > 500)
                {
                    position.Y = 500;
                }

                if (position.Y < -500)
                {
                    position.Y = -500;
                }
            }

            
            //unused growth of plane
            public void Grow(float growth)
            {
                radius += growth * growthspeed;
            }

        }

       
    }
}
