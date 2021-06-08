module M =
    let inline private (|HasName|) x = (^a : (member Name: string) x)

    let inline printName (HasName name) = printfn $"{name}"

type Person1 = { Name: string; Age: int }
type Person2 = { Name: string; Age: int; IsFunny: bool }

type Name(name) =
    member _.Name = name

let p1 = { Name = "Phillip"; Age = 30 }
let p2 = { Name = "Phillip"; Age = 30; IsFunny = false }
let nm = Name "Phillip"

M.printName p1
M.printName p2
M.printName nm

let r = {| a = "yeet" |}
let r2 = {| a = "yeet"; b = "yote" |}

let inline f< ^T when ^T: (member a: string)> (r: ^T) = ()

f r
f r2
