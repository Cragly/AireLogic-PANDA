﻿namespace AireLogic.PANDA.API.Application.Contracts;

public interface ILoggerManager
{
    void LogDebug(string message);
    void LogInformation(string message);
    void LogWarning(string message);
    void LogError(string message);
}
