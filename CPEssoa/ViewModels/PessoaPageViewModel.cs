using CPEssoaAPI.ViewModels;
using System.Collections.Generic;

namespace CPEssoaAPI.ViewModel
{
    public class PessoaPageViewModel
    {
        public PessoaPageViewModel()
        {
            Pessoas = new List<PessoaViewModel>();
        }
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int QtdPagina { get; set; }
        public List<PessoaViewModel> Pessoas { get; set; }
    }
}
