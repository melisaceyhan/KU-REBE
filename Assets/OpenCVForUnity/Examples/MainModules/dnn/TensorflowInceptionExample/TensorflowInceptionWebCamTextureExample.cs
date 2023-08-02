#if !(PLATFORM_LUMIN && !UNITY_EDITOR)

#if !UNITY_WSA_10_0

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using OpenCVForUnity.CoreModule;
using OpenCVForUnity.DnnModule;
using OpenCVForUnity.ImgprocModule;
using OpenCVForUnity.UnityUtils;
using OpenCVForUnity.UnityUtils.Helper;
using UnityEngine.Events;
using Random = System.Random;

namespace OpenCVForUnityExample
{
    /// <summary>
    /// TensorFlow WebCamTexture Example
    /// An example of using OpenCV dnn module with Tensorflow Inception model.
    /// Referring to https://github.com/opencv/opencv/blob/master/samples/dnn/tf_inception.cpp.
    /// </summary>
    [RequireComponent(typeof(WebCamTextureToMatHelper))]
    public class TensorflowInceptionWebCamTextureExample : MonoBehaviour
    {
        public Text ObjectText;
        public string Object1;
        public string Object2;
        public string Object3;
        public string Object4;
        public string Object5;
        public string Object6;
        public string Object7;

        string[] class1 = {"umbrella", "soccer ball", "ant", "laptop", "strawberry", "balloon", "shopping cart", "bookcase", "medicine chest", "chiffonier", "table lamp", "file", "folding chair", "toilet seat", "desk", "dining table", "wardrobe", "orange", "lemon", "fig", "pineapple", "banana", "corn", "custard apple", "pomegranate", "ear", "organ", "cornet", "flute", "rocking chair", "studio couch", "Granny Smith", "jackfruit", "hip", "rapeseed", "upright", "yellow lady's slipper", "letter opener", "power drill", "hammer", "can opener", "plunger", "screwdriver", "kite", "paintbrush", "loudspeaker", "microphone", "screen", "mouse", "strainer", "rule", "analog clock", "digital clock", "scale", "wall clock", "digital watch", "sunglasses", "computer keyboard", "lighter", "abacus", "desktop computer", "notebook", "web site", "remote control", "hair slide", "knot", "nail", "safety pin", "cucumber", "screw", "candle", "torch", "vacuum", "dishwasher", "refrigerator", "washer", "coffeepot", "teapot", "spatula", "bell pepper", "jean", "carton", "handkerchief", "sandal", "plate", "necklace", "modem", "tub", "mask", "pop bottle", "pajama", "running shoe", "chest", "tray", "balance beam", "bagel", "prayer rug", "kimono", "hot pot", "knee pad", "book jacket", "spindle", "ski mask", "crash helmet", "bottlecap", "suit", "meatloaf", "sunscreen", "lampshade", "wool", "water jug", "bucket", "dishrag", "soup bowl", "trench coat", "chain", "mixing bowl", "swab", "potpie", "cardigan", "sweatshirt", "binder", "pot", "hamper", "pencil box", "backpack", "pencil sharpener", "broom", "cup", "space bar", "poncho", "dough", "lipstick", "shower cap", "vase", "mitten", "brassiere", "milk can", "paper towel", "miniskirt", "perfume", "pillow", "toilet tissue", "lotion", "hairspray", "pill bottle", "washbasin", "ballpoint", "basketball", "cellular phone", "packet", "wallet", "comic book", "piggy bank", "television", "coffee mug", "volleyball", "fountain pen", "purse", "bib", "wooden spoon", "saltshaker", "chocolate sauce", "ballplayer", "water bottle", "soap dispenser", "plastic bag", "diaper", "band-aid", "ice lolly", "tennis ball", "doormat", "ice cream", "pitcher", "matchstick", "bikini", "sock"};
        string[] class2 = {"bicycle-built-for-two", "gasmask", "CD player", "lens cap", "vault", "cheeseburger", "parallel bars", "clog", "bubble", "flagpole", "eraser", "stole", "dumbbell", "loafer", "ipod", "bolete", "pretzel", "quilt", "maillot", "velvet", "school bus", "jigsaw puzzle", "ambulance", "cab", "jeep", "minivan", "garbage truck", "park bench", "barber chair", "daisy", "valley", "lakeside", "seashore", "plane", "shovel", "dogsled", "mountain bike", "freight car", "beer bottle", "passenger", "whiskey jug", "car", "barrow", "motor scooter", "moped", "fire engine", "tow truck", "trailer truck", "moving van", "police van", "street car", "tractor", "bassinet", "cradle", "crib", "china cabinet", "entertainment center", "chime", "drum", "gong", "steel drum", "banjo", "cello", "violin", "harp", "acoustic guitar", "electric guitar", "cliff", "lawn mover", "plow", "cock", "hen", "bulbul", "goldfish", "electric fan", "space heater", "stove", "barometer", "odometer", "hourglass", "stopwatch", "stethoscope", "syringe", "magnetic compass", "binoculars", "loupe", "typewriter keyboard", "cash machine", "printer", "joystick", "switch", "car wheel", "pinwheel", "carousel", "swing", "hard disk", "sunglass", "pick", "car mirror", "disk brake", "buckle", "combination lock", "padlock", "seat belt", "neckbrace", "iron", "microwave", "dutch oven", "toaster", "frying pan", "caldron", "safe", "cocktail shaker", "manhole cover", "teddy bear", "photocopier", "croquet ball", "fur coat", "thimble", "mashed potato", "head cabbage", "broccoli", "cauliflower", "zucchini", "spaghetti squash", "acorn squash", "butternut squash", "artichoke", "cardoon", "mushroom", "shower curtain", "ashcan", "golf ball", "crossword puzzle", "trifle", "red wine", "drumstick", "Christmas stocking", "hoopskirt", "menu", "stage", "bonnet", "baseball", "face powder", "beer glass", "guacamole", "hay", "bow tie", "mailbag", "eggnog", "paddle", "wine bottle", "birdhouse", "ping-pong ball", "pay-phone", "apron", "punching bag", "mosquito net", "abaya", "mortarboard", "traffic light", "radio", "monitor", "french loaf", "envelope", "bathtub", "hotdog", "cassette", "wig", "burrito", "barrel", "bath towel", "gown", "barbell", "mailbox", "street sign", "parachute", "sleeping bag", "swimming trunks", "measuring cup", "espresso", "pizza", "shopping basket", "goblet", "dial phone"};
        string[] class3 = {"electric locomotive", "steam locomotive", "pool table", "alp", "volcano", "dummy", "hare", "hamster", "revolver", "schooner", "accordion", "starfish", "grand piano", "airliner", "warplane", "fireboat", "canoe", "yawl", "container ship", "katamaran", "trimaran", "liner", "aircraft carrier", "pirate", "bobsled", "amphibian", "convertible", "Model T", "racer", "sports car", "go-cart", "golfcart", "snowplow", "pickup", "snowmobile", "recreational vehicle", "mobile home", "tricycle", "unicycle", "horse cart", "four-poster", "throne", "maraca", "marimba", "French horn", "oscilloscope", "trombone", "harmonica", "panpipe", "bassoon", "oboe", "sax", "ocarina", "promontory", "sandbar", "coral reef", "geyser", "hatchet", "cleaver", "corkscrew", "chain saw", "ostrich", "brambling", "goldfinch", "house finch", "junco", "indigo bunting", "robin", "jay", "magpie", "chickadee", "water ouzel", "hand blower", "oxygen mask", "snorkel", "oil filter", "sundial", "parking meter", "projector", "bow", "cannon[ground]", "rifle", "projectile", "crane", "slide rule", "hand-held computer", "harvester", "thresher", "slot", "vending machine", "sewing machine", "hook", "paddlewheel", "gas pump", "reel", "radiator", "puck", "solar dish", "muzzle", "ski", "tripod", "maypole", "mousetrap", "spider web", "espresso maker", "rotisserie", "waffle iron", "Crock Pot", "wok", "vestment", "megalith", "bannister", "breakwater", "dam", "tile roof", "Petri dish", "football helmet", "bathing cap", "holster", "chainlink fence", "picket fence", "worm fence", "stone wall", "grille", "sliding door", "turnstile", "mountain tent", "scoreboard", "honeycomb", "plate rack", "pedestal", "beacon", "barn", "greenhouse", "palace", "monastery", "library", "apiary", "boathouse", "church", "mosque", "stupa", "planetarium", "restaurant", "cinema", "home theater", "lumbermill", "coil", "obelisk", "totem pole", "castle", "prison", "grocery store", "bakery", "barbershop", "bookshop", "butcher shop", "confectionery", "shoe shop", "tobacco shop", "toyshop", "fountain", "cliff dwelling", "yurt", "dock", "feather boa", "cloak", "shield", "scabbard", "hen-of-the-woods", "mortar", "bulletproof vest", "consommé", "crutch", "cuirass", "military uniform", "cowboy hat", "trolley bus", "bullet train", "carpenter's kit", "ladle", "academic gown", "dome", "crate", "theater curtain", "window shade", "cowboy boot", "window screen", "lab coat", "fire screen", "minibus", "sombrero", "pickelhaube", "rain barrel", "cassette player", "bell cote", "Windsor tie", "overskirt", "sarong", "bolo tie", "breastplate", "stretcher", "jersey", "reflex camera", "tape player", "scuba diver", "thatch", "beaker", "carbonara"};
        string[] class4 = {"trilobite", "harvestman kit fox", "English setter", "Siberian husky", "Australian terrier", "English springer", "grey whale", "lesser panda", "Egyptian cat", "ibex", "Persian cat", "cougar", "gazelle", "porcupine", "sea lion", "malamute", "badger", "Great Dane", "Walker hound", "Welsh springer spaniel", "whippet", "Scottish deerhound", "killer whale", "mink", "African elephant", "Weimaraner", "soft-coated wheaten terrier", "Dandie Dinmont", "red wolf", "Old English sheepdog", "jaguar", "otterhound", "bloodhound", "Airedale", "hyena", "meerkat", "giant schnauzer", "titi", "three-toed sloth", "sorrel", "black-footed ferret", "dalmatian", "black-and-tan coonhound", "papillon", "skunk", "Staffordshire bullterrier", "Mexican hairless", "Bouvier des Flandres", "weasel", "miniature poodle", "Cardigan", "malinois", "bighorn", "fox squirrel", "colobus", "tiger cat", "Lhasa", "impala", "coyote", "Yorkshire terrier", "Newfoundland", "brown bear", "red fox", "Norwegian elkhound", "Rottweiler", "hartebeest", "Saluki", "grey fox", "schipperke", "Pekinese", "Brabancon griffon", "West Highland white terrier", "Sealyham terrier", "guenon", "mongoose", "indri", "tiger", "Irish wolfhound", "wild boar", "EntleBucher", "zebra", "ram", "French bulldog", "orangutan", "basenji", "leopard", "Bernese mountain dog", "Maltese dog", "Norfolk terrier", "toy terrier", "vizsla", "cairn", "squirrel monkey", "groenendael", "clumber", "Siamese cat", "chimpanzee", "komondor", "Afghan hound", "Japanese spaniel", "proboscis monkey", "guinea pig", "white wolf", "ice bear", "gorilla", "borzoi", "toy poodle", "Kerry blue terrier", "ox", "Scotch terrier", "Tibetan mastiff", "spider monkey", "Doberman", "Boston bull", "Greater Swiss Mountain dog", "Appenzeller", "Shih-Tzu", "Irish water spaniel", "Pomeranian", "Bedlington terrier", "warthog", "Arabian camel", "siamang", "miniature schnauzer", "collie", "golden retriever", "Irish terrier", "affenpinscher", "Border collie", "boxer", "silky terrier", "beagle", "Leonberg", "German short-haired pointer", "patas", "dhole", "baboon", "macaque", "Chesapeake Bay retriever", "bull mastiff", "kuvasz", "capuchin", "pug", "curly-coated retriever", "Norwich terrier", "flat-coated retriever", "hog", "keeshond", "Eskimo dog", "Brittany spaniel", "standard poodle", "Lakeland terrier", "snow leopard", "Gordon setter", "dingo", "standard schnauzer", "Tibetan terrier", "Arctic fox", "wire-haired fox terrier", "basset", "water buffalo", "American black bear", "Angora", "bison", "howler monkey", "hippopotamus", "chow", "giant panda", "American Staffordshire terrier", "Shetland sheepdog", "Great Pyrenees", "Chihuahua", "tabby", "marmoset", "Labrador retriever", "Saint Bernard", "armadillo", "Samoyed", "bluetick", "redbone", "polecat", "marmot", "kelpie", "gibbon", "llama", "miniature pinscher", "pole", "maze", "horizontal bar", "wood rabbit", "Italian greyhound", "lion", "cocker spaniel", "Irish setter", "dugong", "Indian elephant", "beaver", "Sussex spaniel", "Pembroke", "Blenheim spaniel", "Madagascar cat", "Rhodesian ridgeback", "lynx", "African hunting dog", "langur", "Ibizan hound", "timber wolf", "cheetah", "English foxhound", "briard", "sloth bear", "Border terrier", "German shepherd", "otter", "koala", "tusker", "echidna", "wallaby", "platypus", "wombat", "chambered nautilus", "space shuttle", "airship", "submarine", "wreck", "tank", "half track", "missile", "beach vagon", "jinrikisha", "oxcart", "bald eagle", "vulture", "great grey owl", "black grouse", "ptarmigan", "ruffed grouse", "prairie chicken", "peacock", "quail", "partridge", "African grey", "macaw", "sulphur-crested cockatoo", "lorikeet", "coucal", "bee eater", "hornbill", "hummingbird", "jacamar", "toucan", "drake", "red-breasted merganser", "goose", "black swan", "white stork", "black stork", "spoonbill", "flamingo", "American egret", "little blue heron", "bittern", "crane", "limpkin", "American coot", "bustard", "ruddy turnstone", "red-backed sandpiper", "redshank", "dowitcher", "oystercatcher", "European gallinule", "pelican", "king penguin", "albatross", "great white shark", "tiger shark", "hammerhead", "electric ray", "stingray", "barracouta", "coho", "tench", "eel", "rock beauty", "anemone fish", "lionfish", "puffer", "sturgeon", "gar", "loggerhead", "leatherback turtle", "guillotine", "radio telescope", "assault rifle", "potter's wheel", "jack-o'-lantern", "pier", "shoji", "drilling platform", "groom", "bearskin", "polaroid camera", "racket", "coral fungus", "earthstar", "stinkhorn", "chain mail", "gyromitre", "Water tower", "altar", "triumphal arch", "patio", "steel arch bridge", "suspension bridge", "viaduct", "mud turtle", "terrapin", "box turtle", "banded gecko", "common iguana", "American chameleon", "whiptail", "agama", "frilled lizard", "alligator lizard", "Gila monster", "green lizard", "African chameleon", "Komodo dragon", "triceratops", "African crocodile", "American alligator", "thunder snake", "ringneck snake", "hognose snake", "green snake", "king snake", "garter snake", "water snake", "vine snake", "night snake", "boa constrictor", "rock python", "Indian cobra", "green mamba", "sea snake", "horned viper", "diamondback", "sidewinder", "European fire salamander", "common newt", "eft", "spotted salamander", "axolotl", "bullfrog", "tree frog", "tailed frog", "whistle", "wing", "scorpion", "black and gold garden spider", "barn spider", "garden spider", "black widow", "tarantula", "wolf spider", "tick", "centipede", "isopod", "Dungeness crab", "rock crab", "fiddler crab", "king crab", "American lobster", "spiny lobster", "crayfish", "hermit crab", "tiger beetle", "ladybug", "ground beetle", "long-horned beetle", "leaf beetle", "dung beetle", "rhinoceros beetle", "weevil", "fly", "bee", "grasshopper", "cricket", "walking stick", "cockroach", "mantis", "cicada", "leafhopper", "lacewing", "dragonfly", "damselfly", "admiral", "ringlet", "monarch", "cabbage butterfly", "sulphur butterflyi lycaenid", "jellyfish", "sea anemone", "brain coral", "flatworm", "nematode", "conch", "snail", "slug", "sea slug", "chiton", "sea urchin", "sea cucumber"};

        public UnityEvent FirstOrder;
        public UnityEvent SecondOrder;
        public UnityEvent ThirdOrder;
        public UnityEvent FourthOrder;

        public GameObject objectFoundScreen;
        public Button FirstButton;
        public Button SecondButton;
        public Button ThirdButton;
        public Button FourthButton;
        public Button FifthButton;
        public Button SixthButton;
        public Button SeventhButton;

        public bool FirstObjectFound;
        public bool SecondObjectFound;
        public bool ThirdObjectFound;
        public bool FourthObjectFound;
        public bool FifthObjectFound;
        public bool SixthObjectFound;
        public bool SeventhObjectFound;


        [ContextMenu("RandomObjectSelection")]
        public void RandomObjectSelection()
        {
            Random random = new Random();

            var randomIndex1 = random.Next(0, class1.Length);
            Object1 = class1[randomIndex1];

            var randomIndex2 = random.Next(0, class1.Length);
            while (randomIndex2 == randomIndex1)
            {
               randomIndex2 = random.Next(0, class1.Length); 
            }
            Object2 = class1[randomIndex2];

            var randomIndex3 = random.Next(0, class1.Length);
            while (randomIndex3 == randomIndex1 || randomIndex3 == randomIndex2)
            {
               randomIndex3 = random.Next(0, class1.Length); 
            }
            Object3 = class1[randomIndex3];


            var randomIndex4 = random.Next(0, class2.Length);
            Object4 = class2[randomIndex4];

            var randomIndex5 = random.Next(0, class2.Length);
            while (randomIndex5 == randomIndex4)
            {
               randomIndex5 = random.Next(0, class2.Length); 
            }
            Object5 = class2[randomIndex5];

            var randomIndex6 = random.Next(0, class3.Length);
            Object6 = class3[randomIndex6];

            var randomIndex7 = random.Next(0, class4.Length);
            Object7 = class4[randomIndex7];
        }


        public NavigationScript navigationScript;
        public ObjectFoundScreenTextsScript objectFoundScreenTextsScript;
        public Rigidbody trail;


        public IEnumerator ScanAnimation()
        {
            trail.velocity = new Vector3(0, -2560, 0);
            yield return new WaitForSeconds(1);
            trail.velocity = new Vector3(0, 2560, 0);
            yield return new WaitForSeconds(1);
            trail.velocity = new Vector3(0, 0, 0);
            objectFoundScreen.SetActive(true);

        }


        /// <summary>
        /// The texture.
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The webcam texture to mat helper.
        /// </summary>
        WebCamTextureToMatHelper webCamTextureToMatHelper;

        /// <summary>
        /// The bgr mat.
        /// </summary>
        Mat bgrMat;

        /// <summary>
        /// The net.
        /// </summary>
        Net net;

        /// <summary>
        /// The classes.
        /// </summary>
        List<string> classes;

        /// <summary>
        /// The FPS monitor.
        /// </summary>
        FpsMonitor fpsMonitor;

        /// <summary>
        /// MODEL_FILENAME
        /// </summary>
        protected static readonly string MODEL_FILENAME = "dnn/tensorflow_inception_graph.pb";

        /// <summary>
        /// The model filepath.
        /// </summary>
        string model_filepath;

        /// <summary>
        /// CLASSES_FILENAME
        /// </summary>
        protected static readonly string CLASSES_FILENAME = "dnn/imagenet_comp_graph_label_strings.txt";

        /// <summary>
        /// The classes filepath.
        /// </summary>
        string classes_filepath;

#if UNITY_WEBGL
        IEnumerator getFilePath_Coroutine;
#endif

        // Use this for initialization
        void Start()
        {
            
            FirstButton.interactable = (PlayerPrefs.GetInt("FirstButtonNotInteractable") == 0);
            SecondButton.interactable = (PlayerPrefs.GetInt("SecondButtonNotInteractable") == 0);
            ThirdButton.interactable = (PlayerPrefs.GetInt("ThirdButtonNotInteractable")) == 0;
            FourthButton.interactable = (PlayerPrefs.GetInt("FourthButtonNotInteractable") == 0);
            FifthButton.interactable = (PlayerPrefs.GetInt("FifthButtonNotInteractable") == 0);
            SixthButton.interactable = (PlayerPrefs.GetInt("SixthButtonNotInteractable") == 0);
            SeventhButton.interactable = (PlayerPrefs.GetInt("SeventhButtonNotInteractable") == 0);

            fpsMonitor = GetComponent<FpsMonitor>();

            webCamTextureToMatHelper = gameObject.GetComponent<WebCamTextureToMatHelper>();

#if UNITY_WEBGL
            getFilePath_Coroutine = GetFilePath();
            StartCoroutine(getFilePath_Coroutine);
#else
            model_filepath = Utils.getFilePath(MODEL_FILENAME);
            classes_filepath = Utils.getFilePath(CLASSES_FILENAME);
            Run();
#endif
        }

#if UNITY_WEBGL
        private IEnumerator GetFilePath()
        {
            var getFilePathAsync_0_Coroutine = Utils.getFilePathAsync(MODEL_FILENAME, (result) =>
            {
                model_filepath = result;
            });
            yield return getFilePathAsync_0_Coroutine;

            var getFilePathAsync_1_Coroutine = Utils.getFilePathAsync(CLASSES_FILENAME, (result) =>
            {
                classes_filepath = result;
            });
            yield return getFilePathAsync_1_Coroutine;

            getFilePath_Coroutine = null;

            Run();
        }
#endif

        // Use this for initialization
        void Run()
        {
            //if true, The error log of the Native side OpenCV will be displayed on the Unity Editor Console.
            Utils.setDebugMode(true);


            classes = readClassNames(classes_filepath);
            if (classes == null)
            {
                Debug.LogError(CLASSES_FILENAME + " is not loaded. Please read “StreamingAssets/dnn/setup_dnn_module.pdf” to make the necessary setup.");
            }

            if (string.IsNullOrEmpty(model_filepath))
            {
                Debug.LogError(MODEL_FILENAME + " is not loaded. Please read “StreamingAssets/dnn/setup_dnn_module.pdf” to make the necessary setup.");
            }
            else
            {
                net = Dnn.readNetFromTensorflow(model_filepath);
            }

#if UNITY_ANDROID && !UNITY_EDITOR
            // Avoids the front camera low light issue that occurs in only some Android devices (e.g. Google Pixel, Pixel2).
            webCamTextureToMatHelper.avoidAndroidFrontCameraLowLightIssue = true;
#endif
            webCamTextureToMatHelper.Initialize();
        }

        /// <summary>
        /// Raises the webcam texture to mat helper initialized event.
        /// </summary>
        public void OnWebCamTextureToMatHelperInitialized()
        {
            Debug.Log("OnWebCamTextureToMatHelperInitialized");

            Mat webCamTextureMat = webCamTextureToMatHelper.GetMat();

            texture = new Texture2D(webCamTextureMat.cols(), webCamTextureMat.rows(), TextureFormat.RGBA32, false);
            Utils.matToTexture2D(webCamTextureMat, texture);

            gameObject.GetComponent<Renderer>().material.mainTexture = texture;

            gameObject.transform.localScale = new Vector3(webCamTextureMat.cols(), webCamTextureMat.rows(), 1);
            Debug.Log("Screen.width " + Screen.width + " Screen.height " + Screen.height + " Screen.orientation " + Screen.orientation);

            if (fpsMonitor != null)
            {
                fpsMonitor.Add("width", webCamTextureMat.width().ToString());
                fpsMonitor.Add("height", webCamTextureMat.height().ToString());
                fpsMonitor.Add("orientation", Screen.orientation.ToString());
            }


            float width = webCamTextureMat.width();
            float height = webCamTextureMat.height();

            float widthScale = (float)Screen.width / width;
            float heightScale = (float)Screen.height / height;
            if (widthScale < heightScale)
            {
                Camera.main.orthographicSize = (width * (float)Screen.height / (float)Screen.width) / 2;
            }
            else
            {
                Camera.main.orthographicSize = height / 2;
            }

            bgrMat = new Mat(webCamTextureMat.rows(), webCamTextureMat.cols(), CvType.CV_8UC3);
        }

        /// <summary>
        /// Raises the webcam texture to mat helper disposed event.
        /// </summary>
        public void OnWebCamTextureToMatHelperDisposed()
        {
            Debug.Log("OnWebCamTextureToMatHelperDisposed");

            if (bgrMat != null)
                bgrMat.Dispose();

            if (texture != null)
            {
                Texture2D.Destroy(texture);
                texture = null;
            }
        }

        /// <summary>
        /// Raises the webcam texture to mat helper error occurred event.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        public void OnWebCamTextureToMatHelperErrorOccurred(WebCamTextureToMatHelper.ErrorCode errorCode)
        {
            Debug.Log("OnWebCamTextureToMatHelperErrorOccurred " + errorCode);
        }

        // Update is called once per frame
        void Update()
        {
            if (webCamTextureToMatHelper.IsPlaying() && webCamTextureToMatHelper.DidUpdateThisFrame())
            {

                Mat rgbaMat = webCamTextureToMatHelper.GetMat();

                if (net == null || classes == null)
                {
                    Imgproc.putText(rgbaMat, "model file is not loaded.", new Point(5, rgbaMat.rows() - 30), Imgproc.FONT_HERSHEY_SIMPLEX, 0.7, new Scalar(255, 255, 255, 255), 2, Imgproc.LINE_AA, false);
                    Imgproc.putText(rgbaMat, "Please read console message.", new Point(5, rgbaMat.rows() - 10), Imgproc.FONT_HERSHEY_SIMPLEX, 0.7, new Scalar(255, 255, 255, 255), 2, Imgproc.LINE_AA, false);
                }
                else
                {

                    Imgproc.cvtColor(rgbaMat, bgrMat, Imgproc.COLOR_RGBA2BGR);

                    Mat blob = Dnn.blobFromImage(bgrMat, 1, new Size(224, 224), new Scalar(104, 117, 123), false, true);
                    net.setInput(blob);

                    Mat prob = net.forward();

                    Core.MinMaxLocResult minmax = Core.minMaxLoc(prob.reshape(1, 1));
                    //Debug.Log ("Best match " + (int)minmax.maxLoc.x);
                    //Debug.Log ("Best match class " + classes [(int)minmax.maxLoc.x]);
                    //Debug.Log ("Probability: " + minmax.maxVal * 100 + "%");

                    prob.Dispose();
                    blob.Dispose();


                    if (Object1 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject1 == true && FirstObjectFound != true)
                    {
                        if (FirstOrder != null)
                        {
                            FirstOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        FirstObjectFound = true;

                        FirstButton.interactable = false;
                        PlayerPrefs.SetInt("FirstButtonNotInteractable", 1);
                    }

                    if (Object2 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject2 == true && SecondObjectFound != true)
                    {
                        if (FirstOrder != null)
                        {
                            FirstOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        SecondObjectFound = true;

                        SecondButton.interactable = false;
                        PlayerPrefs.SetInt("SeocndButtonNotInteractable", 1);
                    }

                   if (Object3 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject3 == true && ThirdObjectFound != true)
                    {
                        if (FirstOrder != null)
                        {
                            FirstOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        ThirdObjectFound = true;

                        ThirdButton.interactable = false;
                        PlayerPrefs.SetInt("ThirdButtonNotInteractable", 1);
                    }

                    if (Object4 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject4 == true && FourthObjectFound != true)
                    {
                        if (SecondOrder != null)
                        {
                            SecondOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        FourthObjectFound = true;

                        FourthButton.interactable = false;
                        PlayerPrefs.SetInt("FourthButtonNotInteractable", 1);
                    }

                    if (Object5 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject5 == true && FifthObjectFound != true)
                    {
                        if (SecondOrder != null)
                        {
                            SecondOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        FifthObjectFound = true;

                        FifthButton.interactable = false;
                        PlayerPrefs.SetInt("FifthButtonNotInteractable", 1);
                    }

                    if (Object6 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject6 == true && SixthObjectFound != true)
                    {
                        if (ThirdOrder != null)
                        {
                            ThirdOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        SixthObjectFound = true;

                        SixthButton.interactable = false;
                        PlayerPrefs.SetInt("SixthButtonNotInteractable", 1);
                    }

                    if (Object7 == (classes[(int)minmax.maxLoc.x]) && navigationScript.CanSearchObject7 == true && SeventhObjectFound != true)
                    {
                        if (FourthOrder != null)
                        {
                            FourthOrder.Invoke();
                        }

                        StartCoroutine(ScanAnimation());
                        ObjectText.text = "You have found the:\n" + classes[(int)minmax.maxLoc.x];
                        objectFoundScreenTextsScript.PrintRecentScore();

                        SeventhObjectFound = true;

                        SeventhButton.interactable = false;
                        PlayerPrefs.SetInt("SeventhButtonNotInteractable", 1);
                    }

                    PlayerPrefs.Save();

                    //Imgproc.putText (rgbaMat, "Best match class " + classes [(int)minmax.maxLoc.x], new Point (5, rgbaMat.rows () - 10), Core.FONT_HERSHEY_SIMPLEX, 1.0, new Scalar (255, 255, 255, 255), 2, Imgproc.LINE_AA, false);
                    if (fpsMonitor != null)
                    {
                        fpsMonitor.consoleText = "Best match class " + classes[(int)minmax.maxLoc.x];

                    }
                }

                Utils.matToTexture2D(rgbaMat, texture);
            }
        }

        /// <summary>
        /// Raises the destroy event.
        /// </summary>


        [ContextMenu("ResetButtonStates")]
        public void ResetButtonStates()
        {
            PlayerPrefs.SetInt("FirstButtonNotInteractable", 0);
            PlayerPrefs.SetInt("SecondButtonNotInteractable", 0);
            PlayerPrefs.SetInt("ThirdButtonNotInteractable", 0);
            PlayerPrefs.SetInt("FourthButtonNotInteractable", 0);
            PlayerPrefs.SetInt("FifthButtonNotInteractable", 0);
            PlayerPrefs.SetInt("SixthButtonNotInteractable", 0);
            PlayerPrefs.SetInt("SeventhButtonNotInteractable", 0);
        }


        void OnDestroy()
        {
            webCamTextureToMatHelper.Dispose();

            if (net != null)
                net.Dispose();

            Utils.setDebugMode(false);

#if UNITY_WEBGL
            if (getFilePath_Coroutine != null)
            {
                StopCoroutine(getFilePath_Coroutine);
                ((IDisposable)getFilePath_Coroutine).Dispose();
            }
#endif
        }

        /// <summary>
        /// Raises the back button click event.
        /// </summary>
        public void OnBackButtonClick()
        {
            SceneManager.LoadScene("OpenCVForUnityExample");
        }

        /// <summary>
        /// Raises the play button click event.
        /// </summary>
        public void OnPlayButtonClick()
        {
            webCamTextureToMatHelper.Play();
        }

        /// <summary>
        /// Raises the pause button click event.
        /// </summary>
        public void OnPauseButtonClick()
        {
            webCamTextureToMatHelper.Pause();
        }

        /// <summary>
        /// Raises the stop button click event.
        /// </summary>
        public void OnStopButtonClick()
        {
            webCamTextureToMatHelper.Stop();
        }

        /// <summary>
        /// Raises the change camera button click event.
        /// </summary>
        public void OnChangeCameraButtonClick()
        {
            webCamTextureToMatHelper.requestedIsFrontFacing = !webCamTextureToMatHelper.requestedIsFrontFacing;
        }

        private List<string> readClassNames(string filename)
        {
            List<string> classNames = new List<string>();

            System.IO.StreamReader cReader = null;
            try
            {
                cReader = new System.IO.StreamReader(filename, System.Text.Encoding.Default);

                while (cReader.Peek() >= 0)
                {
                    string name = cReader.ReadLine();
                    classNames.Add(name);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError(ex.Message);
                return null;
            }
            finally
            {
                if (cReader != null)
                    cReader.Close();
            }

            return classNames;
        }
    }
}
#endif

#endif