module RomanNumeralFSharp

open System
open System.Reflection

(* Based on https://stackoverflow.com/a/18142246/5652483 *)
let units =
    [1000, "M"
     900, "CM"
     500, "D"
     400, "CD"
     100, "C"
     90, "XC"
     50, "L"
     40, "XL"
     10, "X"
     9, "IX"
     5, "V"
     4, "IV"
     1, "I"]

let toRomanNumeral n =
    let rec getNextPart acc n =
        match n with
        | 0 -> acc
        | n ->
            let x, s = units |> List.find (fun (x, _) -> x <= n)
            getNextPart (acc + s) (n-x)
        
    getNextPart "" n
[<EntryPoint>]
let main argv =
    printfn "Hello, World!"
    Console.ReadLine() |> ignore
    0
