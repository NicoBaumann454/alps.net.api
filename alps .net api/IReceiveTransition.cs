namespace alps.net_api
{
    /// <summary>
    /// interface of the receive transition class
    /// </summary>
    public interface IReceiveTransition : ICommunicationTransition
    {
        /// <summary>
        /// Method that sets the data mapping incoming to local attribute of the instance
        /// </summary>
        /// <param name="dataMappingIncomingToLocal"></param>
        void setDataMappingFunctionIncomingToLocal(IDataMappingIncomingToLocal dataMappingIncomingToLocal);

        /// <summary>
        /// Method that returns the data mapping incoming to local attribute of the instance
        /// </summary>
        /// <returns>The data mapping incoming to local attribute of the instance</returns>
        IDataMappingIncomingToLocal getDataMappingIncomingToLocal();

        /// <summary>
        /// Method that sets the priority number attribute of the instance
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        void setPriorityNumber(int nonNegativInteger);

        /// <summary>
        /// Method that returns the priority number attribute of the instance
        /// </summary>
        /// <returns>The priority number attribute of the instance</returns>
        int getPriorityNumber();

        /// <summary>
        /// Method that sets the receiver transition condition attribute of the instance
        /// </summary>
        /// <param name="receiveTransitionCondition"></param>
        void setReceiveTransitionCondition(IReceiveTransitionCondition receiveTransitionCondition);

        /// <summary>
        /// Method that returns the receive transition condition attribute of the instance
        /// </summary>
        /// <returns>The receive transition condition attribute of the instance</returns>
        IReceiveTransitionCondition getReceiveTransitionCondition();

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive transition class
        /// </summary>
        /// <returns>A new empty instance of the receive transition class</returns>
        new ReceiveTransition factoryMethod();
    }
}
