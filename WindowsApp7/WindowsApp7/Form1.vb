Imports Emgu.CV
Imports Emgu.CV.Util
Imports Emgu.CV.OCR
Imports Emgu.CV.Structure
Imports System.IO
Imports System.IO.Ports
Imports System.Threading



Public Class Form1
    Dim webcam As Capture = New Capture
    Dim ocr As Tesseract = New Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_ONLY = 500, whiteList:="ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz")
    Dim pic As Bitmap = New Bitmap(270, 270)
    Dim gf As Graphics = Graphics.FromImage(pic)
    Dim data As String
    Dim search As String


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SerialPort1.Close()
        SerialPort1.PortName = "com5"
        SerialPort1.BaudRate = "9600"
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim photo As Image(Of Bgr, Byte) = webcam.QueryFrame
        'gf.CopyFromScreen(New Point(Me.Location.X = PictureBox1.Location.X = 4, Me.Location.Y = PictureBox1.Location.Y = 30), New Point(0, 0), pic.Size)
        PictureBox1.Image = photo.ToBitmap
        ocr.Recognize(New Image(Of Bgr, Byte)(photo.ToBitmap))
        RichTextBox1.Text = ocr.GetText
        data = RichTextBox1.Text
        If InStr(data, "LHR786") Or InStr(data, " lhr786") Or InStr(data, "Lhr786") Then
            Label1.Text = "registered"
            Label2.Text = "Jhon"
            Label3.Text = "13106-5256283-7"
            Label4.Text = "Corolla 2006"
            Label5.Text = "3322bv54676"
            '  SerialPort1.Open()
            ' SerialPort1.Write("1")

            ' SerialPort1.Close()

        ElseIf InStr(data, "ABC1") Or InStr(data, " abc1") Or InStr(data, "Abc1") Then
            Label1.Text = "registered"
            Label2.Text = "Afaq"
            Label3.Text = "13401-6756284-2"
            Label4.Text = "HONDA 2004"
            Label5.Text = "552Cbv76676"
            SerialPort1.Open()
            SerialPort1.Write("1")

            SerialPort1.Close()

        ElseIf InStr(data, "RWP4") Or InStr(data, " RWP 4") Or InStr(data, "rwp 4") Then
            Label1.Text = "un registered"
            Label2.Text = "No record"
            Label3.Text = "No record"
            Label4.Text = "No record"
            Label5.Text = "No record"

        End If

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SerialPort1.Open()
        SerialPort1.Write("1")

        SerialPort1.Close()

    End Sub
End Class