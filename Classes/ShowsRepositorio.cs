using System;
using System.Collections.Generic;
using DIO.Shows.Interfaces;

namespace DIO.Shows
{
	public class ShowsRepositorio : IRepositorio<Shows>
	{
        private List<Shows> listaShows = new List<Shows>();
		public void Atualiza(int id, Shows objeto)
		{
			listaShows[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaShows[id].Excluir();
		}

		public void Insere(Shows objeto)
		{
			listaShows.Add(objeto);
		}

		public List<Shows> Lista()
		{
			return listaShows;
		}

		public int ProximoId()
		{
			return listaShows.Count;
		}

		public Shows RetornaPorId(int id)
		{
			return listaShows[id];
		}
	}
}