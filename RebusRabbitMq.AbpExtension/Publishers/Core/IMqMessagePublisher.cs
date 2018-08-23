using System.Threading.Tasks;

namespace RebusRabbitMq.AbpExtension.Publishers.Core
{
    public interface IMqMessagePublisher
    {
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="mqMessages"></param>
        void Publish(object mqMessages);

        /// <summary>
        /// 发布异步
        /// </summary>
        /// <param name="mqMessages"></param>
        /// <returns></returns>
        Task PublishAsync(object mqMessages);
    }
}
