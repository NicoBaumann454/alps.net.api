using System.Collections.Generic;

namespace alps.net_api
{
    interface ILayeredPassProcessModel
    {
        /// <summary>
        /// Method that sets the message exchange attribute of the instance
        /// </summary>
        /// <param name="messageExchange"></param>
        void setRelationToModelComponent(IMessageExchange messageExchange);

        /// <summary>
        /// Method that returns the message exchange attribute of the instance
        /// </summary>
        /// <returns>The message exchange attribute of the instance</returns>
        List<IMessageExchange> getRelationToModelComponentMessageExchange();

        /// <summary>
        /// Method that sets the subject attribute of the instance
        /// </summary>
        /// <param name="subject"></param>
        void setRelationToModelComponent(ISubject subject);

        /// <summary>
        /// Method that returns the subject attribute of the instance
        /// </summary>
        /// <returns>The subject attribute of the instance</returns>
        List<ISubject> getRelationToModelComponentSubject();

        /// <summary>
        /// Method that sets the start subject attribute of the instance
        /// </summary>
        /// <param name="startSubject"></param>
        void setStartSubject(IStartSubject startSubject);

        /// <summary>
        /// Method that returns the start subject attribute of the instance
        /// </summary>
        /// <returns>The start subject attribute of the instance</returns>
        List<IStartSubject> getStartSubject();

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the pass process model class
        /// </summary>
        /// <returns>A new empty instance of the pass process model class</returns>
        LayeredPASSProcessModel factoryMethod();
    }
}
