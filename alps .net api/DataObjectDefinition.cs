using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a data object definition
    /// </summary>
    public class DataObjectDefinition : DataDescribingComponent, IDataObjectDefiniton
    {
        private IDataTypeDefintion dataTypeDefintion;
        private string tmpDataTypeDefinition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DataObjectDefinition";

        /// <summary>
        /// Constructor that creates a new empty instance of the data object definition class
        /// </summary>
        public DataObjectDefinition()
        {
            setModelComponentID("DataObjectDefinition");
            setComment("The standart Element for DataObjectDefinition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the data object definition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataTypeDefintion"></param>
        public DataObjectDefinition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, DataTypeDefinition dataTypeDefintion)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setDataTypeDefinition(dataTypeDefintion);
        }

        /// <summary>
        /// Method that sets the data type definition attribute
        /// </summary>
        /// <param name="dataTypeDefintion"></param>
        public void setDataTypeDefinition(IDataTypeDefintion dataTypeDefintion)
        {
            this.dataTypeDefintion = dataTypeDefintion;
        }

        /// <summary>
        /// Method that returns the data type definition attribute
        /// </summary>
        /// <returns>The data type definition attribute</returns>
        public IDataTypeDefintion getDataTypeDefintion()
        {
            return dataTypeDefintion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpDataTypeDefinition()
        {
            return tmpDataTypeDefinition;
        }

        /// <summary>
        /// Method that creates a new instance of the data object definition class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

                if (s.Contains("hasDataTypeDefinition"))
                {
                    tmpDataTypeDefinition = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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
                    if (new DataTypeDefinition().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.dataTypeDefintion = (DataTypeDefinition)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                        //tmp.Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the data object definition class
        /// </summary>
        /// <returns></returns>
        new public DataObjectDefinition factoryMethod()
        {
            DataObjectDefinition dataObjectDefiniton = new DataObjectDefinition();
            return dataObjectDefiniton;
        }

        /// <summary>
        /// Method that exports a data object defintion object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (dataTypeDefintion != null)
                {
                    sw.WriteLine("      <standard-pass-ont:contains" + " rdf:resource=\"" + dataTypeDefintion.getModelComponentID() + "\" ></standard-pass-ont:contains>");
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