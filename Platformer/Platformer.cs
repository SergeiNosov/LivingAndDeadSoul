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
        bool LimitQ;
        public Platformer()
        {
            MapGenerator mapGenerater = new MapGenerator();
            Vector2 playerEnter = mapGenerater.playerEnter;

            
            PlayerGirl.textureName = "PlayerGirl";
            PlayerGirl.position = new Vector2(playerEnter.X * PlayerGirl.Size, playerEnter.Y * PlayerGirl.Size);

            PlayerGhost.textureName = "GhostIdle1";
            var GhostEnter = playerEnter.Y;
            PlayerGhost.position = new Vector2((playerEnter.X * PlayerGhost.Size)-50, (GhostEnter * PlayerGhost.Size)-64);

          


            foreach (string map in mapGenerater.maps)
            {
                MapView mapView = new MapView(map);
                mapView.InitMap();
                views.AddRange(mapView.MapObjects);
            }
            views.Add(PlayerGhost);
            views.Add(PlayerGirl);

            PlayerGirl.views = views;
            PlayerGhost.views = views;
        }
        public override void LoadContent(Game game) {
            foreach (GameObject view in views)
            {
                view.LoadContent(game, IdTypeMode);
            }
         
        }
     
        public override void Update(GameTime gameTime)
        {

        
            foreach(GameObject view in views)
            {
                view.Update(gameTime);
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
            foreach (GameObject view in views)
            {
                view.Draw(gameTime, spriteBatch);
            }
        }
    }
}