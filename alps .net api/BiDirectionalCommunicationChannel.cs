using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    class BiDirectionalCommunicationChannel : AbstractCommunicationChannel, IBiDirectionalCommunicationChannel
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "BiDirectionalCommunicationChannel";

        /// <summary>
        /// Constructor that creates a new empty instance of the BiDirectionalCommunicationChannel class
        /// </summary>
        public BiDirectionalCommunicationChannel()
        {
            setModelComponentID("BiDirectionalCommunicationChannel");
            setComment("The standart Element for BiDirectionalCommunicationChannel");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the BiDirectionalCommunicationChannel class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        public BiDirectionalCommunicationChannel(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the interaction description component class
        /// </summary>
        /// <returns></returns>
        new public BiDirectionalCommunicationChannel factoryMethod()
        {
            BiDirectionalCommunicationChannel interactionDescriptionComponent = new BiDirectionalCommunicationChannel();

            return interactionDescriptionComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = false;
            result = base.createInstance(attribute, attributeType);

            return result;
        }

        /// <summary>
        /// Method that sets the Object Properties of the created Objects, it first takes the base Class to this and asks if the Object can take 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        /// 
        public override void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp)
        {
            base.completeObject(ref allElements, ref tmp);
        }

        /// <summary>
        /// Method that exports an buisness day timer transition to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
