using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {

            var bootstrap = BootstrapFactory.CreateBootstrap();

            if (!bootstrap.Initialize())
            {
                Console.WriteLine("init the server!");
                Console.ReadKey();
                return;
            }
            var result = bootstrap.Start();
            Console.WriteLine("start the server!");
            Console.ReadKey();
            //var server = new myServer();
            //if (server.Setup(8888))
            //{ 
            //    Console.WriteLine("setup the server!");
            //    if (server.Start())
            //    {
            //        Console.WriteLine("start the server!");
            //        Console.ReadKey();
            //    }
            //}
            //else {
            //    Console.WriteLine("start the server error!");
            //    Console.ReadKey();
            //}


            // Console.WriteLine("Press any key to start the server!");

            //    Console.ReadKey();
            //    Console.WriteLine();

            //    var appServer = new AppServer();
            //    //Setup the appServer
            //    if (!appServer.Setup(8888)) //Setup ith listening port
            //    {
            //        Console.WriteLine("Failed to setup!");
            //        Console.ReadKey();
            //        return;
            //    }

            //    //Try to start the appServer
            //    if (!appServer.Start())
            //    {
            //        Console.WriteLine("Failed to start!");
            //        Console.ReadKey();
            //        return;
            //    }
            //    appServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(appServer_NewRequestReceived);
            //    //appServer.NewSessionConnected += new SessionHandler<AppSession>(appServer_NewSessionConnected);
            //   // myServer.NewRequestReceived += new RequestHandler<AppSession, StringRequestInfo>(appServer_NewRequestReceived);

            //    Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            //    while (Console.ReadKey().KeyChar != 'q')
            //    {
            //        Console.WriteLine();
            //        continue;
            //    }

            //    //Stop the appServer
            //    appServer.Stop();

            //    Console.WriteLine("The server was stopped!");
            //    Console.ReadKey();
            //}
            //    //*************************

            //static void appServer_NewSessionConnected(AppSession session)
            //{
            //    session.Send("Welcome to SuperSocket Telnet Server");
            //}
            //    static void appServer_NewRequestReceived(AppSession session, StringRequestInfo requestInfo)
            //    {
            //        switch (requestInfo.Key.ToUpper())
            //        {
            //            case ("ECHO"):
            //                session.Send(requestInfo.Body);
            //                break;

            //            case ("ADD"):
            //                session.Send(requestInfo.Parameters.Select(p => Convert.ToInt32(p)).Sum().ToString());
            //                break;

            //            case ("MULT"):

            //                var result = 1;

            //                foreach (var factor in requestInfo.Parameters.Select(p => Convert.ToInt32(p)))
            //                {
            //                    result *= factor;
            //                }

            //                session.Send(result.ToString());
            //                break;
            //        }
            //    }
        }
    }
}

