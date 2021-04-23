namespace alps.net_api
{
    /// <summary>
    /// Interface for the MessageSpecification class
    /// </summary>

    public interface IMessageSpecification : IInteractionDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="payloadDescription"></param>
        void setContainsPayloadDescription(IPayloadDescription payloadDescription);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IPayloadDescription getPayloadDescription();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new MessageSpecification factoryMethod();
    }

}
