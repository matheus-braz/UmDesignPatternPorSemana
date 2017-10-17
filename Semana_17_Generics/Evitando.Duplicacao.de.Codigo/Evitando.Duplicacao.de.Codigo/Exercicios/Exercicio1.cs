using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 1: Precisamos preencher as informações de contato do prestador, 
    // beneficiário e contratante em um dto, atualmente nosso código esta duplicado
    // para cada uma das entidades, como podemos melhorar isso?

    public interface IContatoBase
    {
        string Email { get; set; }

        string Telefone { get; set; }

        string Endereco { get; set; }
    }

    public class Prestador : Entidade<Prestador>, IContatoBase
    {
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }

    public class Beneficiario : Entidade<Beneficiario>, IContatoBase
    {
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }

    public class Contratante : Entidade<Contratante>, IContatoBase
    {
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }

    public class ContatoDto
    {
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }
    }

    public class InformacoesContato
    {
        public ContatoDto ObterContato(IContatoBase dados)
        {
            return new ContatoDto
            {
                Email = dados.Email,
                Endereco = dados.Endereco,
                Telefone = dados.Telefone
            };
        }
    }
}
