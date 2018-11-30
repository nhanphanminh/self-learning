using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public int weight;

        public TreeNode(int x)
        {
            this.val = x;
            this.left = this.right = null;
        }

        public TreeNode(int x, int w)
        {
            this.val = x;
            this.left = this.right = null;
            this.weight = w;
        }
    }

    public partial class Solution
    {
        private void PostTravelTree(TreeNode A, List<int> ls)
        {
            if (A == null)
            {
                return;
            }

            if (ls.Count == 0)
            {
                ls.Add(A.val);
            }
            else
            {
                ls.Insert(0, A.val);
            }

            PostTravelTree(A.right, ls);
            PostTravelTree(A.left, ls);
        }

        public List<int> postorderTraversal(TreeNode A)
        {
            var rs = new List<int>();
            PostTravelTree(A, rs);
            return rs;
        }

        private void TravelTree(TreeNode A, List<int> ls)
        {
            if (A == null)
            {
                return;
            }


            ls.Add(A.val);

            TravelTree(A.left, ls);
            TravelTree(A.right, ls);

        }


        public List<int> preorderTraversal(TreeNode A)
        {
            var rs = new List<int>();
            TravelTree(A, rs);
            return rs;
        }

        private void TravelTree(TreeNode A, List<int> ls, int B, ref int sum, List<List<int>> rs)
        {
            if (A == null)
            {
                return;
            }


            ls.Add(A.val);
            sum += A.val;

            if (IsLeafNode(A) && sum == B)
            {
                rs.Add(ls);
                sum -= A.val;
                return;
            }

            if (A.left != null)
                TravelTree(A.left, ls.ToList(), B, ref sum, rs);

            if (A.right != null)
                TravelTree(A.right, ls.ToList(), B, ref sum, rs);
            sum -= A.val;
        }

        public List<List<int>> pathSum(TreeNode A, int B)
        {
            var rs = new List<List<int>>();
            var sum = 0;
            TravelTree(A, new List<int>(), B, ref sum, rs);
            return rs;
        }

        private bool IsLeafNode(TreeNode A)
        {
            return A.left == null && A.right == null;
        }

        private bool IsHasWay(TreeNode A, int B, ref int sum)
        {
            if (A == null)
            {
                return false;
            }

            sum += A.val;

            if (IsLeafNode(A) && sum == B)
            {
                return true;
            }

            if (IsHasWay(A.left, B, ref sum) || IsHasWay(A.right, B, ref sum))
            {
                return true;
            }

            sum -= A.val;
            return false;
        }

        public int hasPathSum(TreeNode A, int B)
        {
            var sum = 0;

            if (IsHasWay(A, B, ref sum))
            {
                return 1;
            }

            return 0;
        }


        private void maxDepth(TreeNode A, ref int deep, ref int max)
        {
            if (A == null)
            {
                return;
            }

            deep++;

            if (IsLeafNode(A))
            {
                if (deep > max)
                    max = deep;
            }

            maxDepth(A.left, ref deep, ref max);
            maxDepth(A.right, ref deep, ref max);
            deep--;
        }

        public int maxDepth(TreeNode A)
        {
            var deep = 0;
            var max = 0;
            maxDepth(A, ref deep, ref max);
            return max;
        }

        private void minDepth(TreeNode A, ref int deep, ref int min)
        {
            if (A == null)
            {
                return;
            }

            deep++;

            if (IsLeafNode(A))
            {
                if (deep < min)
                    min = deep;
            }

            minDepth(A.left, ref deep, ref min);
            minDepth(A.right, ref deep, ref min);
            deep--;
        }

        public int minDepth(TreeNode A)
        {
            var deep = 0;
            var min = int.MaxValue;
            minDepth(A, ref deep, ref min);
            return min;
        }

        private void sumNumbers(TreeNode A, ref int deep, ref long sum, ref long total)
        {
            if (A == null)
            {
                return;
            }

            deep++;
            var tmp = sum;
            sum = (((sum * 10) % 1003) + (A.val % 1003)) % 1003;

            if (IsLeafNode(A))
            {
                //total = ((total % 1003) + (sum % 1003)) % 1003;
                total = ((total % 1003) + sum) % 1003;
            }

            sumNumbers(A.left, ref deep, ref sum, ref total);
            sumNumbers(A.right, ref deep, ref sum, ref total);
            deep--;
            sum = tmp;
        }

        public int sumNumbers(TreeNode A)
        {
            var deep = 0;
            long sum = 0;
            long total = 0;
            sumNumbers(A, ref deep, ref sum, ref total);
            return (int)total;
        }

        private bool t2Sum(TreeNode A, int B, Dictionary<int, int> dict)
        {
            if (A == null)
            {
                return false;
            }

            var tmp = B - A.val;

            if (dict.ContainsKey(tmp))
            {
                return true;
            }

            if (!dict.ContainsKey(A.val))
            {
                dict.Add(A.val, tmp);
            }

            if (t2Sum(A.left, B, dict))
            {
                return true;
            }

            if (t2Sum(A.right, B, dict))
            {
                return true;
            }

            return false;
        }

        public int t2Sum(TreeNode A, int B)
        {
            var dict = new Dictionary<int, int>();
            if (t2Sum(A, B, dict))
            {
                return 1;
            }

            return 0;
        }

        private int getIndex(TreeNode A, Dictionary<int, int> dict, int fatherIndex, int B, bool isLeftlef = false)
        {
            if (A == null)
            {
                return -1;
            }

            var currentIndex = -1;

            if (A.left != null)
            {
                currentIndex = getIndex(A.left, dict, fatherIndex, B, isLeftlef) + 1;
                if (currentIndex == -99)
                {
                    return -100;
                }
            }
            else
            {
                if (isLeftlef)
                {
                    currentIndex = 1;
                }
                else
                {
                    currentIndex = fatherIndex - 1;
                }
            }



            dict.Add(currentIndex, A.val);

            if (currentIndex == B)
            {
                return -100;
            }

            var maxIndex = -1;
            if (A.right != null)
            {
                if (A.val == 5)
                {
                }

                maxIndex = getIndex(A.right, dict, currentIndex + 2, B, false);
                if (maxIndex == -100)
                {
                    return -100;
                }

            }

            return currentIndex > maxIndex ? currentIndex : maxIndex;
        }

        public int kthsmallest(TreeNode A, int B)
        {
            var dict = new Dictionary<int, int>();
            getIndex(A, dict, -1, B, true);
            if (!dict.ContainsKey(B))
            {
                return -1;
            }

            return dict[B];
        }


        private void RecoverTree(TreeNode A, List<int> rs, int minValue, int maxValue)
        {
            if (A == null)
            {
                return;
            }

            if (A.val < minValue || A.val > maxValue)
            {
                rs.Add(A.val);

                RecoverTree(A.left, rs, minValue, A.val - 1);
                RecoverTree(A.right, rs, A.val + 1, maxValue);
                return;
            }

            if (A.left != null)
            {
                if (A.val < A.left.val)
                {
                    rs.Add(A.left.val);
                    rs.Add(A.val);
                }

                RecoverTree(A.left, rs, minValue, A.val - 1);
            }

            if (A.right != null)
            {
                if (A.val > A.right.val)
                {
                    rs.Add(A.right.val);
                    rs.Add(A.val);
                }

                RecoverTree(A.right, rs, A.val + 1, maxValue);
            }
        }

        public List<int> RecoverTree(TreeNode A)
        {
            var rs = new List<int>();
            RecoverTree(A, rs, int.MinValue, int.MaxValue);

            if (rs.Count == 2)
            {
                return rs;
            }

            if (rs.Count == 3)
            {
                rs.RemoveAt(1);
                return rs;
            }

            if (rs.Count == 4)
            {
                return new List<int> { rs[0], rs[2] };
            }

            return new List<int>();
        }

        public List<List<int>> zigzagLevelOrder(TreeNode rootTreeNode)
        {
            var result = new List<List<int>>();
            if (rootTreeNode == null)
            {
                return result;
            }

            var listNodes = new List<TreeNode> { rootTreeNode };
            var isLeftToRight = true;

            while (listNodes.Any())
            {
                var resultTmp = new List<int>();
                var tmp = new List<TreeNode>();

                foreach (var node in listNodes)
                {
                    if (node.left != null)
                    {
                        tmp.Add(node.left);
                    }

                    if (node.right != null)
                    {
                        tmp.Add(node.right);
                    }

                    if (isLeftToRight)
                    {
                        resultTmp.Add(node.val);
                    }
                    else
                    {
                        resultTmp.Insert(0, node.val);
                    }
                }

                result.Add(resultTmp.ToList());
                listNodes = tmp.ToList();
                isLeftToRight = !isLeftToRight;
            }

            return result;
        }

        public int isSameTree(TreeNode A, TreeNode B)
        {
            if (A == B && A == null)
            {
                return 1;
            }

            if (A == null || B == null)
            {
                return 0;
            }

            if (A.val != B.val)
            {
                return 0;
            }

            if (isSameTree(A.left, B.left) == 0)
            {
                return 0;
            }

            if (isSameTree(A.right, B.right) == 0)
            {
                return 0;
            }

            return 1;
        }

        public int isSymmetric(TreeNode rootTreeNode)
        {
            if (rootTreeNode == null)
            {
                return 1;
            }

            if (rootTreeNode.left == null && rootTreeNode.right == null)
            {
                return 1;
            }

            if (rootTreeNode.left == null || rootTreeNode.right == null)
            {
                return 0;
            }

            var listNodes = new List<TreeNode> { rootTreeNode.left, rootTreeNode.right };

            while (listNodes.Any())
            {
                if (listNodes.Count % 2 != 0)
                {
                    return 0;
                }

                var resultTmp = new List<int>();

                var lastIndex = listNodes.Count / 2 - 1;

                for (int i = 0; i <= lastIndex; i++)
                {
                    if (listNodes[i].val != listNodes[listNodes.Count - 1 - i].val)
                    {
                        return 0;
                    }
                }

                var tmp = new List<TreeNode>();

                foreach (var node in listNodes)
                {
                    if (node.left != null)
                    {
                        tmp.Add(node.left);
                    }

                    if (node.right != null)
                    {
                        tmp.Add(node.right);
                    }
                }

                listNodes = tmp.ToList();
            }

            return 1;
        }

        //Input: 
        //S = "cool_ice_wifi"
        //R = ["water_is_cool", "cold_ice_drink", "cool_wifi_speed"]

        //Output:
        //ans = [2, 0, 1]
        //Here, sorted reviews are["cool_wifi_speed", "water_is_cool", "cold_ice_drink"]

        private Dictionary<string, int> GetGoodWords(string S)
        {
            var dict = new Dictionary<string, int>();
            var tmpList = S.Split('_').ToList();

            foreach (var word in tmpList)
            {
                if (!dict.ContainsKey(word))
                {
                    dict.Add(word, 0);
                }
            }

            return dict;
        }

        private int GetNumOfGoodWord(string A, Dictionary<string, int> S)
        {
            var tmp = 0;
            var a = A.Split('_').ToArray();

            foreach (var w in a)
            {
                if (S.ContainsKey(w))
                {
                    tmp++;
                }
            }

            return tmp;
        }

        private void InsertNode(ref TreeNode root, TreeNode newNode)
        {
            var tmp = root;

            while (true)
            {
                if (tmp.weight < newNode.weight)
                {
                    if (tmp.left != null)
                    {
                        tmp = tmp.left;
                    }
                    else
                    {
                        tmp.left = newNode;
                        break;
                    }
                }
                else
                {
                    if (tmp.right != null)
                    {
                        tmp = tmp.right;
                    }
                    else
                    {
                        tmp.right = newNode;
                        break;
                    }
                }
            }
        }

        private TreeNode CreateGoodWord(string A, List<string> B, List<int> ls)
        {
            if (!B.Any())
            {
                return null;
            }

            var dict = GetGoodWords(A);
            var w = GetNumOfGoodWord(B[0], dict);
            var root = new TreeNode(0, w);
            ls.Add(-1);

            for (int i = 1; i < B.Count; i++)
            {
                w = GetNumOfGoodWord(B[i], dict);
                var node = new TreeNode(i, w);
                InsertNode(ref root, node);
                ls.Add(-1);
            }

            return root;
        }

        private int getIndex1(TreeNode A, List<int> listIndex, int fatherIndex, bool isLeftlef = false)
        {
            if (A == null)
            {
                return -1;
            }

            var currentIndex = -1;

            if (A.left != null)
            {
                currentIndex = getIndex1(A.left, listIndex, fatherIndex, isLeftlef) + 1;
            }
            else
            {
                if (isLeftlef)
                {
                    currentIndex = 0;
                }
                else
                {
                    currentIndex = fatherIndex - 1;
                }
            }

            listIndex[currentIndex] = A.val;

            var maxIndex = -1;

            if (A.right != null)
            {
                maxIndex = getIndex1(A.right, listIndex, currentIndex + 2);
            }

            return currentIndex > maxIndex ? currentIndex : maxIndex;
        }

        public List<int> solve(string A, List<string> B)
        {
            var list = new List<int>(B.Count);
            var root = CreateGoodWord(A, B, list);

            getIndex1(root, list, -1, true);
            return list;
        }

        int next = 0;

        public TreeNode BuildTreeFromPreAndInOrder(List<int> A, List<int> B)
        {

            next = 0;

            if (A.Count == 0)
            {
                return null;
            }

            TreeNode root = getNode(B, A, 0, A.Count - 1);

            return root;
        }

        private TreeNode getNode(List<int> inOrder, List<int> preOrder, int start, int end)
        {

            if (start > end)
            {
                return null;
            }


            int number = preOrder[next];

            TreeNode node = new TreeNode(number);

            int index = getIndex(inOrder, start, number);

            next++;
            node.left = getNode(inOrder, preOrder, start, index - 1);
            node.right = getNode(inOrder, preOrder, index + 1, end);

            return node;

        }


        private int getIndex(List<int> inOrder, int start, int value)
        {
            int i = start;

            while (inOrder[i] != value)
            {
                i++;
            }

            return i;
        }

        public TreeNode buildTree(List<int> A, List<int> B)
        {
            return BuildTreeRecurssive(A, B, 0, 0, A.Count);
        }

        public TreeNode BuildTreeRecurssive(List<int> inOrder, List<int> postOrder, int inOrderStartIdx,
            int postOrderStartIdx, int size)
        {
            if (size == 0)
            {
                return null;
            }

            int postOrderRootIdx = postOrderStartIdx + size - 1;
            int rootVal = postOrder[postOrderRootIdx];
            int inOrderRootIdx = inOrder.IndexOf(rootVal, inOrderStartIdx, size);
            int leftSubTreeSize = inOrderRootIdx - inOrderStartIdx;
            int rightSubTreeSize = size - leftSubTreeSize - 1;

            var rootNode = new TreeNode(rootVal)
            {
                left = BuildTreeRecurssive(
                    inOrder, postOrder, inOrderStartIdx, postOrderStartIdx, leftSubTreeSize),
                right = BuildTreeRecurssive(
                    inOrder, postOrder, inOrderRootIdx + 1, postOrderStartIdx + leftSubTreeSize, rightSubTreeSize)
            };
            return rootNode;
        }

        private TreeNode InsetNodeToCartesianTree(TreeNode root, TreeNode node)
        {
            if (node.val > root.val)
            {
                node.left = root;
                return node;
            }

            var pre = root;
            var tmp = root.right;

            while (tmp != null && tmp.val > node.val)
            {
                pre = tmp;
                tmp = tmp.right;
            }

            if (tmp == null)
            {
                pre.right = node;
            }
            else
            {
                node.left = tmp;
                pre.right = node;
            }

            return root;
        }


        public TreeNode buildTree(List<int> A)
        {
            if (A == null || !A.Any())
            {
                return null;
            }

            var index = 1;
            var rootNode = new TreeNode(A[0]);

            while (index < A.Count)
            {
                var node = new TreeNode(A[index]);
                rootNode = InsetNodeToCartesianTree(rootNode, node);
                index++;
            }

            return rootNode;
        }

        //Input : 6
        //Heights: 5 3 2 6 1 4
        //InFronts: 0 1 2 0 3 2
        //Output : 
        //actual order is: 5 3 2 1 6 4 

        //Please read the previous hint if you haven’t done so already.

        //    Here, we will explore how to efficiently answer the query of finding the ith empty space.

        //    The query can be solved using segment / interval tree.
        //    The root contains the number of elements in [0, N].
        //Left node contains the number of elements in [0, N / 2]
        //Right node contains the number of elements in [N / 2 + 1, N]

        //Lets say we need to find the ith empty position.
        //    We look at the number of elements X in [0, N / 2].

        //If
        //    N / 2 - X >= i, the position lies in the left part of array and we move down to the left node.
        //    N / 2 - X<i, we now look for i - (N / 2 - X) th position in the right part of the array and move to the right node in the tree.
        public List<int> order(List<int> H, List<int> F)
        {
            List<int> sortedindexList = new List<int>();

            for (int i = 0; i < H.Count; i++)
            {
                sortedindexList.Add(i);
            }

            sortedindexList = sortedindexList.OrderBy(i => H[i]).ToList();
            int[] resultIndexList = new int[H.Count];

            for (int i = 0; i < sortedindexList.Count; i++)
            {
                int index = sortedindexList[i];
                int n = F[index] + 1;
                int j = 0;

                while (n > 0 && j < resultIndexList.Length)
                {
                    if (resultIndexList[j] == 0)
                    {
                        n--;
                    }
                    j++;
                }

                resultIndexList[j - 1] = H[sortedindexList[i]];
            }
            return resultIndexList.ToList();
        }

        private void FindNode(TreeNode A, int B, List<int> result, ref bool isFound)
        {
            if (A == null)
            {
                return;
            }

            if (A.val == B)
            {
                result.Add(B);
                isFound = true;
            }

            if (isFound)
            {
                return;
            }

            result.Add(A.val);
            if (A.left != null)
            {
                FindNode(A.left, B, result, ref isFound);

                if (isFound)
                {
                    return;
                }

                result.Remove(A.left.val);
            }

            if (A.right != null)
            {
                FindNode(A.right, B, result, ref isFound);


                if (isFound)
                {
                    return;
                }

                result.Remove(A.right.val);
            }
        }

        public int lca(TreeNode A, int B, int C)
        {
            var travelA = new List<int>();
            var isFoundA = false;
            FindNode(A, B, travelA, ref isFoundA);

            if (!isFoundA)
            {
                return -1;
            }

            var travelC = new List<int>();
            var isFoundC = false;
            FindNode(A, C, travelC, ref isFoundC);

            if (!isFoundC)
            {
                return -1;
            }

            var tmp = -1;
            var index = 0;
            while (index < travelA.Count && index < travelC.Count && travelA[index] == travelC[index])
            {
                tmp = travelA[index];
                index++;
            }

            return tmp;
        }
    }
}





