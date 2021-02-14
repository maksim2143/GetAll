using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Abstract
{
    /// <summary>
    /// Клас який відповідає за папку, і відає інформацію про файли і папки, і файли конфігурації
    /// </summary>
    abstract class ReaderDirAbstract
    {
        public abstract void Create();
        public abstract List<ReaderDirAbstract> Next { set; get; }
        public abstract ReaderDirAbstract Preview { set; get; }
        public abstract List<string> DirectoryFiles {protected set; get; }
        public abstract List<string> ListFiles { protected set; get; }
        /// <summary>
        /// Метод який вертає файли даної папки
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<string> Files();
        /// <summary>
        /// Метод який вертає папки цієї папки
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<string> Directory();
        public string Current { get => dir; }
        protected string dir;
        public ReaderDirAbstract(string dir)
        {
            this.dir = dir;
        }
    }
}
