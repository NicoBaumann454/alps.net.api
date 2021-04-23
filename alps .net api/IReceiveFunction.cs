namespace alps.net_api
{
    /// <summary>
    /// Interface of the receive function class
    /// </summary>
    public interface IReceiveFunction : ICommunicationAct
    {
        /// <summary>
        /// Factory method that creates and returns a new empty instance of the receive function class
        /// </summary>
        /// <returns>A new empty instance of the receive function class</returns>
        new ReceiveFunction factoryMethod();
    }

}
