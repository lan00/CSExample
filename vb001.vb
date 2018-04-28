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
