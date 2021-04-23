using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using VDS.RDF;
using VDS.RDF.Parsing;
//using System.Windows.Forms;
//using Microsoft.VisualStudio.GraphModel;




namespace alps_.net_api
{

    public class OwlGraph
    {
        private int numberOfFiles = 0;
        private int numberOfSubjects = 0;
        private string filePath;
        private string filePathAbstractPass;
        private string filePathStandartPass;
        private List<Graph> files = new List<Graph>();
        private List<string> ID = new List<string>();
        private List<string> URI = new List<string>();
        private List<Triple> topLayer = new List<Triple>();
        private List<Triple> fullySpecifiedSubjects = new List<Triple>();
        private List<Triple>[] subjectBehaviors; //= new List<string>[2];
        private Graph standartPass;
        private Graph abstractPass;
        private Graph newGraph;

        public OwlGraph()
        {
            string path = Directory.GetCurrentDirectory();

            if (File.Exists(path + "\\logs\\" + "logfile.txt"))
            {
                File.Delete(path + "\\logs\\" + "logfile.txt");
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\logfile.txt")
                .CreateLogger();
            //, rollingInterval: RollingInterval.Day
        }

        public OwlGraph(string newPass, Boolean standartWanted)
        {
            string path = Directory.GetCurrentDirectory();
            if (Directory.Exists(path + "/" + "logfile" + RollingInterval.Day + ".txt"))
            {

            }
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\logfile.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            if (standartWanted)
            {
                readingStandartPass(newPass);
            }
            else
            {
                readingAbstractPass(newPass);
            }
        }

        public OwlGraph(string standartPass, string abstactPass)
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine(path);
            if (Directory.Exists(path + "/" + "logfile" + RollingInterval.Day + ".txt"))
            {

            }
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\Logfile.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            readingFiles(standartPass, abstactPass);
        }

        //Schreibender Zugriff wird eventl noch eingeschraenkt oder ganz entfernt
        public void setStandartPass(Graph standartPass)
        {
            this.standartPass = standartPass;
        }

        public Graph getStandartPass()
        {
            return standartPass;
        }

        //Schreibender Zugriff wird eventl noch eingeschraenkt oder ganz entfernt
        public void setAbstractPass(Graph abstractPass)
        {
            this.abstractPass = abstractPass;
        }

        public Graph getAbstractPass()
        {
            return abstractPass;
        }

        public List<Graph> getFiles()
        {
            return files;
        }

        public List<Triple> getTopLayer()
        {
            return topLayer;
        }

        //Liest die Daten aus der Standart Pass und aus der Abstract Pass Ont aus und schreibt sie jeweils in einen Graph
        public Boolean readingFiles(string filePathStandartPass, string filePathAbstractPass)
        {
            Boolean readingSuccesful = false;
            try
            {
                standartPass = new Graph();
                this.filePathStandartPass = filePathStandartPass;
                FileLoader.Load(standartPass, filePathStandartPass);
                files.Add(standartPass);
                numberOfFiles++;
                readingSuccesful = true;
                Log.Information("Done reading the Standart Pass Ont");

            }
            catch (RdfParseException parseException)
            {
                Log.Error("Parser Error in Standert Pass " + parseException);
            }

            try
            {
                abstractPass = new Graph();
                this.filePathAbstractPass = filePathAbstractPass;
                FileLoader.Load(abstractPass, filePathAbstractPass);
                files.Add(abstractPass);
                numberOfFiles++;
                readingSuccesful = true;
                Log.Information("Done reading the Abstract Pass Ont");
            }
            catch (RdfParseException parseException)
            {
                Log.Error("Parser Error in Abstract Pass " + parseException);
            }

            return readingSuccesful;

        }

        public Boolean readingFiles(List<string> filepath)
        {
            Boolean readingSuccesful = false;
            foreach (string i in filepath)
            {
                try
                {
                    newGraph = new Graph();
                    if ((i.ToLower().Contains("standard") && i.ToLower().Contains("pass")) || (i.ToLower().Contains("abstract") && i.ToLower().Contains("pass")))
                    {
                        this.ID.Add("standardPass");
                    }
                    else
                    {
                        this.ID.Add(i);
                    }
                    this.filePath = i;
                    FileLoader.Load(newGraph, filePath);
                    files.Add(newGraph);
                    numberOfFiles++;
                    readingSuccesful = true;
                    Log.Information("Done reading the new File");
                    readingSuccesful = true;
                }
                catch (RdfParseException parseException)
                {
                    Log.Error("Parser Error when reading the new File " + parseException);
                }
            }
            return readingSuccesful;
        }

        public Boolean readingStandartPass(string filePathStandartPass)
        {

            Boolean readingSuccesful = false;
            try
            {
                standartPass = new Graph();
                this.filePathStandartPass = filePathStandartPass;
                FileLoader.Load(standartPass, filePathStandartPass);
                files.Add(standartPass);
                numberOfFiles++;
                readingSuccesful = true;
                Log.Information("Done reading the Standart Pass Ont");

            }
            catch (RdfParseException parseException)
            {
                Log.Error("Parser Error in reading Standart Pass " + parseException);
            }

            return readingSuccesful;
        }

        public Boolean readingAbstractPass(string filePathAbstractPass)
        {

            Boolean readingSuccesful = false;
            try
            {
                abstractPass = new Graph();
                this.filePathAbstractPass = filePathAbstractPass;
                FileLoader.Load(abstractPass, filePathAbstractPass);
                files.Add(abstractPass);
                numberOfFiles++;
                readingSuccesful = true;
                Log.Information("Done reading the Abstract Pass Ont");

            }
            catch (RdfParseException parseException)
            {
                Log.Error("Parser Error in reading Abstract Pass " + parseException);
            }
            numberOfFiles++;
            return readingSuccesful;
        }

        public Boolean readingFile(string filePath)
        {

            Boolean readingSuccesful = false;
            try
            {
                newGraph = new Graph();
                this.filePath = filePath;
                FileLoader.Load(newGraph, filePath);
                files.Add(newGraph);
                numberOfFiles++;
                readingSuccesful = true;
                Log.Information("Done reading the new File");

            }
            catch (RdfParseException parseException)
            {
                Log.Error("Parser Error when reading the new File " + parseException);
            }
            return readingSuccesful;
        }

        //WIP, kann eventl. enfernt werden oder wird umgebaut zum durchsuchen des Baumes
        public List<Triple> findAllSubclasses(string className)
        {

            string classURI;
            List<Triple> subClasses = new List<Triple>();

            foreach (Graph j in files)
            {

                if (j == null)
                {
                    Log.Error("No such file found");
                    return subClasses;
                }
                else
                {
                    foreach (string i in URI)
                    {

                        classURI = i + "#" + className;
                        INode superClass = this.standartPass.GetUriNode(new Uri(classURI));
                        INode subClassOf = this.standartPass.CreateUriNode(new Uri(NamespaceMapper.RDFS + "subClassOf"));
                        int counter = 0;

                        try
                        {

                            foreach (Triple t in j.GetTriplesWithPredicateObject(subClassOf, superClass))
                            {
                                Log.Information("SUPER CLASS " + classURI + " TO SUBCLASSES");
                                Log.Information("Sub Class: " + t.Subject.ToString());
                                subClasses[counter] = t;
                                counter++;
                            }

                        }
                        catch
                        {

                        }

                    }

                }

            }

            return subClasses;

        }

        //WIP, wird eventl noch anders geregelt aktuell nur zum Testen gut
        public void creatingTree()
        {
            string URIstring;
            string[] splittedURI;
            int counter = 0;

            findAllURI();

            foreach (Graph j in files)
            {
                foreach (IUriNode i in j.Nodes.UriNodes())
                {
                    URIstring = i.ToString();
                    splittedURI = URIstring.Split('#');

                    if (splittedURI.Length > 1)
                    {
                        findAllSubclasses(splittedURI[1]);
                        counter++;
                    }

                }

                Console.WriteLine("Found all Subclasses" + counter);
            }

        }

        //WIP, Brauch ich diese wirklich noch ? scheint aktuell fast schon unnoetig zu sein, bleibt aber erstmal erhalten
        public void findAllURI()
        {
            string URIstring;
            string[] splittedURI;
            int counter = 0;

            foreach (Graph j in files)
            {

                foreach (IUriNode i in j.Nodes.UriNodes())
                {
                    URIstring = i.ToString();
                    splittedURI = URIstring.Split('#');
                    bool sameURI = false;

                    foreach (string k in URI)
                    {
                        if (k == splittedURI[0])
                        {
                            sameURI = true;
                            break;
                        }
                    }

                    if (!sameURI)
                    {
                        this.URI.Add(splittedURI[0]);
                        Log.Information(URI[counter]);
                        counter++;
                    }

                }

                counter = 0;

            }

        }

        public void findTopLayer()
        {
            int j = 0;

            //Hier muss ich erstmal noch herausfinden wie ich sicherstellen kann das nur das die oberste Stufe des Faller Prozesses gefunden wird
            //(eventl noch eine Liste mit der quasi ID ?)
            foreach (Graph i in files)
            {

                foreach (Triple t in i.Triples)
                {

                    if (!(ID[j].Contains("standardPass")))
                    {
                        //Ist das Standart das diese immer SID heißen muessen ? wenn ja klappt das genau so, sonst hab ich ein Problem (Unterscheidung sonst nur sehr schwer moeglich)
                        if (t.Subject.ToString().Contains("SID"))
                        {

                            Log.Information(t.Subject.ToString());
                            this.topLayer.Add(t);

                        }
                    }

                    //Console.WriteLine(t.Subject.ToString());
                }
                j++;
            }

            findAllFullySpecifiedSubjects();

        }

        //Findet alle Subjekte innerhalb des Modells und weist ihnen ihre BaseBehavior zu um das Modell sinnvoll aufzubauen
        public void findAllFullySpecifiedSubjects()
        {
            List<string> subjectNames = new List<string>();
            foreach (Triple t in topLayer)
            {
                if (t.Object.ToString().Contains("Subject"))
                {
                    //Findet die Namen der Subjekte in der TopLayer des Modells und zerschneidet sie um danach dann die Behavior anhand der Subjekte zu erkennen
                    string name = t.Object.ToString();
                    string[] subjectName = name.Split('#');
                    subjectNames.Add(subjectName[1]);

                    fullySpecifiedSubjects.Add(t);
                    numberOfSubjects++;
                }
            }

            subjectBehaviors = new List<Triple>[numberOfSubjects];
            int importantFile = 0;
            int tmp = 0;

            foreach (string i in ID)
            {
                if (!(ID[tmp].Contains("standardPass")))
                {
                    importantFile = tmp;
                }
                tmp++;
            }

            //In diesem Schritt werden nun die Namen der Base Behaviors der einzelnen Subjekte gefunden und zugeschnitten fuer die weitere Verarbeitung
            tmp = 0;
            List<Triple> baseBehavior;
            List<string> behaviorNames = new List<string>();

            foreach (string i in subjectNames)
            {
                foreach (Triple t in files[importantFile].Triples)
                {
                    if (t.Subject.ToString().Contains(i) && t.Predicate.ToString().ToLower().Contains("basebehavior"))
                    {
                        string name = t.Object.ToString();
                        string[] behaviorName = name.Split('#');
                        behaviorNames.Add(behaviorName[1]);
                    }

                }
                tmp++;
            }

            //Finden und speichern der einzelnen Behaviors innerhalb des Modells, hier in diesem Schritt kann dann schon fast mit dem Aufbau des Graphen begonnen werden
            tmp = 0;

            foreach (string i in behaviorNames)
            {
                baseBehavior = findAllComponentParts(i);
                subjectBehaviors[tmp] = baseBehavior;
                tmp++;
            }

        }

        //Diese Methode findet alle Teile z.B. eines Konnektors oder Subjekts und kann verwendet werden diese innerhalb des Modells die Objekte zu erzeuegen 
        //AKUTELLE FRAGEN: sollen die Objekte in das Modell gecodet werden (quasi das was in der Standart Pass und in der Abstract Pass steht ?)
        public List<Triple> findAllComponentParts(string name)
        {
            int j = 0;
            List<Triple> componentParts = new List<Triple>();

            foreach (Graph i in files)
            {
                //Console.WriteLine(ID[j]);
                foreach (Triple t in i.Triples)
                {
                    if (!(ID[j].Contains("standardPass")))
                    {
                        if (t.Subject.ToString().Contains(name))
                        {
                            //Hier bleiben fuers erste die Console.write Befehle diese werden danach dann fuer die erstellung der Objekte verwendet wuerde ich mal sagen
                            Console.WriteLine();
                            Console.WriteLine(t.Subject.ToString());
                            Console.WriteLine(t.Predicate.ToString());
                            Console.WriteLine(t.Object.ToString());
                            Console.WriteLine();
                            componentParts.Add(t);
                        }
                    }

                }
                j++;
            }

            return componentParts;
        }



        public void createTree()
        {
            //GraphLink graphLink = new GraphLink();

            OwlThing owlThing = new OwlThing();

            //GraphNode graphNode = new GraphNode(owlThing);

            PASSProcessModelElement pASSProcessModelElement = new PASSProcessModelElement();

            //TreeNode treeNode1 = new TreeNode(pASSProcessModelElement.getModelComponentID());

            //treeNode.setNextNode(treeNode1);


            BehaviorDescriptionComponent behaviorDescriptionComponent = new BehaviorDescriptionComponent();
            Action action = new Action();
            FunctionSpecification functionSpecification = new FunctionSpecification();
            CommunicationAct communicationAct = new CommunicationAct();
            ReceiveFunction receiveFunction = new ReceiveFunction();
            SendFunction sendFunction = new SendFunction();
            DoFunction doFunction = new DoFunction();
            ReceiveType receiveType = new ReceiveType();
            SendType sendType = new SendType();
            State state = new State();
            ChoiceSegment choiceSegment = new ChoiceSegment();
            ChoiceSegmentPath choiceSegmentPath = new ChoiceSegmentPath();
            MandatoryToEndChoiceSegment mandatoryToEndChoiceSegment = new MandatoryToEndChoiceSegment();
            MandatoryToStartChoiceSegment mandatoryToStartChoiceSegment = new MandatoryToStartChoiceSegment();
            OptionalToEndChoiceSegmentPath optionalToEndChoiceSegmentPath = new OptionalToEndChoiceSegmentPath();
            OptionalToStartChoiceSegmentPath optionalToStartChoiceSegmentPath = new OptionalToStartChoiceSegmentPath();
            EndState endState = new EndState();
            GenericReturnToOriginReference genericReturnToOriginReference = new GenericReturnToOriginReference();
            InitialStateOfBehavior initialStateOfBehavior = new InitialStateOfBehavior();
            InitialStateOfChoiceSegmentPath initialStateOfChoiceSegmentPath = new InitialStateOfChoiceSegmentPath();
            MacroState macroState = new MacroState();
            StandartPASSState standartPASSState = new StandartPASSState();
            DoState doState = new DoState();
            ReceiveState receiveState = new ReceiveState();
            SendState sendState = new SendState();
            StateReference stateReference = new StateReference();
            Transition transition = new Transition();
            CommunicationTransition communicationTransition = new CommunicationTransition();
            ReceiveTransition receiveTransition = new ReceiveTransition();
            SendTransition sendTransition = new SendTransition();
            DoTransition doTransition = new DoTransition();
            SendingFailedTransition sendingFailedTransition = new SendingFailedTransition();
            TimeTransition timeTransition = new TimeTransition();
            ReminderTransition reminderTransition = new ReminderTransition();
            CalenderBasedReminderTransition calenderBasedReminderTransition = new CalenderBasedReminderTransition();
            TimeBasedReminderTransition timeBasedReminderTransition = new TimeBasedReminderTransition();
            TimerTransition timerTransition = new TimerTransition();
            BuisnessDayTimerTransition buisnessDayTimerTransition = new BuisnessDayTimerTransition();
            DayTimeTimerTransition dayTimeTimerTransition = new DayTimeTimerTransition();
            YearMonthTimerTransition yearMonthTimerTransition = new YearMonthTimerTransition();
            UserCancelTransition userCancelTransition = new UserCancelTransition();
            TransitionCondition transitionCondition = new TransitionCondition();
            DoTransitionCondition doTransitionCondition = new DoTransitionCondition();
            MessageExchangeCondition messageExchangeCondition = new MessageExchangeCondition();
            ReceiveTransitionCondition receiveTransitionCondition = new ReceiveTransitionCondition();
            SendTransitionCondition sendTransitionCondition = new SendTransitionCondition();
            SendingFailedCondition sendingFailedCondition = new SendingFailedCondition();
            TimeTransitionCondition timeTransitionCondition = new TimeTransitionCondition();
            ReminderEventTransitionCondition reminderEventTransitionCondition = new ReminderEventTransitionCondition();
            CalenderBasedReminderTransitionCondition calenderBasedReminderTransitionCondition = new CalenderBasedReminderTransitionCondition();
            TimeBasedReminderTransitionCondition timeBasedReminderTransitionCondition = new TimeBasedReminderTransitionCondition();
            TimerTransitionCondition timerTransitionCondition = new TimerTransitionCondition();
            //BuisnessDayTimerTransitionCondition
            //DayTimeTimerTransitionCondition
            //YearMonthTimerTransitionConditions
            DataDescribingComponent dataDescribingComponent = new DataDescribingComponent();
            DataMappingFunction dataMappingFunction = new DataMappingFunction();
            DataMappingIncomingToLocal dataMappingIncomingToLocal = new DataMappingIncomingToLocal();
            DataMappingLocalToOutgoing dataMappingLocalToOutgoing = new DataMappingLocalToOutgoing();
            DataObjectDefiniton dataObjectDefiniton = new DataObjectDefiniton();
            DataObjectListDefiniton dataObjectListDefiniton = new DataObjectListDefiniton();
            PayloadDataObjectDefinition payloadDataObjectDefinition = new PayloadDataObjectDefinition();
            SubjectDataDefinition subjectDataDefinition = new SubjectDataDefinition();
            DataTypeDefintion dataTypeDefintion = new DataTypeDefintion();
            CustomOrExternalDataTypeDefintion customOrExternalDataTypeDefintion = new CustomOrExternalDataTypeDefintion();
            JSONDataTypeDefintion jSONDataTypeDefintion = new JSONDataTypeDefintion();
            OWLDataTypeDefintion oWLDataTypeDefintion = new OWLDataTypeDefintion();
            XSDDataTypeDefintion xSDDataTypeDefintion = new XSDDataTypeDefintion();
            ModelBuiltInDataTypes modelBuiltInDataTypes = new ModelBuiltInDataTypes();
            PayloadDescription payloadDescription = new PayloadDescription();
            PayloadDataObjectDefinition payloadDataObjectDefinition1 = new PayloadDataObjectDefinition();
            //PayloadPhysikalObjectDefinition
            InteractionDescriptionComponent interactionDescriptionComponent = new InteractionDescriptionComponent();
            InputPoolConstraint inputPoolConstraint = new InputPoolConstraint();
            MessageSenderTypeConstraint messageSenderTypeConstraint = new MessageSenderTypeConstraint();
            MessageTypeConstraint messageTypeConstraint = new MessageTypeConstraint();
            SenderTypeConstraint senderTypeConstraint = new SenderTypeConstraint();
            InputPoolConstraintHandlingStrategy inputPoolConstraintHandlingStrategy = new InputPoolConstraintHandlingStrategy();
            MessageExchange messageExchange = new MessageExchange();
            MessageExchangeList messageExchangeList = new MessageExchangeList();
            MessageSpecification messageSpecification = new MessageSpecification();
            Subject subject = new Subject();
            FullySpecifiedSubject fullySpecifiedSubject = new FullySpecifiedSubject();
            InterfaceSubject interfaceSubject = new InterfaceSubject();
            MultiSubject multiSubject = new MultiSubject();
            SingleSubject singleSubject = new SingleSubject();
            StartSubject startSubject = new StartSubject();
            PassProcessModell passProcessModell = new PassProcessModell();
            SubjectBehavior subjectBehavior = new SubjectBehavior();
            GuardBehavior guardBehavior = new GuardBehavior();
            MacroBehavior macroBehavior = new MacroBehavior();
            SubjectBaseBehavior subjectBaseBehavior = new SubjectBaseBehavior();

        }

    }









    /// <summary>
    /// Dies ist die Beschreibung der einfachen Element wobei diese an sich nicht unbedingt
    /// notwending ist, mal schauen ob diese in der Bibliothek verbleiben, vermutlich schon 
    /// </summary>

    public interface SimplePASSElement : IOwlThing
    {

    }

    //public interface CommunicationTransition : SimplePASSElement


    /// <summary>
    /// hier sollte die Beschreibung der AbstractPass kommen, mal schauen was ich davon
    /// brauche, vermutlich alles
    /// </summary>

    public interface abstracPass
    {

    }
}




//Stuff to remind me of something when I might need it again later
/*
 * 
 * Wird eventl gebaraucht um alle Subjekte innerhalb es 
 * <rdf:type rdf:resource="&standard-pass-ont;FullySpecifiedSubject" ></rdf:type>
 * 
 * 
 * 
//%%So funktioniert das splitten von Strings, total einfach%%%
//URIstring = "http://www.i2pm.net/standard-pass-ont#Test";
//string[] splittedURI;
//splittedURI = URIstring.Split('#');
//Console.WriteLine(splittedURI[0] + "     " + splittedURI[1]);


    if (standartPassWandted)
            {
                
            }
            else
            {
                if (abstractPass == null)
                {
                    Log.Error("No such file found");
                    return subClasses;
                }
                else
                {
                    classURI = "http://www.imi.kit.edu/abstract-pass-ont#" + className;
                    INode superClass = this.abstractPass.GetUriNode(new Uri(classURI));
INode subClassOf = this.abstractPass.CreateUriNode(new Uri(NamespaceMapper.RDFS + "subClassOf"));
int counter = 0;

                    /*foreach (Triple t in abstractPass.GetTriplesWithPredicateObject(subClassOf, superClass))
                    {
                        Console.WriteLine("Sub Class: " + t.Subject.ToString());
                        subClasses[counter] = t;
                        counter++;

                    }*/


//%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%