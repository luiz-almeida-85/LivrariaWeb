using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LivrariaWeb.Models
{
    [Table("Livros")]
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Nome: ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Descrição: ")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Numero de Paginas: ")]
        public int Npag { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Gereno: ")]
        public string Gereno { get; set; }

        [Required(ErrorMessage = "Campo Obrigatorio")]
        [Display(Name = "Escritor: ")]
        [ForeignKey("Escritor")]
        public int IdEscritor { get; set; }

        /*EF Relation*/

        public Escritor Escritor { get; set; }

    }
}
