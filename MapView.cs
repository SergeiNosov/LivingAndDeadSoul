using System;
using System.Collections.Generic;
using LivingAndDeadSoul.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace LivingAndDeadSoul
{
    public class MapView
    {
        string WorldData;
        string[] WorldSpace;
        Vector2 mapEnter;
        public List<GameObject> MapObjects = new List<GameObject>();
  
        public MapView(string worldString)
        {
            WorldSpace = worldString.Split('\n');
            WorldData = worldString;

            Console.WriteLine(WorldData);
        }

     


        public void InitMap()
        {
            for (int i = 0; i < WorldSpace.Length; i++) //позиция Y
            {

                for (int j = 0; j < WorldSpace[i].Length;j++) //позиция X
                {

                    switch(WorldSpace[i][j])
                    {
                        case '#': //GROUND
                            Ground ground = new Ground();

                            ground.textureName = "ground";
                            ground.position = new Vector2(j * ground.Size, i * ground.Size);
                            Console.WriteLine("Object Info:"+ground.textureName+ " Position.x: " + ground.position.X + "Position.Y: " + ground.position.Y);
                            MapObjects.Add(ground);
                            break;
                            
                        /* 
                        case 'G':
                            { //GROUND
                                PlGirl PlayerGirl = new PlGirl();

                                PlayerGirl.textureName = "PlayerGirl";
                                PlayerGirl.position = new Vector2(j * PlayerGirl.Size, i * PlayerGirl.Size);
                                Console.WriteLine("Object Info:" + PlayerGirl.textureName +  " Position.x: " + PlayerGirl.position.X + "Position.Y: " + PlayerGirl.position.Y);
                                MapObjects.Add(PlayerGirl);

                            }
                            break;
                        */
                    }

                }

            }
            Console.WriteLine("Объекты получены, координаты указаны!");
  
        }

       
        public void LoadContent(Game game, int idType) 
        {
            foreach(GameObject obj in MapObjects)
            {
                obj.LoadContent(game,idType);
            }
        
        }

        public void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            foreach (GameObject obj in MapObjects)
            {
                obj.Draw(time, spriteBatch);
            }
        }
    }
}
