Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace ResizableRectangle
    Public Partial Class Form2
        Inherits Form

        Private firstPoint As Point = New Point()

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub pictureBox1_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            firstPoint = MousePosition

            If e.Button = MouseButtons.Left Then
                Me.pictureBox1.Height += 10
                Me.pictureBox1.Width += 10
            ElseIf e.Button = MouseButtons.Right Then
                firstPoint = MousePosition
                If Me.pictureBox1.Height > 50 Then Me.pictureBox1.Height -= 10
                If Me.pictureBox1.Width > 50 Then Me.pictureBox1.Width -= 10
            End If
        End Sub

        Private Sub pictureBox1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = MouseButtons.Left Then
                ' Create a temp Point
                Dim temp = MousePosition
                Dim res As Point = New Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y)
                Dim newX = Me.pictureBox1.Location.X - res.X
                Dim newY = Me.pictureBox1.Location.Y - res.Y
                If newX < 0 Then newX = 0
                If newY < 0 Then newY = 0

                ' Apply value to object
                Me.pictureBox1.Location = New Point(newX, newY)
                Me.label2.Text = Me.pictureBox1.Location.X.ToString()
                Me.label4.Text = Me.pictureBox1.Location.Y.ToString()

                ' Update firstPoint
                firstPoint = temp
            End If
        End Sub

        Private Sub Form2_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim currPoint = MousePosition
            Call MessageBox.Show(currPoint.X.ToString() & "/" & currPoint.Y.ToString())
        End Sub

        Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs)
        End Sub
    End Class
End Namespace
