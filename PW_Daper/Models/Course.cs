namespace PW_Daper.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"CourseId: {Id}, CourseName: {CourseName}, Description: {Description}";
        }
    }
}
