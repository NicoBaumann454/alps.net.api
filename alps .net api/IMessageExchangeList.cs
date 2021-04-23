using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the message exchange list class
    /// </summary>

    public interface IMessageExchangeList : IInteractionDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchange"></param>
        void setContainsMessageExchange(IMessageExchange messageExchange);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, IMessageExchange> getMessageExchange();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageExchangeList factoryMethod();
    }
}
