open System
open AocLib

let internal printP1 day =
    printfn ""
    printfn "##################################"

    String.replicate (((-) 11) << String.length << string <| day) "*"
    |> printfn "###*********** DAY %d %s###" day

    printfn "##################################"
    printfn ""

let internal printP2 day =
    printfn ""
    printfn "##################################"

    String.replicate (((-) 8) << String.length << string <| day) "*"
    |> printfn "###******* DAY %d PART 2 %s###" day

    printfn "##################################"
    printfn ""

let internal printOutputWithBanner runP1 runP2 day =
    printP1 day
    runP1 ()

    match runP2 with
    | Some f ->
        printP2 day
        f ()
    | _ -> ()


[<EntryPoint>]
let unit argv =
    printOutputWithBanner
        (fun () -> printfn "%d" Day1.run)
        (Some(fun () -> printfn "%d" Day1P2.run))
        1

    printOutputWithBanner 
        (fun () -> printfn "%d" Day2.run) 
        (Some(fun () -> printfn "%d" Day2P2.run))
        2

    printOutputWithBanner 
        (fun () -> printfn "%d" Day3.run) 
        None
        3

    0
