using System;
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
        public Rectangle destinationRectangle;
        public PlGirl() {
           
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var x = Convert.ToInt32(position.X);
            var y = Convert.ToInt32(position.Y);
            destinationRectangle = new Rectangle(x - (Width - Size), y - (Height - Size), Width, Height);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
        }
        public override void LoadContent(Game game, int idType)
        {

            DataTypeScene type = new DataTypeScene();
            if(textureName!="PlayerGirl"&&textureName!="PlayerMan")
            game.Content.RootDirectory = "Content/" + type.GetTypeMode(idType);
            else {
                game.Content.RootDirectory = "Content/Players";
            }
            texture = game.Content.Load<Texture2D>(textureName);

        }
       
    }
}
