using System.Data;

namespace Syntax.Ofesauto.Security.Transversal.Common
{

    #region [ INTERFACE CONNECTION DATABASE ]
    /// <summary>
    /// Method to interact with different database engines
    /// </summary>
    /// 
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
    #endregion

}
