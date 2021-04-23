namespace alps.net_api
{
    /// <summary>
    /// Interface to the message exchange class
    /// </summary>

    public interface IMessageExchange : IInteractionDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSpecification"></param>
        void setMessageType(IMessageSpecification messageSpecification);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMessageSpecification getMessageType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receiver"></param>
        void setReceiver(ISubject receiver);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubject getReceiver();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        void setSender(ISubject sender);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubject getSender();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageExchange factoryMethod();
    }

}
