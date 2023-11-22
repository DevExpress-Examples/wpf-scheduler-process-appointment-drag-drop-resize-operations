Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Xpf.Scheduling
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

Namespace SchedulerDragDropResizeExample

    Public Class MainViewModel
        Inherits ViewModelBase

        Public Sub New()
            Doctors = New ObservableCollection(Of Doctor)()
            Appointments = New ObservableCollection(Of MedicalAppointment)()
            PaymentStates = New ObservableCollection(Of PaymentState)()
            CreateDoctors()
            CreateAppointments()
            CreatePaymentStates()
        End Sub

        Private Sub CreateAppointments()
            Dim rand As Random = New Random(Date.Now.Millisecond)
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddHours(10), endTime:=Date.Now.Date.AddHours(11.5), doctorId:=1, paymentStateId:=1, location:="101", patientName:="Dave Murrel", note:="Take care"))
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddDays(2).AddHours(15), endTime:=Date.Now.Date.AddDays(2).AddHours(16.5), doctorId:=1, paymentStateId:=1, location:="101", patientName:="Mike Roller", note:="Schedule next visit soon"))
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddDays(1).AddHours(11), endTime:=Date.Now.Date.AddDays(1).AddHours(12), doctorId:=2, paymentStateId:=1, location:="103", patientName:="Bert Parkins", note:=""))
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddDays(2).AddHours(10), endTime:=Date.Now.Date.AddDays(2).AddHours(12), doctorId:=2, paymentStateId:=0, location:="103", patientName:="Carl Lucas", note:=""))
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddHours(12), endTime:=Date.Now.Date.AddHours(13.5), doctorId:=3, paymentStateId:=0, location:="104", patientName:="Brad Barnes", note:="Tests are necessary"))
            Appointments.Add(New MedicalAppointment(startTime:=Date.Now.Date.AddDays(1).AddHours(14), endTime:=Date.Now.Date.AddDays(1).AddHours(15), doctorId:=3, paymentStateId:=1, location:="104", patientName:="Richard Fisher", note:=""))
        End Sub

        Private Sub CreateDoctors()
            Doctors.Add(New Doctor(id:=1, name:="Stomatologist"))
            Doctors.Add(New Doctor(id:=2, name:="Ophthalmologist"))
            Doctors.Add(New Doctor(id:=3, name:="Surgeon"))
        End Sub

        Private Sub CreatePaymentStates()
            PaymentStates.Add(New PaymentState(id:=0, caption:="Unpaid", color:="Tomato"))
            PaymentStates.Add(New PaymentState(id:=1, caption:="Paid", color:="LightGreen"))
        End Sub

        <Command>
        Public Sub OnDragAppointmentOver(ByVal e As DragAppointmentOverEventArgs)
            If e.DragAppointments.Count > 1 Then e.Effects = System.Windows.DragDropEffects.None
        End Sub

        <Command>
        Public Sub OnDropAppointment(ByVal e As DropAppointmentEventArgs)
            Dim draggedAppointment As AppointmentItem = e.DragAppointments.First()
            Dim draggedAppointmentSource As AppointmentItem = e.SourceAppointments.First()
            If draggedAppointment.LabelId IsNot Nothing Then
                If CInt(draggedAppointment.LabelId) = 1 AndAlso (draggedAppointment.Start <> CType(draggedAppointmentSource.SourceObject, MedicalAppointment).StartTime) Then e.Cancel = True
            End If
        End Sub

        <Command>
        Public Sub OnStartAppointmentResize(ByVal e As StartAppointmentResizeEventArgs)
            If e.ResizeAppointment.LabelId IsNot Nothing Then
                If CInt(e.ResizeAppointment.LabelId) = 1 OrElse e.ResizeHandle = ResizeHandle.Start Then e.Cancel = True
            End If
        End Sub

        Public Property Appointments As ObservableCollection(Of MedicalAppointment)

        Public Property Doctors As ObservableCollection(Of Doctor)

        Public Property PaymentStates As ObservableCollection(Of PaymentState)
    End Class
End Namespace
