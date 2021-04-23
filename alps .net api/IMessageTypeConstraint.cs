namespace alps.net_api
{
    /// <summary>
    /// Interface to the message type constraint class
    /// </summary>
    public interface IMessageTypeConstraint : IInputPoolConstraint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSpecification"></param>
        void setReferncesMessageSpecification(IMessageSpecification messageSpecification);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IMessageSpecification getMessageSpecification();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageTypeConstraint factoryMethod();
    }

}
