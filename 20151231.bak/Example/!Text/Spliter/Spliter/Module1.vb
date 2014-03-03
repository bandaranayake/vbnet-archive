Module Module1

    Sub Main()
        Dim source As String = "[stop]ONE[stop]TWO[yop]THREE[yop]"
        Dim stringSeparators() As String = {"[stop]", "[yop]"}
        Dim result() As String

        result = source.Split(stringSeparators, _
                              StringSplitOptions.None)
        For Each s As String In result
            Console.WriteLine("{0} ", s)
        Next
        Console.ReadKey()
    End Sub

End Module
