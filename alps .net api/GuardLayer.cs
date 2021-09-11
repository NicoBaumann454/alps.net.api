using System.Collections.Generic;
using System.IO;

namespace alps.net_api
{
    class GuardLayer : ModelLayer, IGuardLayer
    {
        private List<IGuardBehavior> aLPSModelElements = new List<IGuardBehavior>();
        private List<IModelLayer> modelLayers = new List<IModelLayer>();

        public GuardLayer()
        {
            setModelComponentID("GuardLayer");
            setComment("The standart Element for GuardLayer");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLPSModelElement"></param>
        public void setALPSModelElements(GuardBehavior aLPSModelElement)
        {
            this.aLPSModelElements.Add(aLPSModelElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IGuardBehavior> getALPSModelElements()
        {
            return this.aLPSModelElements;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aLPSModelElement"></param>
        public void setModelLayers(ModelLayer aLPSModelElement)
        {
            this.modelLayers.Add(aLPSModelElement);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IModelLayer> getModelLayers()
        {
            return this.modelLayers;
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
                    if (new GuardBehavior().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.aLPSModelElements.Add((GuardBehavior)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }

                    if (new ModelLayer().GetType().IsInstanceOfType(allElements[s]))
                    {
                        this.modelLayers.Add((ModelLayer)allElements[s]);
                        int place = getAdditionalAttribute().IndexOf(s);
                        getAdditionalAttributeType().RemoveAt(place);
                        getAdditionalAttribute().Remove(s);
                    }
                }
            }
        }

        /// <summary>
        /// Method that exports an guard layer object to the file given in the filename
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
