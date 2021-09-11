using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VDS.RDF;

namespace alps.net_api
{
    /// <summary>
    /// Root class for the inheritans graphs. Represents a PASS process model element
    /// </summary>
    public class PASSProcessModelElement : OwlThing, IPASSProcessModellElement
    {
        private List<string> additionalAttribute = new List<string>();
        private List<string> additionalAttributeType = new List<string>();
        private string modelComponentID;
        private List<string> modelComponentLabel = new List<string>();
        private List<string> comment = new List<string>();
        private Dictionary<string, string> singleAttributes = new Dictionary<string, string>();
        private Dictionary<string, Dictionary<string, string>> multiAttributes = new Dictionary<string, Dictionary<string, string>>();
        Guid guid = new Guid();

        /// <summary>
        /// 
        /// </summary>
        public bool external = false; 

        /// <summary>
        /// Name of the class
        /// </summary>
        public static string className = "PASSProcessModelElement";

        /// <summary>
        /// Constructor that creates a empty instance of the PASS Process Model Element class
        /// </summary>
        public PASSProcessModelElement()
        {
            setModelComponentID("PASSProcessModelElement");
            setComment("The standart Element for PASSProcessModellElement");
        }

        /// <summary>
        /// Constructor that creates a fully specified instance of the PASS Process Model Element class
        /// </summary>
        /// <param name="additionalAttribute"></param>
        /// <param name="modelComponentID"></param>
        /// <param name="modelComponentLabel"></param>
        /// <param name="comment"></param>
        public PASSProcessModelElement(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment)
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
        public PASSProcessModelElement(string label, string comment = "", List<string> additionalAttribute = null)
        {
            guid = Guid.NewGuid();
            this.modelComponentID = label + guid.ToString() + "@EN";
            this.modelComponentLabel.Add(modelComponentID);
            if (comment != "")
            {
                this.comment.Add(comment + "@EN");
            }
            
            if (additionalAttribute != null)
            {
                this.additionalAttribute = additionalAttribute;
            }
        }

        /// <summary>
        /// Method that sets the additional attribute attribute
        /// </summary>
        /// <param name="additionalAttribute"></param>
        public void setAdditionalAttribute(List<string> additionalAttribute)
        {
            foreach (string s in additionalAttribute)
            {
                this.additionalAttribute.Add(s);
            }
        }

        /// <summary>
        /// Method that returns the additional attribute
        /// </summary>
        /// <returns>The additional attribute</returns>
        public List<string> getAdditionalAttribute()
        {
            return additionalAttribute;
        }

        /// <summary>
        /// Method that sets the model component ID attribute
        /// </summary>
        /// <param name="modelComponentID"></param>
        public void setModelComponentID(string modelComponentID)
        {
            this.modelComponentID = modelComponentID;
            this.comment.Clear();

        }

        /// <summary>
        /// Method that returns the model component ID attribute
        /// </summary>
        /// <returns>The model component ID attribute</returns>
        public string getModelComponentID()
        {
            return modelComponentID;
        }



        /// <summary>
        /// Method that sets the model component label attribute
        /// </summary>
        /// <param name="modelComponentLabel"></param>
        public void setModelComponentLabel(List<string> modelComponentLabel)
        {
            this.modelComponentLabel = modelComponentLabel;
        }

        /// <summary>
        /// 
        /// </summary>
        public void setModelComponentLabel(string modelComponentLabel)
        {
            this.modelComponentLabel.Add(modelComponentLabel);
        }

        /// <summary>
        /// Method that returns the model component label attribute
        /// </summary>
        /// <returns>The model component label attribute</returns>
        public List<string> getModelComponentLabel()
        {
            return modelComponentLabel;
        }

        /// <summary>
        /// Method that sets the comment attribute
        /// </summary>
        /// <param name="comment"></param>
        public void setComment(string comment)
        {
            this.comment.Add(comment);
        }

        /// <summary>
        /// Method that returns the comment attribute
        /// </summary>
        /// <returns>The comment attribute</returns>
        public List<string> getComment()
        {
            return comment;
        }

        /// <summary>
        /// Sets the additional attribute type list
        /// </summary>
        /// <param name="additionalAttributeType"></param>
        public void setAdditionalAttributeType(List<string> additionalAttributeType)
        {
            foreach (string s in additionalAttributeType)
            {
                this.additionalAttributeType.Add(s);
            }
        }

        /// <summary>
        /// Returns the additional attribute type List
        /// </summary>
        /// <returns>List(string)</returns>
        public List<string> getAdditionalAttributeType()
        {
            return additionalAttributeType;
        }

        /// <summary>
        /// Adds another entry to the key value pair of the Attributes. If a key already exists in the single attributes dictionary, both the 
        /// already existing attribute and the new attribute will be put in the multi attribute Dicionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void addAttribute(string key, string value)
        {
            if (multiAttributes.ContainsKey(key))
            {
                if (!multiAttributes[key].ContainsKey(value))
                {
                    multiAttributes[key].Add(value, value);
                }
            }
            else
            {
                if (singleAttributes.ContainsKey(key))
                {
                    Dictionary<string, string> tmp = new Dictionary<string, string>();
                    tmp.Add(singleAttributes[key], singleAttributes[key]);
                    if (!tmp.ContainsKey(value))
                    {
                        tmp.Add(value, value);
                    }
                    singleAttributes.Remove(key);
                    multiAttributes.Add(key, tmp);
                }
                else
                {
                    singleAttributes.Add(key, value);
                }
            }
        }

        /// <summary>
        /// Method that returns the single Attributes
        /// </summary>
        /// <returns>Dictionary(string, string)</returns>
        public Dictionary<string, string> getAttributes()
        {
            return singleAttributes;

        }

        /// <summary>
        /// Returns the single Attributes
        /// </summary>
        /// <returns>Dictionary(string, string)</returns>
        public Dictionary<string, string> getSingleAttribute()
        {
            return singleAttributes;
        }

        /// <summary>
        /// Method that returns the multi attributes
        /// </summary>
        /// <returns>Dictionary(string, Dictionary(string, string))</returns>
        public Dictionary<string, Dictionary<string, string>> getMultiAttributes()
        {
            return multiAttributes;
        }

        /// <summary>
        /// 
        /// </summary>
        public void emptyAdditionalAttribute()
        {
            //additionalAttribute.Clear();
            //additionalAttributeType.Clear();
        }

        /// <summary>
        /// Method that creates and returns a new empty instance of the PASS process model element class
        /// </summary>
        /// <returns>A new empty instance of the PASS process model element class</returns>
        public virtual PASSProcessModelElement factoryMethod()
        {
            PASSProcessModelElement pASSProcessModellElement = new PASSProcessModelElement();

            return pASSProcessModellElement;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual bool createInstance(List<string> additionalAttribute, string modelComponentID, List<string> modelComponentLabel, string comment)
        {
            bool result = false;

            this.modelComponentID = modelComponentID;
            this.modelComponentLabel = modelComponentLabel;
            this.comment.Add(comment);
            this.additionalAttribute = additionalAttribute;

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public virtual bool createInstance(List<string> attribute, List<string> attributeType)
        {
            bool result = false;
            int counter = 0;
            List<int> toBeRemoved = new List<int>();

            comment.Clear();

            foreach (string s in attributeType)
            {

                if (s.ToLower().Contains("comment"))
                {
                    comment.Add(attribute[counter]);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasModelComponentLabel"))
                {
                    modelComponentLabel.Add(attribute[counter]);
                    toBeRemoved.Add(counter);
                }

                if (s.Contains("hasModelComponentID"))
                {
                    modelComponentID = attribute[counter];
                    toBeRemoved.Add(counter);
                }

                if (s.ToLower().Contains("type"))
                {
                    toBeRemoved.Add(counter);
                }

                counter++;
            }

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
        /// 
        /// </summary>
        /// <param name="allElements"></param>
        /// <param name="tmp"></param>
        public virtual void completeObject(ref Dictionary<string, PASSProcessModelElement> allElements, ref List<string> tmp)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="last"></param>
        public virtual void exporting(bool last, string filename)
        {
            using (StreamWriter sw = File.AppendText("../../../../" + filename + ".owl"))
            {
                sw.WriteLine("  <owl:NamedIndividual rdf:about=" + "\"" + getModelComponentID() + "\" >");

                if (getModelComponentID().Split('#').Length > 1)
                {
                    sw.WriteLine("      <standard-pass-ont:hasModelComponentID rdf:datatype=" + "\"&xsd;string\" >" + getModelComponentID().Split('#')[1] + "</standard-pass-ont:hasModelComponentID>");
                }
                else
                {
                    Console.WriteLine("Hier stimmt etwas nicht: " + getModelComponentID() + "  ++++++++++++++++++++++++");
                    sw.WriteLine("      <standard-pass-ont:hasModelComponentID rdf:datatype=" + "\"&xsd;string\" >" + getModelComponentID() + "</standard-pass-ont:hasModelComponentID>");
                }

                int counter = 0;
                foreach (string s in getModelComponentLabel())
                {
                    if (getModelComponentLabel().Count == 1)
                    {
                        if (!s.Contains('&'))
                        {
                            Console.WriteLine("In dem label nochmal nachschauen");
                            //sw.WriteLine("      <standard-pass-ont:hasModelComponentLabel xml:lang=\"" + s.Split('@')[1] + "\" >" + s.Split('@')[0] + "</standard-pass-ont:hasModelComponentLabel>");
                        }
                    }
                    else
                    {
                        if (counter == 0)
                        {

                        }
                    }

                    counter++;
                }

                foreach (string s in getComment())
                {
                    Console.WriteLine("In dem Comment nochmal nachschauen");
                    //sw.WriteLine("      <rdfs:comment xml:lang=\"" + s.Split('@')[1] + "\" >" + s.Split('@')[0] + "</rdfs:comment>");
                }

                counter = 0;
                foreach (string s in getAdditionalAttribute())
                {
                    if (getAdditionalAttribute()[counter].Contains("integer") && getAdditionalAttributeType()[counter].Contains("standard-pass-ont"))
                    {
                        //sw.WriteLine("      <standard-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + " rdf:datatype=\"http://www.w3.org/2001/XMLSchema#integer\" >" + getAdditionalAttribute()[counter].Split('^')[0] + "</standard-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + ">");

                    }
                    else
                    {

                        if (getAdditionalAttribute()[counter].Contains("double") && getAdditionalAttributeType()[counter].Contains("abstract-pass-ont"))
                        {
                            sw.WriteLine("      <abstract-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + " rdf:datatype=\"&xsd;double\" >" + getAdditionalAttribute()[counter].Split('^')[0] + "</abstract-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + ">");

                        }
                        else
                        {
                            //if (getAdditionalAttributeType()[counter].Contains("standard-pass-ont"))
                            if (getAdditionalAttributeType()[counter].Contains("standard-pass-ont") && !getAdditionalAttributeType()[counter].Contains("Bound") && !getAdditionalAttributeType()[counter].Contains("Priority"))
                            {
                                sw.WriteLine("      <standard-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + " rdf:resource=\"" + getAdditionalAttribute()[counter].Split('^')[0] + "\" ></standard-pass-ont:" + getAdditionalAttributeType()[counter].Split('#')[1] + ">");
                            }
                            else
                            {
                                if (getAdditionalAttributeType()[counter].Contains("SimpleSimTransmission"))
                                {
                                    sw.WriteLine("      <abstract-pass-ont:hasSimpleSimTransmissionDurationMeanValue rdf:datatype=\"&xsd;dayTimeDuration\" >" + getAdditionalAttribute()[counter].Split('^')[0] + "</abstract-pass-ont:hasSimpleSimTransmissionDurationMeanValue>");
                                }
                            }
                        }
                    }
                    counter++;
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
