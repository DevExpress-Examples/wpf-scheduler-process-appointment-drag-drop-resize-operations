#Region "#usings"
Imports DevExpress.Mvvm.POCO
Imports System
#End Region ' #usings

Namespace SchedulerDragDropResizeExample
	Public Class Doctor
		Public Shared Function Create() As Doctor
			Return ViewModelSource.Create(Function() New Doctor())
		End Function
		Public Shared Function Create(ByVal id As Integer, ByVal name As String) As Doctor
'INSTANT VB NOTE: The variable doctor was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
			Dim doctor_Conflict As Doctor = SchedulerDragDropResizeExample.Doctor.Create()
			doctor_Conflict.Id = id
			doctor_Conflict.Name = name
			Return doctor_Conflict
		End Function

		Protected Sub New()
		End Sub

		Public Overridable Property Id() As Integer
		Public Overridable Property Name() As String
	End Class
End Namespace

