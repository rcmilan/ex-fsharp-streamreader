module typesModule =
    type profile(id, username) =
        member _.id : string = id
        member _.username : string = username

    type user(id, profile) =
        member _.id : string = id
        member _.profile : profile = profile

    type question(id, title, slug, user) =
        member _.id : string = id
        member _.title : string = title
        member _.slug : string = slug
        member _.user : user = user

open typesModule
open System.IO
open System.Text.Json

let printQuestion (q : question) =
    printfn "id:[%s] slug:[%s] user:[%s]" q.id q.slug q.user.profile.username

let streamReader = new StreamReader("questions.json")

streamReader.ReadToEnd()
    |> JsonSerializer.Deserialize<question list>
    |> List.iter printQuestion