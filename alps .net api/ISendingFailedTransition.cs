namespace alps.net_api
{
    /// <summary>
    /// Interface to the sending failed transition 
    /// </summary>
    public interface ISendingFailedTransition : ITransition
    {
        /// <summary>
        /// Method that sets the send state attribute of the instance
        /// </summary>
        /// <param name="sendState"></param>
        void setSourceState(ISendState sendState);

        /// <summary>
        /// Method that returns the send state attribute of the instance
        /// </summary>
        /// <returns>The send state attribute of the instance</returns>
        ISendState getSourceSendState();

        /// <summary>
        /// Method that sets the sending failed condition attribute of the instance
        /// </summary>
        /// <param name="sendingFailedCondition"></param>
        void setTransitionCondition(ISendingFailedCondition sendingFailedCondition);

        /// <summary>
        /// Method that returns the sending failed condition attribute of the instance
        /// </summary>
        /// <returns>The sending failed condition attribute of the instance</returns>
        ISendingFailedCondition getSendingFailedCondition();

    }

}
