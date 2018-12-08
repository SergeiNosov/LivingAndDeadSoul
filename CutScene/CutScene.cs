using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Json;
using System.Collections.Generic;

namespace LivingAndDeadSoul
{
    public class CutScene: Component {
        public List<AnimationPoint> animations = new List<AnimationPoint>();
        public CutScene() {}
        override public void Initialize() {
            
            Console.WriteLine("Initialize");
        }   
        override public void Draw(GameTime gameTime, SpriteBatch spriteBatch) {

        }
        override public void LoadContent(Game game)
        {
            using (StreamReader r = new StreamReader("Content/CutScenes/Intro/script.json"))
            {
                string json = r.ReadToEnd();
                JsonRecord jsonParsed = JsonParser.Deserialize<JsonRecord>(json);
                List<Object> jsonRecord = jsonParsed.Data;

                for (int i = 0; i < jsonRecord.Count; i+=2)
                {
                   string path = String.Format("CutScenes/Intro/{0}", jsonRecord[i]);
                   Console.WriteLine(path);
                   animations.Add(
                       new AnimationPoint(Convert.ToDouble(jsonRecord[i+1]),
                        game.Content.Load<Texture2D>(path))
                   );
                }
            }
        }
    }
    public class JsonRecord
    {
        public List<Object> Data { get; set; }
    }
    public class AnimationPoint
    {
        public double time;
        public Texture2D texture;
        public AnimationPoint(double time, Texture2D texture) {
            this.time = time;
            this.texture = texture;
        }
    }
}