using System.ComponentModel.DataAnnotations;

namespace BranchRegistrationWork.Models
{
    public class Monk
    {
        public int Id { get; set; }

        public string? Title { get; set; }
        public string? Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfOrdination { get; set; }
        public string? MonasteryName { get; set; }
        public decimal Price { get; set; }
    }
}
