using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class LevelTransition: GameEntity
    {
        public LevelTransition() {

        }
        public override void LoadContent(Game game) {}
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            spriteBatch.GraphicsDevice.Clear(Color.CornflowerBlue);
        }
        public override void Update(GameTime gameTime) {}
    }
}