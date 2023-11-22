<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655949/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T605963)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# WPF Scheduler - Process Appointment Drag/Drop/Resize Operations

This example handles drag and resize appointment events ([DragAppointmentOver](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.DragAppointmentOver), [DropAppointment](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.DropAppointment), and [StartAppointmentResize](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.StartAppointmentResize)) to apply the following restrictions:

* Users cannot drag multiple appointments at a time.
* Users can move appointments with the **Paid** status only between resources (appointment **Start** and **End** values cannot be changed).
* Users can resize appointments with the **Unpaid** status only to change the **End** value.

![image](https://github.com/DevExpress-Examples/how-to-handle-appointment-drag-drop-resize-operations-t605963/assets/65009440/b8fe2646-e1d2-4f7b-9f31-0271e7db4b53)

## Files to Review

* [MainWindow.xaml](./CS/SchedulerDragDropResizeExample/MainWindow.xaml)
* [MainViewModel.cs](./CS/SchedulerDragDropResizeExample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/SchedulerDragDropResizeExample/ViewModel/MainViewModel.vb))

## Documentation

* [Drag and Drop Appointments](https://docs.devexpress.com/WPF/400539/controls-and-libraries/scheduler/drag-and-drop-appointments)
* [Resize Appointments](https://docs.devexpress.com/WPF/401525/controls-and-libraries/scheduler/resize-appointments)
* [SchedulerControl.DragAppointmentOver](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.DragAppointmentOver)
* [SchedulerControl.DropAppointment](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.DropAppointment)
* [SchedulerControl.StartAppointmentResize](https://docs.devexpress.com/WPF/DevExpress.Xpf.Scheduling.SchedulerControl.StartAppointmentResize)

## More Examples

* [WPF Scheduler - Drop Data From the Grid Control to Create Appointments](https://github.com/DevExpress-Examples/wpf-scheduler-drop-data-from-grid-control-to-create-appointments)
