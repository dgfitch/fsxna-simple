open Xunit
open Simple

let (==>) x y = Assert.Equal(y, x)
let (=!>) x y = Assert.NotEqual(y, x)

[<Fact>]
let ScreenManagerStartsBlank() =
  let s = ScreenManager.Start
  s.Screens.Count ==> 0

[<Fact>]
let WorldInitsWithoutExploding() =
  let w = new World()
  w =!> null

[<Fact>]
let CanAddTilesToWorld() =
  let w = new World()
  w.Tiles.Count ==> 0
  w.AddTile(0.0f, 0.0f)
  w.Tiles.Count ==> 1

[<Fact>]
let TilesStayPut() =
  let w = new World()
  w.AddTile(0.0f, 0.0f)
  w.Tiles.[0].body.Position.Y ==> 0.0f
  w.Update(0.5f)
  w.Tiles.[0].body.Position.Y ==> 0.0f

[<Fact>]
let ShapesDropYayGravity() =
  let w = new World()
  w.AddShape(Shape.Circle(w.Sim, 20.0f, 10.0f, 0.0f, 0.0f) )
  w.Shapes.[0].body.Position.Y ==> 0.0f
  w.Update(0.5f)
  w.Shapes.[0].body.Position.Y =!> 0.0f

