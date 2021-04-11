#r "nuget: FsToolkit.ErrorHandling"

open FsToolkit.ErrorHandling

let f x =
    printfn $"testing {x}"
    if x > 0 then Ok x else Error "negative!"

let f2 x y z =
    result {
        let! one = f x
        let! two = f y
        let! three = f z
        return one + two + three
    }

printfn $"%A{f2 1 -2 3}"