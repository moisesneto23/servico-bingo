using Microsoft.AspNetCore.Mvc;
using servico_bingo.Repository;
using servico_bingo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace servico_bingo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabelaBingoController : ControllerBase
    {
        public readonly CartelaRepository _cartelaRepository;
        public readonly GeracaoCartelaService cartelaService;
        public TabelaBingoController()
        {
            _cartelaRepository = new CartelaRepository();
            cartelaService = new GeracaoCartelaService();
        }
       
        [HttpPost("numero-sorteado")]
        public IActionResult AdicionarNumeroSorteado(int numero, int posicao)
        {

            return Ok(cartelaService.AdicionarNumeroSorteado(numero, posicao));

        }

        [HttpGet("tabelas")]
        public IActionResult ObterTodasTabelas()
        {
            var tabela = new List<int>();
            return Ok(_cartelaRepository.ObterTodasCartelas());
        }
       
        [HttpGet]
        public IActionResult obterCartelasPorApelido(string nome)
        {
           return Ok(_cartelaRepository.ObterCartelasPorApelido(nome));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post()
        {
            for (int i =0; i < 100000; i++)
            {
                cartelaService.gerarCartela(i.ToString());
                Console.WriteLine(i);

            }
            return Ok();

        }


    }
}
