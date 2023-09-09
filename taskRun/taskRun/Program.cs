using System;
using System.Threading;
using Serilog;
using Serilog.Events;

class Program
{

    
    static void Main(string[] args)
    {
        // Configurar o logger para aparecer no console e escrever os logs em um arquivo txt
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("C:\\Users\\Kaua VAR\\OneDrive\\Documentos\\SOLUTIONS\\Task\\TaskRun\\taskRun\\taskRun\\TaskRelatorio\\Relatorio.txt", restrictedToMinimumLevel: LogEventLevel.Information)
            .CreateLogger();

        Log.Information($"*************INICIANDO APLICAÇÃO*************");

        // Coloquem aqui a hora que a função vai ser executada
        int horaExecucao = 13;
        int minutoExecucao = 0;

        // Calcula o tempo restante até a próxima execução
        TimeSpan tempoRestante = CalculaTempoRestanteParaExecucao(horaExecucao, minutoExecucao);

        // Cria um Timer que executa a função todos os dias no horário especificado
        Timer timer = new Timer(ExecutarFuncao, null, tempoRestante, TimeSpan.FromDays(7)); // Executar a cada 7 dias

        // Mantém o console aberto
        Console.ReadLine();
    }

    static TimeSpan CalculaTempoRestanteParaExecucao(int hora, int minuto)
    {
        DateTime agora = DateTime.Now;
        DateTime proximaExecucao = new DateTime(agora.Year, agora.Month, agora.Day, hora, minuto, 0);

        
        if (agora > proximaExecucao)
        {
            proximaExecucao = proximaExecucao.AddDays(7);
        }

        Log.Information("função será executada às " + proximaExecucao);
        return proximaExecucao - agora;
    }

    //Colocar aqui o metodo de aprovar matricula
    static void ExecutarFuncao(object? state)
    {
        try
        {
            Log.Information($"Função executada às {DateTime.Now}");
            Log.Information($" à proxima será executada às " + DateTime.Now.AddDays(7));
        }
        catch (Exception ex)
        {
            Log.Error($"Erro na função ExecutarFuncao: {ex.Message}");
        }
    }
}
