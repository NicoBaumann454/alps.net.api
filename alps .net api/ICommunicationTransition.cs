namespace alps.net_api
{
    /// <summary>
    /// Interface to the communication transition class
    /// </summary>
    public interface ICommunicationTransition : ITransition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchangeCondition"></param>
        void setMessageExchangeCondition(IMessageExchangeCondition messageExchangeCondition);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMessageExchangeCondition getMessageExchangeCondition();
    }
}
