<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128655949/21.1.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T605963)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/SchedulerDragDropResizeExample/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/SchedulerDragDropResizeExample/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/SchedulerDragDropResizeExample/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/SchedulerDragDropResizeExample/MainWindow.xaml.vb))
* [Doctor.cs](./CS/SchedulerDragDropResizeExample/Models/Doctor.cs) (VB: [Doctor.vb](./VB/SchedulerDragDropResizeExample/Models/Doctor.vb))
* [MedicalAppointment.cs](./CS/SchedulerDragDropResizeExample/Models/MedicalAppointment.cs) (VB: [MedicalAppointment.vb](./VB/SchedulerDragDropResizeExample/Models/MedicalAppointment.vb))
* [PaymentState.cs](./CS/SchedulerDragDropResizeExample/Models/PaymentState.cs) (VB: [PaymentState.vb](./VB/SchedulerDragDropResizeExample/Models/PaymentState.vb))
* [MainViewModel.cs](./CS/SchedulerDragDropResizeExample/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/SchedulerDragDropResizeExample/ViewModel/MainViewModel.vb))
<!-- default file list end -->
# How to handle appointment drag/drop/resize operations


This example illustrates how to handle the <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_AppointmentDragtopic">AppointmentDrag</a>, <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_AppointmentDroptopic">AppointmentDrop</a> and <a href="http://help.devexpress.com/#WPF/DevExpressXpfSchedulingSchedulerControl_AppointmentResizetopic">AppointmentResize</a> events to apply the following restrictions

* single appointment drag;
* appointments with the Paid status can be moved only between resources, so that their Start and End values remain unchanged;
* resizing is allowed for Unpaid status to change the End value.<br><br><img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-handle-appointment-drag-drop-resize-operations-t605963/17.2.3+/media/6c8e0768-1495-4642-810f-7d88747475d7.png"><br><br>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-process-appointment-drag-drop-resize-operations&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-scheduler-process-appointment-drag-drop-resize-operations&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
