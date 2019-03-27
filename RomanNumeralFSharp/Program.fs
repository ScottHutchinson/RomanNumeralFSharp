module Solution

open NUnitLite
open NUnit.Framework
open System
open System.Reflection

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
    let rec iter acc n =
        match n with
        | 0 -> acc
        | n ->
            let x, s = units |> List.find (fun (x, _) -> x <= n)
            iter (acc + s) (n-x)
        
    iter "" n

let test value expected =
    let actual = toRomanNumeral value
    Assert.AreEqual(expected, actual)
        
[<Test>]
let ``Integers are correctly encoded as Roman Numerals`` () =
    test 10 "X"
    test 1963 "MCMLXIII"

[<EntryPoint>]
let main argv =
    printfn "Hello, World!"
    (new AutoRun(Assembly.GetCallingAssembly())).Execute( [| "--labels=All" |]) |> ignore
    Console.ReadLine() |> ignore
    0
