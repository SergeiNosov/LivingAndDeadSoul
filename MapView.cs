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
        public bool isPlayerG = false;
        public  bool isPlayerM = false;
        List<GameObject> MapObjects = new List<GameObject>();
  
        public MapView(string worldString, string typePlayer="null")
        {
            switch(typePlayer)
            {
                case "PlG": {
                        isPlayerG = true;
                    }
                    break;
                case "PlM": {
                        isPlayerM = true;
                    } break;
                case "null": {}break;
            }
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
                        case '#':{ //GROUND
                                Ground ground = new Ground();

                                ground.textureName = "ground";
                                ground.position = new Vector2(j * ground.Size, i * ground.Size);
                                Console.WriteLine("Object Info:"+ground.textureName+ " Position.x: " + ground.position.X + "Position.Y: " + ground.position.Y);
                                MapObjects.Add(ground);

                            }break;
                        case 'G':
                            { //GROUND
                                PlGirl PlayerGirl = new PlGirl();

                                PlayerGirl.textureName = "PlayerGirl";
                                PlayerGirl.position = new Vector2(j * PlayerGirl.Size, i * PlayerGirl.Size);
                                Console.WriteLine("Object Info:" + PlayerGirl.textureName +  " Position.x: " + PlayerGirl.position.X + "Position.Y: " + PlayerGirl.position.Y);
                                MapObjects.Add(PlayerGirl);

                            }
                            break;
                        case '^':
                            { //GROUND
                                Stairs stairs = new Stairs();

                                stairs.textureName = "stairs";
                                stairs.position = new Vector2(j * stairs.Size, i * stairs.Size);
                                Console.WriteLine("Object Info:" + stairs.textureName + " Position.x: " + stairs.position.X + "Position.Y: " + stairs.position.Y);
                                MapObjects.Add(stairs);

                            }
                            break;

                        case '!':
                            { //GROUND
                                ArrowTop arrowTop = new ArrowTop();

                                arrowTop.textureName = "ArrowTop";
                                arrowTop.position = new Vector2(j * arrowTop.Size, i * arrowTop.Size);
                                Console.WriteLine("Object Info:" + arrowTop.textureName + " Position.x: " + arrowTop.position.X + "Position.Y: " + arrowTop.position.Y);
                                MapObjects.Add(arrowTop);

                            }
                            break;

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
                obj.Draw(time,spriteBatch);
            }
        }

        public void RightDirection()
        {
            foreach (GameObject obj in MapObjects)
            {
                obj.RightDirection();
            }
        }
      

       
    }
}
