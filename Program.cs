using System;

namespace DIO.Shows
{
    class Program
    {
        static ShowsRepositorio repositorio = new ShowsRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarShows();
						break;
					case "2":
						Listarrenda();
						break;
					case "3":
						InserirShows();
						break;
					case "4":
						AtualizarShows();
						break;
					case "5":
						ExcluirShows();
						break;
					case "6":
						VisualizarShows();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Programa finalizado.");
			Console.ReadLine();
        }

        private static void ExcluirShows()
		{
			Console.Write("Digite o id do Show: ");
			int indiceShows = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceShows);
		}

        private static void VisualizarShows()
		{
			Console.Write("Digite o id do show: ");
			int indiceShows = int.Parse(Console.ReadLine());

			var Shows = repositorio.RetornaPorId(indiceShows);

			Console.WriteLine(Shows);
		}

        private static void AtualizarShows()
		{
			Console.Write("Digite o id do show: ");
			int indiceShows = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero da banda entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da banda: ");
			string entradabanda = Console.ReadLine();

			Console.Write("Digite o Ano do show: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do show: ");
			string entradaDescricao = Console.ReadLine();
			
			Console.Write("Digite a Lotação do show: ");
			int entradalotacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor do bilhete: ");
			int entradavalor = int.Parse(Console.ReadLine());

			Shows atualizaShows = new Shows(id: indiceShows,
										genero: (Genero)entradaGenero,
										banda: entradabanda,
										ano: entradaAno,
										descricao: entradaDescricao,
										lotacao: entradalotacao,
										valor: entradavalor);

			repositorio.Atualiza(indiceShows, atualizaShows);
		}
        private static void ListarShows()
		{
			Console.WriteLine("Listar shows");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum show cadastrado.");
				return;
			}

			foreach (var shows in lista)
			{
                var excluido = shows.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2} {3}", shows.retornaId(), shows.retornabanda(), shows.retornadescricao(), (excluido ? "*Excluído*" : ""));
			}
		}

		private static void Listarrenda()
		{
			Console.WriteLine("Listar renda dos shows já cadastrados");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum show cadastrado.");
				return;
			}

			foreach (var shows in lista)
			{
                var excluido = shows.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} Renda total do Show: R${2} {3}", shows.retornaId(), shows.retornabanda(), shows.retornarenda(), (excluido ? "*Excluído*" : ""));
			}
		}


        private static void InserirShows()
		{
			Console.WriteLine("Inserir novo show");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da banda: ");
			string entradabanda = Console.ReadLine();

			Console.Write("Digite o Ano do show: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do show: ");
			string entradaDescricao = Console.ReadLine();

			Console.Write("Digite a Lotação do show: ");
			int entradalotacao = int.Parse(Console.ReadLine());

			Console.Write("Digite o valor do bilhete: ");
			int entradavalor = int.Parse(Console.ReadLine());

			Shows novoShows = new Shows(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										banda: entradabanda,
										ano: entradaAno,
										descricao: entradaDescricao,
										lotacao: entradalotacao,
										valor: entradavalor);

			repositorio.Insere(novoShows);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Shows!!!");
			Console.WriteLine("Informe a opção desejada:");
			Console.WriteLine("1- Listar todos os eventos cadastrados");
			Console.WriteLine("2- Listar a renda por eventos");
			Console.WriteLine("3- Inserir novo evento");
			Console.WriteLine("4- Atualizar evento já cadastrado");
			Console.WriteLine("5- Excluir evento");
			Console.WriteLine("6- Visualizar eventos cadastrado");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
