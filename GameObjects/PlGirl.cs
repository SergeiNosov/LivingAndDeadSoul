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
       public List<GameObject> views;
        public bool moveRight = true;
        public bool moveVertical = false;
   
        private Animation animationHorisontal;
        private Animation animationVertical;
        public  bool SelectPl=true;
        private Animation animation;
        bool LimitE = false;
        public PlGirl() {
          string[] texturesHorisontal = { "PlayerGirl/GirlIdle1",  "PlayerGirl/GirlRun1",  "PlayerGirl/GirlRun2",  "PlayerGirl/GirlRun3", "PlayerGirl/GirlRun4" };
          string[] texturesVertical = { "PlayerGirl/GirlClimbingStrairs1", "PlayerGirl/GirlClimbingStrairs2", "PlayerGirl/GirlClimbingStrairs1", "PlayerGirl/GirlClimbingStrairs2" };
          animationHorisontal = new Animation(texturesHorisontal);
          animationHorisontal.FrameSpeed = 0.15f;
          animationVertical = new Animation(texturesVertical);
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x - (Width - Size), y - (Height - Size)+7, Width, Height);
            Texture2D texture = moveVertical ? animationVertical.currentTexture : animationHorisontal.currentTexture;
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
            game.Content.RootDirectory = "Content/Players";
            animationHorisontal.LoadContent(game, 0);
            animationVertical.LoadContent(game, 0);
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
                            if (view2.textureName == "ground" || view2.textureName == "GasIdle1")
                            {
                                if (view2.destinationRectangle.Intersects(destinationRectangle))
                                {
                                    if(view2.textureName == "GasIdle1")
                                    {
                                        if(view2.IsCrash==false)
                                        {
                                            AllowDown = false;
                                        }else {
                                            //тут дестрой
                                        }
                                    } else AllowDown = false;

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
                            if (view2.textureName == "ground" || view2.textureName == "GasIdle1")
                            {
                                if (!view2.destinationRectangle.Intersects(destinationRectangle))
                                {
                                    droping = true;
                                }
                                else
                                {
                                    if (view2.textureName == "GasIdle1")
                                    {
                                        if (view2.IsCrash == false)
                                        {
                                            droping = false;
                                            AllowDown = false;
                                        }
                                        else
                                        {
                                            //тут дестрой
                                        }

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


            }
            foreach (GameObject view in views)
            {
                //проверка объектов на взаимодействие
                if (view.textureName == "Light") //выход из уровня
                {
                    if (view.destinationRectangle.Intersects(destinationRectangle))
                    {
                        Console.WriteLine("Следующий уровень");

                    }



                }


                if (view.textureName == "ButtonOn" && SelectPl) //проверка кнопки
                {
                    if (view.destinationRectangle.Intersects(destinationRectangle))
                    {
                        if(Keyboard.GetState().IsKeyDown(Keys.E) && LimitE == false)
                        {
                            LimitE = true;
                            // тут писать включени и выключение инструкции по смене игроков
                            Console.WriteLine("Кликнулось от девочки");


                        }else if(!Keyboard.GetState().IsKeyDown(Keys.E) && LimitE)
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


                if (view.textureName == "GasIdle1") //выход из уровня
                {
                    if (view.destinationRectangle.Intersects(destinationRectangle))
                    {  

                        if(view.IsCrash)
                        Console.WriteLine("Dead");

                    }

                }

            }

            if (AllowDown && droping)
               Droping(gameTime);
           
            if (Keyboard.GetState().IsKeyDown(Keys.D) && AllowRight && SelectPl)
            {
                AddPositionRight(gameTime);
                animationHorisontal.Move();
                animationVertical.Stop();
                moveRight = true; 
                moveVertical = false;
            } else
                if (Keyboard.GetState().IsKeyDown(Keys.A) && AllowLeft && SelectPl)
            {
                AddPositionLeft(gameTime);
                animationHorisontal.Move();
                animationVertical.Stop();
                moveRight = false;
                moveVertical = false;
            } else
                    if (Keyboard.GetState().IsKeyDown(Keys.W) && AllowUP && SelectPl)
            {
                AddPositionUP(gameTime);
                animationHorisontal.Stop();
                animationVertical.Move();
                moveVertical = true;
            } else
                        if (Keyboard.GetState().IsKeyDown(Keys.S) && AllowDown && SelectPl)
            {
               AddPositionDown(gameTime);
               animationHorisontal.Stop();
               animationVertical.Move();
               moveVertical = true;
            }
            else
            {

                animationHorisontal.Stop();
                animationVertical.Stop();
            }
            animationVertical.Update(gameTime);
            animationHorisontal.Update(gameTime);
        }
    }
}
