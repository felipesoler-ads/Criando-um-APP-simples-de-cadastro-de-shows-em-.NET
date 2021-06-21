using System;

namespace DIO.Shows
{
    public class Shows : EntidadeBase
    {
        // Atributos
		private Genero Genero { get; set; }
		private string banda { get; set; }
		private string Descricao { get; set; }
		private int Ano { get; set; }
		private int lotacao { get; set; }
		private int valor{ get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Shows(int id, Genero genero, string banda, string descricao, int ano, int lotacao, int valor)
		{
			this.Id = id;
			this.Genero = genero;
			this.banda = banda;
			this.Descricao = descricao;
			this.Ano = ano;
			this.lotacao = lotacao;
			this.valor = valor;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Banda: " + this.banda + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de realização: " + this.Ano + Environment.NewLine;
			retorno += "Lotação do evento: " + this.lotacao + Environment.NewLine;
			retorno += "Valor do ingresso: " + this.valor + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornabanda()
		{
			return this.banda;
		}

		public string retornadescricao()
		{
			return this.Descricao;
		}
		public int retornarenda()
		{
			return lotacao * valor;
		}
		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}