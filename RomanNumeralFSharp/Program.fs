module Solution

open NUnitLite
open NUnit.Framework
open System
open System.Reflection

let sum a b = a + b

let repeatChar ch times = String.replicate times ch
    
let getChar (str: string) idx = string (str.[idx])

let rec romanNumeralForDigit digit (numeralOneFiveTen: string) =
    match digit with
    | d when d < 0 -> ""
    | 1 | 2 | 3 -> repeatChar (getChar numeralOneFiveTen 0) digit
    | 4 -> (getChar numeralOneFiveTen 0) + (getChar numeralOneFiveTen 1)
    | 5 | 6 | 7 | 8 -> (getChar numeralOneFiveTen 1) + (romanNumeralForDigit (digit - 5) numeralOneFiveTen)
    | _ -> (getChar numeralOneFiveTen 0) + (getChar numeralOneFiveTen 2)
    
let rec romanNumeralRecursive (value: int) (numerals: string) =
    match value with
    | 0 -> ""
    | _ -> 
        let bigPart = romanNumeralRecursive (value / 10) (numerals.[2..])
        let smallPart = romanNumeralRecursive (value % 10) numerals
        bigPart + smallPart
    
let romanNumeral value = romanNumeralRecursive value "IVXLCDM??"

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

let rec toRomanNumeral = function
    | 0 -> ""
    | n ->
        let x, s = units |> List.find (fun (x, _) -> x <= n)
        s + toRomanNumeral (n-x)
        
let test value expected =
    let actual = toRomanNumeral value
    Assert.AreEqual(expected, actual)

[<Test>]
let testRomanNumeralForDigit () =
    let expected = "IX"
    let actual = romanNumeralForDigit 9 "IVXLCDM??"
    Assert.AreEqual(expected, actual)
    
[<Test>]
let testRepeatChar () =
    let expected = "III"
    let actual = repeatChar "I" 3
    Assert.AreEqual(expected, actual)
        
[<Test>]
let testRomanNumerals () =
    test 10 "X"
    
[<Test>]
let testSum () = 
    let expected = 2 + 2
    let actual = sum 2 2
    Assert.AreEqual(expected, actual)

[<EntryPoint>]
let main argv =
    printfn "Hello, World!"
    (new AutoRun(Assembly.GetCallingAssembly())).Execute( [| "--labels=All" |]) |> ignore
    Console.ReadLine() |> ignore
    0
