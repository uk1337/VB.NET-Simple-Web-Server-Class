Imports System.Net
Imports System.IO
Imports System.Threading

Public Class SimpleWebServer
    Private listener As HttpListener
    Private responseContentType As String = "text/html"

    Public Sub New(ByVal port As Integer)
        listener = New HttpListener()
        listener.Prefixes.Add(String.Format("http://*:{0}/", port))
    End Sub

    Public Sub Start()
        listener.Start()
        Console.WriteLine("Web server started.")

        While listener.IsListening
            Dim context As HttpListenerContext = listener.GetContext()
            ThreadPool.QueueUserWorkItem(AddressOf HandleRequest, context)
        End While
    End Sub

    Public Sub [Stop]()
        listener.Stop()
        Console.WriteLine("Web server stopped.")
    End Sub

    Private Sub HandleRequest(ByVal state As Object)
        Dim context As HttpListenerContext = DirectCast(state, HttpListenerContext)

        Try
            Dim request As HttpListenerRequest = context.Request
            Dim response As HttpListenerResponse = context.Response

            ' Get the request URL and query string
            Dim url As String = request.Url.ToString()
            Dim query As String = request.Url.Query

            ' Set the response headers and content type
            response.ContentType = responseContentType
            response.Headers("Access-Control-Allow-Origin") = "*"

            ' Write the response body
            Dim buffer As Byte() = Encoding.UTF8.GetBytes("<h1>Hello, world!</h1>")
            response.ContentLength64 = buffer.Length
            Dim output As Stream = response.OutputStream
            output.Write(buffer, 0, buffer.Length)
            output.Close()
        Catch ex As Exception
            Console.WriteLine("Error handling request: " & ex.Message)
        Finally
            context.Response.Close()
        End Try
    End Sub
End Class
