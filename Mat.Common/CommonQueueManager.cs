using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mat.Common
{
    public class CommonQueueManager : IQueueManager
    {
        private readonly IList<Media> _media = new List<Media>();
        private int _position;
        public int Seed { get; set; }

        public CommonQueueManager()
        {
            Seed = new Random().Next(int.MaxValue);
            _media = SourceContainer.GetInstance().Sources
                .SelectMany(s => s.Media)
                .OrderBy(i => (~(i.Ordering() & Seed)) & (i.Ordering() | Seed))
                .ToList();
        }

        public IEnumerable<Media> Queue
        {
            get { return _media.Skip(_position); }
        }

        public IEnumerable<Media> History
        {
            get { return _media.Take(_position); }
        }

        public Media Next()
        {
            _position++;
            if (_media.Count <= _position)
            {
                _position = 0;
            }
            return Current;
        }

        public Media Previous()
        {
            _position--;
            if (_position < 0)
            {
                _position = _media.Count - 1;
            }
            return Current;
        }

        public Media Current
        {
            get { return _media[_position]; }
        }

        public void NewMedia(Media media)
        {
            _media.Insert(_position + 1, media);
        }

        public void RemoveMedia(Media media)
        {
            _media.Remove(media);
        }
    }
}
