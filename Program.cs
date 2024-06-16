public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Gerador de números por extenso");
        string? controle = "S";

        try
        {
            while (controle != null && controle.Trim().ToUpper().Substring(0, 1) == "S")
            {
                GeraNumeroPorExtenso(ValidaNumero());

                Console.Write("\nDeseja gerar outro número por extenso? [Sim ou Não]: ");
                controle = Console.ReadLine();

                if (controle != null && string.Equals(controle.Trim().ToUpper().Substring(0, 1), "N"))
                {
                    Console.Clear();
                    break;
                }
                Console.Clear();
            }
        }
        catch (Exception e)
        {
            throw new Exception($"Erro: {e.Message}");
        }
        Console.WriteLine("\nFim do programa");
    }

    private static int ValidaNumero()
    {
        try
        {
            Console.Write("\nDigite um número positivo: ");
            string? numero = Console.ReadLine();

            while (!int.TryParse(numero, out int erro) || numero is null || Convert.ToInt32(numero) < 0)
            {
                Console.WriteLine("Opção inválida, tente novamente!");
                Console.Write("\nDigite um número positivo: ");
                numero = Console.ReadLine();
            }

            return Convert.ToInt32(numero);
        }
        catch (Exception e)
        {
            throw new Exception($"Erro no número digitado: {e.Message}");
        }
    }

    private static void GeraNumeroPorExtenso(int numero)
    {
        if (numero.ToString().Length == 1) Console.WriteLine($"{numero} = {Unidade(numero)}");

        if (numero.ToString().Length == 2)
        {
            int dezena = int.Parse(numero.ToString().Substring(0, 1));
            int unidade = int.Parse(numero.ToString().Substring(1, 1));

            if (numero > 9 && numero < 21)
                Console.WriteLine($"{numero} = {DezAVinte(numero)}");

            if (numero > 20)
            {
                if (unidade == 0)
                    Console.WriteLine($"{numero} = {DemaisDezenas(dezena)}");
                else
                    Console.WriteLine($"{numero} = {DemaisDezenas(dezena)} e {Unidade(unidade)}");
            }
        }

        if (numero.ToString().Length == 3)
        {
            int centena = int.Parse(numero.ToString().Substring(0, 1));
            int dezenaVinte = int.Parse(numero.ToString().Substring(1, 2));
            int demaisDezenas = int.Parse(numero.ToString().Substring(1, 1));
            int unidade = int.Parse(numero.ToString().Substring(2, 1));

            if (numero == 100) Console.WriteLine($"{numero} = {Centena(numero)}");

            if (numero > 100 && numero <= 199)
            {
                if (numero.ToString().Substring(0, 2) == "10")
                    Console.WriteLine($"{numero} = Cento e {Unidade(unidade)}");

                else if (numero > 109 && numero < 121)
                    Console.WriteLine($"{numero} = Cento e {DezAVinte(dezenaVinte)}");

                else if (numero.ToString().Substring(2, 1) == "0")
                    Console.WriteLine($"{numero} = Cento e {DemaisDezenas(demaisDezenas)}");

                else
                    Console.WriteLine($"{numero} = Cento e {DemaisDezenas(demaisDezenas)} e {Unidade(unidade)}");
            }

            if (numero >= 200 && numero <= 999)
            {
                if (numero.ToString().Substring(1, 2) == "00")
                    Console.WriteLine($"{numero} = {Centena(numero)}");

                else if (dezenaVinte > 9 && dezenaVinte < 21)
                    Console.WriteLine($"{numero} = {Centena(int.Parse($"{centena}00"))} e {DezAVinte(dezenaVinte)}");

                else
                    Console.WriteLine($"{numero} = {Centena(int.Parse($"{centena}00"))} e {DemaisDezenas(demaisDezenas)} e {Unidade(unidade)}");
            }
        }
    }

    private static string Unidade(int numero)
    {
        return numero switch
        {
            0 => "Zero",
            1 => "Um",
            2 => "Dois",
            3 => "Três",
            4 => "Quatro",
            5 => "Cinco",
            6 => "Seis",
            7 => "Sete",
            8 => "Oito",
            9 => "Nove",
            _ => "Inválido"
        };
    }

    private static string DezAVinte(int numero)
    {
        return numero switch
        {
            10 => "Dez",
            11 => "Onze",
            12 => "Doze",
            13 => "Treze",
            14 => "Quatorze",
            15 => "Quinze",
            16 => "Dezesseis",
            17 => "Dezessete",
            18 => "Dezoite",
            19 => "Dezenove",
            20 => "Vinte",
            _ => "Inválido"
        };
    }

    private static string DemaisDezenas(int numero)
    {
        return numero switch
        {
            2 => "Vinte",
            3 => "Trinta",
            4 => "Quarenta",
            5 => "Cinquenta",
            6 => "Sessenta",
            7 => "Setenta",
            8 => "Oitenta",
            9 => "Noventa",
            _ => "Inválido"
        };
    }

    private static string Centena(int numero)
    {
        return numero switch
        {
            100 => "Cem",
            101 => "Cento",
            200 => "Duzentos",
            300 => "Trezentos",
            400 => "Quatrocentos",
            500 => "Quinhentos",
            600 => "Seiscentos",
            700 => "Setecentos",
            800 => "Oitocentos",
            900 => "Novecentos",
            _ => "Inválido"
        };
    }
}