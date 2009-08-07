namespace Simple

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Audio
open Microsoft.Xna.Framework.Content
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input
open Microsoft.Xna.Framework.Storage
open FarseerGames.FarseerPhysics
open FarseerGames.FarseerPhysics.Collisions
open FarseerGames.FarseerPhysics.Dynamics
open FarseerGames.FarseerPhysics.Factories
open System
open Microsoft.FSharp.Collections
open System.IO

open Simple.UsefulCrud

type ScreenState =
  | Active
  | Hidden
  | MoveOn
  | MoveOff


type Screen =
  { mutable State : ScreenState }

// TODO: Screen manager
type ScreenManager =
  { mutable Screens : ResizeArray<Screen> }
  with static member Start = { Screens = new ResizeArray<Screen>() }


type World() =
  class
    let sim  = new PhysicsSimulator(v 0 0)
    //let view = new PhysicsSimulatorView(sim)
  end


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
