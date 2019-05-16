Public Class Form1

    Dim inputtype As Integer = 0
    Dim numsorter(19) As Double
    Dim sortcounter As Integer = -1
    Dim showninput As String = ""
    Dim numtemp As String = ""
    Dim chartype As String = ""
    Dim calctemp As Integer = 0

    Sub inputnum(ByVal val As Char)
        If inputtype = 0 Then
            lblInput.Text = ""
        End If
        If inputtype <> 1 Then
            numtemp = ""
            inputtype = 1
            sortcounter += 1
            If Len(sortcounter.ToString) = 1 Then
                chartype = chartype & "0" & sortcounter & "|"
            ElseIf Len(sortcounter.ToString) = 2 Then
                chartype = chartype & sortcounter & "|"
            End If
        End If
        numtemp = numtemp & val
        showninput = showninput & val
        lblInput.Text = showninput
        'lblOutput.Text = chartype
    End Sub

    Sub inputop(ByVal val As Char, ByVal optype As String)
        If inputtype = 0 Then
            lblInput.Text = ""
        End If
        If inputtype <> 2 Then
            If sortcounter = -1 Then
                End 'Error write later
            End If
            numsorter(sortcounter) = numtemp
            inputtype = 2
        End If
        chartype = chartype & optype & "|"
        showninput = showninput & val
        lblInput.Text = showninput
        'lblOutput.Text = chartype
    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        If inputtype = 1 Then
            numsorter(sortcounter) = numtemp
            inputtype = 0
        End If
        calctemp = numsorter(0)

        While chartype.IndexOf("23|") > -1
            calctemp = CDbl(numsorter(chartype.Substring(chartype.IndexOf("23|") - 3, 2))) / CDbl(numsorter(chartype.Substring(chartype.IndexOf("23|") + 3, 2)))
            numsorter(chartype.Substring(chartype.IndexOf("23|") - 3, 2)) = calctemp.ToString
            chartype = Microsoft.VisualBasic.Left(chartype, chartype.IndexOf("23|") - 3) & chartype.Substring(chartype.IndexOf("23|") - 3, 2) & "|" & Microsoft.VisualBasic.Right(chartype, chartype.Length - chartype.IndexOf("23|") - 6)
        End While
        While chartype.IndexOf("22|") > -1
            calctemp = CDbl(numsorter(chartype.Substring(chartype.IndexOf("22|") - 3, 2))) * CDbl(numsorter(chartype.Substring(chartype.IndexOf("22|") + 3, 2)))
            numsorter(chartype.Substring(chartype.IndexOf("22|") - 3, 2)) = calctemp.ToString
            chartype = Microsoft.VisualBasic.Left(chartype, chartype.IndexOf("22|") - 3) & chartype.Substring(chartype.IndexOf("22|") - 3, 2) & "|" & Microsoft.VisualBasic.Right(chartype, chartype.Length - chartype.IndexOf("22|") - 6)
        End While
        While chartype.IndexOf("21|") > -1
            calctemp = CDbl(numsorter(chartype.Substring(chartype.IndexOf("21|") - 3, 2))) - CDbl(numsorter(chartype.Substring(chartype.IndexOf("21|") + 3, 2)))
            numsorter(chartype.Substring(chartype.IndexOf("21|") - 3, 2)) = calctemp.ToString
            chartype = Microsoft.VisualBasic.Left(chartype, chartype.IndexOf("21|") - 3) & chartype.Substring(chartype.IndexOf("21|") - 3, 2) & "|" & Microsoft.VisualBasic.Right(chartype, chartype.Length - chartype.IndexOf("21|") - 6)
        End While
        While chartype.IndexOf("20|") > -1
            calctemp = CDbl(numsorter(chartype.Substring(chartype.IndexOf("20|") - 3, 2))) + CDbl(numsorter(chartype.Substring(chartype.IndexOf("20|") + 3, 2)))
            numsorter(chartype.Substring(chartype.IndexOf("20|") - 3, 2)) = calctemp.ToString
            chartype = Microsoft.VisualBasic.Left(chartype, chartype.IndexOf("20|") - 3) & chartype.Substring(chartype.IndexOf("20|") - 3, 2) & "|" & Microsoft.VisualBasic.Right(chartype, chartype.Length - chartype.IndexOf("20|") - 6)
        End While

        lblOutput.Text = calctemp
        Array.Clear(numsorter, 0, numsorter.Length)
        inputtype = 0
        sortcounter = -1
        showninput = ""
        numtemp = ""
        chartype = ""
        calctemp = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        inputop("+", "20")
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        inputop("-", "21")
    End Sub

    Private Sub btnMul_Click(sender As Object, e As EventArgs) Handles btnMul.Click
        inputop("*", "22")
    End Sub

    Private Sub btnDiv_Click(sender As Object, e As EventArgs) Handles btnDiv.Click
        inputop("/", "23")
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        inputnum("0")
    End Sub
    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        inputnum("1")
    End Sub
    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        inputnum("2")
    End Sub
    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        inputnum("3")
    End Sub
    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        inputnum("4")
    End Sub
    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        inputnum("5")
    End Sub
    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        inputnum("6")
    End Sub
    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        inputnum("7")
    End Sub
    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        inputnum("8")
    End Sub
    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        inputnum("9")
    End Sub

End Class
