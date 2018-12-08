using System;
using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace LivingAndDeadSoul.GameObjects
{
    public class ArrowTop:GameObject
    {
        public int Size = 64;
        public bool IsSolid = true;
        private float blinkTimer = 0f;
        Random rand = new Random();
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if(blinkTimer > 0) {
              return; 
            }
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x*Size, y*Size, 64, 64);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);


        }
        public override void LoadContent(Game game, int idType)
        {

            DataTypeScene type = new DataTypeScene();

            game.Content.RootDirectory = "Content/" + type.GetTypeMode(idType);

            texture = game.Content.Load<Texture2D>(textureName);

        }

        public override void Update(GameTime gameTime, List<GameObject> views)
        {
            if(blinkTimer <= 0 && (rand.Next(0, 100)> 98)) {
                blinkTimer = 0.1f;
            } else {
                blinkTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
