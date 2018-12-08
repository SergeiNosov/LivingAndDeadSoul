using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace LivingAndDeadSoul
{
    public class Animation: GameObject
    {
        public Texture2D currentTexture { get; set; }
        public string[] textureContent { get; set; }
        public float FrameSpeed { get; set; }
        private int currentTextureIndex = 0;
        private List<Texture2D> textures = new List<Texture2D>();
        private bool move = false;
        private float timer = 0;
        public Animation(string[] textureContent) {
            this.textureContent = textureContent;
            FrameSpeed = 0.2f;
        }

        public override void LoadContent(Game game, int idType)
        {
            foreach(string path in textureContent)
            {
               textures.Add(game.Content.Load<Texture2D>(path));
            }
            currentTexture = textures[0];
        }
        public override void Update(GameTime gameTime) {
            if(move) {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if(timer > FrameSpeed)
                {
                    timer = 0f;
                    currentTextureIndex = (currentTextureIndex + 1 < textures.Count) ? currentTextureIndex + 1 : 1;
                    currentTexture = textures[currentTextureIndex];
                }
            }

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch){}
        public void Move()
        {
            move = true;
        }
        public void Stop()
        {
            move = false;
            currentTexture = textures[0];
            timer = 0f;
        }
    }
}
