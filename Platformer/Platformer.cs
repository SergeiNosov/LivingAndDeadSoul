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

            views.AddRange(mapView.MapObjects);
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