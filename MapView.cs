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
                            ground.position = new Vector2(j, i);
                            Console.WriteLine("Object Info:"+ground.textureName+ " Position.x: " + ground.position.X + "Position.Y: " + ground.position.Y);
                            MapObjects.Add(ground);
                            break;
                            
                     
                        case '^':
                            { //EventObjects
                                Stairs stairs = new Stairs();

                                stairs.textureName = "stairs";
                                stairs.position = new Vector2(j*stairs.Size, i*stairs.Size);
                                Console.WriteLine("Object Info:" + stairs.textureName + " Position.x: " + stairs.position.X + "Position.Y: " + stairs.position.Y);
                                MapObjects.Add(stairs);

                            }
                            break;

                        case '!':
                            { //Pushaup
                                ArrowTop arrowTop = new ArrowTop();

                                arrowTop.textureName = "ArrowTop";
                                arrowTop.position = new Vector2(j, i);
                                Console.WriteLine("Object Info:" + arrowTop.textureName + " Position.x: " + arrowTop.position.X + "Position.Y: " + arrowTop.position.Y);
                                MapObjects.Add(arrowTop);

                            }
                            break;

                        case '%':
                            { //Controll info
                                ControllDecoration ControllInfo = new ControllDecoration();

                                ControllInfo.textureName = "Hint2";
                                ControllInfo.position = new Vector2(j* ControllInfo.Size, i* ControllInfo.Size);
                                Console.WriteLine("Object Info:" + ControllInfo.textureName + " Position.x: " + ControllInfo.position.X + "Position.Y: " + ControllInfo.position.Y);
                                MapObjects.Add(ControllInfo);

                            }
                            break;
                             case 'E':
                            { //Controll info
                                ExitLvl exitLvl = new ExitLvl();

                                exitLvl.textureName = "Light";
                                exitLvl.position = new Vector2(j * exitLvl.Size, i * exitLvl.Size);
                                MapObjects.Add(exitLvl);

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
                obj.Draw(time, spriteBatch);
            }
        }
    }
}
