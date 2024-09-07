using Assignment.Data.Contexts.Configuration;

namespace Assignment.Data.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string ImgUrl { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        



    }

}
