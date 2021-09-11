using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a data mapping local to outgoing
    /// </summary>
    public class DataMappingLocalToOutgoing : DataMappingFunction, IDataMappingLocalToOutgoing
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DataMappingLocalToOutgoing";

        /// <summary>
        /// Constructor that creates a new empty instance of the data mapping local to outgoing class
        /// </summary>
        public DataMappingLocalToOutgoing()
        {
            setModelComponentID("DataMappingLocalToOutgoing");
            setComment("The standart Element for DataMappingLocalToOutgoing");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the data mapping local to outgoing class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataMappingString"></param>
        /// <param name="feelExpression"></param>
        /// <param name="toolSpecificDefinition"></param>
        public DataMappingLocalToOutgoing(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, string dataMappingString, string feelExpression, string toolSpecificDefinition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setDataMappingString(dataMappingString);

            if (feelExpression != null)
            {
                setFeelExpressionAsDataMapping(feelExpression);
            }
            else
            {
                setToolSpecificDefintion(toolSpecificDefinition);
            }
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the data mapping local to outgoing class
        /// </summary>
        /// <returns>A new empty instance of the data mapping local to outgoing class</returns>
        new public DataMappingLocalToOutgoing factoryMethod()
        {
            DataMappingLocalToOutgoing dataMappingLocalToOutgoing = new DataMappingLocalToOutgoing();

            return dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// Method that creates a new instance of the data mapping local to outgoing class
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
        /// Method that exports a data mapping local to outgoing object to the file given in the filename
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
