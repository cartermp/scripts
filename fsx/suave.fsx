#r "nuget: suave"

open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful

let app =
  choose
    [ GET >=> choose
        [ path "/" >=> OK "Try '/hello', '/goodbye', etc."
          path "/hello" >=> OK "Hello GET"
          path "/goodbye" >=> OK "Good bye GET" ]
      POST >=> choose
        [ path "/hello" >=> OK "Hello POST"
          path "/goodbye" >=> OK "Good bye POST" ] ]

startWebServer defaultConfig app
