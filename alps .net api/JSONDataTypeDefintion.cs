using System.Collections.Generic;
using VDS.RDF;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an JSONDataTypeDefinition
    /// </summary>

    public class JSONDataTypeDefinition : CustomOrExternalDataTypeDefinition, IJSONDataTypeDefintion
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "JSONDataTypeDefintion";

        /// <summary>
        /// Constructor that creates a new empty instance of the JSON data type defintion class
        /// </summary>
        public JSONDataTypeDefinition()
        {
            setModelComponentID("JSONDataTypeDefintion");
            setComment("The standart Element for JSONDataTypeDefintion");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the JSON data type defintion class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataObjectDefiniton"></param>
        public JSONDataTypeDefinition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, DataObjectDefinition dataObjectDefiniton)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsDataObjectDefintion(dataObjectDefiniton);

        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the JSON data type defintion class
        /// </summary>
        /// <returns>A new empty instance of the JSON data type defintion class</returns>
        new public JSONDataTypeDefinition factoryMethod()
        {
            JSONDataTypeDefinition jSONDataTypeDefintion = new JSONDataTypeDefinition();

            return jSONDataTypeDefintion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);
            bool result = false;
            List<int> toBeRemoved = new List<int>();

            toBeRemoved.Sort();
            toBeRemoved.Reverse();

            foreach (int i in toBeRemoved)
            {
                attribute.RemoveAt(i);
                attributeType.RemoveAt(i);
            }

            setAdditionalAttribute(attribute);
            setAdditionalAttributeType(attributeType);

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
        /// Method that exports an JSON data type definition object to the file given in the filename
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
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
