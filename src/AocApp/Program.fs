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

let internal printOutputWithMenu run1 run2 day =
    printP1 day
    run1 ()

    match run2 with
    | Some f ->
        printP2 day
        f ()
    | _ -> ()


[<EntryPoint>]
let unit argv =
    printOutputWithMenu
        (fun () -> printfn "%d" Day1.run) // 1
        (Some(fun () -> printfn "%d" Day1P2.run))
        1

    printOutputWithMenu (fun () -> printfn "%s" Day2.run) None 2

    0
