open System
open System.Collections.Generic

let example =
    @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2"

let getSetUpAndInstructions (s:string) =
    let all = s.Split "\n"
    let setup =
        all 
        |> Seq.takeWhile (fun x -> not (x.StartsWith("move")))
        |> Seq.filter (fun x -> x.Length > 2)
    let instructions = 
        all
        |> Seq.skipWhile (fun x -> not (x.StartsWith("move")))
    all,setup, instructions
    


let cleanUp (ls:string seq) = 
    let all = 
        ls
        |> Seq.map (fun x -> x.Replace("  ", " ").Replace("[", "").Replace("]", ""))
    let start = all |> Seq.takeWhile (fun x -> not (x.StartsWith(" 1")))
    start

let findDimensions (ls: string seq) = 
    let x = ls |> Seq.length
    let y = ls |> Seq.map (fun x -> x.Length) |> Seq.max
    (x,y)

let rotateGridClockwise grid =
    let height, width = Array2D.length1 grid, Array2D.length2 grid
    Array2D.init width height (fun row column -> Array2D.get grid (height - column - 1) row)

let makeArray2d (ls: string seq) =
    let a = 
        array2D [
                for s in ls do
                yield (s |> Seq.map (fun x -> x.ToString()))
        ]
    a


let dictClean (d: Dictionary<string, string list>) = 
    let dn = 
        Dictionary<string, list<string>>()
    d 
    |> Seq.iter (fun x -> 
                    match x.Value with
                    | [] -> ()
                    | _ -> 
                        dn.Add(x.Key, x.Value)
                        ())
    let r =
        dn
        |> Seq.mapi (fun i x -> 
                            let v = dn.[x.Key] |> List.rev
                            KeyValuePair((i+1).ToString(), v)
                            )
        |> fun x -> Dictionary<string, string list>(x)
    r

let cleanArray2d (a2d) =     
    let dict = 
        Dictionary<string, list<string>>()
    let l = a2d |> Array2D.length1
    seq {0 .. l}
    |> Seq.iter (fun x -> dict.Add((x+1).ToString(), []))
    a2d
    |> Array2D.iteri (fun i j v -> 
                        let s = dict.[(i+1).ToString()]
                        if v <> " " then
                            dict[(i+1).ToString()] <- (s @ [v])
                        else 
                            ()
                        () )
    dict
    

type Move =
    {
        NumberToMove: int
        FromKey: string
        ToKey: string
    }

let getMove (s:string) =
    let sp = s.Split(" ") |> Seq.toList
    let (_::ntm::_::fk::_::tk::[]) = sp
    {
        NumberToMove = int ntm
        FromKey = fk
        ToKey = tk
    }

let getMoveInstructions ls =
    ls
    |> Seq.map getMove


let doMove1 (dict:Dictionary<string, list<string>>) m =
    let noM = seq {1 .. m.NumberToMove}
    //printfn "%A" m
    noM 
    |> Seq.iteri (fun i _ -> 
                    let from = dict.[m.FromKey]
                    let tos = dict.[m.ToKey]
                    let fh::ft = from
                    let nto = fh::tos
                    // printfn "move %d-------------" i
                    // printfn "from: %A" from
                    // printfn "ft: %A" ft
                    // printfn "to: %A" tos
                    // printfn "nto: %A" nto
                    dict.[m.ToKey] <- nto
                    dict.[m.FromKey] <- ft
      //              printfn "%A" dict
        )
    dict

let (all,s, i) = example |> getSetUpAndInstructions
all
let sdict = s |> cleanUp |> makeArray2d |> rotateGridClockwise |> cleanArray2d |> dictClean

i |> getMoveInstructions |> Seq.fold (fun s e -> doMove1 s e) sdict


open System.IO

let fc = 
    File
        .ReadAllText("5\\input.txt")


let (all,s, i) = fc |> getSetUpAndInstructions

let sdict = s |> cleanUp |> makeArray2d |> rotateGridClockwise |> cleanArray2d |> dictClean

i |> Seq.filter (fun s -> s.Contains("move")) |> getMoveInstructions |> Seq.fold (fun s e -> doMove1 s e) sdict
  

//RLFNRTNFB
//RLFNRTNFB

sdict
|> Seq.map (fun kv -> kv.Value |> Seq.head)
|> Seq.iter (printf "%s")


let doMove2 (dict:Dictionary<string, list<string>>) m =
    //let noM = seq {1 .. m.NumberToMove}
    //printfn "%A" m
    //noM 
    //|> Seq.iteri (fun i _ -> 
    let from = dict.[m.FromKey]
    let tos = dict.[m.ToKey]
    let fh = from |> List.take m.NumberToMove
    let ft = from |> List.skip m.NumberToMove
    let nto = fh @ tos
    // printfn "move %d-------------" i
    // printfn "from: %A" from
    // printfn "ft: %A" ft
    // printfn "to: %A" tos
    // printfn "nto: %A" nto
    dict.[m.ToKey] <- nto
    dict.[m.FromKey] <- ft
      //              printfn "%A" dict
      //  )
    dict


let (all,s, i) = example |> getSetUpAndInstructions

let sdict = s |> cleanUp |> makeArray2d |> rotateGridClockwise |> cleanArray2d |> dictClean

i |> getMoveInstructions |> Seq.fold (fun s e -> doMove2 s e) sdict



let (all,s, i) = fc |> getSetUpAndInstructions

let sdict = s |> cleanUp |> makeArray2d |> rotateGridClockwise |> cleanArray2d |> dictClean

i |> Seq.filter (fun s -> s.Contains("move")) |> getMoveInstructions |> Seq.fold (fun s e -> doMove2 s e) sdict
sdict
|> Seq.map (fun kv -> kv.Value |> Seq.head)
|> Seq.iter (printf "%s")