namespace alps.net_api
{
    /// <summary>
    /// Interface to the receive transition condition class
    /// </summary>
    public interface IReceiveTransitionCondition : IMessageExchangeCondition
    {
        /// <summary>
        /// Method that sets the lower bound attribute of the instance
        /// </summary>
        /// <param name="lowerBound"></param>
        void setMultipleReceiveLowerBound(int lowerBound);

        /// <summary>
        /// Method that returns the lower bound attribute of the instance
        /// </summary>
        /// <returns>The lower bound attribute of the instance</returns>
        int getMultilpleLowerBound();

        /// <summary>
        /// Method that sets the upper bound attribute of the instance
        /// </summary>
        /// <param name="upperBound"></param>
        void setMultipleReceiveUpperBound(int upperBound);

        /// <summary>
        /// Method that returns the upper bound attribute of the instance
        /// </summary>
        /// <returns>The upper bound attribute of the instance</returns>
        int getMultipleUpperBound();

        /// <summary>
        /// Method that sets the receive type attribute of the instance
        /// </summary>
        /// <param name="receiveType"></param>
        void setReceiveType(IReceiveType receiveType);

        /// <summary>
        /// Method that returns the receive type attribute of the instance
        /// </summary>
        /// <returns>The receive type attribute of the instance</returns>
        IReceiveType getReceiveType();

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        void setRequiresMessageSentFrom(ISubject subject);

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        ISubject getMessageSentFrom();

        /// <summary>
        /// Method that sets the message specification attribute of the instance
        /// </summary>
        /// <param name="messageSpecification"></param>
        void setRequiresReceptionOfMessage(IMessageSpecification messageSpecification);

        /// <summary>
        /// Method that returns the message specification attribute of the instance
        /// </summary>
        /// <returns>The message specification attribute of the instance</returns>
        IMessageSpecification getReceptionOfMessage();
    }
}
