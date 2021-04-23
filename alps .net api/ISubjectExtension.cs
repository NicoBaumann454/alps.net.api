namespace alps.net_api
{
    interface ISubjectExtension
    {
        /// <summary>
        /// Method that sets the incoming message exchange attribute of the instance
        /// </summary>
        /// <param name="incomingMessageExchange"></param>
        void setIncomingMessageExchange(IMessageExchange incomingMessageExchange);

        /// <summary>
        /// Method that returns the incoming message exchange attribute of the instance
        /// </summary>
        /// <returns>The incoming message exchange attribute of the instance</returns>
        IMessageExchange getIncomingMessageExchange();

        /// <summary>
        /// Method that sets the instance restriction attribute of the instance
        /// </summary>
        /// <param name="instanceRestriction"></param>
        void setMaximumSubjectInstanceRestriction(int instanceRestriction);

        /// <summary>
        /// Method that returns the instance restriction attribute of the instance
        /// </summary>
        /// <returns>The instance restriction attribute of the instance</returns>
        int getInstanceRestriction();

        /// <summary>
        /// Method that sets the outgoing message exchange attribute of the instance
        /// </summary>
        /// <param name="outgoingMessageExchange"></param>
        void setOutgoingMessageExchange(IMessageExchange outgoingMessageExchange);

        /// <summary>
        /// Method that returns the outgoing message exchange attribute of the instance
        /// </summary>
        /// <returns>The outgoing message exchange attribute of the instance</returns>
        IMessageExchange getOutgoingMessageExchange();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extensionBehavior"></param>
        void setExtensionBehavior(ExtensionBehavior extensionBehavior);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IExtensionBehavior getExtensionBehavior();
    }
}
