using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PavComponents
{
    public partial class TreeView : UserControl
    {
        private Queue<string> _nodeNames;

        public int SelectedNodeIndex
        {
            get
            {
                if (treeView.SelectedNode != null)
                    return treeView.SelectedNode.Index;
                return -1;
            }
            set
            {
                if (value < treeView.Nodes.Count && value >= 0)
                {
                    treeView.SelectedNode = treeView.Nodes[value];
                    treeView.Focus();
                }
            }
        }

        public TreeView()
        {
            InitializeComponent();
        }

        public void SetTreeСonfiguration(Queue<string> nodeNames)
        {
            if (nodeNames != null)
                _nodeNames = nodeNames;
            else
                throw new NullReferenceException();
        }

        public void AddItems<T>(T item) where T : class, new()
        {
            if (_nodeNames == null)
                throw new NullReferenceException("Не установлена конфигурация дерева. Используйте метод SetTreeСonfiguration для конфигурации.");

            if (item == null)
                throw new NullReferenceException("Входной параметр T item не указывает на объект");

            var itemType = item.GetType();
            var currentLevelNodes = treeView.Nodes;

            int currentLevel = 1;
            foreach (var nodeName in _nodeNames)
            {
                var propertyInfo = itemType.GetProperty(nodeName);

                if (propertyInfo != null)
                {
                    var propertyValue = propertyInfo.GetValue(item).ToString();
                    if (currentLevelNodes.ContainsKey(propertyValue) == false || currentLevel == _nodeNames.Count)
                    {
                        currentLevelNodes.Add(propertyValue, propertyValue);
                    }
                    var nextLevels = currentLevelNodes.Find(propertyValue, false);
                    currentLevelNodes = nextLevels[0].Nodes;
                }
            }
        }

        public T GetSelectedItem<T>() where T : class, new()
        {
            if (treeView.SelectedNode == null)
                return null;

            var currentNode = treeView.SelectedNode;
            while (currentNode.Nodes != null && currentNode.Nodes.Count > 0)
            {
                if (currentNode.Nodes.Count > 1)
                    throw new Exception("Неоднозначный определение. В выбранной ветки несколько дочерних элементов");

                currentNode = currentNode.Nodes[0];
            }

            Stack<string> propertyValues = new Stack<string>();
            while (currentNode != null)
            {
                propertyValues.Push(currentNode.Text);
                currentNode = currentNode.Parent;
            }

            object item = Activator.CreateInstance<T>();
            foreach (var properyName in _nodeNames)
            {
                var propertyInfo = item.GetType().GetProperty(properyName);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(item, Convert.ChangeType(propertyValues.Pop(), propertyInfo.PropertyType));
                }
            }
            return (T)item;
        }

        public void Clear()
        {
            treeView.Nodes.Clear();
        }
    }
}
