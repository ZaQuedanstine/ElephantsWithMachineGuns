using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ElephantsWithMachineGuns
{
    public class Clouds
    {
        private Texture2D texture;

        private Vector2[] positions;
        private bool outOfScreen;
        private int maxHeight;
        private int maxWidth;

        public Clouds(GraphicsDevice graphics)
        {
            Random rand = new Random();
            maxHeight = graphics.Viewport.Height;
            maxWidth = graphics.Viewport.Width;

            positions = new Vector2[] 
            {
                new Vector2(rand.Next(50, maxWidth/2), rand.Next(50, maxHeight - 100)),
                new Vector2(rand.Next(50, maxWidth/2), rand.Next(50, maxHeight - 100)),
                new Vector2(rand.Next(50, maxWidth/2), rand.Next(50, maxHeight - 100)),
                new Vector2(rand.Next(maxWidth / 2, maxWidth - 50), rand.Next(50, maxHeight - 100)),
                new Vector2(rand.Next(maxWidth / 2, maxWidth - 50), rand.Next(50, maxHeight - 100)),
            };

            
        }

        public void Update(GameTime gameTime)
        {
            positions[0] += new Vector2(0.5f, 0);
            positions[1] += new Vector2(0.75f, 0);
            positions[2] += new Vector2(1, 0);
            positions[3] += new Vector2(0.5f, 0);
            positions[4] += new Vector2(0.25f, 0);
            int cloud = 0;
            foreach (var position in positions)
            {
                if (position.X >= maxWidth + 50)
                {
                    ResetCloud(cloud);
                }
                cloud++;
            }
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("cloud");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(Vector2 position in positions)
            {
                spriteBatch.Draw(texture, position, null, Color.White, 0, new Vector2(400, 200), 0.15f, SpriteEffects.None, 0);
            }
        }

        private void ResetCloud(int index)
        {
            positions[index].X = -50;
        }
    }
}
