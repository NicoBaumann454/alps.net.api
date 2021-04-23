namespace alps.net_api
{
    /// <summary>
    /// Interface to the MessageSenderTypeConstraint Class
    /// </summary>

    public interface IMessageSenderTypeConstraint : IInputPoolConstraint
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
        /// <param name="subject"></param>
        void setReferencesSubject(ISubject subject);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ISubject getReferenceSubject();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageSenderTypeConstraint factoryMethod();
    }

}
