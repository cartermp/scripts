#r "nuget: FsHttp"

open FsHttp

http {
    GET "https://reqres.in/api/users"
} |> toJson

http {
    POST "https://reqres.in/api/users"
    CacheControl "no-cache"
    body
    json """
    {
        "name": "morpheus",
        "job": "leader"
    }
    """
} |> toJson