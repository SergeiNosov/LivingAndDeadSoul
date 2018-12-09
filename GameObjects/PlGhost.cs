using System;
using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
        public bool move = false;
        public  bool SelectPl=false;
        private Animation animationStand;
        private Animation animationMove;
        bool LimitE = false;
        public PlGhost() {
              string[] texturesStand = { "PlayerGhost/GhostIdle1", "PlayerGhost/GhostIdle2", "PlayerGhost/GhostIdle1", "PlayerGhost/GhostIdle2" };
              string[] texturesMove = { "PlayerGhost/GhostIdle1", "PlayerGhost/GhostFly1",  "PlayerGhost/GhostFly2" };
              animationStand = new Animation(texturesStand);
              animationMove = new Animation(texturesMove);
        }
        
        public override void LoadContent(Game game, int idType)
        {
            DataTypeScene type = new DataTypeScene();
            // animation.LoadContent(game, 0);
            game.Content.RootDirectory = "Content/Players";
            animationStand.LoadContent(game, 0);
            animationStand.FrameSpeed = 0.6f;
            animationMove.LoadContent(game, 0);
            animationMove.FrameSpeed = 0.6f;
            animationStand.Move();
            animationMove.Move();
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D texture = move ? animationMove.currentTexture : animationStand.currentTexture;
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
            animationStand.Update(gameTime);
            animationMove.Update(gameTime);
            bool AllowLeft=true;
            bool AllowRight=true;
            if (SelectPl)
            {


                foreach (GameObject view in views)//проверка объектов
                {
                    if (view.textureName == "ButtonOn" && SelectPl) //проверка кнопки
                    {
                        if (view.destinationRectangle.Intersects(destinationRectangle))
                        {
                            if (Keyboard.GetState().IsKeyDown(Keys.E) && LimitE == false)
                            {
                                LimitE = true;
                                // тут писать включени и выключение инструкции по смене игроков
                                Console.WriteLine("Кликнулось от Ghost");


                            }
                            else if (!Keyboard.GetState().IsKeyDown(Keys.E) && LimitE)
                            {
                                LimitE = false;
                            }

                        }



                    }



                    if (view.textureName == "ColliderLeft") //выход из уровня
                    {
                        if (view.destinationRectangle.Intersects(destinationRectangle))
                        {
                            AllowLeft = false;

                        }

                    }
                    if (view.textureName == "ColliderRight") //выход из уровня
                    {
                        if (view.destinationRectangle.Intersects(destinationRectangle))
                        {
                            AllowRight = false;

                        }

                    }


                }









                if (Keyboard.GetState().IsKeyDown(Keys.D)&&AllowRight)
                {
                    AddPositionRight(gameTime);
                    moveRight = true;
                    move = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.A)&&AllowLeft)
                {
                    AddPositionLeft(gameTime);
                    moveRight = false;
                    move = true;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    AddPositionUP(gameTime);
                    move = false;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    AddPositionDown(gameTime);
                    move = false;
                }
                
            }
            else
            {
                foreach (GameObject view in views)
                {
                    var CheckName = view.textureName.Substring(0, 3);
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
                                if(x1 - x2 > 64) {
                                    moveRight = false;
                                    move = true;
                                }
                            }
                            else if (x2 > x1) // в лево
                            {

                                MoveToGirlX(gameTime, 1);
                                if(x2 - x1 > 64) {
                                    moveRight = true;
                                    move = true;
                                }
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

                        } else {
                            move = false;
                        }

                    }
                }
            }
        }
    }
}
