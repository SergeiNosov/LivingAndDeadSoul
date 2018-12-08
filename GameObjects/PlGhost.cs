using System;
using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LivingAndDeadSoul.GameObjects
{
    public class PlGhost:GameObject
    {
        public int Size = 64;
        public int Width = 64;
        public int Height = 64;
        public bool IsSolid = true;
        public List<GameObject> views;
        public bool moveRight = true;
        public  bool SelectPl=false;
        private Animation animation;
  
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
            // animation.LoadContent(game, 0);
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
        public void MoveToGirlX(GameTime gameTime, int Direction)
        {
            //Direction -1 (в лево) 1 (в право)
            if(Direction==(-1))
            {
                position.X -= 60 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else {

                position.X += 60 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

        }
        public void MoveToGirlY(GameTime gameTime, int Direction)
        {
            //Direction -1 (вниз) 1 (вверх)
            if (Direction == (-1))
            {
                position.Y += 60 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {

                position.Y -= 60 * (float)gameTime.ElapsedGameTime.TotalSeconds;

            }

        }
        public override void Update(GameTime gameTime)
        {

            if (SelectPl)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    AddPositionRight(gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    AddPositionLeft(gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    AddPositionUP(gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    AddPositionDown(gameTime);
                }
            }
            else
            {
                foreach (GameObject view in views)
                {
                    var CheckName = view.textureName.Substring(0, 3);
                    // Console.WriteLine(CheckName);
                    if (view.textureName == "PlayerGirl")
                    {
                        var x1 = position.X;
                        var y1 = position.Y;

                        var x2 = view.position.X-32;
                        var y2 = view.position.Y-64;
                        double Distance = Math.Abs(Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1))));
                        if (Distance > 64)
                        {
                            if (x1 > x2) //в право
                            {
                                MoveToGirlX(gameTime, -1);
                            }
                            else if (x2 > x1) // в лево
                            {
                                MoveToGirlX(gameTime, 1);
                            }

                            //по высоте проверяем


                            if (y1 < y2) //вниз
                            {
                                MoveToGirlY(gameTime, -1);

                            }
                            else if (y1 > y2) //верх
                            {
                                MoveToGirlY(gameTime, 1);
                            }

                        }

                    }
                }
            }
        }
    }
}
