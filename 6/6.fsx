let e1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb"
let e2 = "bvwbjplbgvbhsrlpgdmjqwftvncz"
let e3 = "nppdvjthqldpwncqszvftbrmjlhg"
let e4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg"
let e5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw"


e1 |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //3: 7
e2 |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //1: 5
e3 |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //2: 6
e4 |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //6: 10
e5 |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //7: 11


open System.IO

let fc = 
    File
        .ReadAllText("6\\input.txt")


fc |> Seq.windowed 4 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 4) //1278: 1282



e1 |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //5: 19
e2 |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //9: 23
e3 |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //9: 23
e4 |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //15: 29
e5 |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //12: 26

fc |> Seq.windowed 14 |> Seq.map Seq.distinct |> Seq.mapi (fun i x -> x |> Seq.length, i) |> Seq.filter (fun (x,i) -> x = 14) //3499: 3513

3499+14