using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a transition condition
    /// </summary>
    public class TransitionCondition : BehaviorDescriptionComponent, ITransitionCondition
    {
        private string toolSpecificDefintion = "";
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "TransitionCondition";

        /// <summary>
        /// Constructor that creates a new empty instance of the transition condition class
        /// </summary>
        public TransitionCondition()
        {
            setModelComponentID("TransitionCondition");
            setComment("The standart Element for TransitionCondition");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the transition condition class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="subjectBehavior"></param>
        /// <param name="toolSpecificDefintion"></param>
        public TransitionCondition(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, SubjectBehavior subjectBehavior, string toolSpecificDefintion)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setBelongsToSubjectBehavior(subjectBehavior);
            setToolSpecificDefiniton(toolSpecificDefintion);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="toolSpecificDefintion"></param>
        /// <param name="additionalAttribute"></param>
        public TransitionCondition(string label, string comment = "", string toolSpecificDefintion = "", List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            this.toolSpecificDefintion = toolSpecificDefintion;
        }

        /// <summary>
        /// Method that sets the tool specific definition attribute of the instance
        /// </summary>
        /// <param name="toolSpecificDefintion"></param>
        public void setToolSpecificDefiniton(string toolSpecificDefintion)
        {
            this.toolSpecificDefintion = toolSpecificDefintion;
        }

        /// <summary>
        /// Method that returns the tool specific definition attribute of the instance
        /// </summary>
        /// <returns>The tool specific definition attribute of the instance</returns>
        public string getToolSpecificDefintion()
        {
            return toolSpecificDefintion;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the transition condition class
        /// </summary>
        /// <returns>A new empty instance of the transition condition class</returns>
        new public TransitionCondition factoryMethod()
        {
            TransitionCondition transitionCondition = new TransitionCondition();

            return transitionCondition;
        }

        /// <summary>
        /// Method that creates a new instance of the transition condition class
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
            try
            {
                Uri name = new Uri(nameString);
                //Console.WriteLine(name);
                //Console.WriteLine();

                if (this.toolSpecificDefintion != "")
                {
                    subject = g.CreateUriNode(name);
                    predicate = g.CreateUriNode("rdf:hasToolSpecificDefinition");
                    objec = g.CreateUriNode("standard-pass-ont:" + toolSpecificDefintion);

                    test = new Triple(subject, predicate, objec);
                    g.Assert(test);

                    //Console.WriteLine(name + "  " + "http://www.w3.org/1999/02/22-rdf-syntax-ns#type" + "  " + "http://www.w3.org/2002/07/owl#NamedIndividual");
                }
            }
            catch { }
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

                if (toolSpecificDefintion != null)
                {
                    //sw.WriteLine("      <standard-pass-ont:containsBaseBehavior" + " rdf:resource=\"" + lowerBound + "\" ></standard-pass-ont:containsBaseBehavior>");
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