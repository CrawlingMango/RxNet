using Microsoft.Extensions.Logging;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Sample.Rx.Buffer.Api.Services
{
    /*
     * will log after 5 seconds
     * if after five seconds and the buffer is not full, it will not log
     */
    public class AlertService
    {
        private readonly ILogger<AlertService> _logger;

        public static BehaviorSubject<string> _obsAlertMessage = new BehaviorSubject<string>("first-alert");

        public AlertService(ILogger<AlertService> logger)
        {
            _logger = logger;

            Observable.AsObservable(_obsAlertMessage)
                .Delay(new TimeSpan(0, 0, 5))
                .Buffer(5)
                .Subscribe(m => _logger.LogInformation(string.Join("|", m)));
        }

        public void Alert(string message)
        {
            _obsAlertMessage.OnNext(message);
        }
    }
}
