using DevExpress.Mvvm;

namespace SchedulerDragDropResizeExample {
    public class Doctor : BindableBase {
        public Doctor(int id, string name) {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
