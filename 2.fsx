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

let calcRes1 (x: Game seq) =
    let a = x |> Seq.toList
    match a with
    | [Rock; Rock] -> draw + rock
    | [Paper; Paper] -> draw + paper
    | [Scissors; Scissors] -> draw + scissors

    | [Rock; Paper] -> win + paper
    | [Paper; Scissors] -> win + scissors
    | [Scissors; Rock] -> win + rock

    | [Rock; Scissors] -> loose + scissors
    | [Paper; Rock] -> loose + rock
    | [Scissors; Paper] -> loose + paper

fc
|> Seq.map (fun x -> x |> calcRes1)
|> Seq.sum


let win = 6
let draw = 3
let loose = 0

let rock = 1
let paper = 2
let scissors = 3

// X: Rock -> lose
// Y: Paper -> draw
// Z: Scissors -> win
// 
let calcRes2 (x: Game seq) =
    let a = x |> Seq.toList
    match a with
    //Draw + prev
    | [Paper; Paper] -> draw + paper
    | [Rock; Paper] -> draw + rock
    | [Scissors; Paper] -> draw + scissors

    //loose + prev
    | [Rock; Rock] -> loose + scissors
    | [Paper; Rock] -> loose + rock
    | [Scissors; Rock] -> loose + paper
    
    //win + prev
    | [Rock; Scissors] -> win + paper
    | [Paper; Scissors] -> win + scissors
    | [Scissors; Scissors] -> win + rock


fc
|> Seq.map (fun x -> x |> calcRes2)
|> Seq.sum


["A Y"; "B X"; "C Z"] 
|> Seq.map(fun s -> s.Split(" "))
|> Seq.map(Seq.map getChosen)
|> Seq.map (calcRes2)
|> Seq.sum

