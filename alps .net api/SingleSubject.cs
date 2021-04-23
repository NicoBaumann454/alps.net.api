using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a single subject
    /// </summary>
    public class SingleSubject : Subject, ISingleSubject
    {
        private static int instanceRestriction = 1;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "SingleSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the single subject class
        /// </summary>
        public SingleSubject()
        {
            setModelComponentID("SingleSubject");
            setComment("The standart Element for SingleSubject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the single subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        public SingleSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, MessageExchange outgoingMessageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setOutgoingMessageExchange(outgoingMessageExchange);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        /// <param name="maxSubjectInstanceRestriction"></param>
        /// <param name="additionalAttribute"></param>
        public SingleSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 1, List<string> additionalAttribute = null) : base(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute)
        {
            if (maxSubjectInstanceRestriction == 1)
            {
                this.setMaximumSubjectInstanceRestriction(maxSubjectInstanceRestriction);
            }
            else
            {
                this.setMaximumSubjectInstanceRestriction(1);
            }

        }

        /// <summary>
        /// Method that returns the instance restriction attribute of the instance
        /// </summary>
        /// <returns>The instance restriction attribute of the instance</returns>
        public int getMaximumInstanceRestriction()
        {
            return instanceRestriction;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the single subject class
        /// </summary>
        /// <returns>A new empty instance of the single subject class</returns>
        new public SingleSubject factoryMethod()
        {
            SingleSubject singleSubject = new SingleSubject();

            return singleSubject;
        }

        /// <summary>
        /// Method that creates a new instance of the single subject class
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

            if (instanceRestriction >= 0)
            {
                subject = g.CreateUriNode(name);
                predicate = g.CreateUriNode("rdf:hasInstanceRestriction");
                objec = g.CreateUriNode("standard-pass-ont:" + instanceRestriction);

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

                sw.WriteLine("      <standard-pass-ont:hasMaximumSubjectInstanceRestriction rdf:datatype=\"http://www.w3.org/2001/XMLSchema#positiveInteger\" >" + instanceRestriction + "</standard-pass-ont:hasMaximumSubjectInstanceRestriction>");

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}