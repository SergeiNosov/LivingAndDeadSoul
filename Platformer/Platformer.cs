using LivingAndDeadSoul.GameObjects;
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
        PlGhost PlayerGhost = new PlGhost();
        int PlayerType = 1; //1 - Girl, 2- Ghost
        public int lvl = 1;
        public int backNumber = 1;
        bool LimitQ;
        MapGenerator2 mapGenerater2;
        MapGenerator mapGenerater;
        public Platformer()
        {
          //  mapGenerater = new MapGenerator();
             mapGenerater2 = new MapGenerator2();
            Vector2 playerEnter = new Vector2(0,0);
         if(lvl == 0)
             playerEnter = mapGenerater.playerEnter;
            if(lvl==1)
                playerEnter = mapGenerater2.playerEnter;


            PlayerGirl.textureName = "PlayerGirl";
            PlayerGirl.position = new Vector2(playerEnter.X * PlayerGirl.Size, playerEnter.Y * PlayerGirl.Size);

            PlayerGhost.textureName = "GhostIdle1";
            var GhostEnter = playerEnter.Y;
            PlayerGhost.position = new Vector2((playerEnter.X * PlayerGhost.Size)-50, (GhostEnter * PlayerGhost.Size)-64);



            if (lvl == 0)
            {
                foreach (string map in mapGenerater.maps)
                {
                    MapView mapView = new MapView(map);
                    mapView.InitMap();
                    views.AddRange(mapView.MapObjects);
                }
            }if(lvl==1)
            {
                foreach (string map in mapGenerater2.maps)
                {
                    MapView mapView = new MapView(map);
                    mapView.InitMap();
                    views.AddRange(mapView.MapObjects);
                }
            }
            views.Add(PlayerGhost);
            views.Add(PlayerGirl);

            PlayerGhost.platformer = this;
            PlayerGirl.views = views;
            PlayerGhost.views = views;
         
        }
        public override void LoadContent(Game game) {
       
            foreach (GameObject view in views)
            {
                view.LoadContent(game, IdTypeMode);
            }
            if (lvl == 1)
            {
             
                game.Content.RootDirectory = "Content/Shelter";
                mapGenerater2.backgroundLose = game.Content.Load<Texture2D>("BackLvl1Lose");
                mapGenerater2.backgroundHappy = game.Content.Load<Texture2D>("BackLvl1Happy");
            }

        }
     
        public override void Update(GameTime gameTime)
        {

        
            foreach(GameObject view in views)
            {
                view.Update(gameTime);
                if(view is ExitLvl) {
                    if(view.destinationRectangle.Intersects(PlayerGirl.destinationRectangle)) {
                        this.completed = true;
                    }
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Q) && LimitQ==false)
            {
                LimitQ = true;
                if (PlayerType == 1)
                {
                    PlayerGirl.SelectPl = false;
                    PlayerGhost.SelectPl = true;
                    PlayerType = 2;
                }
                else{
                    PlayerGirl.SelectPl = true;
                    PlayerGhost.SelectPl = false;
                    PlayerType = 1;
                }

            }else if (!Keyboard.GetState().IsKeyDown(Keys.Q) && LimitQ == true)
            {
                LimitQ = false;
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (lvl == 1 && backNumber==1)
            {
                spriteBatch.Draw(
                    mapGenerater2.backgroundLose,
     new Vector2(0, 0),
     new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
     Color.White,
     0f,
     new Vector2(0, 0),
     Vector2.One,
     SpriteEffects.None,
     0f
     );
            }
            if (lvl == 1 && backNumber == 2)
            {
                spriteBatch.Draw(
                    mapGenerater2.backgroundHappy,
     new Vector2(0, 0),
     new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
     Color.White,
     0f,
     new Vector2(0, 0),
     Vector2.One,
     SpriteEffects.None,
     0f
     );
            }
            foreach (GameObject view in views)
            {
                view.Draw(gameTime, spriteBatch);
            }
           
        }
    }
}