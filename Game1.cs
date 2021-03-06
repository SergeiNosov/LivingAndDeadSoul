﻿using System.Collections.Generic;
using LivingAndDeadSoul.HelperClass;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace LivingAndDeadSoul
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameEntity activeEntity;
        Platformer platformer = new Platformer(0);
        Platformer platformetLvl1 = new Platformer(1);
        Platformer platformetLvl2 = new Platformer(2);

        List<Platformer> levels = new List<Platformer>();
        LevelTransition levelTransition = new LevelTransition(); 
        public Game1()
        {
         
            levels.Add(platformetLvl1);
            levels.Add(platformetLvl2);
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            levelTransition.graphics = graphics;
            platformer.graphics = graphics;
            platformetLvl1.graphics = graphics;
            platformetLvl2.graphics = graphics;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //activeEntity = new Platformer();
            activeEntity = platformer;
            //activeEntity = levelTransition;
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
       
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Content.RootDirectory = "Content/Players";
            platformer.LoadContent(this);
            platformetLvl1.LoadContent(this);
            platformetLvl2.LoadContent(this);
            levelTransition.LoadContent(this);
          
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //проверяем стукаемся ли с объектом
         
            // TODO: Add your update logic here
           
                if(activeEntity is Platformer && activeEntity.completed) {
                    activeEntity = levelTransition;
                    activeEntity.completed = false;
                }
                if(activeEntity is LevelTransition && activeEntity.completed) {


                    activeEntity = levels[0];
                    levels.Remove(levels[0]);
                }


          
            activeEntity.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
           
            // TODO: Add your drawing code here
            spriteBatch.Begin();
            activeEntity.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}