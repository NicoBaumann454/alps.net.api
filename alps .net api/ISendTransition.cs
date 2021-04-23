namespace alps.net_api
{
    /// <summary>
    /// Interface to the send transition
    /// </summary>
    public interface ISendTransition : ICommunicationTransition
    {
        /// <summary>
        /// Method that sets the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <param name="dataMappingLocalToOutgoing"></param>
        void setDataMappingFunctionLocalToOutgoing(IDataMappingLocalToOutgoing dataMappingLocalToOutgoing);

        /// <summary>
        /// Method that returns the data mapping local to outgoing attribute of the instance
        /// </summary>
        /// <returns>The data mapping local to outgoing attribute of the instance</returns>
        IDataMappingLocalToOutgoing getDataMappingLocalToOutgoing();

        /// <summary>
        /// Method that sets the send transition condition attribute of the instance
        /// </summary>
        /// <param name="sendTransitionCondition"></param>
        void setSendTransitionCondition(ISendTransitionCondition sendTransitionCondition);

        /// <summary>
        /// Method that returns the send transition condition attribute of the instance
        /// </summary>
        /// <returns>The send transition condition attribute of the instance</returns>
        ISendTransitionCondition getSendTransitionCondition();
    }

}
