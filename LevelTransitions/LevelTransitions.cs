using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class LevelTransition: GameEntity
    {
        Texture2D background;
        public GraphicsDeviceManager graphics;
        public LevelTransition() {

        }
        public override void LoadContent(Game game) {
            game.Content.RootDirectory = "Content";
            this.background = game.Content.Load<Texture2D>("LevelTransition/MapEmpty");
        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) {
            
            spriteBatch.Draw(
                this.background,
                new Vector2(0,0),
                new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight),
                Color.White,
                0f,
                new Vector2(0, 0),
                Vector2.One,
                SpriteEffects.None,
                0f
                );
        }
        public override void Update(GameTime gameTime) {}
    }
}