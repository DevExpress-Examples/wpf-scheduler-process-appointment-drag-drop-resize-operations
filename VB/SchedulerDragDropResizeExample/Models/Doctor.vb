Imports DevExpress.Mvvm

Namespace SchedulerDragDropResizeExample

    Public Class Doctor
        Inherits BindableBase

        Public Sub New(ByVal id As Integer, ByVal name As String)
            Me.Id = id
            Me.Name = name
        End Sub

        Public Property Id As Integer

        Public Property Name As String
    End Class
End Namespace
