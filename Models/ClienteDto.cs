using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web_api_cliente_mongo.Entities;

namespace web_api_cliente_mongo.Models
{
    public class ClienteDto
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório.")]
        public string Nome { get; set; }
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Sexo é um campo obrigatório.")]
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }
    }
}