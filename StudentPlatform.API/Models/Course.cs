namespace StudentPlatform.API.Models 
{
    public class Course
    {
        public int Id { get; set;}
        public string Name { get; set;}
        // Having a single property means that a course can only have one Teacher
        // Since Teacher has an ICollection<Course>, this is called a one-to-many relation
        // The ? after Teacher means that the property can be null.
        public Teacher? Teacher {get; set;}

        public ICollection<Student> Student { get; set; } = new List<Student>();

        public Course(string name)
        {
            Name = name;
        }

    }
}