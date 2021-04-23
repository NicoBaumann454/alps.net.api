namespace alps.net_api
{
    /// <summary>
    /// Interface to the send transition condition class
    /// </summary>
    public interface ISendTransitionCondition : IMessageExchangeCondition
    {
        /// <summary>
        /// Method that sets the lower bound attribute of the instance
        /// </summary>
        /// <param name="lowerBound"></param>
        void setMultipleSendLowerBound(int lowerBound);

        /// <summary>
        /// Method that returns the lower bound attribute of the instance
        /// </summary>
        /// <returns>The lower bound attribute of the instance</returns>
        int getMultilpleLowerBound();

        /// <summary>
        /// Method that sets the upper bound attribute of the instance
        /// </summary>
        /// <param name="upperBound"></param>
        void setMultipleSendUpperBound(int upperBound);

        /// <summary>
        /// Method that returns the upper bound attribute of the instance
        /// </summary>
        /// <returns>The upper bound attribute of the instance</returns>
        int getMultipleUpperBound();

        /// <summary>
        /// Method that sets the send type attribute of the instance
        /// </summary>
        /// <param name="sendType"></param>
        void setSendType(ISendType sendType);

        /// <summary>
        /// Method that returns the send type attribute of the instance
        /// </summary>
        /// <returns>The send type attribute of the instance</returns>
        ISendType getSendType();

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        void setRequiresMessageSentTo(ISubject subject);

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        ISubject getMessageSentTo();

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        void setRequiresSendingOfMessage(IMessageSpecification messageSpecification);

        /// <summary>
        /// Method that returns the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        IMessageSpecification getSenderOfMessage();
    }

}
