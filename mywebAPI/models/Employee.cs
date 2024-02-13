using System.ComponentModel.DataAnnotations;

namespace mywebAPI.models
{
    public class Employee
    {
        [Key]public Guid ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }  

    }
}
