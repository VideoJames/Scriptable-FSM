using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VideoJames.ScriptableFSM.Samples
{
    public enum LogLevel { Log, Warn, Error }
    public class LogMessage : IAction<ICharacter>
    {
        public string Name => $"Logging {message}";

        [SerializeField] private LogLevel logLevel;
        [SerializeField] private string message;

        public void Act(ICharacter stateHaver)
        {
            switch (logLevel)
            {
                case LogLevel.Log:
                    Debug.Log(message);
                    break;
                case LogLevel.Warn:
                    Debug.LogWarning(message);
                    break;
                case LogLevel.Error:
                    Debug.LogError(message);
                    break;
            }
        }

    }
}