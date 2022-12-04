let examples = 
    [
        "vJrwpWtwJgWrhcsFMMfFFhFp"
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
        "PmmdzqPrVvPwwTWBwg"
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
        "ttgJtRGJQctTZtZT"
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    ]

let split (s:string) = 
    let half = 
        s.Length / 2 
    let f = 
        s.Substring(0,half)
    let s = s.Substring(half, half)
    f,s

let first = examples |> List.head |> split
let second = examples |> List.tail |> List.head |> split

let getIntersect (s1:string) (s2:string) =
    let st1 = 
        s1
        |> Set.ofSeq
    let st2 =
        s2 
        |> Set.ofSeq
    
    st1 |> Set.intersect st2

first ||> getIntersect

let calculate (c:char) = 
    let r = (int) c - (int) 'A'
    if r > 31 then
        r - 31
    else
        r + 27

'a' |> calculate
'z' |> calculate
'A' |> calculate
'Z' |> calculate

let calculateAll x =
    x 
    |> split 
    ||> getIntersect 
    |> Seq.map calculate 
    |> Seq.sum

let e1 =
    examples
    |> List.map calculateAll
    |> List.sum 
    
open System.IO

let fc = 
    File
        .ReadLines("3\\input.txt")

fc 
|> List.ofSeq
|> List.map calculateAll
|> List.sum


let g1 =
    [
        "vJrwpWtwJgWrhcsFMMfFFhFp"
        "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"
        "PmmdzqPrVvPwwTWBwg"
    ]

let g2 = 
    [
        "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"
        "ttgJtRGJQctTZtZT"
        "CrZsJsPPZsGzwwsLwLmpwMDw"
    ]

let grouper l = 
    l 
    |> String.concat ""


let badge l = 
    let (one :: two :: three :: []) = l
    (one, two) ||> getIntersect 
    |> Set.intersect ((two,three) ||> getIntersect)

g1 |> badge |> Set.toList |> List.head |> calculate
g2 |> badge |> Set.toList |> List.head |> calculate


//g1 @ g2
fc
|> Seq.chunkBySize 3
|> Seq.map (Seq.toList >> badge >> Set.toList >> List.head >> calculate)
|> Seq.sum
