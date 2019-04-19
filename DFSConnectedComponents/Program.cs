using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Найти количество компонент связности неориентированного графа при помощи поиска в глубину.

Формат входных данных:
На вход подаётся описание графа. В первой строке указаны два натуральных числа, разделенные пробелом: число вершин v≤1000 и число рёбер e≤1000. В следующих e строках содержатся описания рёбер. Каждое ребро задаётся разделённой пробелом парой номеров вершин, которые это ребро соединяет. Считается, что вершины графа пронумерованы числами от 1 до v.

Формат выходных данных:
Одно число — количество компонент связности графа.
 */

namespace DFSConnectedComponents
{
    class Program
    {
        static List<List<Vertex>> _edgeList = new List<List<Vertex>>();
        private static int _countComponents;

        static void Main(string[] args)
        {
            bool[] notIsolated = Input();
            int countIsolated = CountIsolated(notIsolated);

            DepthFirstSearch();
            Console.WriteLine(_countComponents + countIsolated);
        }

        private static bool[] Input()
        {
            int v, e;
            var str = Console.ReadLine();
            var array = str.Split();
            v = int.Parse(array[0]);
            e = int.Parse(array[1]);

            bool[] notIsolated = new bool[v];
            for (int i = 0; i < e; i++)
            {
                List<Vertex> list = new List<Vertex>();
                str = Console.ReadLine();
                array = str.Split();
                for (int j = 0; j < 2; j++)
                {
                    int intVar = int.Parse(array[j]);
                    notIsolated[intVar - 1] = true;
                    Vertex vertex = new Vertex(intVar);
                    list.Add(vertex);
                }

                _edgeList.Add(list);
            }

            return notIsolated;
        }

        private static int CountIsolated(bool[] notIsolated)
        {
            int countIsolated = 0;
            foreach (var value in notIsolated)
            {
                if (!value)
                    countIsolated++;
            }

            return countIsolated;
        }

        private static List<Vertex> DepthFirstSearch()
        {
            List<Vertex> vertices = new List<Vertex>();
            foreach (var list in _edgeList)
                foreach (var vertex in list)
                    vertex.IsDiscovered = false;

            foreach (var list in _edgeList)
            {
                foreach (var vertex in list)
                {
                    if (vertex.IsDiscovered == false)
                    {
                        _countComponents++;
                        vertices = DFSVisit(vertex, vertices);
                    }
                }
            }

            return vertices;
        }

        private static List<Vertex> DFSVisit(Vertex vertex, List<Vertex> vertices)
        {
            vertex.IsDiscovered = true;
            foreach (var edge in _edgeList)
                for (int i = 0; i < 2; i++)
                {
                    if (edge[i].Index == vertex.Index && !edge[i == 0 ? 1 : 0].IsDiscovered)
                        DFSVisit(edge[i == 0 ? 1 : 0], vertices);
                }

            vertices.Add(vertex);
            return vertices;
        }
    }
}
