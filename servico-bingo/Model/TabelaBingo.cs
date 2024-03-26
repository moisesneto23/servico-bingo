using OrcamentoGenerico.Api.Dominio.Entite.Base;

namespace servico_bingo.Model
{
    public class TabelaBingo : BaseEntite
    {
        private List<int> tabela = new List<int>();
        private Random random = new Random();
        public DateTime? dataPagamento { get; set; }
        public List<int> numeros { get; set; }
        public TabelaBingo()
        {
            GeraTAbela();
            this.numeros = this.tabela;
        }
        private void GeraTAbela()
        {
            GeraNumero();
            Primeiro = tabela[0];
            Segundo = tabela[1];
            Terceiro = tabela[2];
            Quarto = tabela[3];
            Quinto = tabela[4];
            Sexto = tabela[5];
            Setimo = tabela[6];
            Oitavo = tabela[7];
            Nono = tabela[8];
            Decimo = tabela[9];
            DecimoPrimeiro = tabela[10];
            DecimoSegundo = tabela[11];
            DecimoTerceiro = tabela[12];
            DecimoQuarto = tabela[13];
            DecimoQuinto = tabela[14];
            DecimoSexto = tabela[15];
            DecimoSetimo = tabela[16];
            DecimoOitavo = tabela[17];
            DecimoNono = tabela[18];
            Vigezimo = tabela[19];
            VigezimoPrimeiro = tabela[20];
            VigezimoSegundo = tabela[21];
            VigezimoTerceiro = tabela[22];
            VigezimoQuarto = tabela[23];
        }

        private void GeraNumero()
        {
            
            while(tabela.Count < 24)
            {
                int num = random.Next(1,75);
                if (tabela.Contains(num))
                    GeraNumero();
                else tabela.Add(num);
            }
        }
       
        public int Primeiro { get; set; }
        public int Segundo { get; set; }
        public int Terceiro { get; set; }
        public int Quarto { get; set; }
        public int Quinto { get; set; }
        public int Sexto { get; set; }
        public int Setimo { get; set; }
        public int Oitavo { get; set; }
        public int Nono { get; set; }
        public int Decimo { get; set; }
        public int DecimoPrimeiro { get; set; }
        public int DecimoSegundo { get; set; }
        public int DecimoTerceiro { get; set; }
        public int DecimoQuarto { get; set; }
        public int DecimoQuinto { get; set; }
        public int DecimoSexto { get; set; }
        public int DecimoSetimo { get; set; }
        public int DecimoOitavo { get; set; }
        public int DecimoNono { get; set; }
        public int Vigezimo { get; set; }
        public int VigezimoPrimeiro { get; set; }
        public int VigezimoSegundo { get; set; }
        public int VigezimoTerceiro { get; set; }
        public int VigezimoQuarto { get; set; }
        public bool PrimeiroAtivo { get; set; } = false;
        public bool SegundoAtivo { get; set; } = false;
        public bool TerceiroAtivo { get; set; } = false;
        public bool QuartoAtivo { get; set; } = false;
        public bool QuintoAtivo { get; set; } = false;
        public bool SextoAtivo { get; set; } = false;
        public bool SetimoAtivo { get; set; } = false;
        public bool OitavoAtivo { get; set; } = false;
        public bool NonoAtivo { get; set; } = false;
        public bool DecimoAtivo { get; set; } = false;
        public bool DecimoPrimeiroAtivo { get; set; } = false;
        public bool DecimoSegundoAtivo { get; set; } = false;
        public bool DecimoTerceiroAtivo { get; set; } = false;
        public bool DecimoQuartoAtivo { get; set; } = false;
        public bool DecimoQuintoAtivo { get; set; } = false;
        public bool DecimoSextoAtivo { get; set; } = false;
        public bool DecimoSetimoAtivo { get; set; } = false;
        public bool DecimoOitavoAtivo { get; set; } = false;
        public bool DecimoNonoAtivo { get; set; } = false;
        public bool VigezimoAtivo { get; set; } = false;
        public bool VigezimoPrimeiroAtivo { get; set; } = false;
        public bool VigezimoSegundoAtivo { get; set; } = false;
        public bool VigezimoTerceiroAtivo { get; set; } = false;
        public bool VigezimoQuartoAtivo { get; set; } = false;

    }
}
