open Xunit
open Simple

let (=>>) x y = Assert.Equal(y, x)
let (>>!) x y = Assert.NotEqual(y, x)

[<Fact>]
let ScreenManagerStartsBlank() =
  let s = ScreenManager.Start
  s.Screens.Count =>> 0

[<Fact>]
let CanInitWorld() =
  let w = new World()
  w >>! null


