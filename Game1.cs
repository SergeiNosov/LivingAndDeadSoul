using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LivingAndDeadSoul
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<MapView> views = new List<MapView>();
        int IdTypeMode=1;
     
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            views.Add(new MapView( //MAPS
                "\n" +
                "\n" +
        "       !\n" +
                "\n" +
                "\n"+
                "\n" + 
                "\n"+
                "#############\n"

        ));


            views.Add(new MapView( //EventObjects
    "        ^\n" +
    "        ^\n" +
    "        ^\n" +
    "        ^\n" +
    "        ^\n" +
    "        ^\n" +
    "        ^\n" +
    "\n"





   ));


            views.Add(new MapView( //PlayerGirl
            "\n" +
            "\n" +
            "\n" +
            "\n" +
            "\n" +
            "\n" +
            "   G\n" +
            "\n"


                                 
              ,"PlG"

           ));



         


        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            foreach(MapView view in views)
            {
                view.InitMap();
            }
      

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            foreach (MapView view in views)
            {
                view.LoadContent(this,IdTypeMode);
            }
            Content.RootDirectory = "Content/Players";


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //проверяем стукаемся ли с объектом

            // TODO: Add your update logic here
            if(Keyboard.GetState().IsKeyDown(Keys.D))
            {
                foreach (MapView view in views)
                {
                    if(view.isPlayerG)
                    {
                        //управление девочкой
                        view.RightDirection();

                    }
                    if(view.isPlayerM)
                    {
                        //упарвление призраком
                    }
                
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
      
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            foreach (MapView view in views)
            {
                view.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}