using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Xunit;

namespace leetcode.Tests.leetcode
{
    public class UnivaluedBinaryTree
    {
        [Fact]
        public void Test()
        {
            var arr = new int?[] { 1, 1, 1, 1, 1, null, 1 };
            var expected = true;

            var root = new TreeNode(1);
            root.left = new TreeNode(1);
            root.right = new TreeNode(1);

            root.left.left = new TreeNode(1);
            root.left.right = new TreeNode(1);

            root.right.left = new TreeNode(1);
            root.right.right = new TreeNode(1);
            
            var s = new Solution();
            Assert.True(s.IsUnivalTree(root));


            var root2 = new TreeNode(1);
            root2.left = new TreeNode(1);
            root2.right = new TreeNode(1);

            root2.left.left = new TreeNode(2);
            root2.left.right = new TreeNode(1);

            root2.right.left = new TreeNode(1);
            root2.right.right = new TreeNode(1);
            Assert.False(s.IsUnivalTree(root2));
        }
        
        public class Solution
        {
            private int _rVal;
            bool _flag = true;

            public bool IsUnivalTree(TreeNode root)
            {
                if(_rVal == 0) _rVal = root.val;

                if (_rVal != root.val)
                    _flag = false;
                
                if (root.left != null)
                    IsUnivalTree(root.left);

                Debug.WriteLine(root.val);

                if (root.right != null)
                    IsUnivalTree(root.right);

                return _flag;
            }
        }
    }
}
