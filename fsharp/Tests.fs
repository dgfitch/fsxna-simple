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
  w.Tiles.AddTile(0.0f, 0.0f)
  w.Tiles.Count ==> 1



