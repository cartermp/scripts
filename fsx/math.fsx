let collatz n =
    match n with
    | n when n <= 0 -> failwith "collatz' :n is zero or less"
    | n when n % 2 = 0 -> n / 2
    | _ -> 3 * n + 1
    
let applyN f n N =
    let rec loop acc N =
        match N with
        | 0 ->
            match acc with
            | [] ->
                (n :: acc)
            | x :: xs ->
                (f x :: x :: xs)
        | _ ->
            match acc with
            | [] ->
                loop (n :: acc) (N - 1)
            | x :: xs ->
                loop (f x :: x :: xs) (N - 1)
            
    loop [] N
    |> List.rev
    
let res = applyN collatz 42 8

for x in res do
    printfn $"{x}"
