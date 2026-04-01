namespace DebuggerWatchesApp.Models.Configuration;
public class Configuration
{
    public required Logging Logging { get; set; }
    public required string AllowedHosts { get; set; }
    public required ConnectionStrings ConnectionStrings { get; set; }
}

public class Logging
{
    public required LogLevel LogLevel { get; set; }
}

public class LogLevel
{
    public required string Default { get; set; }
}

public class ConnectionStrings
{
    public required string MainConnection { get; set; }
}
