using System;
using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Method that represents an abstract single subject 
    /// </summary>
    class AbstractSingleSubject : AbstractSubject, IAbstractSingleSubject
    {
        private static int instanceRestriction = 1;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "AbstractSingleSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the abstract single subject class
        /// </summary>
        public AbstractSingleSubject()
        {
            setModelComponentID("SingleSubject");
            setComment("The standart Element for SingleSubject");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the abstract single subject class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="incomingMessageExchange"></param>
        /// <param name="outgoingMessageExchange"></param>
        public AbstractSingleSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, MessageExchange outgoingMessageExchange)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setIncomingMessageExchange(incomingMessageExchange);
            setOutgoingMessageExchange(outgoingMessageExchange);
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
        new public AbstractSingleSubject factoryMethod()
        {
            AbstractSingleSubject singleSubject = new AbstractSingleSubject();

            return singleSubject;
        }

        /// <summary>
        /// Method that creates a new instance of the abstract single subject class
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            base.createInstance(attribute, attributeType);

            emptyAdditionalAttribute();

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
        /// Method that exports an abstract single subject to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                if (instanceRestriction > -1)
                {
                    Console.WriteLine("in Abstract Single Subject are still problems");
                    //sw.WriteLine("      <standard-pass-ont:hasInputPoolConstraint" + " rdf:resource=\"" + instanceRestriction + "\" ></standard-pass-ont:hasInputPoolConstraint>");
                }

                if (last)
                {
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
