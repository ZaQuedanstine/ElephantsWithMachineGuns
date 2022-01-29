using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ElaphantsWithMachineGuns
{
    public enum Direction
    {
        Backward,
        Right,
        Forward,
        Left
    }

    public class Elephant
    {
        private Texture2D texture;
        private Texture2D gun;
        private double animationTimer;
        private double directionTimer;
        private short animationFrame;
        private Direction direction = Direction.Right;
        private Vector2 position;

        public Elephant(GraphicsDevice graphics)
        {
            position = new Vector2(graphics.Viewport.Width / 2, graphics.Viewport.Height - 48);
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Tipper");
            gun = content.Load<Texture2D>("pack");
        }

        public void Update(GameTime gameTime)
        {
            directionTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (directionTimer > 3.0)
            {
                switch (direction)
                {
                    case Direction.Right:
                        direction = Direction.Left;
                        break;
                    case Direction.Left:
                        direction = Direction.Forward;
                        break;
                    case Direction.Forward:
                        direction = Direction.Right;
                        break;

                }
                directionTimer = 0;
            }

            if(direction == Direction.Right)
            {
                position += new Vector2(1, 0);
            }
            if(direction == Direction.Left)
            {
                position += new Vector2(-1, 0);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(animationTimer > 0.2)
            {
                animationFrame++;
                if (animationFrame > 2)
                {
                    animationFrame = 0;
                }
                animationTimer = 0;
            }
            Rectangle source;
            Rectangle gunSource = new Rectangle(0, 96, 16, 16);
            if (animationFrame == 0)
                source = new Rectangle((int)direction * 16, 0, 16, 16);
            else
                source = new Rectangle((animationFrame - 1) * 16, ((int)direction + 1) * 16, 16, 16);

            spriteBatch.Draw(texture, position, source, Color.White, 0, new Vector2(8, 8), 2f, SpriteEffects.None, 0);

            SpriteEffects spriteEffects = (direction == Direction.Left) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(gun, position, gunSource, Color.White, 0, new Vector2(8, 8), 1.5f, spriteEffects, 0);
        }
    }
}
