using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a data object list definition
    /// </summary>
    public class DataObjectListDefiniton : DataObjectDefinition, IDataObjectListDefiniton
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DataObjectListDefiniton";

        /// <summary>
        /// Constructor that creates a new empty instance of the data object list definition class
        /// </summary>
        public DataObjectListDefiniton()
        {
            setModelComponentID("DataObjectListDefiniton");
            setComment("The standart Element for DataObjectListDefiniton");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the data object list definition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataTypeDefintion"></param>
        public DataObjectListDefiniton(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, DataTypeDefinition dataTypeDefintion)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setDataTypeDefinition(dataTypeDefintion);
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the data object definition list definition class
        /// </summary>
        /// <returns>A new empty instance of the data object definition list definition class</returns>
        new public DataObjectListDefiniton factoryMethod()
        {
            DataObjectListDefiniton dataObjectListDefiniton = new DataObjectListDefiniton();

            return dataObjectListDefiniton;
        }

        /// <summary>
        /// Method that creates a new instance of the data object list defintion class
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
        /// Method that exports a data object list definition object to the file given in the filename
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
