let e =
    [
        "2-4,6-8"
        "2-3,4-5"
        "5-7,7-9"
        "2-8,3-7"
        "6-6,4-6"
        "2-6,4-8"
    ]

let parse (s:string) =
    s.Split ","        
    |> Seq.map (fun x -> x.Split "-")
    |> Seq.toList
    
e
|> List.map parse

let getOverLap [[|(f1:string); (t1:string)|]; [|(f2:string); (t2:string)|]] =
    (int f1 <=  int f2 &&  int t1 >=  int t2)
    ||
    (int f2 <=  int f1 &&  int t2 >=  int t1)


let r = e |> List.map (parse) |> List.head |> Seq.toList



e |> List.map (parse >> Seq.toList >> getOverLap)

open System.IO

let fc = 
    File
        .ReadLines("4\\input.txt")
    |> Seq.toList
 
fc |> List.map (parse >> Seq.toList >> getOverLap) |> Seq.filter id |> Seq.length


let getOverLap2 [[|(f1:string); (t1:string)|]; [|(f2:string); (t2:string)|]] =
    let s1 =
        seq {int f1 .. int t1} |> Set.ofSeq
    let s2 = 
        seq {int f2 .. int t2} |> Set.ofSeq
    s1 |> Set.intersect s2
    
e |> List.map (parse >> Seq.toList >> getOverLap2) |> List.filter (fun x -> x <> Set.empty)


fc |> List.map (parse >> Seq.toList >> getOverLap2) |> List.filter (fun x -> x <> Set.empty) |> List.length

