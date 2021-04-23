using System.Collections.Generic;
using System.IO;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Class that represents an InteractionDescriptionComponten 
    /// </summary>

    public class InteractionDescriptionComponent : PASSProcessModelElement, IInteractionDescriptionComponent
    {
        /// <summary>
        /// Name of the class
        /// </summary>
        new public const string className = "InteractionDescriptionComponent";

        /// <summary>
        /// Constructor that creates a new empty instance of the interaction description component class
        /// </summary>
        public InteractionDescriptionComponent()
        {
            setModelComponentID("InteractionDescriptionComponent");
            setComment("The standart Element for InteractionDescriptionComponent");
        }

        /// <summary>
        /// Constructor that creates a new fully specified instance of the interaction description component class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        public InteractionDescriptionComponent(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment)
        {
            setAdditionalAttribute(additionalAttribute);
            setModelComponentID(modelComponentID);
            setModelComponentLabel(modelComponentLabel);
            setComment(comment);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="comment"></param>
        /// <param name="additionalAttribute"></param>
        public InteractionDescriptionComponent(string label, string comment = "", List<string> additionalAttribute = null) : base(label, comment, additionalAttribute)
        {

        }

        /// <summary>
        /// Factory method that creates and returns a new empty instance of the interaction description component class
        /// </summary>
        /// <returns></returns>
        new public InteractionDescriptionComponent factoryMethod()
        {
            InteractionDescriptionComponent interactionDescriptionComponent = new InteractionDescriptionComponent();

            return interactionDescriptionComponent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public override bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = false;
            result = base.createInstance(attribute, attributeType);

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
