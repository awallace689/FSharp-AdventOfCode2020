open System
open AocLib

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let unit argv =
  printfn "%d" Day1.run
  0