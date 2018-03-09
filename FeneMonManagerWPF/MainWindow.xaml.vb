Class MainWindow
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataContext = New MainViewModel()
		'Test comment
    End Sub
End Class
