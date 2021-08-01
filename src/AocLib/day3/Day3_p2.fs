namespace AocLib

open System
open System.Data
open FSharp.Collections

module Day3P2 =
    type internal Coord = int * int
    type internal Slope = int * int

    let rec internal solveRec 
        (lines: string array) coord len wid count ((slopeX, slopeY): Slope) =
        match coord with
        | (_, y) when y >= len -> count
        | (x, y) when x >= wid -> 
            solveRec lines (x % wid, y) len wid count (slopeX, slopeY)
        | (x, y) ->
            if (lines.[y]).[x] = '#' then
                solveRec 
                    lines (x + slopeX, y + slopeY) len wid (count + 1) (slopeX, slopeY)
            else
                solveRec lines (x + slopeX, y + slopeY) len wid count (slopeX, slopeY)

    let internal solve (lines: seq<string>) =
        let slopes =
            [ (1, 1)
              (3, 1)
              (5, 1)
              (7, 1)
              (1, 2) ]

        let lines = Seq.toArray lines
        let coord: Coord = (0, 0)
        let length = Seq.length lines
        let width = Seq.length lines.[0]

        slopes
        |> List.map (solveRec lines coord length width 0)
        |> List.reduce ((*): int -> int -> int)

    let run =
        let lines = IO.File.ReadLines @"./input/day3.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> solve lines
