#r "../packages/FSharp.Data.2.3.2/lib/net40/FSharp.Data.dll"
#r "System.Xml.Linq.dll"

#load "golem.fs"

open FSharp.Data
open Golem.API

type DeveloperKey = XmlProvider<"developerKeys.xml">

let developerKeys = DeveloperKey.GetSample()
let testKey = developerKeys.TestKey.ToString("N")
let personalKey = developerKeys.PersonalKey.ToString("N")

let latestArticles = fetchArticles personalKey Latest

let latestArticlesWithoutLimit = (None |> latestArticles).Data

let headLines =
    latestArticlesWithoutLimit
    |> Seq.map (fun article -> article.Headline)

headLines
|> Seq.iter (printfn "%s")