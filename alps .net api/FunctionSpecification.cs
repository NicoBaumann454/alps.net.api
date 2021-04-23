using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an FunctionSpecification
    /// </summary>

    public class FunctionSpecification : BehaviorDescriptionComponent, IFunctionSpecification
    {
        private string toolSpecificDefinition;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "FunctionSpecification";

        /// <summary>
        /// Constructor that creates a new empty instance of the function specification class
        /// </summary>
        public FunctionSpecification()
        {
            setModelComponentID("FunctionSpecification");
            setComment("The standart Element for FunctionSpecification");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the function specification class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefinition"></param>
        public FunctionSpecification(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefinition)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefinition(toolSpecificDefinition);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefinition"></param>
        /// <param name="additionalAttribute"></param>
        public FunctionSpecification(string label, string comment = "", string toolSpecificDefinition = "", List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            this.toolSpecificDefinition = toolSpecificDefinition;
        }

        /// <summary>
        /// Method that sets the tool specific defintion attribute
        /// </summary>
        /// <param name="toolSpecificDefinition"></param>
        public void setToolSpecificDefinition(string toolSpecificDefinition)
        {
            this.toolSpecificDefinition = toolSpecificDefinition;
        }

        /// <summary>
        /// Method that returns the tool specific defintion attribute
        /// </summary>
        /// <returns>The tool specific defintion attribute</returns>
        public string getToolSpecificDefinition()
        {
            return toolSpecificDefinition;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the function specification class
        /// </summary>
        /// <returns>A new empty instance of the function specification class</returns>
        new public FunctionSpecification factoryMethod()
        {
            FunctionSpecification functionSpecification = new FunctionSpecification();

            return functionSpecification;
        }

        /// <summary>
        /// Method that creates a new instance of the function specification class
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

            if (toolSpecificDefinition != "")
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasToolSpecificDefinition");
                objec = g.CreateUriNode("standard-pass-ont:" + toolSpecificDefinition);

                test = new Triple(subject, predicate, objec);
                g.Assert(test);

                //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
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

                if (toolSpecificDefinition != null)
                {
                    //sw.WriteLine("      <standard-pass-ont:hasToolSpecificDefintion" + " rdf:resource=\"" + toolSpecificDefinition + "\" ></standard-pass-ont:hasToolSpecificDefintion>");
                }

                Console.WriteLine("###############   Muss noch angepasst werden tool specific definition +++++++++++++++++++++");

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}

