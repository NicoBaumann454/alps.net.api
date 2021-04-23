using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents a multi subject
    /// </summary>
    public class MultiSubject : Subject, IMultiSubject
    {
        private int instanceRestriction = 2;
        private string tmpInstanceRestriciton;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "MultiSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the mulit subject class
        /// </summary>
        public MultiSubject()
        {
            setModelComponentID("MultiSubject");
            setComment("The standart Element for MultiSubject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the mulit subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="instanceRestriction"></param>
        /// <param name="outgoingMessageExchange"></param>
        public MultiSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, int instanceRestriction, MessageExchange outgoingMessageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setMaximumSubjectInstanceRestriction(instanceRestriction);
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
        public MultiSubject(string label, string comment = "", IMessageExchange incomingMessageExchange = null, IMessageExchange outgoingMessageExchange = null, int maxSubjectInstanceRestriction = 2, List<string> additionalAttribute = null) : base(label, comment, incomingMessageExchange, outgoingMessageExchange, maxSubjectInstanceRestriction, additionalAttribute)
        {
            if (maxSubjectInstanceRestriction >= 2)
            {
                this.setMaximumSubjectInstanceRestriction(maxSubjectInstanceRestriction);
            }
            else
            {
                this.setMaximumSubjectInstanceRestriction(2);
            }

        }

        /// <summary>
        /// Method that sets the instance restriction attribute of the instance
        /// </summary>
        /// <param name="instanceRestriction"></param>
        public new void setMaximumSubjectInstanceRestriction(int instanceRestriction)
        {
            if (instanceRestriction >= 2)
            {
                this.instanceRestriction = instanceRestriction;
            }
            else
            {
                this.instanceRestriction = 2;
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
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpInstanceRestriciton()
        {
            return tmpInstanceRestriciton;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the multi subject class
        /// </summary>
        /// <returns>A new empty instance of the multi subject class</returns>
        new public MultiSubject factoryMethod()
        {
            MultiSubject multiSubject = new MultiSubject();

            return multiSubject;
        }

        /// <summary>
        /// 
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
                if (s.ToLower().Contains("hasInstanceRestriction"))
                {
                    tmpInstanceRestriciton = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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

            if (instanceRestriction >= 2)
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
                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&standard-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
