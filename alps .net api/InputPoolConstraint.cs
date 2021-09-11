using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an InputPoolConstraint
    /// </summary>

    public class InputPoolConstraint : InteractionDescriptionComponent, IInputPoolConstraint
    {
        private IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy;
        private int limit = 0;
        private string tmpInputPoolConstraintHandlingStrategy;
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "InputPoolConstraint";

        /// <summary>
        /// Constructor that creates a new empty instance of the input pool constraint class
        /// </summary>
        public InputPoolConstraint()
        {
            setModelComponentID("InputPoolConstraint");
            setComment("The standart Element for InputPoolConstraint");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the input pool constraint class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        public InputPoolConstraint(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment, InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy, int limit)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
            setHandlingStrategy(inputPoolConstraintHandlingStrategy);
            setLimit(limit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        /// <param name="limit"></param>
        public InputPoolConstraint(string label, string comment = "", IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = null, int limit = 0, List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {
            if (inputPoolConstraintHandlingStrategy != null)
            {
                this.inputPoolConstraintHandlingStrategy = inputPoolConstraintHandlingStrategy;
            }

            this.limit = limit;
        }

        /// <summary>
        /// Method that sets the input pool constraint handling strategy attribute of the instance 
        /// </summary>
        /// <param name="inputPoolConstraintHandlingStrategy"></param>
        public void setHandlingStrategy(IInputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy)
        {
            this.inputPoolConstraintHandlingStrategy = inputPoolConstraintHandlingStrategy;
        }

        /// <summary>
        /// Method that sets the limit attribute of the instance
        /// </summary>
        /// <param name="nonNegativInteger"></param>
        public void setLimit(int nonNegativInteger)
        {
            this.limit = nonNegativInteger;
        }

        /// <summary>
        /// Method that returns the input pool constraint handling strategy attribute of the instance 
        /// </summary>
        /// <returns>The input pool constraint handling strategy attribute of the instance</returns>
        public IInputPoolConstraintHandlingStrategy getInputPoolConstraintHandlingStrategy()
        {
            return inputPoolConstraintHandlingStrategy;
        }

        /// <summary>
        /// Method that returns the limit attribute of the instance
        /// </summary>
        /// <returns>The limit attribute of the instance</returns>
        public int getLimit()
        {
            return limit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getTmpInputPoolConstraintHandlingStrategy()
        {
            return tmpInputPoolConstraintHandlingStrategy;
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the input pool constraint class
        /// </summary>
        /// <returns></returns>
        new public InputPoolConstraint factoryMethod()
        {
            InputPoolConstraint inputPoolConstraint = new InputPoolConstraint();

            return inputPoolConstraint;
        }

        /// <summary>
        /// Method that creates a new instance of the input pool constraint class
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
                    if (new InputPoolConstraintHandlingStrategy().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.inputPoolConstraintHandlingStrategy = (InputPoolConstraintHandlingStrategy)allElements[s];
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports a input pool contraint object to the file given in the filename
        /// </summary>
        /// <param name="last"></param>
        /// <param name="filename"></param>
        public override void exporting(bool last, string filename)
        {
            base.exporting(false, filename);

            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {

                if (inputPoolConstraintHandlingStrategy != null)
                {
                    sw.WriteLine("      <standard-pass-ont:hasHandlingStrategy" + " rdf:resource=\"" + inputPoolConstraintHandlingStrategy.getModelComponentID() + "\" ></standard-pass-ont:hasHandelingStrategy>");
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