#region #usings
using DevExpress.Xpf.Scheduling;
using System;
using System.Collections.ObjectModel;
using System.Linq;
#endregion #usings

namespace SchedulerDragDropResizeExample
{
    public class MainViewModel
    {
        protected MainViewModel()
        {
            Doctors = new ObservableCollection<Doctor>();
            Appointments = new ObservableCollection<MedicalAppointment>();
            PaymentStates = new ObservableCollection<PaymentState>();
            CreateDoctors();
            CreateAppointments();
            CreatePaymentStates();
        }

        private void CreateAppointments()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddHours(10), endTime: DateTime.Now.Date.AddHours(11.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Dave Murrel", note: "Take care", fixedTime: true));
            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddDays(2).AddHours(15), endTime: DateTime.Now.Date.AddDays(2).AddHours(16.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Mike Roller", note: "Schedule next visit soon", fixedTime: true));

            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddDays(1).AddHours(11), endTime: DateTime.Now.Date.AddDays(1).AddHours(12), doctorId: 2, paymentStateId: 1, location: "103", patientName: "Bert Parkins", note: "", fixedTime: true));
            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddDays(2).AddHours(10), endTime: DateTime.Now.Date.AddDays(2).AddHours(12), doctorId: 2, paymentStateId: 0, location: "103", patientName: "Carl Lucas", note: "", fixedTime: false));

            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddHours(12), endTime: DateTime.Now.Date.AddHours(13.5), doctorId: 3, paymentStateId: 0, location: "104", patientName: "Brad Barnes", note: "Tests are necessary", fixedTime: false));
            Appointments.Add(MedicalAppointment.Create(startTime: DateTime.Now.Date.AddDays(1).AddHours(14), endTime: DateTime.Now.Date.AddDays(1).AddHours(15), doctorId: 3, paymentStateId: 1, location: "104", patientName: "Richard Fisher", note: "", fixedTime: true));
        }
        private void CreateDoctors()
        {
            Doctors.Add(Doctor.Create(id: 1, name: "Stomatologist"));
            Doctors.Add(Doctor.Create(id: 2, name: "Ophthalmologist"));
            Doctors.Add(Doctor.Create(id: 3, name: "Surgeon"));
        }
        private void CreatePaymentStates()
        {
            PaymentStates.Add(PaymentState.Create(id: 0, caption: "Unpaid", color: "Tomato"));
            PaymentStates.Add(PaymentState.Create(id: 1, caption: "Paid", color: "LightGreen"));
        }

        #region #OnAppointmentDrag
        public void OnAppointmentDrag(DevExpress.Xpf.Scheduling.AppointmentItemDragDropEventArgs e)
        {
            if (e.ViewModels.Count > 1)
                e.Allow = false;
        }
        #endregion #OnAppointmentDrag
        #region #OnAppointmentDrop
        public void OnAppointmentDrop(DevExpress.Xpf.Scheduling.AppointmentItemDragDropEventArgs e)
        {
            AppointmentDragResizeViewModel draggedViewModel = e.ViewModels.First() as AppointmentDragResizeViewModel;
            if (draggedViewModel.CustomFields["FixedTime"] != null)
                if ((bool)draggedViewModel.CustomFields["FixedTime"] &&
                    (draggedViewModel.Start != draggedViewModel.Appointment.Start))
                    e.Allow = false;
        }
        #endregion #OnAppointmentDrop
        #region #OnAppointmentResize
        public void OnAppointmentResize(DevExpress.Xpf.Scheduling.AppointmentItemResizeEventArgs e)
        {
            if (e.ViewModel.CustomFields["FixedTime"] != null)
                if ((bool)e.ViewModel.CustomFields["FixedTime"] ||
                    e.ResizedSide == DevExpress.XtraScheduler.ResizedSide.AtStartTime)
                    e.Allow = false;
        }
        #endregion #OnAppointmentResize

        public virtual ObservableCollection<MedicalAppointment> Appointments { get; set; }
        public virtual ObservableCollection<Doctor> Doctors { get; set; }
        public virtual ObservableCollection<PaymentState> PaymentStates { get; set; }
    }
}

