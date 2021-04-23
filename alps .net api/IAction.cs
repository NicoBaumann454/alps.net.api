using System.Collections.Generic;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the Action class
    /// </summary>

    public interface IAction : IBehaviorDescriptionComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        void setContainsState(IState state); //exactly one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IState getState();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="transition"></param>
        void setContainsTransition(ITransition transition); //some transition

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Dictionary<string, ITransition> getTransition();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        new Action factoryMethod();
    }

}
