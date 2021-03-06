﻿using Example.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Example.Reader
{
    class Dir : ReaderDirAbstract
    {
        public override List<ReaderDirAbstract> Next { set; get; }
        public override ReaderDirAbstract Preview { set; get; }
        public override List<string> DirectoryFiles { protected set; get; }
        public override List<string> ListFiles { protected set; get; }

        public override void Create()
        {
            this.Next = this.DirectoryFiles
                .Select(x => new Dir(x, this))
                .Cast<ReaderDirAbstract>()
                .ToList();
            this.Next.ForEach(x => x.Create());
        }

        public override IEnumerable<string> Directory()
        {
            try
            {
                return System.IO.Directory.EnumerateDirectories(this.dir);
            }
            catch (Exception ex) { return Enumerable.Empty<string>(); }
        }

        public override IEnumerable<string> Files()
        {
            try
            {
                return System.IO.Directory.EnumerateFiles(this.dir);
            }
            catch (Exception ex) { return Enumerable.Empty<string>(); }
        }

        public override List<string> Invoke(Func<string,bool> action)
        {
            var result = this.ListFiles.Where(x => action.Invoke(x)).ToList();
            result.AddRange(this.Next.SelectMany(x => x.Invoke(action)));
            return result;
        }

        private Dir() : base(null)
        { }
        public Dir(string dir, ReaderDirAbstract preview) : base(dir)
        {
            this.Preview = preview;
            this.Next = new List<ReaderDirAbstract>();
            this.DirectoryFiles = Directory().ToList();
            this.ListFiles = Files().ToList();
        }
    }
}
