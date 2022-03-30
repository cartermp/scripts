
#r "nuget: Plotly.NET.Interactive, 2.0.0-preview.18"
#r "nuget: FSharp.Data"

open Plotly.NET
open StyleParam

open FSharp.Data

type nebraska = CsvProvider<"https://raw.githubusercontent.com/plotly/datasets/master/wind_speed_laurel_nebraska.csv">
let data = nebraska.GetSample()

let x = [ for row in data.Rows -> row.Time ]
let y = [ for row in data.Rows -> row.``10 Min Sampled Avg`` ]
let yUpper = [ for row in data.Rows -> row.``10 Min Sampled Avg`` + row.``10 Min Std Dev`` ]
let yLower = [ for row in data.Rows -> row.``10 Min Sampled Avg`` - row.``10 Min Std Dev`` ]

let xyTrace =
    Trace2DStyle.Scatter(X = x, Y = y)
    |> Trace2D.initScatter
    |> TraceStyle.TraceInfo(Name="Measurement")
    |> TraceStyle.Line(Color = Color.fromString "rgb(31, 119, 180)")
    |> TraceStyle.Marker(Color = Color.fromString "rgb(31, 119, 180)")

let xyUpperTrace =
    Trace2DStyle.Scatter(X = x, Y = yUpper, FillColor=Color.fromString "gb(31, 119, 180)", Fill = Fill.ToNext_y)
    |> Trace2D.initScatter
    |> TraceStyle.TraceInfo(Name ="Upper Bound")
    |> TraceStyle.Line(Color = Color.fromHex "8a8a8a")
    |> TraceStyle.Marker(Color = Color.fromHex "8a8a8a")

let xyLowerTrace =
    Trace2DStyle.Scatter(X = x, Y = yLower)
    |> Trace2D.initScatter
    |> TraceStyle.TraceInfo(Name = "Lower Bound")
    |> TraceStyle.Line(Color = Color.fromHex "8a8a8a")
    |> TraceStyle.Marker(Color = Color.fromHex "8a8a8a")

let layout = Layout.init(Title.init "Continuous, variable value error bars", HoverMode = HoverMode.X)

GenericChart.MultiChart ([xyLowerTrace;xyUpperTrace;xyTrace],layout,Config(),DisplayOptions())
|> Chart.withYAxisStyle ("Wind speed (m/s)")
