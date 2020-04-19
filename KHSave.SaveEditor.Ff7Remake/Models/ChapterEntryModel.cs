using KHSave.LibFf7Remake.Chunks;
using System.Linq;
using System.Windows;

namespace KHSave.SaveEditor.Ff7Remake.Models
{
    public class ChapterEntryModel
    {
        private readonly ChunkChapter _chapter;
        private readonly int _index;

        public ChapterEntryModel(ChunkChapter chapter, int index)
        {
            _chapter = chapter;
            _index = index;
        }

        public bool IsChapterEnabled => !(_chapter.Characters?.All(x => x == 0) ?? true);

        public Visibility ChapterVisibility => IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;
        public Visibility ChapterDisabledVisibility => !IsChapterEnabled ? Visibility.Visible : Visibility.Collapsed;

        public string Name => $"Chapter {_index + 1}";

        public PositionModel Entity0 => new PositionModel(_chapter.Positions[0]);
        public PositionModel Entity1 => new PositionModel(_chapter.Positions[1]);
        public PositionModel Entity2 => new PositionModel(_chapter.Positions[2]);
        public PositionModel Entity3 => new PositionModel(_chapter.Positions[3]);
        public PositionModel Entity4 => new PositionModel(_chapter.Positions[4]);
        public PositionModel Entity5 => new PositionModel(_chapter.Positions[5]);
        public PositionModel Entity6 => new PositionModel(_chapter.Positions[6]);
        public PositionModel Entity7 => new PositionModel(_chapter.Positions[7]);
        public PositionModel Entity8 => new PositionModel(_chapter.Positions[8]);
        public PositionModel Entity9 => new PositionModel(_chapter.Positions[9]);
        public PositionModel Entity10 => new PositionModel(_chapter.Positions[10]);
        public PositionModel Entity11 => new PositionModel(_chapter.Positions[11]);
    }
}
