﻿Module Dijkstras_Algorithm
    Sub Dijkstras(ByVal availablepath As Dictionary(Of Node, List(Of Node)), ByVal ShowSolving As Boolean, ByVal SolvingDelay As Integer, ByVal Evaluation As Boolean)
        Dim source As New Node(availablepath.Keys(availablepath.Count - 2).X, availablepath.Keys(availablepath.Count - 2).Y)
        Dim target As New Node(availablepath.Keys(availablepath.Count - 1).X, availablepath.Keys(availablepath.Count - 1).Y)
        Dim dist As New Dictionary(Of Node, Double)
        Dim prev As New Dictionary(Of Node, Node)
        Dim Q As New PriorityQueue(Of Node)
        dist.Add(source, 0)
        For Each v In availablepath.Keys
            If Not v.Equals(source) Then dist.Add(v, Int32.MaxValue / 2)
            prev(v) = Nothing
            Q.Enqueue(v, dist(v))
        Next
        'Q.Enqueue(source, 0)
        Dim stopwatch As Stopwatch = Stopwatch.StartNew()
        'SetBoth(ConsoleColor.Red)
        While Not Q.IsEmpty
            If ExitCase() Then Exit While
            Dim u As Node = Q.ExtractMin
            'SetBoth(ConsoleColor.Red)
            If u.Equals(source) Then
                'SetBoth(ConsoleColor.Green)
            End If
            u.Print("XX")
            Console.ReadKey()
            If u.Equals(target) Then Exit While
            'If ShowSolving Then : u.Print("██") : Threading.Thread.Sleep(SolvingDelay) : End If
            For Each v As Node In GetNeighboursAd(u, availablepath)
                Dim alt As Integer = dist(u) + 1 'h(u, v, 1)
                If alt < dist(v) Then
                    dist(v) = alt
                    prev(v) = u
                    Q.DecreasePriority(v, alt)
                End If
            Next
        End While
        Backtrack(prev, target, source, stopwatch)
        If Not Evaluation Then Console.ReadKey()
    End Sub
End Module