using System.Windows.Forms.Design.Behavior;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ping_pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    Texture2D pixel;

    SpriteFont fontScore;
    Rectangle paddleLeft = new Rectangle(10,200,20,100);
    Rectangle paddleRight = new Rectangle(770,200,20,100);
    Rectangle ball = new Rectangle(390,230,20,20);

    double velocityX = 5;
    double velocityY = 5;

    int scoreleftplayer =0;
    int scorerightplayer =0;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        pixel = Content.Load<Texture2D>(assetName:"pixel");
        
        fontScore = Content.Load<SpriteFont>("score");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W) && paddleLeft.Y>0)
               
                paddleLeft.Y-=10; 

            if(kState.IsKeyDown(Keys.S) &&paddleLeft.Y+paddleLeft.Height<480)
                paddleLeft.Y+=10;

            if(kState.IsKeyDown(Keys.Up) &&  paddleRight.Y>0)
                paddleRight.Y-=10;

            if(kState.IsKeyDown(Keys.Down) && paddleRight.Y+paddleRight.Height<480)
                paddleRight.Y+=10;

            ball.X+= (int)velocityX;
            ball.Y+= (int)velocityY;
            if(ball.Intersects(paddleRight) ||
            ball.Intersects(paddleLeft)){
                velocityX*=-1.1f;
                  velocityY*=1.1f;
            
            }
            if(ball.Y<=0 ||ball.Y+ ball.Height>=480){
                velocityY*=-1;
            }
            if(ball.X <=0){
                ball.X=390;
                ball.Y=230;
                velocityX=2;
                velocityY=2;
                scorerightplayer++;
            }

            else if(ball.X + ball.Width>=800){
                ball.X=390;
                ball.Y=230;
                velocityX=2;
                velocityY=2;
                scoreleftplayer++;
            }




        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore,scoreleftplayer.ToString(),new Vector2(410,10),Color.DarkOrange);
        _spriteBatch.Draw(pixel,paddleLeft,Color.HotPink);
        _spriteBatch.Draw(pixel,paddleRight,Color.HotPink);
        _spriteBatch.Draw(pixel,ball,Color.LightGoldenrodYellow);
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}
