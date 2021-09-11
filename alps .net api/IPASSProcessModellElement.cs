using System.Collections.Generic;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Interface to the PASS process modell element class
    /// </summary>
    public interface IPASSProcessModellElement : IOwlThing
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="additionalAttribute"></param>
        void setAdditionalAttribute(List<string> additionalAttribute); //some

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<string> getAdditionalAttribute();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<string> getAdditionalAttributeType();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelComponentID"></param>
        void setModelComponentID(string modelComponentID); //exactly one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getModelComponentID();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelComponentLabel"></param>
        void setModelComponentLabel(List<string> modelComponentLabel); //minimum one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<string> getModelComponentLabel();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        void setComment(string comment); //exactly one

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<string> getComment();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        PASSProcessModelElement factoryMethod();

    }
}
