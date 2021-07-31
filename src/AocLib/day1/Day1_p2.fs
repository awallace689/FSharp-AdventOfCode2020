namespace AocLib

open System
open FSharp.Collections

module Day1P2 =
    let rec internal solve x st sumsList =
        match sumsList with
        | [] -> (-1, -1, -1)
        | y :: ys ->
            if Set.contains (2020 - y) st then
                (x, (y - x), (2020 - y))
            else
                solve x st ys

    let rec forEachOutter list =
        let st = Set.ofList list

        match list with
        | [] -> 0
        | x :: xs ->
            let sumList = List.map ((+) x) list
            let (n1, n2, n3) = solve x st sumList

            if (n1 + n2 + n3) = 2020 then
                n1 * n2 * n3
            else
                forEachOutter xs

    let internal parseAndSetup lines =
        let st = Seq.map int lines |> Set.ofSeq
        forEachOutter st

    let run =
        let lines = IO.File.ReadLines @"./input/day1.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> parseAndSetup lines
