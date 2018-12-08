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

        private Animation animation;
        public PlGirl() {
          string[] textures = { "PlayerGirl/GirlIdle1",  "PlayerGirl/GirlRun1",  "PlayerGirl/GirlRun2",  "PlayerGirl/GirlRun3","PlayerGirl/GirlRun4"  };
          animation = new Animation(textures);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x - (Width - Size), y - (Height - Size), Width, Height);
            Texture2D texture = animation.currentTexture;
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
            animation.LoadContent(game, 0);
        }

        public void AddPositionRight(GameTime gameTime)
        {
           
            position.X += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void AddPositionLeft(GameTime gameTime)
        {
            position.X -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void AddPositionUP(GameTime gameTime)
        {
            position.Y -= 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void AddPositionDown(GameTime gameTime)
        {
            position.Y += 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Droping(GameTime gameTime)
        {
            position.Y += 350 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        override public void Update(GameTime gameTime){

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                 animation.Move();
                 moveRight = true; 
            } else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                animation.Move();
                moveRight = false;
            } else {
                animation.Stop();
            }

            animation.Update(gameTime);
        }
    }
}
