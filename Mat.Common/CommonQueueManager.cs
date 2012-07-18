using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mat.Common
{
    public class CommonQueueManager : IQueueManager
    {
        private readonly IList<Image> _images = new List<Image>();
        private int _position;
        public int Seed { get; set; }

        public CommonQueueManager()
        {
            Seed = new Random().Next(int.MaxValue);
            _images = SourceContainer.GetInstance().Sources
                .SelectMany(s => s.Images)
                .OrderBy(i => (~(i.Ordering() & Seed)) & (i.Ordering() | Seed))
                .ToList();
        }

        public IEnumerable<Image> Queue
        {
            get { return _images.Skip(_position); }
        }

        public IEnumerable<Image> History
        {
            get { return _images.Take(_position); }
        }

        public Image Next()
        {
            _position++;
            if (_images.Count <= _position)
            {
                _position = 0;
            }
            return Current;
        }

        public Image Previous()
        {
            _position--;
            if (_position < 0)
            {
                _position = _images.Count;
            }
            return Current;
        }

        public Image Current
        {
            get { return _images[_position]; }
        }

        public void NewImage(Image image)
        {
            _images.Insert(_position + 1, image);
        }

        public void RemoveImage(Image image)
        {
            _images.Remove(image);
        }
    }
}
