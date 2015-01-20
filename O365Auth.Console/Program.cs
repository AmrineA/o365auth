using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using O365Auth;
using System.Threading.Tasks;
using System.Net;
using Microsoft.SharePoint.Client;

namespace O365Auth.Console
{
    class Program
    {
        public static CookieContainer cc
        {
            get;
            set;
        }

        static void Main(string[] args)
        {
            try
            {
                string sharePointUrl = args[0];
                string username = args[1];
                string password = args[2];
                bool integratedAuth = bool.Parse(args[3]);

                // 
                var spa = new SharePointAuth(new Uri(sharePointUrl),
                   username,
                   password,
                   integratedAuth);

                // Attempt to sign the user into SharePoint Online using Integrated Windows Auth or username + password
                cc = spa.Authenticate();

                using (ClientContext ctx = new ClientContext(sharePointUrl))
                {
                    ctx.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(ctx_ExecutingWebRequest);

                    if (ctx != null)
                    {
                        ctx.Load(ctx.Web); // Query for Web
                        ctx.ExecuteQuery(); // Execute
                        System.Console.WriteLine(ctx.Web.Title);
                        System.Console.ReadKey();
                    }
                }

            }
            catch (Exception)
            {
            }

        }

        private static void ctx_ExecutingWebRequest(object sender, WebRequestEventArgs e)
        {
            e.WebRequestExecutor.WebRequest.CookieContainer = cc;
        }
    }
}
