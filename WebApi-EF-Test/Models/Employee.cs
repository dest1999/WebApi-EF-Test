using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_EF_Test.Models
{
    [Index(nameof(FIO),IsUnique = true)]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column]
        [StringLength(50)]
        public string FIO { get; set; } //TODO лучше разбить на отдельные поля Ф.И.О.

        [Column]
        [StringLength(50)]
        public string? JobRole { get; set; } //TODO лучше сделать перечисление или вынести в отдельную таблицу БД
    }
}
