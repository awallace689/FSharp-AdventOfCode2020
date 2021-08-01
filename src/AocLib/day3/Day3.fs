namespace AocLib

open System
open System.Data
open FSharp.Collections

module Day3 =
    type internal Coord = int * int

    let rec internal solveRec (lines: string array) coord len wid count =
        match coord with
        | (_, y) when y >= len -> count
        | (x, y) when x >= wid -> solveRec lines (x % wid, y) len wid count
        | (x, y) ->
            if (lines.[y]).[x] = '#' then
                solveRec lines (x + 3, y + 1) len wid (count + 1)
            else
                solveRec lines (x + 3, y + 1) len wid count

    let internal solve (lines: seq<string>) =
        let lines = Seq.toArray lines
        let coord: Coord = (0, 0)
        let length = Seq.length lines
        let width = Seq.length lines.[0]
        solveRec lines coord length width 0

    let run =
        let lines = IO.File.ReadLines @"./input/day3.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> solve lines
