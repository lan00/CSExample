<%@ Page Language="VB" %>

<!DOCTYPE html>

<script runat="server">
    Public Sub bar()
        foo()
        Response.Write("bar ")
        'func order & output order 
        'recurite intertest
    End Sub

    Dim a = 0
    Public Sub foo()
        Response.Write("foo ")
        a = a + 1
        If a = 10 Then
            Return
        End If
        bar()

    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%bar() %>
        </div>
    </form>
</body>
</html>
