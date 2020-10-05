using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LivrariaWeb.Models
{
    [Table("Escritor")]
    public class Escritor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo Obrigatorio")]
        [Display(Name ="E-mail:")]
        [EmailAddress(ErrorMessage ="E-mail Invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Editora:")]
        public string Editora { get; set; }


        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Endereço:")]
        public string Endereço { get; set; }

        /*EF RELATIONS*/

        public IEnumerable<Livros> Livros { get; set; }
    }
}