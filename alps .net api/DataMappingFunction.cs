using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{

    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! Hier fehlt noch die Create Instance Methode !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1

    /// <summary>
    /// Class that represents a data mapping function
    /// </summary>
    public class DataMappingFunction : DataDescribingComponent, IDataMappingFunction
    {
        private string dataMappingString;
        private string feelExpression;
        private string toolSpecificDefinition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "DataMappingFunction";

        /// <summary>
        /// Constructor that creates a new empty instance of the data mapping function class
        /// </summary>
        public DataMappingFunction()
        {
            setModelComponentID("DataMappingFunction");
            setComment("The standart Element for DataMappingFunction");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the data mapping function class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="dataMappingString"></param>
        /// <param name="feelExpression"></param>
        /// <param name="toolSpecificDefinition"></param>
        public DataMappingFunction(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, string dataMappingString, string feelExpression, string toolSpecificDefinition)
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
        /// Method that sets the data mapping string attribute
        /// </summary>
        /// <param name="dataMappingString"></param>
        public void setDataMappingString(string dataMappingString)
        {
            this.dataMappingString = dataMappingString;
        }

        /// <summary>
        /// Method that sets the feel expression attribute
        /// </summary>
        /// <param name="feelExpression"></param>
        public void setFeelExpressionAsDataMapping(string feelExpression)
        {
            this.feelExpression = feelExpression;
        }

        /// <summary>
        /// Method that sets the tool specific definition attribute
        /// </summary>
        /// <param name="toolSpecificDefinition"></param>
        public void setToolSpecificDefintion(string toolSpecificDefinition)
        {
            this.toolSpecificDefinition = toolSpecificDefinition;
        }

        /// <summary>
        /// Method that returns the data mapping string attribute
        /// </summary>
        /// <returns>The data mapping string attribute</returns>
        public string getDataMappingString()
        {
            return dataMappingString;
        }

        /// <summary>
        /// Method that returns the feel expression attribute
        /// </summary>
        /// <returns>The feel expression attribute</returns>
        public string getFeelExpressionAsDataMapping()
        {
            return feelExpression;
        }

        /// <summary>
        /// Method that returns the tool specific definition attribute
        /// </summary>
        /// <returns>The tool specific definition attribute</returns>
        public string getToolSpecificDefinition()
        {
            return toolSpecificDefinition;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the data mapping function class
        /// </summary>
        /// <returns>A new empty instance of the data mapping function class</returns>
        new public DataMappingFunction factoryMethod()
        {
            DataMappingFunction dataMappingFunction = new DataMappingFunction();

            return dataMappingFunction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            Console.WriteLine("Data Mapping Function !!!!!!!!!!!!!!!!!!! create Instance muss noch korrekt implementiert werden");

            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            foreach (string s in attributeType)
            {

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        public override void export(ref Graph g)
        {
            base.export(ref g);
            //Graph g = new Graph();
            INode subject;
            INode predicate;
            INode objec;
            Triple test;

            string nameString = getModelComponentID();

            Uri name = new Uri(nameString);
            //Console.WriteLine(name);
            //Console.WriteLine();

            if (dataMappingString != "")
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:belongsToAction");
                objec = g.CreateUriNode("standard-pass-ont:" + dataMappingString);

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
            }

            if (feelExpression != "")
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasSourceState");
                objec = g.CreateUriNode("standard-pass-ont:" + feelExpression);

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);

            }

            if (toolSpecificDefinition != "")
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasTargetState");
                objec = g.CreateUriNode("standard-pass-ont:" + toolSpecificDefinition);

                test = new Triple(subject, predicate, objec);
                //Console.WriteLine(test.Subject.ToString() + " " + test.Predicate.ToString() + " " + test.Object.ToString());
                g.Assert(test);
            }

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
                Console.WriteLine(" **************** In DataMappingFunction fehlt noch eine menge ******************");

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
