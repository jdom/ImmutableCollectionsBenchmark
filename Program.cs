using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkImmutableCollections
{
    public class ReadDictionary
    {
        private ImmutableDictionary<int, string> immutable;
        private Dictionary<int, string> mutable;

        private int itemsCount = 10000;
        [Setup]
        public void SetupData()
        {
            this.mutable = Enumerable.Range(0, this.itemsCount).ToDictionary(i => i, i => i.ToString());
            this.immutable = this.mutable.ToImmutableDictionary();
        }

        [Benchmark]
        public void MutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.mutable[i];
            }
        }

        [Benchmark]
        public void ImmutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.immutable[i];
            }
        }
    }

    public class ReadList
    {
        private ImmutableList<string> immutable;
        private List<string> mutable;

        private int itemsCount = 10000;
        [Setup]
        public void SetupData()
        {
            this.mutable = Enumerable.Range(0, this.itemsCount).Select(i => i.ToString()).ToList();
            this.immutable = this.mutable.ToImmutableList();
        }

        [Benchmark]
        public void MutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.mutable[i];
            }
        }

        [Benchmark]
        public void ImmutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.immutable[i];
            }
        }
    }

    public class ReadArray
    {
        private ImmutableArray<string> immutable;
        private string[] mutable;

        private int itemsCount = 10000;
        [Setup]
        public void SetupData()
        {
            this.mutable = Enumerable.Range(0, this.itemsCount).Select(i => i.ToString()).ToArray();
            this.immutable = this.mutable.ToImmutableArray();
        }

        [Benchmark]
        public void MutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.mutable[i];
            }
        }

        [Benchmark]
        public void ImmutableRead()
        {
            string value;
            for (int i = 0; i < this.itemsCount; i++)
            {
                value = this.immutable[i];
            }
        }
    }

    public class ReadAll
    {
        private ReadDictionary dictionaryBenchmark;
        private ReadArray arrayBenchmark;
        private ReadList listBenchmark;

        [Setup]
        public void SetupData()
        {
            this.dictionaryBenchmark = new ReadDictionary();
            this.dictionaryBenchmark.SetupData();

            this.arrayBenchmark = new ReadArray();
            this.arrayBenchmark.SetupData();

            this.listBenchmark = new ReadList();
            this.listBenchmark.SetupData();
        }

        [Benchmark]
        public void DictionaryMutableRead()
        {
            this.dictionaryBenchmark.MutableRead();
        }

        [Benchmark]
        public void DictionaryImmutableRead()
        {
            this.dictionaryBenchmark.ImmutableRead();
        }

        [Benchmark]
        public void ArrayMutableRead()
        {
            this.arrayBenchmark.MutableRead();
        }

        [Benchmark]
        public void ArrayImmutableRead()
        {
            this.arrayBenchmark.ImmutableRead();
        }

        [Benchmark]
        public void ListMutableRead()
        {
            this.listBenchmark.MutableRead();
        }

        [Benchmark]
        public void ListImmutableRead()
        {
            this.listBenchmark.ImmutableRead();
        }
    }

    class Program
    {
        static void Main()
        {
            //var summaryDictionary = BenchmarkRunner.Run<ReadDictionary>();
            //var summaryList = BenchmarkRunner.Run<ReadList>();
            //var summaryArray = BenchmarkRunner.Run<ReadArray>();

            var summary = BenchmarkRunner.Run<ReadAll>();
        }
    }
}
