#Region "#usings"
Imports DevExpress.Xpf.Scheduling
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq

#End Region  ' #usings
Namespace SchedulerDragDropResizeExample

    Public Class MainViewModel

        Protected Sub New()
            Doctors = New ObservableCollection(Of Doctor)()
            Appointments = New ObservableCollection(Of MedicalAppointment)()
            PaymentStates = New ObservableCollection(Of PaymentState)()
            CreateDoctors()
            CreateAppointments()
            CreatePaymentStates()
        End Sub

        Private Sub CreateAppointments()
            Dim rand As Random = New Random(Date.Now.Millisecond)
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddHours(10), endTime:=Date.Now.Date.AddHours(11.5), doctorId:=1, paymentStateId:=1, location:="101", patientName:="Dave Murrel", note:="Take care", fixedTime:=True))
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddDays(2).AddHours(15), endTime:=Date.Now.Date.AddDays(2).AddHours(16.5), doctorId:=1, paymentStateId:=1, location:="101", patientName:="Mike Roller", note:="Schedule next visit soon", fixedTime:=True))
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddDays(1).AddHours(11), endTime:=Date.Now.Date.AddDays(1).AddHours(12), doctorId:=2, paymentStateId:=1, location:="103", patientName:="Bert Parkins", note:="", fixedTime:=True))
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddDays(2).AddHours(10), endTime:=Date.Now.Date.AddDays(2).AddHours(12), doctorId:=2, paymentStateId:=0, location:="103", patientName:="Carl Lucas", note:="", fixedTime:=False))
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddHours(12), endTime:=Date.Now.Date.AddHours(13.5), doctorId:=3, paymentStateId:=0, location:="104", patientName:="Brad Barnes", note:="Tests are necessary", fixedTime:=False))
            Appointments.Add(MedicalAppointment.Create(startTime:=Date.Now.Date.AddDays(1).AddHours(14), endTime:=Date.Now.Date.AddDays(1).AddHours(15), doctorId:=3, paymentStateId:=1, location:="104", patientName:="Richard Fisher", note:="", fixedTime:=True))
        End Sub

        Private Sub CreateDoctors()
            Doctors.Add(Doctor.Create(id:=1, name:="Stomatologist"))
            Doctors.Add(Doctor.Create(id:=2, name:="Ophthalmologist"))
            Doctors.Add(Doctor.Create(id:=3, name:="Surgeon"))
        End Sub

        Private Sub CreatePaymentStates()
            PaymentStates.Add(PaymentState.Create(id:=0, caption:="Unpaid", color:="Tomato"))
            PaymentStates.Add(PaymentState.Create(id:=1, caption:="Paid", color:="LightGreen"))
        End Sub

#Region "#OnAppointmentDrag"
        Public Sub OnAppointmentDrag(ByVal e As AppointmentItemDragDropEventArgs)
            If e.ViewModels.Count > 1 Then e.Allow = False
        End Sub

#End Region  ' #OnAppointmentDrag
#Region "#OnAppointmentDrop"
        Public Sub OnAppointmentDrop(ByVal e As AppointmentItemDragDropEventArgs)
            Dim draggedViewModel As AppointmentDragResizeViewModel = TryCast(e.ViewModels.First(), AppointmentDragResizeViewModel)
            If draggedViewModel.CustomFields("FixedTime") IsNot Nothing Then
                If CBool(draggedViewModel.CustomFields("FixedTime")) AndAlso draggedViewModel.Start <> draggedViewModel.Appointment.Start Then e.Allow = False
            End If
        End Sub

#End Region  ' #OnAppointmentDrop
#Region "#OnAppointmentResize"
        Public Sub OnAppointmentResize(ByVal e As AppointmentItemResizeEventArgs)
            If e.ViewModel.CustomFields("FixedTime") IsNot Nothing Then
                If CBool(e.ViewModel.CustomFields("FixedTime")) OrElse e.ResizedSide = DevExpress.XtraScheduler.ResizedSide.AtStartTime Then e.Allow = False
            End If
        End Sub

#End Region  ' #OnAppointmentResize
        Public Overridable Property Appointments As ObservableCollection(Of MedicalAppointment)

        Public Overridable Property Doctors As ObservableCollection(Of Doctor)

        Public Overridable Property PaymentStates As ObservableCollection(Of PaymentState)
    End Class
End Namespace
