namespace AoC2021.Core.Days
{
  public class Day05 : DayBase
    {
        public override string Name => "Day 5";

        public List<string> HorizontalPoints { get; } = new List<string>();
        public List<string> VerticalPoints { get; } = new List<string>();
        public List<string> DiagPoints { get; } = new List<string>();

        public Day05(List<string> inputs) : base(inputs)
        {
            FormatData();
        }
        private int ToInt(string s) => int.Parse(s);

        private bool IsDiag(int x1, int y1, int x2, int y2)
        {
            return Math.Abs((y2 - y1) / (x2 - x1)) == 1;
        }
        private void FormatData()
        {
            var lines = InputData.Select(x => x.Split(" -> ")).Select(x => new { pt1 = x[0].Split(','), pt2 = x[1].Split(',') }).ToList();
            // var lines = pts.Chunk(2);
            var vert = lines
                .Where(x => x.pt1[0] == x.pt2[0]);

            var horiz = lines
                .Where(x => x.pt1[1] == x.pt2[1]);

            var diag = lines
                .Where(x => x.pt1[0] != x.pt2[0])
                .Where(x => x.pt1[1] != x.pt2[1])
                .Where(x => IsDiag(ToInt(x.pt1[0]), ToInt(x.pt1[1]), ToInt(x.pt2[0]), ToInt((x.pt2[1]))));

            foreach (var item in vert)
            {
                var x = item.pt1[0];
                var y1 = int.Parse(item.pt1[1]);
                var y2 = int.Parse(item.pt2[1]);
                var dist = Math.Abs(y2 - y1);
                var factor = y1 < y2 ? 1 : -1;
                for (int i = 0; i < dist; i++)
                {
                    VerticalPoints.Add($"{x},{int.Parse(item.pt1[1]) + factor * i}");
                }
                VerticalPoints.Add($"{x},{item.pt2[1]}");
            }

            foreach (var item in horiz)
            {
                var y = item.pt1[1];
                var x1 = int.Parse(item.pt1[0]);
                var x2 = int.Parse(item.pt2[0]);
                var dist = Math.Abs(x2 - x1);
                var factor = x1 < x2 ? 1 : -1;
                for (int i = 0; i < dist; i++)
                {
                    HorizontalPoints.Add($"{int.Parse(item.pt1[0]) + factor * i},{y}");
                }
                HorizontalPoints.Add($"{item.pt2[0]},{y}");
            }

            foreach (var item in diag)
            {
                var x1 = ToInt(item.pt1[0]);
                var x2 = ToInt(item.pt2[0]);
                var y1 = ToInt(item.pt1[1]);
                var y2 = ToInt(item.pt2[1]);

                var dist = Math.Abs(x2 - x1);
                var xfactor = x1 < x2 ? 1 : -1;
                var yfactor = y1 < y2 ? 1 : -1;

                for (int i = 0; i < dist; i++)
                {
                    var x = ToInt(item.pt1[0]) + (xfactor * i);
                    var y = ToInt(item.pt1[1]) + (yfactor * i);
                    DiagPoints.Add($"{x},{y}");
                }
                DiagPoints.Add($"{item.pt2[0]},{item.pt2[1]}");
            }
        }



        public override object Answer1()
        {
            var allPoints = new List<string>();
            allPoints.AddRange(HorizontalPoints);
            allPoints.AddRange(VerticalPoints);
            var counts = allPoints.GroupBy(x => x);
            var moreThan1 = counts.Where(x => x.Count() > 1).Count();
            return moreThan1;
        }

        public override object Answer2()
        {
            var allPoints = new List<string>();
            allPoints.AddRange(HorizontalPoints);
            allPoints.AddRange(VerticalPoints);
            allPoints.AddRange(DiagPoints);
            var counts = allPoints.GroupBy(x => x);
            var moreThan1 = counts.Where(x => x.Count() > 1).Count();
            return moreThan1;
        }
    }
}
