using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen_tecnico_COA.Models
{

    [Table("Usuario")]
    public class Usuario
    {
        [Column("IdUsuario")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdUsuario { get; set; }

        [Column("UserName")]
        [StringLength(100)]
        [DisplayName("Nombre de Usuario")]
        [Required]
        public string UserName { get; set; }

        [Column("Nombre")]
        [StringLength(100)]
        [DisplayName("Nombre")]
        [Required]
        public string Name { get; set; }


        [Column("Email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress, ErrorMessage = "el formato debe ser del tipo \"nombre@email.com\"")]
        [Required(ErrorMessage = "Debe ingresar un email")]
        public string Email { get; set; }

        [Column("Telefono")]
        [StringLength(100)]
        [DisplayName("Telefono")]
        [Required]
        public string Telefono { get; set; }


    }
}
