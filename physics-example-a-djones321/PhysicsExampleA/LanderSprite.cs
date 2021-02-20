using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace PhysicsExampleA
{
    /// <summary>
    /// A class representing a lunar lander
    /// </summary>
    public class LanderSprite
    {
        Texture2D texture;
        Vector2 position;
        Vector2 velocity;

        /// <summary>
        /// Constructs a new lander sprite 
        /// </summary>
        public LanderSprite()
        {
            position = new Vector2(0, 50);
            velocity = new Vector2(10, 0);
        }

        /// <summary>
        /// Loads the content for the sprite
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("lander");
        }

        /// <summary>
        /// Updates the sprite
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            
            float t = (float) gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 accel = new Vector2(0, 30);

            if (keyboardState.IsKeyDown(Keys.Space))
            {
                accel += new Vector2(0, -50);
            }

            velocity += accel * t;
            position += velocity * t;
        }

        /// <summary>
        /// Draws the sprite on-screen
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
