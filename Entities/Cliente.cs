using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace web_api_cliente_mongo.Entities
{
    public class Cliente
    {
        public Cliente(string nome, string apelido, string sexo, DateTime dataNascimento, ICollection<Telefone> telefones, Endereco endereco)
        {
            this.Nome = nome;
            this.Apelido = apelido;
            this.Sexo = sexo;
            this.DataNascimento = dataNascimento;
            this.Telefones = telefones;   
            this.Endereco = endereco;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public ICollection<Telefone> Telefones { get; set; }

        [BsonElement("Endereco")]
        public Endereco Endereco { get; set; }
    }
}