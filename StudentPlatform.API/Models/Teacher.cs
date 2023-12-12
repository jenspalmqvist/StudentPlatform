namespace StudentPlatform.API.Models 
{
    public class Teacher
    {
        public int Id { get; set;}
        public string Name { get; set;}

        // ICollection<Course> means that one teacher can 
        // have multiple courses attached to them
        public ICollection<Course> Courses {get; set;} = new List<Course>();

        public Teacher(string name)
        {
            Name = name;
        }

    }
}