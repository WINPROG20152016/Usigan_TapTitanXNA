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
    public class Hero
    {   
        #region Properties
        Vector2 playerPosition;
        Texture2D player;
        ContentManager content;
        Level level;
        MouseState oldMouseState;

        //Animation walk1Animation;
        //Animation walk2Animation;
        //Animation walk3Animation;
        //Animation walk4Animation;


        String Punch = "Idle";
        Animation attackAnimation;
        Animation idleAnimation;
        AnimationPlayer spritePlayer;
        #endregion
        
        //int oldScrollWheelValue = 0;
        
        public Hero(ContentManager content, Level level)
        {
            this.content = content;

            this.level = level;
        }

        public void LoadContent()
        {

            player = content.Load<Texture2D>("Squato/squato_idle2");

            idleAnimation = new Animation(player, 0.1f, true,1);

            int positionX = (Level.windowwidth / 2) - (idleAnimation.FrameWidth/ 4);
            int positionY = (Level.windowheight / 2) - (idleAnimation.FrameWidth / 4);
            playerPosition = new Vector2(500,300);

            spritePlayer.PlayAnimation(idleAnimation);
        }

        public void Update(GameTime gameTime)
        {

           

            if (level.mouseState.LeftButton == ButtonState.Pressed)
            {
                Punch = "attackAnimation";
                spritePlayer.PlayAnimation(new Animation(content.Load<Texture2D>("Squato/Squato"), 0.1f, false, 6));
            }
            if (level.mouseState.LeftButton == ButtonState.Released)
            {
               // spritePlayer.PlayAnimation(idleAnimation);
            }

            if (Punch == "Idle")
            {

            }
            else if (Punch == "attackAnimation")
            {
                if (spritePlayer.Smash == 5)
                {

                    spritePlayer.PlayAnimation(idleAnimation);
                    Punch = "Idle";
                }

            }

            //var mouseState = Mouse.GetState();

            //spritePlayer.PlayAnimation(attackAnimation);

            //if (mouseState.LeftButton == ButtonState.Pressed ;


            //spritePlayer.PlayAnimation(idleAnimation);

            //    if (mouseState.LeftButton == ButtonState.Pressed &&
            //    oldMouseState.LeftButton == ButtonState.Released)
            //{
            //    player = content.Load<Texture2D>("Squato/squato_walk3");
            //    walk3Animation = new Animation(player, 0.1f, true, 2);
            //    spritePlayer.PlayAnimation(walk3Animation);
            //    playerPosition.X-= 5;
            //}

            //if (mouseState.RightButton == ButtonState.Pressed &&
            //    oldMouseState.RightButton == ButtonState.Released)
            //{
            //    player = content.Load<Texture2D>("Squato/squato_walk2");
            //    walk2Animation = new Animation(player, 0.1f, true, 2);
            //    spritePlayer.PlayAnimation(walk2Animation);
            //    playerPosition.X+= 5;
            //}
            //if (mouseState.ScrollWheelValue > oldScrollWheelValue)
            //{
            //    player = content.Load<Texture2D>("Squato/squato_walk4");
            //    walk4Animation = new Animation(player, 0.1f, true, 2);
            //    spritePlayer.PlayAnimation(walk4Animation);
            //    playerPosition.Y-= 10;
            //    oldScrollWheelValue = mouseState.ScrollWheelValue;
            //}
            //if (mouseState.ScrollWheelValue < oldScrollWheelValue)
            //{
            //    player = content.Load<Texture2D>("Squato/squato_walk1");
            //    walk1Animation = new Animation(player, 0.1f, true, 2);
            //    spritePlayer.PlayAnimation(walk1Animation);
            //    playerPosition.Y += 10;
            //    oldScrollWheelValue = mouseState.ScrollWheelValue;
            //}

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(player,playerPosition,Color.White, 0.0f, Vector2.Zero,1.0f,SpriteEffects.None, 0.0f);
            //spriteBatch.Draw(player, playerPosition, Color.White);
            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);

        }

    }
}
