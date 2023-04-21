using FullStack.Models;

namespace FullStack.ViewModels
{
    public class DashboardViewModel
    {
        public List<Feedbacks>? FeedbacksVM { get; set; }
        public List<Notifications>? NotificationsVM { get; set; }
        public List<AttachmentFile>? AttachmentFileVM { get; set; }
        public List<Enrollment>? EnrollmentVM { get; set; }
        public List<Tasks>? TasksVM { get; set; }
        public int TotalFeedbacks { get; set; }
        public int PossibleGrades { get; set; }
        public int TotalGrades { get; set; }
        public int SumNotifications { get; set; }
        public int SumAttachmentFile { get; set; }
        public int SumEnrollment { get; set; }
        public int SumTasks { get; set; }

    }
}
