using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public abstract class GameObject
    {
        public Vector2 position;
        public Texture2D texture;
        public string textureName;
      
        public Rectangle destinationRectangle;
        public abstract void LoadContent(Game  game, int idType);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);
    }
}
