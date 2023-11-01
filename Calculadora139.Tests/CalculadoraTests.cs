
//1 Bibliotescas

using NUnit.Framework;
using Calc;  //NameSpace da calculadora no desenvolvimento

//2 Namespace
namespace Calculadora139.Tests;

[TestFixture] //Marcação de que a classe vai trabalhar com testes parametrizados / que leem listas, arquivos
//Classe
public class CalculadoraTests
{

    //3.1 Atributos


    //3.2 Funções (tem um retorno) e Métodos (void, não tem retorno, somente faz)
    // Função de apoio  de Leitura de dados a partir de um arquivo CSV
    public static IEnumerable<TestCaseData> lerDadosDeTeste(String operacao)
    {
        String caminhoMassa = @"/home/jessica/Documents/Iterasys/ProjetoCalculadora/Calculadora139.Tests/fixtures/"; //Caminho do arquivo CSV

        switch(operacao)
        {
            case "+":
                caminhoMassa += @"massaSomar.csv";
                break;

            case "-":
                caminhoMassa += @"massaSubtrair.csv";
                break;

            case "*":
                caminhoMassa += @"";
                break;

            case "/":
                caminhoMassa += @"";
                break;
        }

        using (var leitor = new StreamReader(caminhoMassa))
        {
            //pular a primeira linha - cabeçalho
            leitor.ReadLine();

            //repretir as ações até a condição se realizar
            //no caso, seria até o final do arquivo CSV
            //repita enquanto não for o final  (Exclamação no inicio é negação)
            while(!leitor.EndOfStream )
            {
                var linha = leitor.ReadLine();  //lendo uma linha
                var valores = linha.Split(",");    //dividir em campos (pedaços)

                yield return new TestCaseData(int.Parse(valores[0]),int.Parse(valores[1]),int.Parse(valores[2]));
            }
        }
    }


    [Test] // Método de teste
    public void testSomarDoisNumeros()
    {
        //Triplo A = AAA

        //Configura
        //Dados de Entrada
        int num1 = 15;
        int num2 = 35;

        //Resultado esperado / saída
        int resultadoEsperado = 50;

        //Executa
       int resultadoAtual =  Calculadora.somarDoisNumeros(num1 , num2);
        

        //Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }// fecha o teste da Soma


    [Test]
    public void testSubtrairDoisNumeros()
    {
        //Configura
        //Dados de Entrada
        int num1 = 20;
        int num2 = 8;
        int resultadoEsperado = 12;
        //Executa
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1 , num2);

        //Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));

    }
 
    [Test]
    public void testMultiplicarDoisNumeros()
    {
        //Configura
        //Dados de Entrada
        int num1 = 10;
        int num2 = 8;
        int resultadoEsperado = 80;
        //Executa
        int resultadoAtual = Calculadora.multiplicarDoisNumeros(num1 , num2);

        //Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));

    }

    [Test]
    public void testDividirDoisNumeros()
    {
        //Configura - Dados de Entrada
        int num1 = 10;
        int num2 = 2;
        int resultadoEsperado = 5;
        //Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1 , num2);
        //Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

     [Test]
    public void testDividirPorZero()
    {
        //Configura - Dados de Entrada
        int num1 = 10;
        int num2 = 0;
        int resultadoEsperado = 0; //O tratamento de erro retornara 0.
        //Executa
        int resultadoAtual = Calculadora.dividirDoisNumeros(num1 , num2);
        //Valida
        Assert.That(resultadoEsperado, Is.EqualTo(resultadoAtual));
    }

    //Configura - Dados de entrada
    [TestCase(5,8,13)]     

    public void testSomarDoisNumerosTC(int num1, int num2, int resultadoEsperado)
    {
        //Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);
        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }

     
     //Configura - Dados de entrada
    [TestCase(1,10,11)]
    [TestCase(0,8,8)]  
    [TestCase(5,-1,4)]
    [TestCase(3,3,6)]    

    public void testSomarDoisNumerosTC2(int num1, int num2, int resultadoEsperado)
    {
        //Executa  - Valida
        Assert.That(Calculadora.somarDoisNumeros(num1, num2), Is.EqualTo(resultadoEsperado));
    }

    //Teste Data Driven
    //Configura 
     [Test, TestCaseSource("lerDadosDeTeste", new object[] {"+"})]   

    public void testSomarDoisNumerosDD(int num1, int num2, int resultadoEsperado)
    {
        //Executa
        int resultadoAtual = Calculadora.somarDoisNumeros(num1, num2);
        //Valida
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }

[Test, TestCaseSource("lerDadosDeTeste", new object[] {"-"})]
public void testSubtrairDoisNumerosDD(int num1, int num2, int resultadoEsperado)
    {
        int resultadoAtual = Calculadora.subtrairDoisNumeros(num1, num2);
        Assert.That(resultadoAtual, Is.EqualTo(resultadoEsperado));
    }
    
    }