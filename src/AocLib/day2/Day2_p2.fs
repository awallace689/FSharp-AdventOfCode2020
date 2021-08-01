namespace AocLib

open System
open System.Data
open FSharp.Collections

module Day2P2 =
    type internal Indeces = int * int
    type internal ParseResult = Char * Indeces * string

    let internal parseLine (line: string) : ParseResult =
        let [ lhs: string; rhs: string ] = line.Split ':' |> Seq.toList
        let [ indecesStr; charStr ] = lhs.Split ' ' |> Seq.toList
        let char = char charStr
        let indecesAsStr = indecesStr.Split '-' |> Seq.toList
        let indeces: Indeces =
            (int indecesAsStr.[0], int indecesAsStr.[1])

        let str = rhs.[1..]
        (char, indeces, str)

    let internal solve lines =
        let parsedLines = Seq.map parseLine lines

        let validPasswords =
            Seq.filter
                (fun ((char, (index1, index2), str): ParseResult) ->
                    (<>) (str.[index1 - 1] = char) (str.[index2 - 1] = char))
                parsedLines

        Seq.length validPasswords

    let run =
        let lines = IO.File.ReadLines @"./input/day2.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> solve lines
