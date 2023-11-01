//Namespace - Conjunto de Classes 
namespace Calc;
//Bibliotecas = Conjuntos de funções prontas

//3- Classe  = Entidade que vamos criar (nosso programa)

public class Calculadora
{
    //3.1- Atributos = Características /Campos

    //3.2- Funções e Métodos
    public static int somarDoisNumeros(int num1 , int num2)
    {
        return num1 + num2;
    }

    public static int subtrairDoisNumeros(int num1, int num2)
    {
        return num1 - num2;
    }
    public static int multiplicarDoisNumeros(int num1, int num2)
    {
        return num1 * num2;
    } 
    public static int dividirDoisNumeros(int num1, int num2)
    {
        try  //tenta realizar as seguintes operações
        {
           return num1 / num2; 
        }
        catch (System.DivideByZeroException) // se der errado, faça isso:
        {
            
            Console.WriteLine("Não é possível dividir por zero.");
            return 0;
        }
        
    }

    public static void Main()
    {
        //chamar as quatro operações
        Console.WriteLine("5 + 7 = " + somarDoisNumeros(5, 7));
        Console.WriteLine("5 - 7 = " + subtrairDoisNumeros(5, 7));
        Console.WriteLine("5 * 7 = " + multiplicarDoisNumeros(5, 7));
        Console.WriteLine("35 / 7 = " + dividirDoisNumeros(35, 7));

    }

} //fim da classe