using GameLib;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AVRGame
{
    public class Game : GameLib.AVRGame
    {
        RasterizerState rasterizerState = new RasterizerState() { MultiSampleAntiAlias = true };
        public Game()
        {
            this.ScreenWidth = 800;
            this.ScreenHeight = 600;
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
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Begin your spritebatch.
            spriteBatch.Begin(rasterizerState: this.rasterizerState, transformMatrix: Camera.TransformMatrix);

            //Place your world drawing logic here.

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

            //Place your non-camera related drawing logic here, for example the UI

            spriteBatch.End();
        }
    }
}