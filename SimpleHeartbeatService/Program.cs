using SimpleHeartbeatService.Service;
using System;
using Topshelf;

namespace SimpleHeartbeatService
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
            {
                x.Service<Heartbeat>(s =>
                {
                    s.ConstructUsing(hearbeat => new Heartbeat());
                    s.WhenStarted(hearbeat => hearbeat.Start());
                    s.WhenStopped(hearbeat => hearbeat.Stop());
                });

                x.RunAsLocalSystem();

                x.SetServiceName("HeartbeatService");
                x.SetDisplayName("Heartbeat Service");
                x.SetDescription("this is sample heartbeat service used in....");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
