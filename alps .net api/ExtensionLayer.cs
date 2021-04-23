using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    class ExtensionLayer : ModelLayer, IExtensionLayer
    {
        private List<IExtensionBehavior> aLPSModelElements = new List<IExtensionBehavior>();

        public ExtensionLayer()
        {
            setModelComponentID("ExtensionLayer");
            setComment("The standart Element for ExtensionLayer");
        }

        public void setALPSModelElements(ExtensionBehavior aLPSModelElement)
        {
            this.aLPSModelElements.Add(aLPSModelElement);
        }

        public List<IExtensionBehavior> getALPSModelElements()
        {
            return this.aLPSModelElements;
        }

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

            foreach (string s in tmp)
            {

                if (allElements.ContainsKey(s))
                {
                    if (new ExtensionBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.aLPSModelElements.Add((ExtensionBehavior)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
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

                foreach (ISubjectBehavior s in aLPSModelElements)
                {
                    if (aLPSModelElements != null)
                    {
                        sw.WriteLine("      <standard-pass-ont:extends" + " rdf:resource=\"" + s.getModelComponentID() + "\" ></standard-pass-ont:extends>");
                    }
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
