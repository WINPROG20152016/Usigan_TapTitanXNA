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
        //Vector2 suppPosition;
        //Vector2 bossPosition;
        Texture2D player;
        //Texture2D support;
        //Texture2D boss;
        ContentManager content;
        Level level;
        //MouseState oldMouseState;

        //Animation walk1Animation;
        //Animation walk2Animation;
        //Animation walk3Animation;
        //Animation walk4Animation;


        String Punch = "Idle";
        //Animation attackAnimation;
        Animation idleAnimation;
        //Animation idleSupport;
        //Animation idleBoss;
        AnimationPlayer spritePlayer;
        //AnimationPlayer spriteSupport;
        //AnimationPlayer spriteBoss;
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
            /*boss = content.Load<Texture2D>("SquidOni/twig");
            support = content.Load<Texture2D>("SquidOni/SquidOni");*/

            idleAnimation = new Animation(player, 0.1f, true, 1);

            int positionX = (Level.windowwidth / 2) - (idleAnimation.FrameWidth / 2);
            int positionY = (Level.windowheight / 2) - (idleAnimation.FrameWidth / 2);
            playerPosition = new Vector2(500, 300);
            /*
            int supposX = (Level.windowwidth / 2) - (idleAnimation.FrameWidth / 2);
            int supposY = (Level.windowheight / 2) - (idleAnimation.FrameWidth / 2);
            suppPosition = new Vector2(600, 1000);

            int bossX = (Level.windowwidth / 2) - (idleAnimation.FrameWidth /  2);
            int bossY = (Level.windowheight / 2) - (idleAnimation.FrameWidth / 2);
            bossPosition = new Vector2(200, 300);*/

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


        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            // spriteBatch.Draw(player,playerPosition,Color.White, 0.0f, Vector2.Zero,1.0f,SpriteEffects.None, 0.0f);
            //spriteBatch.Draw(player, playerPosition, Color.White);

            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            //spriteSupport.Draw(gameTime, spriteBatch, suppPosition, SpriteEffects.None);
            //spriteBoss.Draw(gameTime, spriteBatch, bossPosition, SpriteEffects.None);

        }

    }
}
