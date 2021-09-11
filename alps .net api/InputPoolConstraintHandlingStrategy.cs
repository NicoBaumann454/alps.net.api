using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an InputConstraintHandlingStrategy
    /// </summary>

    public class InputPoolConstraintHandlingStrategy : InteractionDescriptionComponent, IInputPoolConstraintHandlingStrategy
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "InputPoolConstraintHandlingStrategy";

        /// <summary>
        /// Constructor that creates a new empty instance of the input pool constraint handling strategy class
        /// </summary>
        public InputPoolConstraintHandlingStrategy()
        {
            setModelComponentID("InputPoolConstraintHandlingStrategy");
            setComment("The standart Element for InputPoolConstraintHandlingStrategy");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the input pool constraint handling strategy class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        public InputPoolConstraintHandlingStrategy(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the input pool constraint handling strategy class
        /// </summary>
        /// <returns>A new empty instance of the input pool constraint handling strategy class</returns>
        new public InputPoolConstraintHandlingStrategy factoryMethod()
        {
            InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = new InputPoolConstraintHandlingStrategy();

            return inputPoolConstraintHandlingStrategy;
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
        /// Method that exports a input pool constraint handling strategy object to the file given in the filename
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
