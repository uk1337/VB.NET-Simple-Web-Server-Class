# Simple Web Server Class in VB.NET

This is a simple web server class in VB.NET that uses the HttpListener class to listen for incoming HTTP requests and respond with a fixed "Hello, world!" message.


## Usage

To use this class, create a new instance of the SimpleWebServer class and call the Start method:
```VB.net
Dim server As New SimpleWebServer(8080)
server.Start()
```
This will start the web server on port 8080.

To stop the server, call the Stop method:
```VB.net
server.Stop()
```

By default, the server responds with a content type of "text/html" and a fixed message of "Hello, world!". You can customize the content type and message by setting the responseContentType and responseMessage variables in the SimpleWebServer class.

Note that this is a very basic web server implementation and is not suitable for production use. In a real-world scenario, you would need to add more functionality to handle multiple concurrent requests, handle different HTTP methods (such as POST and PUT), and properly handle error conditions.

## Dependencies
This class depends on the System.Net and System.IO namespaces, which should already be included in a standard VB.NET project.

## Contributing
If you find any issues with this module or have suggestions for improvements, feel free to open an issue or submit a pull request.

## License
This module is licensed under the MIT License.
