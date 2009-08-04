open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Audio
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Storage
open System
open System.IO

type FGame =
  class
    inherit Game
    
    val mutable graphics : GraphicsDeviceManager
    
    new() as this = { graphics = null } then this.graphics <- new GraphicsDeviceManager(this)
    
    override this.Draw(gameTime) =
      let gd = this.graphics.GraphicsDevice
      gd.Clear(Color.Green)
  end
  
