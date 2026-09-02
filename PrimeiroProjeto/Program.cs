//Screen Sounds
string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> ListaDasBandas = new List<string> { "U2", "The Beatles", "Calypso" };
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); // Dictionary serve para quando quero associar um item a outro e acessar de um jeito eficiente
bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());
void ExibirLogo()
{
    Console.WriteLine(@"
█▀ █▀▀ █▀█ █▀▀ █▀▀ █▄░█   █▀ █▀█ █░█ █▄░█ █▀▄ █▀
▄█ █▄▄ █▀▄ ██▄ ██▄ █░▀█   ▄█ █▄█ █▄█ █░▀█ █▄▀ ▄█
");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas a bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 5 para sair");

    Console.Write("\nDigite a sua opção:");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas();
            break;
        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaDaBanda();
            break;
        case 5:
            Console.WriteLine("Tchau Tchau :)");
            break;
        default:
            Console.WriteLine("Opção invalida");
            break;

    }

}

void RegistrarBandas()
{
    Console.Clear(); // Limpa a antiga tela para exibir  uma nova tela
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar:");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso"); // o cifrão serve para uma interpolação de string que inseri valores de variaveis dentro de uma string usando {}
    Thread.Sleep(2000);//Serve como uma pausa para o usuario ler o a mensagem em tela antes de muda-la
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");
    //for(int i = 0; i < ListaDasBandas.Count; i++) // O.Count trasnforma nossa lista em numero, ou seja na quantidade de itens que tem dentro dela
    //{
    //    Console.WriteLine($"Banda: {ListaDasBandas[i]}"); // os colchetes [] são usados acessar um elemento específico dentro da lista e o i que vai dentro dos colchetes é o indice do elemento que queremos acessar
    //}

    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }


    Console.Write("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey(); // Serve para o usuario ter a pausa no tempo dele para ler oq tiver na tela e logo depois clicar em uma tecla e voltar para o menu
    Console.Clear();
    ExibirOpcoesDoMenu();

}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length; // .Length propriedade que se pode usar em uma variavel do tipo string ela retorna um numero inteiro que representa a quantidade de caracteres (letras, espaços, símbolos, etc.) que existem naquela string
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*'); //.empty representa uma string vazia, o .PadLeft metodo que chama qualquer caractere desejado e coloque a esquerda de uma string ate que o comprimento total
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //Digite queal a banda deseja avaliar
    //se a banda existir no dicionario >> atribuir uma nota
    //senão existir, voltar ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar:");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!); // .Parse transforma uma variavel string em numero
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }




    else
    {
        Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MediaDaBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("MediaDaBanda");
    Console.Write("Qual nome da banda gostaria de ver a média de avaliações: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
        {

        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
        double totalNotas = 0;
        for (int i = 0; i < notasDaBanda.Count; i++){
            totalNotas += notasDaBanda[i];
        }
        double media = totalNotas / notasDaBanda.Count;
        Console.WriteLine($"A média de avaliação da banda {nomeDaBanda} é {media}");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();

    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();

    }

}

ExibirOpcoesDoMenu();


