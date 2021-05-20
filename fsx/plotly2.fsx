
#r "nuget: Plotly.NET.Interactive, 2.0.0-beta9"
#r "nuget: FSharp.Data"

open Plotly.NET
open Trace
open StyleParam

open FSharp.Data

type nebraska = CsvProvider<"https://raw.githubusercontent.com/plotly/datasets/master/wind_speed_laurel_nebraska.csv">
let data = nebraska.GetSample()

let x = [ for row in data.Rows -> row.Time ]
let y = [ for row in data.Rows -> row.``10 Min Sampled Avg`` ]
let yUpper = [ for row in data.Rows -> row.``10 Min Sampled Avg`` + row.``10 Min Std Dev`` ]
let yLower = [ for row in data.Rows -> row.``10 Min Sampled Avg`` - row.``10 Min Std Dev`` ]

let xyTrace =
    TraceStyle.Scatter(x, y)
    |> Trace.initScatter
    |> TraceStyle.TraceInfo(Name="Measurement")
    |> TraceStyle.Line(Color="rgb(31, 119, 180)")
    |> TraceStyle.Marker(Color="rgb(31, 119, 180)")

let xyUpperTrace =
    TraceStyle.Scatter(x, yUpper, Fillcolor="gb(31, 119, 180)", Fill = Fill.ToNext_y)
    |> Trace.initScatter
    |> TraceStyle.TraceInfo(Name="Upper Bound")
    |> TraceStyle.Line(Color="#444")
    |> TraceStyle.Marker(Color="#444")

let xyLowerTrace =
    TraceStyle.Scatter(x,yLower)
    |> Trace.initScatter
    |> TraceStyle.TraceInfo(Name="Lower Bound")
    |> TraceStyle.Line(Color="#444")
    |> TraceStyle.Marker(Color="#444")

let layout = Layout.init(Title="Continuous, variable value error bars", Hovermode = Hovermode.X)

GenericChart.MultiChart ([xyLowerTrace;xyUpperTrace;xyTrace],layout,Config(),DisplayOptions())
|> Chart.withY_AxisStyle ("Wind speed (m/s)")
