using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace OinkServer
{
    public class SoundProvider
    {
        private const string SoundNamespace = "OinkServer.Assets.Sounds";

        private readonly IReadOnlyList<string> _soundFileList;
        private readonly Random _random = new Random();
        
        public SoundProvider()
        {
            _soundFileList = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(rn => rn.StartsWith(SoundNamespace)).ToList();
        }
        
        public Stream GetRandomSound()
        {
            var randomIndex = _random.Next(0, _soundFileList.Count);
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(_soundFileList[randomIndex])!;
        }
    }
}