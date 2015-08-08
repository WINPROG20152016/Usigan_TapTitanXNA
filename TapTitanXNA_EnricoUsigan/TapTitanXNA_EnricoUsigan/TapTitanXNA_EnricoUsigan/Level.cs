using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_EnricoUsigan
{
    public class Level
    {

        public static int windowwidth = 1300;
        public static int windowheight = 1000;

        #region Properties
        ContentManager content;

        Texture2D background;
        public MouseState oldMouseState;
        public MouseState mouseState;
        bool mpressed, prev_mpressed = false;
        int mouseX, mouseY;

        Hero hero;

        SpriteFont damageStringFont;
        int damageNumber = 0;

        Button playButton;
        Button attackButton;

        #endregion

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this);
        }
        public void LoadContent()
        {
            background = content.Load<Texture2D>("BG/Oni3Background");
            damageStringFont = content.Load<SpriteFont>("SpriteFont1");

            playButton = new Button(content, "Button/aqwbuttonplay", new Vector2(500,50));
            attackButton = new Button(content,"Button/AttackButton", new Vector2(560,900));

            hero.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;

            hero.Update(gameTime);

            oldMouseState = mouseState;

            if (attackButton.Update(gameTime, mouseX, mouseY,
                mpressed, prev_mpressed)) 
            {
                damageNumber += 15;

            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(90,-100), Color.White);
            hero.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(damageStringFont,
               "Damage Applied (Stacking):" + damageNumber, new Vector2(750,150), Color.White);

            playButton.Draw(gameTime, spriteBatch);
            attackButton.Draw(gameTime, spriteBatch);
        }
    }
}
