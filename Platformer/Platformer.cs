using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LivingAndDeadSoul
{
    public class Platformer: GameEntity
    {
        int IdTypeMode=1;
        List<MapView> views = new List<MapView>();
        public Platformer()
        {
            views.Add(new MapView( MapGenerator.Gen()));

            views.Add(new MapView( MapGenerator.Gen2(), "PlG"));

            foreach(MapView view in views)
            {
                view.InitMap();
            }
        }
        public override void LoadContent(Game game) {
            foreach (MapView view in views)
            {
                view.LoadContent(game, IdTypeMode);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                foreach (MapView view in views)
                {
                    if(view.isPlayerG)
                    {
                        //управление девочкой
                        view.RightDirection();

                    }
                    if(view.isPlayerM)
                    {
                        //упарвление призраком
                    }
                
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (MapView view in views)
            {
                view.Draw(gameTime, spriteBatch);
            }
        }
    }
}