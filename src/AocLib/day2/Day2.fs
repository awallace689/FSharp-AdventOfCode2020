namespace AocLib

open System
open System.Data
open FSharp.Collections

type Range = int * int
type ParseResult = Char * Range * string

module Day2 =

    let parseLine (line: string) : ParseResult =
        let [ lhs: string; rhs: string ] = line.Split ':' |> Seq.toList
        let [ rangeStr; charStr ] = lhs.Split ' ' |> Seq.toList
        let char = char charStr
        let rangeAsStr = rangeStr.Split '-' |> Seq.toList
        let range: Range = (int rangeAsStr.[0], int rangeAsStr.[1])
        let str = rhs.[1..]
        (char, range, str)


    let solve lines =
        let parsedLines = Seq.map parseLine lines

        let validPasswords =
            Seq.filter
                (fun ((char, (low, high), str): ParseResult) ->
                    let numOccurences =
                        (Seq.length << Seq.filter (fun c -> c = char)
                         <| str)

                    low <= numOccurences && numOccurences <= high)
                parsedLines

        Seq.length validPasswords




    let run =
        let lines = IO.File.ReadLines @"./input/day2.txt"

        match lines with
        | lines when Seq.isEmpty lines -> failwith "bad input"
        | _ -> solve lines
