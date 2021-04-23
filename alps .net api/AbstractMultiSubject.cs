using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an abstract multi subject class 
    /// </summary>
    class AbstractMultiSubject : AbstractSubject, IAbstractMultiSubject
    {
        private int instanceRestriction;
        private string tmpInstanceRestriciton;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "AbstractMultiSubject";

        /// <summary>
        /// Constructor that creates a new empty instance of the mulit subject class
        /// </summary>
        public AbstractMultiSubject()
        {
            setModelComponentID("AbstractMultiSubject");
            setComment("The standart Element for AbstractMultiSubject");
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
        public AbstractMultiSubject(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, MessageExchange incomingMessageExchange, int instanceRestriction, MessageExchange outgoingMessageExchange)
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
        /// Method that sets the instance restriction attribute of the instance
        /// </summary>
        /// <param name="instanceRestriction"></param>
        public new void setMaximumSubjectInstanceRestriction(int instanceRestriction)
        {
            if (instanceRestriction <= 2)
            {
                this.instanceRestriction = instanceRestriction;
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
        /// Method that returns the temporary instance restriction attribute
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
        new public AbstractMultiSubject factoryMethod()
        {
            AbstractMultiSubject multiSubject = new AbstractMultiSubject();

            return multiSubject;
        }

        /// <summary>
        /// Method that creates a new instance of the abstract multi subject class 
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
        /// Method that exports an abstract multi subject object to the file given in the filename 
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
                    sw.WriteLine("      <rdf:type rdf:resource=" + "\"&abstract-pass-ont;" + this.GetType().ToString().Split('.')[2] + "\" ></rdf:type>");
                    sw.WriteLine("  </owl:NamedIndividual>");
                }
            }
        }
    }
}
