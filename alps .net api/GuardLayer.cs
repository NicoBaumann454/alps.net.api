using System.Collections.Generic;

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

        public void setALPSModelElements(GuardBehavior aLPSModelElement)
        {
            this.aLPSModelElements.Add(aLPSModelElement);
        }

        public List<IGuardBehavior> getALPSModelElements()
        {
            return this.aLPSModelElements;
        }

        public void setModelLayers(ModelLayer aLPSModelElement)
        {
            this.modelLayers.Add(aLPSModelElement);
        }

        public List<IModelLayer> getModelLayers()
        {
            return this.modelLayers;
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
    }
}
