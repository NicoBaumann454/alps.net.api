namespace alps.net_api
{
    /// <summary>
    /// Interface to the message exchange condition class
    /// </summary>

    public interface IMessageExchangeCondition : ITransitionCondition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageExchange"></param>
        void setRequiresPerformedMessageExchange(IMessageExchange messageExchange);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMessageExchange getRequiresPerformedMessageExchange();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageExchangeCondition factoryMethod();
    }

}
