using System;
using System.Collections.Generic;
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
       public List<GameObject> views;
        public bool moveRight = true;
        public  bool SelectPl=true;
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
        public void Jump(GameTime gameTime)
        {
            position.Y -= 250 * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public override void Update(GameTime gameTime)
        {
            bool AllowRight = true;
            bool AllowLeft = true;
            bool AllowUP = false;
            bool AllowDown = true;

            bool droping = false;
            foreach (GameObject view in views)
            {
                if (view.textureName == "stairs")
                {
                    Rectangle rectRange = view.destinationRectangle;
                    rectRange.Width = -32;
                    rectRange.X += 40;
                    if (rectRange.Intersects(destinationRectangle))
                    {

                        AllowUP = true;
                        AllowDown = true;

                        foreach (GameObject view2 in views)
                        {
                            if (view2.textureName == "ground")
                            {
                                if (view2.destinationRectangle.Intersects(destinationRectangle))
                                {
                                    AllowDown = false;

                                }
                            }
                        }
                        droping = false;
                        break;
                    }
                    else
                    {
                        droping = true;
                        foreach (GameObject view2 in views)
                        {
                            if (view2.textureName == "ground")
                            {
                                if (!view2.destinationRectangle.Intersects(destinationRectangle))
                                {
                                    droping = true;
                                }
                                else
                                {
                                    droping = false;
                                    AllowDown = false;
                                }
                            }
                        }






                    }

                }


            }


            if (AllowDown && droping)
               Droping(gameTime);
           
            if (Keyboard.GetState().IsKeyDown(Keys.D) && AllowRight && SelectPl)
            {
                AddPositionRight(gameTime);
                animation.Move();
                moveRight = true; 
            } else
                if (Keyboard.GetState().IsKeyDown(Keys.A) && AllowLeft && SelectPl)
            {
                AddPositionLeft(gameTime);
                animation.Move();
                moveRight = false;

            } else
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && AllowUP && SelectPl)
            {
                AddPositionUP(gameTime);
            } else
                        if (Keyboard.GetState().IsKeyDown(Keys.S) && AllowDown && SelectPl)
            {
               AddPositionDown(gameTime);
            }
            else
            {
                animation.Stop();
            }
            animation.Update(gameTime);
        }
    }
}
