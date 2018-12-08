using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LivingAndDeadSoul
{
    abstract public class Component
    {
       
        public abstract void Initialize();
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void LoadContent(Game game);
    }
}