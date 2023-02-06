[<AutoOpen>]
module Extensions

open System
open Fable.Core
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module StaticFile =
    // import by relative path
    let inline import (path: string) : string = importDefault<string> path

[<RequireQualifiedAccess>]
module Config =
    [<Emit("process.env[$0] ? process.env[$0] : ''")>]
    let variable (key: string) : string = jsNative
    let variableOrDefault (key: string) (defaultValue: string) =
        let foundValue = variable key
        if String.IsNullOrWhiteSpace foundValue
        then defaultValue
        else foundValue

/// let private stylehsheet = Stylesheet.load "./fancy.module.css"
/// stylesheet.["fancy-class-name"] which returns a string
module Stylesheet =
    type IStylesheet =
        [<Emit "$0[$1]">]
        abstract Item : className:string -> string
    let inline load (path: string) = importDefault<IStylesheet> path