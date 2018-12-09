using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LivingAndDeadSoul
{
    public class LevelTransition: GameEntity
    {
        Texture2D background;
        Texture2D pointTexture;
        Texture2D point2Texture;
        public GraphicsDeviceManager graphics;
        Vector2[] bigPoints = {new Vector2(10, 163), new Vector2(185, 220)};
        Vector2[] smallPoints = {new Vector2(50, 173),new Vector2(90, 185), new Vector2(122, 196), new Vector2(148, 206) };
        public LevelTransition() {

        }
        public override void LoadContent(Game game) {
            game.Content.RootDirectory = "Content";
            this.background = game.Content.Load<Texture2D>("LevelTransition/MapEmpty");
            this.pointTexture = game.Content.Load<Texture2D>("LevelTransition/Point1");
            this.point2Texture = game.Content.Load<Texture2D>("LevelTransition/Point2");
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
            foreach(Vector2 point in bigPoints)
            {
                spriteBatch.Draw(this.pointTexture, point , Color.White);
            }
            foreach(Vector2 point in smallPoints)
            {
                spriteBatch.Draw(this.point2Texture, point, Color.White);
            }
        }
        public override void Update(GameTime gameTime) {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                this.completed = true;
            }
        }
    }
}