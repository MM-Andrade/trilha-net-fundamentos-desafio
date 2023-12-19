using System.Runtime.CompilerServices;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private Dictionary<string,string> veiculos = new Dictionary<string,string>();
        private string placa;
        private string modelo;

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            placa = string.Empty;
            modelo = string.Empty;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo:");
            //recebe a placa de um veíuclo
            placa = Console.ReadLine();

            Console.WriteLine("Digite o modelo do veículo:");
            //recebe o modelo de um veículo
            modelo = Console.ReadLine();

            //verifica se a placa é valida e cadastra o modelo/veiculo
            if(ValidarPlaca(placa)){
                veiculos.Add(placa, modelo);
                LimpaVariaveisVeiculo();
            }
                
            else
                Console.WriteLine("Placa inválida ou veículo já cadastrado.");
        }

        public void RemoverVeiculo()
        {
            //Verifica se existem veículos estacionados
            if(VerificaSeExistemVeiculosCadastrados(veiculos)){
                // Pedir para o usuário digitar a placa e armazenar na variável placa
                // *IMPLEMENTE AQUI*
                Console.WriteLine("Digite a placa do veículo para remover:");
                placa = Console.ReadLine();

                    // Verifica se o veículo existe
                    if (VerificarVeiculoCadastrado(placa))
                    {

                        Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                        // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                        // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                        // *IMPLEMENTE AQUI*
                        decimal horasEstacionado = 0;
                        decimal valorTotal = 0; 

                        horasEstacionado = int.Parse(Console.ReadLine());
                        do
                        {
                          Console.WriteLine("Digite um valor válido para horas estacionado:");
                          horasEstacionado =  decimal.TryParse(Console.ReadLine().Replace(".",","), out horasEstacionado) ? horasEstacionado : 0;

                        }while(horasEstacionado <= 0);

                        valorTotal = CalcularHoraEstacionado(horasEstacionado);
                        // TODO: Remover a placa digitada da lista de veículos
                        // *IMPLEMENTE AQUI*
                        veiculos.Remove(placa);

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                        LimpaVariaveisVeiculo();
                    }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }else
                Console.WriteLine("Não há veículos estacionados.");
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach(var veiculo in veiculos)
                    Console.WriteLine(veiculo.Key.ToUpper() + " - " + veiculo.Value.ToUpper());
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa){
            //Como existe o padrão mercosul, a placa pode ter 7 caracteres, então é necessário remover o hifem para validarmos
            placa = placa.Replace("-", "").Trim();
            if(!string.IsNullOrEmpty(placa) && placa.Length == 7)
                if(VerificarVeiculoCadastrado(placa))
                    return false;
                else
                return true;   
            return false;
        }
        private bool VerificarVeiculoCadastrado(string placa){
            placa = placa.Replace("-", "").Trim();
            if(veiculos.Any(x => x.Key == placa))
                return true;
            return false;
        }
        private bool VerificaSeExistemVeiculosCadastrados(Dictionary<string,string> veiculos){
            if(veiculos.Any())
                return true;
            return false;
        }
        private decimal CalcularHoraEstacionado(decimal horas){
            return precoInicial + (precoPorHora * horas);
        }
        private void LimpaVariaveisVeiculo(){
            //limpa as variáveis
            placa = string.Empty;
            modelo = string.Empty;
        }
    }
}
