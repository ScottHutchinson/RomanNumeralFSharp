namespace Tests

open NUnit.Framework
open RomanNumeralFSharp

[<TestClass>]
type TestClass () =

    let test value expected =
        let actual = toRomanNumeral value
        Assert.AreEqual(expected, actual)

    [<SetUp>]
    member this.Setup () =
        ()
        
    [<Test>]
    member this.``Integers are correctly encoded as Roman Numerals`` () =
        test 10 "X"
        test 1963 "MCMLXIII"
