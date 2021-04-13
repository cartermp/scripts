// From https://www.reddit.com/r/fsharp/comments/mqcan3/how_to_use_tail_recursion_to_check_if_2_lists_are/
let rec areEqual l1 l2 =
    match l1, l2 with
    | [], [] -> true
    | x::xs, y::ys ->
        if x <> y then
            false
        else
            areEqual xs ys
    | _ -> false

areEqual [] []

areEqual [1] []

areEqual [] [1]

areEqual [1; 2] [1; 2]

areEqual [1; 2] [1; 3]

