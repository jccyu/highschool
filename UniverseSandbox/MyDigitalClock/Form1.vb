Public Class Form1
    '1 px = 507000000 m
    '1 tick = <daypersec>/<tickpersec> days
    Dim tscale As Integer = 86400
    Dim dscale As Integer = 507000000

    Dim tickpersec As Integer = 10
    Dim daypersec As Integer = 10 'cannot be too small!!!

    Dim planetn As Integer = 0
    Dim dx = New Decimal(5) {500, 200, 0, 0, 0, 0}
    Dim dy = New Decimal(5) {400, 400, 0, 0, 0, 0}
    Dim vx = New Decimal(5) {0, 0, 0, 0, 0, 0}
    Dim vy = New Decimal(5) {0, 0, 0, 0, 0, 0}
    Dim ax As Decimal = 0
    Dim ay As Decimal = 0
    Dim mass = New Decimal(5) {19.89, 0.00005972, 0.00005972, 0.00005972, 0.00005972, 0.00005972} '*10^29 kg (our sun is 19.89)

    Dim colorobj = New Object(5) {Brushes.White, Brushes.Aqua, Brushes.DarkSeaGreen, Brushes.OrangeRed, Brushes.Yellow, Brushes.SandyBrown}
    Dim colorstr = New Object(5) {"White", "Blue", "Green", "Orange", "Yellow", "Brown"}

    Dim mdown As Boolean = False
    Dim redline As New Pen(Color.Red, 1)
    Dim point1 As New Point(0, 0)
    Dim point2 As New Point(0, 0)
    Dim mdx As Decimal = 0
    Dim mdy As Decimal = 0
    
    Dim tstep As Decimal = (1 / tickpersec) * daypersec

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Interval = 1000 / tickpersec
        Timer1.Enabled = True
        vx(1) = 1 * (tscale / dscale)
        vy(1) = 30000 * (tscale / dscale)
        planetn += 1
        cboExisting.Items.Add(colorstr(0))
        cboExisting.Items.Add(colorstr(1))

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        mdx = e.X
        mdy = e.Y
        mdown = True
        point1.X = e.X
        point1.Y = e.Y
        point2.X = e.X
        point2.Y = e.Y
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If planetn < 5 Then
            planetn += 1
            dx(planetn) = e.X
            dy(planetn) = e.Y
            vx(planetn) = (mdx - e.X) / tickpersec
            vy(planetn) = (mdy - e.Y) / tickpersec
            cboExisting.Items.Add(colorstr(planetn))
        End If
        mdown = False
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        If mdown = True Then
            point2.X = e.X
            point2.Y = e.Y
        End If
    End Sub

    Private Sub pictureBox1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        If mdown = False Then
            point1.X = 0
            point1.Y = 0
            point2.X = 0
            point2.Y = 0
        End If
        e.Graphics.DrawLine(redline, point1, point2)
        For i = 0 To planetn
            ax = 0
            ay = 0
            If i = 0 Then
                e.Graphics.TranslateTransform(dx(i), dy(i))
            Else
                e.Graphics.TranslateTransform(dx(i) - dx(i - 1), dy(i) - dy(i - 1))
            End If
            If mass(i) <= txtStatic.Text Then
                dx(i) = dx(i) + vx(i) * tstep
                dy(i) = dy(i) + vy(i) * tstep
                For j = 0 To i - 1
                    ax = ax + (420 * mass(j) * (dx(j) - dx(i))) / (Math.Sqrt((dx(j) - dx(i)) ^ 2 + (dy(j) - dy(i)) ^ 2) ^ 3)
                    ay = ay + (420 * mass(j) * (dy(j) - dy(i))) / (Math.Sqrt((dx(j) - dx(i)) ^ 2 + (dy(j) - dy(i)) ^ 2) ^ 3)
                Next
                For k = i + 1 To planetn
                    ax = ax + (420 * mass(k) * (dx(k) - dx(i))) / (Math.Sqrt((dx(k) - dx(i)) ^ 2 + (dy(k) - dy(i)) ^ 2) ^ 3)
                    ay = ay + (420 * mass(k) * (dy(k) - dy(i))) / (Math.Sqrt((dx(k) - dx(i)) ^ 2 + (dy(k) - dy(i)) ^ 2) ^ 3)
                Next
                vx(i) = vx(i) + ax * tstep
                vy(i) = vy(i) + ay * tstep
            End If
            e.Graphics.DrawString("■", New Font("Arial", 10), colorobj(i), New PointF(0, 0))
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Refresh()
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        planetn = 0
        lblMassTextA.Text = "2.0e30 kg"
        tkbMass.Value = 10
        txtDPS.Text = "10"
        tkbDPS.Value = 10
        txtTPS.Text = "10"
        tkbTPS.Value = 10
        daypersec = 10
        tstep = (1 / tickpersec) * daypersec
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub txtDPS_TextChanged(sender As Object, e As EventArgs) Handles txtDPS.TextChanged
        If txtDPS.Text > 20 Then
            tkbDPS.Value = 20
            daypersec = txtDPS.Text
            tstep = CInt((1 / tickpersec) * daypersec)
        ElseIf txtTPS.Text < 1 Then
            MsgBox("Value too small!")
            txtDPS.Text = tkbDPS.Value
        Else
            tkbDPS.Value = CInt(txtDPS.Text)
            daypersec = txtDPS.Text
            tstep = CInt((1 / tickpersec) * daypersec)
        End If
    End Sub

    Private Sub tkbDPS_Scroll(sender As Object, e As EventArgs) Handles tkbDPS.Scroll
        txtDPS.Text = tkbDPS.Value
        daypersec = tkbDPS.Value
        tstep = (1 / tickpersec) * daypersec
    End Sub

    Private Sub txtTPS_TextChanged(sender As Object, e As EventArgs) Handles txtTPS.TextChanged
        If txtTPS.Text > 20 Then
            tkbTPS.Value = 20
            tickpersec = txtTPS.Text
            tstep = CInt((1 / tickpersec) * daypersec)
        ElseIf txtTPS.Text < 1 Then
            MsgBox("Value too small!")
            txtTPS.Text = tkbTPS.Value
        Else
            tkbTPS.Value = CInt(txtTPS.Text)
            tickpersec = txtTPS.Text
            tstep = CInt((1 / tickpersec) * daypersec)
        End If
        Timer1.Interval = 1000 / tickpersec
    End Sub

    Private Sub tkbTPS_Scroll(sender As Object, e As EventArgs) Handles tkbTPS.Scroll
        txtTPS.Text = tkbTPS.Value
        tickpersec = tkbTPS.Value
        tstep = (1 / tickpersec) * daypersec
        Timer1.Interval = 1000 / tickpersec
    End Sub

    Private Sub txtMass_TextChanged(sender As Object, e As EventArgs) Handles txtMass.TextChanged
        If txtMass.Text > 10 Then
            tkbMass.Value = 10
        ElseIf txtMass.Text < 0 Then
            MsgBox("Value too small!")
            txtMass.Text = tkbMass.Value
        Else
            tkbMass.Value = CInt(txtMass.Text)
        End If
    End Sub

    Private Sub tkbMass_Scroll(sender As Object, e As EventArgs) Handles tkbMass.Scroll
        txtMass.Text = tkbMass.Value
    End Sub

End Class
