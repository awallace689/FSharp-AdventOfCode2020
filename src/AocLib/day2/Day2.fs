namespace AocLib

open System
open FSharp.Collections

module Day2 = 
    let run =
        let lines = IO.File.ReadLines @"./input/day2.txt"
        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> "hi"