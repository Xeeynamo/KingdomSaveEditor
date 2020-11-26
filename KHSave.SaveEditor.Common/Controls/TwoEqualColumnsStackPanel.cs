// MIT License
// 
// Copyright(c) 2018 Luciano (Xeeynamo) Ciccariello
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// Part of this software belongs to XeEngine toolset and United Lines Studio
// and it is currently used to create commercial games by Luciano Ciccariello.
// Please do not redistribuite this code under your own name, stole it or use
// it artfully, but instead support it and its author. Thank you.

using System;
using System.Windows;
using System.Windows.Controls;

namespace KHSave.SaveEditor.Common.Controls
{
    public class TwoEqualColumnsStackPanel : Panel
    {
        const double MyMargin = 5.0;

        //protected override Size MeasureOverride(Size constraint)
        //{
        //    for (int i = 0; i < VisualChildrenCount; i += 2)
        //        Children[i].Measure(constraint);

        //    for (int i = 1; i < VisualChildrenCount; i += 2)
        //        Children[i].Measure(new Size((constraint.Width - MyMargin) / 2.0, constraint.Height));

        //    return new Size(
        //        constraint.Width,
        //        0);
        //}

        protected override Size MeasureOverride(Size constraint)
        {
            var y = 0.0;
            var width = (constraint.Width - MyMargin) / 2.0;

            int count = VisualChildrenCount;
            for (var i = 0; i < count; i += 4)
            {
                var child1 = Children[i];
                var child2 = count > i + 1 ? Children[i + 1] : null;
                var child3 = count > i + 2 ? Children[i + 2] : null;
                var child4 = count > i + 3 ? Children[i + 3] : null;

                child1.Measure(new Size(width, constraint.Height));
                child3?.Measure(new Size(width, constraint.Height));
                child2?.Measure(new Size(width, constraint.Height));
                child4?.Measure(new Size(width, constraint.Height));

                var aboveHeight = Math.Max(child1.DesiredSize.Height, child3?.DesiredSize.Height ?? 0);
                var belowHeight = Math.Max(child2?.DesiredSize.Height ?? 0, child4?.DesiredSize.Height ?? 0);

                y += aboveHeight + belowHeight + MyMargin;
            }

            return new Size(constraint.Width, Math.Max(0, y - MyMargin));
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var width = (arrangeSize.Width - MyMargin) / 2.0;
            var rightY = (arrangeSize.Width + MyMargin) / 2.0;
            var y = 0.0;

            int count = VisualChildrenCount;
            for (var i = 0; i < count; i += 4)
            {
                var child1 = Children[i];
                var child2 = count > i + 1 ? Children[i + 1] : null;
                var child3 = count > i + 2 ? Children[i + 2] : null;
                var child4 = count > i + 3 ? Children[i + 3] : null;

                var aboveHeight = Math.Max(child1.DesiredSize.Height, child3?.DesiredSize.Height ?? 0);
                var belowHeight = Math.Max(child2?.DesiredSize.Height ?? 0, child4?.DesiredSize.Height ?? 0);

                child1.Arrange(new Rect(0, y, width, aboveHeight));
                child2?.Arrange(new Rect(0, y + aboveHeight, width, belowHeight));
                child3?.Arrange(new Rect(rightY, y, width, aboveHeight));
                child4?.Arrange(new Rect(rightY, y + aboveHeight, width, belowHeight));

                y += aboveHeight + belowHeight + MyMargin;
            }

            return base.ArrangeOverride(arrangeSize);
        }
    }
}
