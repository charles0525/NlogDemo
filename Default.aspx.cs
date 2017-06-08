using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NLog;
using NLog.Targets;
using NLog.Config;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var logger = LogManager.GetLogger("NlogDemo");
        try
        {
            int i = 10, j = 0;
            var k = i / j;
        }
        catch (Exception ex)
        {
            NlogHelper.Error(ex);
        }

    }

    public class NlogHelper
    {
        static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Info(string msg)
        {
            _logger.Error(msg);
        }
        public static void Info<T>(T t)
        {
            _logger.Error<T>(t);
        }

        public static void Warn(string msg)
        {
            _logger.Warn(msg);
        }
        public static void Warn<T>(T t)
        {
            _logger.Warn(t);
        }

        public static void Error(string msg)
        {
            Error(msg, null);
        }
        public static void Error(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            Error(msg, ex);
        }
        public static void Error(string msg, Exception ex)
        {
            _logger.Error(ex, msg);
        }
        public static void Error<T>(T t)
        {
            _logger.Error<T>(t);
        }

        public static void Fatal(object obj)
        {
            _logger.Fatal(obj);
        }
        public static void Fatal(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            string msg = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            Fatal(msg, ex);
        }
        public static void Fatal(string msg, Exception ex)
        {
            _logger.Fatal(ex, msg);
        }
    }
}