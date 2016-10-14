<%@ Language=VBScript %>
<html>
    <head>
        <title>Classic ASP</title>
    </head>
    <!--Note: This must be run with IIS, not the development server.-->
    <body>
        <%
            FirstVar = "Hello world!<br>"
        %>
        <%FOR i=1 TO 10%>
        <%=FirstVar%>
        <%NEXT%>
    </body>
</html>
