using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ping_pong
{
    public class paddel
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed =1;
        private Keys up;
        private Keys dowwn;
        public paddel(Texture2D t){
            texture=t;
        }
        public void Update(){
            KeyboardState Kstate= Keyboard.GetState();
            if(Kstate.IsKeyDown(up)){
                rectangle.Y-=speed;
            }
        }
        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,rectangle,Color.Green);
        }
    }

}