using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 4: Precisamos verificar se o cpf ou cnpj informado é
    // o mesmo que esta salvo no banco para 3 entidades diferentes

    public interface IDados
    {
        string CnpjOuCpf { get; set; }
    }

    public class SamBeneficiario : Entidade<SamBeneficiario>, IDados
    {
        public string CnpjOuCpf { get; set; }
    }

    public class SamPrestador : Entidade<SamPrestador>, IDados
    {
        public string CnpjOuCpf { get; set; }
    }

    public class SamContratante : Entidade<SamContratante>, IDados
    {
        public string CnpjOuCpf { get; set; }
    }

    public class ValidacaoDto
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }

    public class ValidacaoCadastro
    {
        public ValidacaoDto ValidarCpfBeneficiario(string cpfInformado)
        {
            var criteria = new Criteria("WHERE CPF = :CPF", cpfInformado);
            var cpfCadastrado = SamBeneficiario.GetFirstOrDefault(criteria).CnpjOuCpf;

            if (string.IsNullOrEmpty(cpfCadastrado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado cpf em seu cadastro" };

            if (cpfCadastrado != cpfInformado)
                return new ValidacaoDto { Mensagem = "O cpf informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }

        public ValidacaoDto ValidarCnpjPrestador(string cnpjInformado)
        {
            var criteria = new Criteria("WHERE CNPJ = :CNPJ", cnpjInformado);
            var cnpjCadastrado = SamPrestador.GetFirstOrDefault(criteria).CnpjOuCpf;

            if (string.IsNullOrEmpty(cnpjCadastrado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado cnpj em seu cadastro" };

            if (cnpjCadastrado != cnpjInformado)
                return new ValidacaoDto { Mensagem = "O cnpj informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }

        public ValidacaoDto ValidarCpfCnpjPrestador(string informado)
        {
            var criteria = new Criteria("WHERE CPF_CNPJ = :CPF_CNPJ", informado);
            var cadastrado = SamContratante.GetFirstOrDefault(criteria).CnpjOuCpf;

            if (string.IsNullOrEmpty(cadastrado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado cpf/cnpj em seu cadastro" };

            if (cadastrado != informado)
                return new ValidacaoDto { Mensagem = "O cpf/cnpj informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }
}
