namespace App

open Fable.Core.JS
open Fable.Core.JsInterop
open Feliz
open Feliz.DaisyUI

type Components =
  /// <summary>
  /// Simple react component with button increase
  /// </summary>
  [<ReactComponent>]
  static member HelloWorld() =
    let (count, setCount) = React.useState 0
    Html.button [
      prop.className "btn btn-primary"
      prop.onClick (fun _ -> setCount (count + 1))
      prop.text count
    ]