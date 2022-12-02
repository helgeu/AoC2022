open System.IO

type Game = 
    | Rock
    | Paper
    | Scissors

let getChosen x =
    match x with
    | "A" | "X" -> Rock
    | "B" | "Y" -> Paper
    | "C" | "Z" -> Scissors


let fc = 
    File
        .ReadLines("2\\input.txt")
    |> Seq.map(fun s -> s.Split(" "))
    |> Seq.map(Seq.map getChosen)

// A: Rock
// B: Paper
// C: Scissors
// X: Rock
// Y: Paper
// Z: Scissors

let win = 6
let draw = 3
let loose = 0

let rock = 1
let paper = 2
let scissors = 3

let calcRes (x: Game seq) =
    let a = x |> Seq.toList
    match a with
    | ["A";"X"] -> draw + rock
    | ["B";"Y"] -> draw + paper
    | ["C";"Z"] -> draw + scissors

    | ["A";"Y"] -> win + paper
    | ["B";"Z"] -> win + scissors
    | ["C";"X"] -> win + rock

    | ["A";"Z"] -> loose + scissors
    | ["B";"X"] -> loose + rock
    | ["C";"Y"] -> loose + paper

fc
|> Seq.map (fun x -> x |> calcRes)
|> Seq.sum
    
