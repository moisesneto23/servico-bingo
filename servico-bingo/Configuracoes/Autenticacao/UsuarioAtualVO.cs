namespace OrcamentoGenerico.Api.Configuracoes
{
    public class UsuarioAtualVO
    {
        public UsuarioAtualVO(string nomeCompleto, string login, string email)
        {
            NomeCompleto = nomeCompleto;
            Login = login;
            Email = email;
            NomeSobrenome = ObterNomeSobrenome(nomeCompleto);
            IniciaisUsuario = ObterIniciais(NomeSobrenome);
        }

        public string NomeCompleto { get; private set; }
        public string NomeSobrenome { get; private set; }
        public string IniciaisUsuario { get; private set; }
        public string Login { get; private set; }
        public string Email { get; private set; }

        private string ObterIniciais(string nomeSobrenome)
        {
            string[] nomeArray = nomeSobrenome.Split(' ');
            string iniciaisNome = "";

            for (int i = 0; i < nomeArray.Length; i++)
            {
                if (nomeArray[i].Length > 3)
                {
                    iniciaisNome += nomeArray[i].Substring(0, 1);
                }
            }

            return iniciaisNome;
        }

        private string ObterNomeSobrenome(string nomeCompleto)
        {
            string[] nomeArray = nomeCompleto.Split(' ');

            return nomeArray[0] + " " + nomeArray[nomeArray.Length - 1];
        }
    }
}