using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ping_pong;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D pixel;

    Rectangle paddleLeft = new Rectangle(10,200,20,100);
    Rectangle paddleRight = new Rectangle(770,200,20,100);
    Rectangle ball = new Rectangle(390,230,20,20);




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
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

            KeyboardState kState = Keyboard.GetState();
            if(kState.IsKeyDown(Keys.W))
                paddleLeft.Y-=10;

            if(kState.IsKeyDown(Keys.S))
                paddleLeft.Y+=10;

            if(kState.IsKeyDown(Keys.Up))
                paddleRight.Y-=10;

            if(kState.IsKeyDown(Keys.Down))
                paddleRight.Y+=10;



        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(pixel,paddleLeft,Color.HotPink);
        _spriteBatch.Draw(pixel,paddleRight,Color.HotPink);
        _spriteBatch.Draw(pixel,ball,Color.LightGoldenrodYellow);
        _spriteBatch.End();
        

        base.Draw(gameTime);
    }
}
