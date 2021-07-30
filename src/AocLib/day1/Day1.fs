namespace AocLib

open System
open FSharp.Collections
open System.Collections
open System.Collections.Generic

module Day1 =
    let rec internal solve st list =
        match list with
        | [] -> 0
        | x :: xs ->
            if Set.contains (2020 - x) st then
                (2020 - x) * x
            else
                solve st xs

    let internal parseAndSetup lines =
        let list = Seq.map int lines |> Seq.toList
        let set = Set.ofList list
        solve set list

    let run =
        let lines = IO.File.ReadLines @"./input/day1.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> parseAndSetup lines
