namespace StudentPlatform.API.Models 
{
    public class Student
    {
        public int Id { get; set;}
        public string Name { get; set;}

        // ICollection<Course> means that a student can be a part of many courses
        // Since Course also has an ICollection<Student>, this is called a many-to-many relation
        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public Student(string name)
        {
            Name = name;
        }

    }
}