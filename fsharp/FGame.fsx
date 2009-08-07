#r @"c:\Program Files\Microsoft XNA\XNA Game Studio\v3.1\References\Windows\x86\Microsoft.Xna.Framework.dll" 
#r @"c:\Program Files\Microsoft XNA\XNA Game Studio\v3.1\References\Windows\x86\Microsoft.Xna.Framework.Game.dll" 
#r @"..\Dependencies\FarseerPhysics.dll"
#load "UsefulCrud.fs"
#load "FGame.fs"

open Simple
open Simple.UsefulCrud

(*
open System.Net.Sockets

let port = 16661

let listen =
  let thread =
    new System.Threading.Thread(
      new System.Threading.ThreadStart(
        fun () ->
          let tcp = new TcpListener(System.Net.IPAddress.Any, port)
          tcp.Start()
          // while .....
            // listen or something... what exactly do I expect to do with this message when I get it?
            // this is kind of silly unless FSI has a direct "eval", which I don't think it does
      )
    )
  //thread.SetApartmentState(System.Threading.ApartmentState.STA)
  thread.IsBackground <- true
  thread.Start()

*)
// vim:ft=fs
