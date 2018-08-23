using System;
using System.Threading.Tasks;
using Rebus.Handlers;

namespace RebusRabbitMq.AbpExtension.Consumers.Handlers
{
    /// <summary>
    /// 消息处理抽象基类
    /// </summary>
    /// <typeparam name="TEventData">支持序列化的消息体</typeparam>
    public abstract class EventDataConsumerHandlerBase<TEventData> : IHandleMessages<TEventData>
    {
        public virtual Task Handle(TEventData message)
        {
            throw new NotImplementedException();
        }
    }
}
