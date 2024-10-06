namespace Logging
{
    public static class Logger
    {
        private static ILoggerFactory _loggerFactory;
        private static ILogger _logger;

        // Método para inicializar o logger
        public static void Initialize()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .BuildServiceProvider();

            _loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            _logger = _loggerFactory.CreateLogger("GlobalLogger");
        }

        // Métodos de log estáticos
        public static void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public static void LogError(string message)
        {
            _logger.LogError(message);
        }

        public static void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        // Você pode adicionar mais métodos conforme necessário
    }
}
