using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace LivingAndDeadSoul
{
    public class Platformer: GameEntity
    {
        int IdTypeMode=1;
        List<GameObject> views = new List<GameObject>();
        PlGirl PlayerGirl = new PlGirl();
        public Platformer()
        {
            MapGenerator mapGenerater = new MapGenerator();
            Vector2 playerEnter = mapGenerater.playerEnter;

            
            PlayerGirl.textureName = "PlayerGirl";
            PlayerGirl.position = new Vector2(playerEnter.X * PlayerGirl.Size, playerEnter.Y * PlayerGirl.Size);
            views.Add(PlayerGirl);

            foreach(string map in mapGenerater.maps)
            {
                MapView mapView = new MapView(map);
                mapView.InitMap();
                views.AddRange(mapView.MapObjects);
            }


        }
        public override void LoadContent(Game game) {
            foreach (GameObject view in views)
            {
                view.LoadContent(game, IdTypeMode);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            bool AllowRight=true;
            bool AllowLeft = true;
            bool AllowUP = false;
            bool AllowDown = true;

            bool droping = false;
            foreach (GameObject view in views)
            {
                if (view.textureName == "stairs")
                {
                    Rectangle rectRange = view.destinationRectangle;
                    rectRange.Width =- 32;
                    rectRange.X += 40;
                    if (rectRange.Intersects(PlayerGirl.destinationRectangle))
                    {

                        AllowUP = true;
                        AllowDown = true;
                   
                        foreach (GameObject view2 in views)
                        {
                            if (view2.textureName == "ground")
                            {
                                if (view2.destinationRectangle.Intersects(PlayerGirl.destinationRectangle))
                                {
                                    AllowDown = false;

                                }
                            }
                        }
                        droping = false;
                        break;
                    }
                    else {
                        droping = true;
                        foreach (GameObject view2 in views)
                        {
                            if (view2.textureName == "ground")
                            {
                                if (!view2.destinationRectangle.Intersects(PlayerGirl.destinationRectangle))
                                {
                                    droping = true;
                                }else {
                                    droping = false;
                                    AllowDown = false;
                                }
                            }
                        }

                     
                    
                    
                    
                    
                    }
                  
                }


            }
          
             
           
           
            if(AllowDown && droping)
              PlayerGirl.Droping(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.D) && AllowRight)
                {
                    PlayerGirl.AddPositionRight(gameTime);

                }
            if (Keyboard.GetState().IsKeyDown(Keys.A) && AllowLeft)
                {
                    PlayerGirl.AddPositionLeft(gameTime);

                }
            if(Keyboard.GetState().IsKeyDown(Keys.W)&&AllowUP)
            {
                PlayerGirl.AddPositionUP(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) && AllowDown)
            {
                PlayerGirl.AddPositionDown(gameTime);
            }



        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (GameObject view in views)
            {
                view.Draw(gameTime, spriteBatch);
            }
        }
    }
}