open Xunit

let (=>>) x y = Assert.Equal(y, x)

[<Fact>]
let OnePlusOne() =
  1 + 1 =>> 2
