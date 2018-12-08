using System;
using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class PlGirl:GameObject
    {
        public int Size = 64;
        public int Width = 64;
        public int Height = 128;
        public bool IsSolid = true;
       
        public PlGirl() {
           
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x - (Width - Size), y - (Height - Size), Width, Height);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }
        public override void LoadContent(Game game, int idType)
        {

            DataTypeScene type = new DataTypeScene();
            if(textureName!="PlayerGirl"&&textureName!="PlayerMan")
            game.Content.RootDirectory = "Content/" + type.GetTypeMode(idType);
            else {
                game.Content.RootDirectory = "Content/Players";
            }
            texture = game.Content.Load<Texture2D>(textureName);

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

        public override void Update(GameTime gameTime,List<GameObject> views)
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

            if (Keyboard.GetState().IsKeyDown(Keys.D) && AllowRight)
            {
                AddPositionRight(gameTime);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && AllowLeft)
            {
                AddPositionLeft(gameTime);

            }
            if (Keyboard.GetState().IsKeyDown(Keys.W) && AllowUP)
            {
                AddPositionUP(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && AllowDown)
            {
               AddPositionDown(gameTime);
            }


        }

    }
}
