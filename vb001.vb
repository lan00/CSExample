Module Module1

    Sub Main()
        DynamicCallObject()
    End Sub

End Module


    Sub DynamicCallObject()
        '4/26/2018
        'dynamic call
        Dim o As Object
        o = "asdfdf"
        Console.WriteLine(o.length)

        o = 1
        Console.WriteLine(o.length)
        'An unhandled exception of type 'System.MissingMemberException' occurred in Microsoft.VisualBasic.dll
        'Public member 'length' on type 'Integer' not found.

        Dim i As Int32
        i = 2
        i.GetType()

    End Sub

#Region "TestNative"

    Sub TestNative()
        ' test native method, manage => native
        ' 17.10.18
        Dim pt As System.Drawing.Point = New Drawing.Point()
        GetCursorPos(pt)
        Console.WriteLine("x:{0} , y:{1} ", pt.X, pt.Y)
        GetCursorPos(pt)
        Console.WriteLine("x:{0} , y:{1} ", pt.X, pt.Y)
        GetCursorPos(pt)
        Console.WriteLine("x:{0} , y:{1} ", pt.X, pt.Y)
        GetCursorPos(pt)
        Console.WriteLine("x:{0} , y:{1} ", pt.X, pt.Y)
    End Sub

    Friend Function _GetCursorPos(ByRef pt As System.Drawing.Point) As Boolean
        Return GetCursorPos(pt)
    End Function

    Friend Declare Function GetCursorPos Lib "user32" Alias "GetCursorPos" (ByRef pt As System.Drawing.Point) As Boolean
#End Region
