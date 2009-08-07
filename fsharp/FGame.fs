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

// TODO: Screen manager should actually do something
type ScreenManager =
  { mutable Screens : ResizeArray<Screen> }
  with static member Start = { Screens = new ResizeArray<Screen>() }


type Shape =
  { body : Body
    geom : Geom }

  with 
    static member Circle(sim : PhysicsSimulator, r : float32, mass : float32, x : float32, y : float32) =
      let body = BodyFactory.Instance.CreateCircleBody(sim, r, mass)
      let geom = GeomFactory.Instance.CreateCircleGeom(sim, body, r, int 20)
      body.Position <- vf x y
      { body = body; geom = geom }

    static member Rectangle(sim : PhysicsSimulator, w : float32, h : float32, mass : float32, x : float32, y : float32) =
      let body = BodyFactory.Instance.CreateRectangleBody(sim, w, h, mass)
      let geom = GeomFactory.Instance.CreateRectangleGeom(sim, body, w, h)
      body.Position <- vf x y
      { body = body; geom = geom }


type Tiles() =
  class
    let tiles = new ResizeArray<Shape>()

    member this.AddTile(sim : PhysicsSimulator, x : float32, y : float32) =
      tiles.Add(Shape.Rectangle(sim, 10.0f, 10.0f, 20.0f, x, y))
  end

type World() =
  class
    let sim  = new PhysicsSimulator(vi 0 0)
  end


type FGame =
  class
    inherit Game
    
    val mutable graphics : GraphicsDeviceManager
    val mutable manager : ScreenManager
    
    new() as this = { graphics = null; manager = ScreenManager.Start } then 
      this.graphics <- new GraphicsDeviceManager(this)

    override this.Initialize() =
      this.graphics.IsFullScreen <- false
      this.graphics.SynchronizeWithVerticalRetrace <- false
      this.Window.Title <- "YAY"
      this.TargetElapsedTime <- new TimeSpan(0, 0, 0, 0, 10)
      this.IsFixedTimeStep <- true
      base.Initialize()
        
    override this.Draw(gameTime) =
      let gd = this.graphics.GraphicsDevice
      gd.Clear(Color.Green)
      this.Draw(gameTime)
  end
