using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            MapView mapView = new MapView(mapGenerater.map);
            mapView.InitMap();
            MapView EventObjects = new MapView(MapGenerator.Gen3());
            EventObjects.InitMap();

            MapView PusApObjects = new MapView(MapGenerator.Gen4());
            PusApObjects.InitMap();

            views.AddRange(PusApObjects.MapObjects);
            views.AddRange(mapView.MapObjects);
            views.AddRange(EventObjects.MapObjects);
            views.Add(PlayerGirl);

        }
        public override void LoadContent(Game game) {
            foreach (GameObject view in views)
            {
                view.LoadContent(game, IdTypeMode);
            }
        }
        
        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
              //

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