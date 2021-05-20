#r "nuget: Plotly.NET.Interactive, 2.0.0-beta9"

open Plotly.NET

let x = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
let y = [1; 2; 7; 4; 5; 6; 7; 8; 9; 10]
let y_upper = [2; 3; 8; 5; 6; 7; 8; 9; 10; 11]
let y_lower = [0; 1; 5; 3; 4; 5; 6; 7; 8; 9]

Chart.Range(
    x,
    y,
    y_upper,
    y_lower,
    StyleParam.Mode.Lines,
    Color="rgb(0,100,80)",
    RangeColor="rgba(0,100,80,0.2)")
