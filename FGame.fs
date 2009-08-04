namespace Simple

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Audio
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Storage
open System
open Microsoft.FSharp.Collections
open System.IO

// TODO: Screen manager

type ScreenState =
  | Active
  | Hidden
  | MoveOn
  | MoveOff

type Screen =
  { mutable State : ScreenState }

type ScreenManager =
  { mutable Screens : ResizeArray<Screen> }
  with static member Start = { Screens = new ResizeArray<Screen>() }


type FGame =
  class
    inherit Game
    
    val mutable graphics : GraphicsDeviceManager
    val mutable manager : ScreenManager
    
    new() as this = { graphics = null; manager = ScreenManager.Start } then 
      this.graphics <- new GraphicsDeviceManager(this)
        
    override this.Draw(gameTime) =
      let gd = this.graphics.GraphicsDevice
      gd.Clear(Color.Green)
  end
  
