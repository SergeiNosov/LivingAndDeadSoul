using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace LivingAndDeadSoul
{
    public class Animation: GameObject
    {
        public Texture2D currentTexture;
        private List<Texture2D> textures;
        public string[] textureContent { get; set; }
        public Animation() {}

        public override void LoadContent(Game game, int idType){
            foreach(string path in textureContent)
            {
               textures.Add(game.Content.Load<Texture2D>(path));
            }
        }
        public override void Update(GameTime gameTime){}
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch){}
    }
}
