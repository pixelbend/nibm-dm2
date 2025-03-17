using MaterialSkin.Controls;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanFood.Utils
{
    public static class ErrorHandler
    {
        public static string GetOracleErrorMessage(OracleException ex)
        {
            if (ex.Number == 20001)
            {
                string message = ex.Message;
                int indexOfColon = message.IndexOf(": ");
                if (indexOfColon > 0)
                {
                    message = message.Substring(indexOfColon + 2);
                }

                int indexOfNextCode = message.IndexOf("ORA-");
                if (indexOfNextCode > 0)
                {
                    message = message.Substring(0, indexOfNextCode).Trim();
                }

                return message;
            }

            return ex.Message;
        }

    }
}
