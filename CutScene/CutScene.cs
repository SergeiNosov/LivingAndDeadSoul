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
        public Boolean complete = false;
        GameTime startTime;
        public CutScene() {}
        public int animationIndex = 0;
        override public void Initialize() {}
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
                   animations.Add(
                       new AnimationPoint(Convert.ToInt32(jsonRecord[i+1]),
                       game.Content.Load<Texture2D>(path))
                   );
                }
            }
        }
        override public void Update(GameTime gameTime) {
            if(complete)
            {
                return;
            }
            if(startTime == null)
            {
                startTime = gameTime;
                return;
            }
            if(this.animations.Count <= animationIndex)
            {
                complete = true;
                return;
            }
            float startSecond = (float)startTime.TotalGameTime.TotalSeconds;
            float gameSecond = (float)gameTime.TotalGameTime.TotalSeconds;
            float animationSecond = this.animations[this.animationIndex].time;
            Console.WriteLine("startSecond: {0}", startSecond);
            Console.WriteLine("gameSecond: {0}", gameSecond);
            Console.WriteLine("animationSecond: {0}", animationSecond);
            if(gameSecond - startSecond > animationSecond)
            {
                this.animationIndex += 1; 
                this.startTime = gameTime; 
            }
        }
        override public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animations[animationIndex].Draw(gameTime, spriteBatch);
        }
    }
    public class JsonRecord
    {
        public List<Object> Data { get; set; }
    }
    public class AnimationPoint
    {
        public int time;
        public Texture2D texture;
        public AnimationPoint(int time, Texture2D texture)
        {
            this.time = time;
            this.texture = texture;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Console.WriteLine("Draw");
            spriteBatch.Draw(texture, new Vector2(0, 0), Color.White);
        }
    }
}