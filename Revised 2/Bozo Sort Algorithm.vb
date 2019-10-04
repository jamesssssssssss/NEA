﻿Module BozoSort
    Function BozoSort(a As List(Of Double))
        Dim r As New Random
        While Not IsSorted(a)
            Swap(a, r.Next(0, a.Count), r.Next(0, a.Count))
            AnimateSort(a, 1)
        End While
        Return a
    End Function
    Sub Swap(ByRef a As List(Of Double), index1 As Integer, index2 As Integer)
        Dim temp As Double = a(index1)
        a(index1) = a(index2)
        a(index2) = temp
    End Sub
End Module
