using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a data mapping incoming to local
    /// </summary>
    public class DataMappingIncomingToLocal : DataMappingFunction, IDataMappingIncomingToLocal
    {
        /// <summary>
        /// Constructor that creates a new empty instance of the data mapping incoming to local class
        /// </summary>
        public DataMappingIncomingToLocal()
        {
            setModelComponentID("DataMappingIncomingToLocal");
            setComment("The standart Element for DataMappingIncomingToLocal");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the data mapping incoming to local class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataMappingString"></param>
        /// <param name="feelExpression"></param>
        /// <param name="toolSpecificDefinition"></param>
        public DataMappingIncomingToLocal(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, string dataMappingString, string feelExpression, string toolSpecificDefinition)
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
        /// Factory Method that creates and returns a new empty instance of the data mapping incoming to local class
        /// </summary>
        /// <returns>A new empty instance of the data mapping incoming to local class</returns>
        new public DataMappingIncomingToLocal factoryMethod()
        {
            DataMappingIncomingToLocal dataMappingLocalToOutgoing = new DataMappingIncomingToLocal();

            return dataMappingLocalToOutgoing;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = base.createInstance(attribute, attributeType);

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
        /// 
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
