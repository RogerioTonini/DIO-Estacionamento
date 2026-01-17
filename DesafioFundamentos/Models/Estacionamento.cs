namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            // Lê a entrada do usuário e remove espaços em branco extras
            string placa = Console.ReadLine()?.Trim();
            
            // Valida se a placa não está vazia
            if (!string.IsNullOrWhiteSpace(placa))
            {
                // Adiciona a placa na lista de veículos
                veiculos.Add(placa);
                Console.WriteLine($"Veículo {placa} adicionado com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida. Tente novamente.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Lê a placa digitada pelo usuário
            string placa = Console.ReadLine()?.Trim();

            // Verifica se o veículo existe na lista (ignora maiúsculas/minúsculas)
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // Lê a quantidade de horas e converte para inteiro
                int horas = int.Parse(Console.ReadLine());
                
                // Calcula o valor total: preço inicial + (preço por hora * quantidade de horas)
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove o veículo da lista (busca ignorando maiúsculas/minúsculas)
                veiculos.Remove(veiculos.First(x => x.ToUpper() == placa.ToUpper()));

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                
                // Percorre a lista e exibe cada veículo com numeração
                for (int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}º - {veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
