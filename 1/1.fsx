open System.IO

let fc = 
    File
        .ReadLines("input.txt")
    |> Seq.toList


let nl =
    fc 
    |> Seq.fold (fun (acc, nl) e -> 
                    match e with
                    | "" ->  ([], acc :: nl)
                    | _ ->  (e::acc, nl)) ([], [[]])
    |> fun (acc,nl) -> acc::nl

let sum =
    nl 
    |> List.map (fun l -> l |> List.map (int) |> List.sum)

let max =
    sum
    |> List.max

let top3 =
    sum
    |> List.sortDescending
    |> List.take 3

let sum3 = 
    top3
    |> List.sum