using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the send type class
    /// </summary>
    public interface ISendState : IStandartPASSState
    {
        /// <summary>
        /// Method that sets the send function attribute of the instance
        /// </summary>
        /// <param name="sendFunction"></param>
        void setFunctionSpecification(ISendFunction sendFunction);

        /// <summary>
        /// Method that returns the send function attribute of the instance
        /// </summary>
        /// <returns>The send function attribute of the instance</returns>
        ISendFunction getSendFunction();

        /// <summary>
        /// Method that sets the send transition attribute of the instance
        /// </summary>
        /// <param name="sendTransition"></param>
        void setSendTransition(ISendTransition sendTransition);

        /// <summary>
        /// Method that returns the send transition attribute of the instance
        /// </summary>
        /// <returns>The send transition attribute of the instance</returns>
        ISendTransition getSendTransition();

        /// <summary>
        /// Method that sets the sending failed transition attribute of the instance
        /// </summary>
        /// <param name="sendingFailedTransition"></param>
        void setSendingFailedTransition(ISendingFailedTransition sendingFailedTransition);

        /// <summary>
        /// Method that sets the sending failed transition attribute of the instance
        /// </summary>
        /// <returns>The sending failed transition attribute of the instance</returns>
        Dictionary<string, ISendingFailedTransition> getSendingFailedTransition();
    }

}
