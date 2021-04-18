namespace web_api_cliente_mongo.Entities
{
    public class Endereco
    {
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }         
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}