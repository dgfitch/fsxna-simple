open Xunit
open Simple

let (=>>) x y = Assert.Equal(y, x)

[<Fact>]
let ScreenManagerStartsBlank() =
  let s = ScreenManager.Start
  s.Screens.Count =>> 0

