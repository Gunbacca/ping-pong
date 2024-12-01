
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
    paddel paddleLeft;
    paddel paddleRight; 
    ball ball;
    float velocityX = 1;
    float velocityY = 1;

    int scoreLeftplayer =0;
    int scoreRightplayer =0;

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

        ball = new ball(pixel);
        paddleLeft = new paddel(pixel, new Rectangle(10,200,20,100),Keys.W, Keys.S);
        paddleRight = new paddel(pixel, new Rectangle(770,200,20,100),Keys.Up,Keys.Down);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            paddleLeft.Update();
        paddleRight.Update();

        ball.Update();
        if(paddleLeft.Rectangle.Intersects(ball.Rectangle) ||
        paddleRight.Rectangle.Intersects(ball.Rectangle)){
            ball.Bounce();
        }

        if(ball.Rectangle.X <= 0){
            ball.Reset();
            scoreRightplayer++;
        }
        else if(ball.Rectangle.X + ball.Rectangle.Width >= 800){
           ball.Reset();
            scoreLeftplayer++;
        }


           




        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.DrawString(fontScore,scoreLeftplayer.ToString(),new Vector2(10,10),Color.Orange);
        _spriteBatch.DrawString(fontScore,scoreRightplayer.ToString(),new Vector2(730,10),Color.Orange);
        paddleLeft.Draw(_spriteBatch);
        paddleRight.Draw(_spriteBatch);
        ball.Draw(_spriteBatch);
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}
