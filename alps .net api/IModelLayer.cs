using System.Collections.Generic;

namespace alps.net_api
{
    interface IModelLayer
    {
        bool createInstance(List<string> attribute, List<string> attributeType);


        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ref Dictionary<string, IPASSProcessModellElement> getElements();

    }
}
