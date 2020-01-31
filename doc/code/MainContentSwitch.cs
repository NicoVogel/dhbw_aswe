internal void OnTeacherView(Teacher selectedTeacher) {
    TeacherViewModel.Teacher = selectedTeacher;
    CurrentView = TeacherView;
    OnPropertyChanged(nameof(CurrentView));
}