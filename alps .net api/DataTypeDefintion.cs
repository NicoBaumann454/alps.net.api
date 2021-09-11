using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a Data Type Definition
    /// </summary>
    public class DataTypeDefinition : DataDescribingComponent, IDataTypeDefintion
    {
        private IDataObjectDefiniton dataObjectDefiniton;
        private string tmpDataObjectDefinition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new private static string className = "DataTypeDefinition";

        /// <summary>
        /// Constructor that creates a new empty instance of the Data Type Definition class
        /// </summary>
        public DataTypeDefinition()
        {
            setModelComponentID("DataTypeDefinition");
            setComment("The standart Element for DataTypeDefinition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the Data Type Definition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataObjectDefiniton"></param>
        public DataTypeDefinition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, DataObjectDefinition dataObjectDefiniton)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setContainsDataObjectDefintion(dataObjectDefiniton);

        }

        /// <summary>
        /// Method that sets the Data Object Definiton attribute 
        /// </summary>
        /// <param name="dataObjectDefiniton"></param>
        public void setContainsDataObjectDefintion(IDataObjectDefiniton dataObjectDefiniton)
        {
            this.dataObjectDefiniton = dataObjectDefiniton;
        }

        /// <summary>
        /// Method that returns the Data Object Definiton attribute
        /// </summary>
        /// <returns>The Data Object Definiton attribute</returns>
        public IDataObjectDefiniton getDataObjectDefiniton()
        {
            return dataObjectDefiniton;
        }

        /// <summary>
        /// Method that returns the tmpDataObjectDefinition
        /// </summary>
        /// <returns></returns>
        public string getTmpDataObjectDefinition()
        {
            return tmpDataObjectDefinition;
        }

        /// <summary>
        /// Factory Method that creates and returns a new empty instance of the Data Type Definition class
        /// </summary>
        /// <returns>A new empty instance of the Data Type Definition class</returns>
        new public DataTypeDefinition factoryMethod()
        {
            DataTypeDefinition dataTypeDefintion = new DataTypeDefinition();

            return dataTypeDefintion;
        }

        /// <summary>
        /// Method that creates a new instance of the data type definition class
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

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new DataObjectDefinition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataObjectDefiniton = (DataObjectDefinition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports a data type definiton object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (dataObjectDefiniton != null)
                {
                    sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + dataObjectDefiniton.getModelComponentID() + "\" ></standard-pass-ont:contains>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}