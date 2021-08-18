
open System
open System.IO

                        
let path = @"D:\Dropbox\My Stuff\UNI\University Materials and Works\2021\SENG2250\Assignments\Assessment 01\eng.txt"
                        
let ciphertext = 
  "rm clmhrwvirmt grnv zh gsv ulfigs wrnvmhrlm nliv li ovhh vjfrezovmg gl gsv gsivv hkzgrzo wrnvmhrlmh dv ifm rmgl lmv izgsvi wruurcfog jfvhgrlm"
  |> fun x -> x.Split(' ')
                                                
let dictionary = File.ReadAllText(path).Split(Environment.NewLine)

let rand = Random()

let swap (a : _ array) x y =
    let tmp = a.[x]
    a.[x] <- a.[y]
    a.[y] <- tmp

// Shuffle array in-place
let shuffle x = Array.iteri (fun i _ -> swap x i (rand.Next(i, Array.length x))) x

// Pipe to unit returning function, then pipe forward the input
let inline (||>) (x : ^a) (f : ^a->unit) : ^a = f x; x

let alpha = [|'a'..'z'|] |> Array.AsReadOnly
let initialCipher = 
  [|'a'..'z'|] 
  ||> shuffle
  |> Array.mapi (fun i x -> (alpha.[i], x)) 
  |> Map.ofArray

// Source: https://www3.nd.edu/~busiforc/handouts/cryptography/letterfrequencies.html
let frequencies = [
  'e'; 'a'; 'r'; 'i'; 'o'; 't'; 'n'; 's'; 'l'; 'c'; 'u'; 'd'; 'p'; 'm'; 'h'; 'g'; 'b'; 'f'; 'y'; 'w'; 'k'; 'v'; 'x'; 'z'; 'j'; 'q'
]

(*
    Logic
      
      Sub each ciphertext character with a character of equal freq
*)

[<EntryPoint>]
let main argv =
    let keymap = 0
    printfn "%A" frequencies.Length
    0