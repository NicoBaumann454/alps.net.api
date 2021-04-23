using System.Collections.Generic;

namespace alps.net_api
{
    interface IExtensionLayer
    {
        void setALPSModelElements(ExtensionBehavior aLPSModelElement);

        List<IExtensionBehavior> getALPSModelElements();

        bool createInstance(List<string> attribute, List<string> attributeType);


        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp);
    }
}
