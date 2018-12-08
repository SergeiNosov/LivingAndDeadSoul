using System;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace LivingAndDeadSoul.GameObjects
{
    public class Stairs:GameObject
    {
        public int Size = 64;
        public bool IsSolid = true;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            Rectangle destinationRectangle = new Rectangle(x, y, 64, 64);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);


        }
        public override void LoadContent(Game game, int idType)
        {

            DataTypeScene type = new DataTypeScene();

            game.Content.RootDirectory = "Content/" + type.GetTypeMode(idType);

            texture = game.Content.Load<Texture2D>(textureName);

        }
        public override void Update(GameTime gameTime){}

    }
}
