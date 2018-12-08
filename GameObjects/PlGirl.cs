using System;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LivingAndDeadSoul
{
    public class PlGirl:GameObject
    {
        public int Size = 64;
        public int Width = 64;
        public int Height = 128;
        public bool IsSolid = true;
        public bool moveRight = true;
        public Rectangle destinationRectangle;
        public PlGirl() {
           
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x - (Width - Size), y - (Height - Size), Width, Height);
            spriteBatch.Draw(
                texture,
                destinationRectangle,
                null,
                Color.White,
                0,
                Vector2.One,
                moveRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                0);

        }
        public override void LoadContent(Game game, int idType)
        {

            DataTypeScene type = new DataTypeScene();
            game.Content.RootDirectory = "Content/Players/PlayerGirl";
            texture = game.Content.Load<Texture2D>("GirlIdle1");
        }
        public void AddPositionRight(GameTime gameTime)
        {
            position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            moveRight = true;
        }
        public void AddPositionLeft(GameTime gameTime)
        {
            position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            moveRight = false;
        }
        public override void Update(GameTime gameTime){}

    }
}
