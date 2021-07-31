open System
open AocLib

let internal printDay1() = 
    printfn ""
    printfn "##################################"
    printfn "###*********** DAY1 ***********###"
    printfn "##################################"
    printfn ""

let internal printDay1P2() = 
    printfn ""
    printfn "##################################"
    printfn "###******* DAY 1 PART 2 *******###"
    printfn "##################################"
    printfn ""

[<EntryPoint>]
let unit argv =
    printDay1()
    printfn "%d" Day1.run
    printDay1P2()
    printfn "%d" Day1P2.run 
    0