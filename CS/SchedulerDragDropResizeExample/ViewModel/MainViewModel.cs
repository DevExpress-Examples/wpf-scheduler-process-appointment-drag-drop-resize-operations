using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Xpf.Scheduling;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace SchedulerDragDropResizeExample {
    public class MainViewModel : ViewModelBase {
        public MainViewModel() {
            Doctors = new ObservableCollection<Doctor>();
            Appointments = new ObservableCollection<MedicalAppointment>();
            PaymentStates = new ObservableCollection<PaymentState>();
            CreateDoctors();
            CreateAppointments();
            CreatePaymentStates();
        }

        private void CreateAppointments() {
            Random rand = new Random(DateTime.Now.Millisecond);
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddHours(10), endTime: DateTime.Now.Date.AddHours(11.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Dave Murrel", note: "Take care"));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(2).AddHours(15), endTime: DateTime.Now.Date.AddDays(2).AddHours(16.5), doctorId: 1, paymentStateId: 1, location: "101", patientName: "Mike Roller", note: "Schedule next visit soon"));

            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(1).AddHours(11), endTime: DateTime.Now.Date.AddDays(1).AddHours(12), doctorId: 2, paymentStateId: 1, location: "103", patientName: "Bert Parkins", note: ""));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(2).AddHours(10), endTime: DateTime.Now.Date.AddDays(2).AddHours(12), doctorId: 2, paymentStateId: 0, location: "103", patientName: "Carl Lucas", note: ""));

            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddHours(12), endTime: DateTime.Now.Date.AddHours(13.5), doctorId: 3, paymentStateId: 0, location: "104", patientName: "Brad Barnes", note: "Tests are necessary"));
            Appointments.Add(new MedicalAppointment(startTime: DateTime.Now.Date.AddDays(1).AddHours(14), endTime: DateTime.Now.Date.AddDays(1).AddHours(15), doctorId: 3, paymentStateId: 1, location: "104", patientName: "Richard Fisher", note: ""));
        }
        private void CreateDoctors() {
            Doctors.Add(new Doctor(id: 1, name: "Stomatologist"));
            Doctors.Add(new Doctor(id: 2, name: "Ophthalmologist"));
            Doctors.Add(new Doctor(id: 3, name: "Surgeon"));
        }
        private void CreatePaymentStates() {
            PaymentStates.Add(new PaymentState(id: 0, caption: "Unpaid", color: "Tomato"));
            PaymentStates.Add(new PaymentState(id: 1, caption: "Paid", color: "LightGreen"));
        }

        [Command]
        public void OnDragAppointmentOver(DragAppointmentOverEventArgs e) {
            if (e.DragAppointments.Count > 1)
                e.Effects = System.Windows.DragDropEffects.None;
        }
        [Command]
        public void OnDropAppointment(DropAppointmentEventArgs e) {
            AppointmentItem draggedAppointment = e.DragAppointments.First();
            AppointmentItem draggedAppointmentSource = e.SourceAppointments.First();
            if (draggedAppointment.LabelId != null)
                if ((int)draggedAppointment.LabelId == 1 && (draggedAppointment.Start != ((MedicalAppointment)draggedAppointmentSource.SourceObject).StartTime))
                    e.Cancel = true;
        }
        [Command]
        public void OnStartAppointmentResize(StartAppointmentResizeEventArgs e) {
            if (e.ResizeAppointment.LabelId != null)
                if ((int)e.ResizeAppointment.LabelId == 1 || e.ResizeHandle == ResizeHandle.Start)
                    e.Cancel = true;
        }

        public ObservableCollection<MedicalAppointment> Appointments { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }
        public ObservableCollection<PaymentState> PaymentStates { get; set; }
    }
}

