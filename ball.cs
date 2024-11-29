
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ping_pong
{
    public class ball
    {
        
        private Texture2D texture;
        private Rectangle rectangle= new Rectangle(390,230,20,20);

        private float velocityX = 1;
        private float velocityY = 1;
        public Rectangle Rectangle{
            get{return rectangle;}
        }
        public ball(Texture2D t){
            texture = t;
        }
        public void Reset(){
            rectangle.X=390;
            rectangle.Y=230;
            velocityX=2;
            velocityY=2;
        
        }
        public void Bounce(){
            velocityX*=-1.1f;
        }
        public void Update(){
            rectangle.X +=(int)velocityX;
            rectangle.Y +=(int)velocityY;
            if(rectangle.Y <= 0 || rectangle.Y + rectangle.Height>=460){
                velocityY*=-1;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.LightYellow);
        }
    }
}