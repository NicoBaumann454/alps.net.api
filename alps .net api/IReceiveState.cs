namespace alps.net_api
{
    /// <summary>
    /// Interface of the receive state class
    /// </summary>
    public interface IReceiveState : IStandartPASSState
    {
        /// <summary>
        /// Method that sets the receive function attribute of the instance
        /// </summary>
        /// <param name="receiveFunction"></param>
        void setFunctionSpecification(IReceiveFunction receiveFunction);

        /// <summary>
        /// Method that returns the receive function attribute of the instance
        /// </summary>
        /// <returns>The receive function attribute of the instance</returns>
        IReceiveFunction getReceiveFunctionSpecification();

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive state class
        /// </summary>
        /// <returns>A new empty instance of the receive state class</returns>
        new ReceiveState factoryMethod();
    }

}
