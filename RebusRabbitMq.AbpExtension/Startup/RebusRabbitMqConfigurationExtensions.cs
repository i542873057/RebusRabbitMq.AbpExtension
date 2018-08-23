using Abp.Configuration.Startup;
using RebusRabbitMq.AbpExtension.Consumers;

namespace RebusRabbitMq.AbpExtension.Startup
{
    public static class RebusRabbitMqConfigurationExtensions
    {
        public static IRebusRabbitMqModuleConfig UseRebusRabbitMq(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.GetOrCreate("Modules.Abp.RebusRabbitMq", () => configurations.AbpConfiguration.IocManager.Resolve<IRebusRabbitMqModuleConfig>());
        }
    }
}
