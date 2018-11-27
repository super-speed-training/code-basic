namespace demojson
{
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }    
        public bool Married { get; set; }
        public Address Address { get; set; }
        public Course[] Course { get; set; }
    }

    public class Address
    {
        public int Zipcode { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}