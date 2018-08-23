using System;
using System.Reflection;
using Newtonsoft.Json;
using Rebus.Config;
using Rebus.Serialization;
using Rebus.Serialization.Json;

namespace RebusRabbitMq.AbpExtension.Consumers
{
    public class RebusRabbitMqModuleConfig : IRebusRabbitMqModuleConfig
    {
        public RebusRabbitMqModuleConfig()
        {
            Enabled = true;
            MessageAuditingEnabled = false;
            MaxParallelism = 1;
            NumberOfWorkers = 1;
            SerializerConfigurer = c => c.UseNewtonsoftJson(new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            LoggingConfigurer = c => c.Log4Net();//默认使用Log4Net记录日志
        }

        public Assembly[] AssemblysIncludeRebusMqMessageHandlers { get; private set; }

        public string ConnectString { get; private set; }

        public bool Enabled { get; private set; }

        public Action<RebusLoggingConfigurer> LoggingConfigurer { get; private set; }

        public int MaxParallelism { get; private set; }

        public bool MessageAuditingEnabled { get; private set; }

        public string MessageAuditingQueueName { get; private set; }

        public int NumberOfWorkers { get; private set; }

        public Action<OptionsConfigurer> OptionsConfigurer { get; private set; }

        public string QueueName { get; private set; }

        public Action<StandardConfigurer<ISerializer>> SerializerConfigurer { get; private set; }

        public IRebusRabbitMqModuleConfig ConnectTo(string connectString)
        {
            ConnectString = connectString;
            return this;
        }

        public IRebusRabbitMqModuleConfig Enable(bool enabled)
        {
            Enabled = enabled;
            return this;
        }

        public IRebusRabbitMqModuleConfig EnableMessageAuditing(string messageAuditingQueueName)
        {
            MessageAuditingEnabled = true;
            MessageAuditingQueueName = messageAuditingQueueName;
            return this;
        }

        public IRebusRabbitMqModuleConfig RegisterHandlerInAssemblys(params Assembly[] assemblys)
        {
            AssemblysIncludeRebusMqMessageHandlers = assemblys;
            return this;
        }

        public IRebusRabbitMqModuleConfig SetMaxParallelism(int maxParallelism)
        {
            MaxParallelism = maxParallelism;
            return this;
        }

        public IRebusRabbitMqModuleConfig SetNumberOfWorkers(int numberOfWorkers)
        {
            NumberOfWorkers = numberOfWorkers;
            return this;
        }

        public IRebusRabbitMqModuleConfig UseLogging(Action<RebusLoggingConfigurer> loggingConfigurer)
        {
            LoggingConfigurer = loggingConfigurer;
            return this;
        }

        public IRebusRabbitMqModuleConfig UseOptions(Action<OptionsConfigurer> optionsConfigurer)
        {
            OptionsConfigurer = optionsConfigurer;
            return this;
        }

        public IRebusRabbitMqModuleConfig UseQueue(string queueName)
        {
            QueueName = queueName;
            return this;
        }

        public IRebusRabbitMqModuleConfig UseSerializer(Action<StandardConfigurer<ISerializer>> serializerConfigurer)
        {
            SerializerConfigurer = serializerConfigurer;
            return this;
        }
    }
}
