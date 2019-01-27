using ConsoleApp1.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    public class Program
    {
        #region extension

        private static void StringExtensionTest()
        {
            var S = "sadadad";
            Console.WriteLine(S.Length());
            Console.WriteLine(S.Length(2));
        }

        #endregion extension
        #region OOP

        public abstract class classAB
        {
            public abstract void xxx();

            public void abc()
            {
            }

        }

        public class A
        {
            public virtual void Hehe()
            {
                Console.WriteLine("A nef");
            }
        }

        public class B : A
        {
            public override void Hehe()
            {
                Console.WriteLine("B nef");
            }
        }

        public class C : A
        {

        }

        public static void testVoid(A a)
        {
            Console.WriteLine(a);
            a.Hehe();
        }

        #endregion

        #region XMLSerialize

        [Serializable]
        public class ItemEntry
        {
            public string Name;
            public string Data;
            public int Amount;

            //parameterless constructor for XmlSerializer
            public ItemEntry()
            {
            }

            public ItemEntry(string iName, string idata, int iAmount)
            {
                Name = iName;
                Data = idata;
                Amount = iAmount;
            }
        }

        [Serializable]
        public class ItemDatabase
        {
            public List<ItemEntry> list = new List<ItemEntry>();

            public ItemDatabase()
            {
            }
        }

        public static void SaveItems(ItemDatabase itemDb)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ItemDatabase));
            FileStream stream = new FileStream("D:\\CraftedComp.xml", FileMode.Create);
            serializer.Serialize(stream, itemDb);
            stream.Close();
        }

        private static ItemDatabase CreatItemDataBase()
        {
            var item = new ItemDatabase();

            for (var i = 0; i < 10; i++)
            {
                item.list.Add(new ItemEntry("name" + i, "data" + i, i));
            }

            return item;
        }

        private static void testXML()
        {
            string mathMLResult = @"<math xmlns='bla'>
                            <SnippetCode>
                              testcode1
                            </SnippetCode>
                        </math>";

            XDocument xml = XDocument.Parse(mathMLResult);
            XElement mathNode = xml.Descendants().FirstOrDefault(x => x.Name.LocalName == "math");
            IEnumerable<XElement> mathNode1 = xml.Descendants("bla" + "math");

            // error occurres in this line
            List<XNode> childNodes = mathNode.Nodes().ToList();

            XElement mrow = new XElement("mrow");
            mrow.Add(childNodes);
            mathNode.RemoveNodes();
            XElement mstyle = new XElement("mstyle");
            XElement semantics = new XElement("semantics");
            XElement annotation = new XElement("annotation",
                new XAttribute("encoding", @"\&quot;application/x-tex\&quot;"));
            semantics.Add(mrow);
            semantics.Add(annotation);
            mstyle.Add(semantics);
            mathNode.Add(mstyle);
            var s = mathNode.ToString();

            Console.WriteLine(s);
        }

        #endregion

        #region properties testing

        public class ApplicationUser
        {


        }

        public class Article
        {


            public ApplicationUser CreatedBy { get; set; }
        }

        #endregion

        #region csvreading

        public class Patient
        {
            public string PatientID;
            public string DateOfBirth;
            public string DateFirstSeen;
            public string DateOfDiagnosis;
            public string TreatmentStartDate;
            public string TreatmentEndDate;
            public string CancerType;
            public string TreatmentType;
        }

        public static List<Patient> LoadPatients(string filePath)
        {
            var list = new List<Patient>();
            string[] LinesInFile = File.ReadAllLines("D:\\Book.csv");

            foreach (string line in LinesInFile)
            {
                if (line != "")
                {

                    string[] columns = line.Split(',');

                    list.Add(new Patient
                    {
                        PatientID = columns[0],
                        DateOfBirth = columns[1],
                        DateFirstSeen = columns[2],
                        DateOfDiagnosis = columns[3],
                        TreatmentStartDate = columns[4],
                        TreatmentEndDate = columns[5],
                        CancerType = columns[6],
                        TreatmentType = columns[7]
                    });
                }
            }

            return list;
        }

        public static Patient GetPatient(List<Patient> patients, string patientId)
        {
            return patients.FirstOrDefault(pt => pt.PatientID.Equals(patientId));
        }

        public static void PrintPatient(List<Patient> patients, string patientId)
        {
            GetPatient(patients, patientId);



        }

        static int hamming_distance(int x, int y)
        {
            int dist = 0;
            int val = x ^ y;

            // Count the number of bits set
            while (val != 0)
            {
                // A bit is set, so increment the count and clear the bit
                dist++;
                val &= val - 1;
            }

            // Return the number of differing bits
            return dist;
        }

        #endregion

        private static string lines = @"<div>&nbsp;</div><div>&nbsp;</div><p>&nbsp;</p><br />this is the input to keep<div>&nbsp;</div><br /><div>&nbsp;</div><p>&nbsp;</p><div>&nbsp;</div>";
        public static string RemoveStartAndEndBreaks(string input)
        {
            var lineBreaks = new[] { "<br>", "<br/>", "<br />", "<p></p>", "<p> </p>", "<p>&nbsp;</p>", "<div></div>", "<div> </div>", "<div>&nbsp;</div>" };
            
            var isMatched = true;



            while (isMatched)
            {
                foreach (var lb in lineBreaks)
                {
                    if (input.StartsWith(lb))
                    {
                        input = input.Substring(lb.Length);
                        isMatched = true;
                        break;
                    }

                    if (input.EndsWith(lb))
                    {
                        input = input.Substring(0, input.Length - lb.Length);
                        isMatched = true;
                        break;
                    }

                    isMatched = false;
                }
            }
            //edit something.
            return input;
        }

        public class Setting
        {
            public string Name;
            public bool IsSelected;
        }

        private static void ReadAndWriteFile()
        {
            var path = @"D:\TextFile.txt";

            //Read all text lines first
            string[] readText = File.ReadAllLines(path);

            //Open the text file to write
            var oStream = new FileStream(path, FileMode.Truncate, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new System.IO.StreamWriter(oStream);


            bool inRewriteBlock = false;

            foreach (var s in readText)
            {
                if (s.Trim() == "#Start")
                {
                    inRewriteBlock = true;
                    sw.WriteLine(s);
                }
                else if (s.Trim() == "#End")
                {
                    inRewriteBlock = false;
                    sw.WriteLine(s);
                }
                else if (inRewriteBlock)
                {
                    //REWRITE DATA HERE (IN THIS CASE IS DELETE LINE THEN DO NOTHING)
                }
                else
                {
                    sw.WriteLine(s);
                }
            }

            sw.Close();
        }

        #region RSA encrypt
        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion
        public const string LoginAdNotFound =
            "Login AD {0} with user {1} success but the user infomation not found on the current directory";
        public static void Main(string[] args)
        {
            var s = "XXX";
            var F = string.Format(LoginAdNotFound, s, s);

            StringExtensionTest();
            //var text = new SortedDictionary<char, int>();
            //var inputText = Console.ReadLine();

            //foreach (var character in inputText)
            //{
            //    if (character == ' ')
            //    {
            //        continue;
            //    }

            //    if (text.ContainsKey(character))
            //    {
            //        text[character]++;
            //    }
            //    else
            //    {
            //        text.Add(character, 1);
            //    }
            //}


            //foreach (var character in text.OrderByDescending(x => x.Value))
            //{
            //    Console.WriteLine($"{character.Key} -> {character.Value}");
            //}


            #region list
            ////A: [9-> 9-> 1]
            ////B: [1]
            //var Ln = new Solution.ListNode(9);
            //Ln.next = new Solution.ListNode(7);
            //Ln.next.next = new Solution.ListNode(8);
            //Ln.next.next.next = new Solution.ListNode(7);
            //Ln.next.next.next.next = new Solution.ListNode(8);
            //Ln.next.next.next.next.next = new Solution.ListNode(3);
            //Ln.next.next.next.next.next.next = new Solution.ListNode(4);
            //Ln.next.next.next.next.next.next.next = new Solution.ListNode(4);
            //Ln.next.next.next.next.next.next.next.next = new Solution.ListNode(4);
            //Ln.next.next.next.next.next.next.next.next.next = new Solution.ListNode(4);
            //Ln.next.next.next.next.next.next.next.next.next.next = new Solution.ListNode(5);
            //Ln.next.next.next.next.next.next.next.next.next.next.next = new Solution.ListNode(5);
            //Ln.next.next.next.next.next.next.next.next.next.next.next.next = new Solution.ListNode(6);
            //Ln.next.next.next.next.next.next.next.next.next.next.next.next.next = new Solution.ListNode(7);
            //Ln.next.next.next.next.next.next.next.next.next.next.next.next.next.next = new Solution.ListNode(7);

            //var Ln1 = new Solution.ListNode(1);
            //Ln1.next = new Solution.ListNode(8);
            //Ln1.next.next = new Solution.ListNode(9);
            //Ln1.next.next.next = new Solution.ListNode(10);
            //Ln1.next.next.next.next = new Solution.ListNode(11);
            //Ln1.next.next.next.next.next = new Solution.ListNode(12);
            #endregion

            //
            int[] A1 = new int[] { 1, 2, 5, 8, 7 };
            Array.Sort(A1);
            var solution = new Solution(2);
            var steps = solution.maxProfit_BestBuyAndSellIII(new List<int> { 1, 2, 5, 7, 1, 2 });//1,3

            var ways = solution.numDecodings("A");
            ways = solution.numDecodings("0");//0
            ways = solution.numDecodings("1");//1
            ways = solution.numDecodings("10");//1
            ways = solution.numDecodings("12");//2
            ways = solution.numDecodings("123456");//3
            ways = solution.numDecodings("26272921");//4
            ways = solution.numDecodings("2611055971756562");//4
            ways = solution.numDecodings("212223");//13
            ways = solution.numDecodings("5163490");//0
            ways = solution.numDecodings("5163490394499093221199401898020270545859326357520618953580237168826696965537789565062429676962877038781708385575876312877941367557410101383684194057405018861234394660905712238428675120866930196204792703765204322329401298924190"); //0
            ways = solution.numDecodings("35951854050586698595637032954677942764426803607970270057511799063015568228620599241247498786783043384076950308860346097055416178750998773266590409624332188226323469665207882618186281911431601595976980616626959878855551179763479654516689714651448113938485023673218643495505336039530090195842960010425454521678136006100012464522579435121824552986555718783925564331098026154783349075578928011643845527023905502587599371732590861748512304337315354512912599720293784757282902915064730915446126706559708653582603917558615912689603532310464458039423810872986602635283171253165801779781129791177627118109708839021704473028222551021737058083722744790305649532896675336558527157232401557709"); //0
            var maxtrix = new List<List<int>>
            {
                new List<int> {1, 3, 2},
                new List<int> {4, 3, 1}
            };

            var min = solution.minPathSum(maxtrix);

            maxtrix = new List<List<int>>
            {
                new List<int> {0},
            };
            min = solution.minPathSum(maxtrix);

            maxtrix = new List<List<int>>
            {
                new List<int> {10, 3, 2},
                new List<int> {4, 3, 1},
                new List<int> {5, 6, 1}
            };
            min = solution.minPathSum(maxtrix);
            //
            //   4 3 1
            //   5 6 1

            var l = solution.longestSubsequenceLength(new List<int> { 1, 11, 2, 10, 4, 5, 2, 1 });
            var l34 = solution.longestSubsequenceLength(new List<int> { 148, 333, 306, 200, 397, 361, 458, 209, 4, 436, 282, 221, 358, 126, 235, 489, 444, 134, 42, 257, 240, 305, 480, 195, 102, 175, 44, 345, 224, 452, 249, 49, 173, 200, 241, 285, 438, -9, 132, 80, 238, 428, 463, 334, 399, 449, 242, 39, 56, 453, 108, 95, 492, 277, 109, 188, 376, 400, 265, 212, 304, 223, 321, 338, 120, 380, 74, 459, 277, 423, 176, 309, 465, 135, 170, 88, 11, 242, 305, 11, 19, 486, -7, 414, 442, 419, 3, 49, 201, 150, 127, 285, -5, 166, 320, 371, 12, 312, 267, 202, 360, 418, 481, 360, 409, 347, 139, 356, 277, 389, 212, 491, 272, 31, 206, 154, 265, 291, 174, 255, 398, 30, 360, 450, 432, 405, 244, 118, 320, 147, 277, 437, 495, 459, 273, 218, 197, 111, 449, 96, 236, 341, 496, 186, 61, 384, 123, 428, 492, 200, 389, 248, 95, 248, 74, 244, 300, 295, 264, 18, 278, 283, 51, 204, 0, 78, 333, 430, 168, 384, 402, 347, 406, 130, 64, 186, 339, 385, 458, 425, 120, 151, 402 });
            var x = solution.order(new List<int> { 1, 5, 3, 2, 6, 4 }, new List<int> { 0, 1, 2, 0, 3, 2 });


            TreeNode A = new TreeNode(5);
            A.left = new TreeNode(3);
            A.left.left = new TreeNode(1);
            A.left.left.right = new TreeNode(9);
            A.left.right = new TreeNode(4);

            A.right = new TreeNode(7);
            A.right.left = new TreeNode(6);
            A.right.right = new TreeNode(2);
            var lca = solution.lca(A, 5, 3);//5
            lca = solution.lca(A, 5, 4);//5
            lca = solution.lca(A, 5, 1);//5
            lca = solution.lca(A, 5, 9);//5
            lca = solution.lca(A, 3, 9);//3
            lca = solution.lca(A, 3, 7);//5
            lca = solution.lca(A, 9, 4);//3
            lca = solution.lca(A, 9, 2);//5
            lca = solution.lca(A, 6, 2);//7
            //A.right = new TreeNode(9);
            //A.right.left = new TreeNode(6);
            //A.right.right = new TreeNode(7);
            //ls = solution.RecoverTree(A);


            //A = new TreeNode(1);
            //A.left = new TreeNode(2);
            //A.right = new TreeNode(1);
            //A.right.left = new TreeNode(1);
            //A.right.left.right = new TreeNode(0);
            //A.right.left.left = new TreeNode(2);


        }
        #region SerializeDictionary
        public static Dictionary<string, string> Dict = new Dictionary<string, string>
        {
            {"GEN", "-"},
            {"TUR", "Turtle"},
            {"MAN", "Manual"},
            {"PRO", "Procedure"},
            {"WI", "Work Instruction"},
            {"TPL", "Template"},
            {"ADD", "Addendum"},
            {"TRA", "Training"},
            {"TOOL", "Tool"},
        };

        public static void SerializeDictionary()
        {
            var root = new XElement("ProcessArea",
                from keyValue in Dict
                select new XElement(keyValue.Key, keyValue.Value)
            );
            Console.WriteLine(root);
        }
        #endregion
    }
}

