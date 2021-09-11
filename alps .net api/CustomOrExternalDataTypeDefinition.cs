using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a custom or external data type definition
    /// </summary>
    public class CustomOrExternalDataTypeDefinition : DataTypeDefinition, ICustomOrExternalDataTypeDefintion
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "CustomOrExternalDataTypeDefintion";

        /// <summary>
        /// Constructor that creates a empty instance of the custom or external data type definition class
        /// </summary>
        public CustomOrExternalDataTypeDefinition()
        {
            setModelComponentID("CustomOrExternalDataTypeDefintion");
            setComment("The standart Element for CustomOrExternalDataTypeDefintion");
        }

        /// <summary>
        /// Constructor that creates a fully specified instance of the custom or external data type definition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataObjectDefiniton"></param>
        public CustomOrExternalDataTypeDefinition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, DataObjectDefinition dataObjectDefiniton)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsDataObjectDefintion(dataObjectDefiniton);

        }

        /// <summary>
        /// Factory Method that creates and returns a new empty instance of the custom or external data type definition class
        /// </summary>
        /// <returns>A new empty instance of the custom or external data type definition class</returns>
        new public CustomOrExternalDataTypeDefinition factoryMethod()
        {
            CustomOrExternalDataTypeDefinition customOrExternalDataTypeDefintion = new CustomOrExternalDataTypeDefinition();

            return customOrExternalDataTypeDefintion;
        }

        /// <summary>
        /// Method that creates a new instance of the ccustom or external data type definition class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

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
        /// Method that exports a custom or external data type defintion object to the file given in the filename
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