namespace Syntax.Ofesauto.Security.Transversal.Common
{

    #region [ IAPPLOGGER ]
    /// <summary>
    /// Interface that implements and displays the messages
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAppLogger<T>
    {
        void LogInformation(string message, params object[] args);

        void LogWarning(string message, params object[] args);

        void LogError(string message, params object[] args);
    }
    #endregion
    
}
