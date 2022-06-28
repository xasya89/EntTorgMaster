using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Drawing;
using SixLabors.ImageSharp.Formats;

namespace EntTorgMaster.Services
{
    public static class ImageGenerate
    {

        private static Pen linePen = new Pen(Color.Black, 1);
        public static void Create(OrderDoor orderDoor)
        {
            Door door = new Door(orderDoor);
            door.FramugaH = door.FramugaH == null ? null : 130 * door.FramugaH / door.H;
            door.W = 130 * door.W / door.H;
            door.H = 130;
            door.S = door.S == null ? null : 130 * door.S / door.H;
            if(door.SEqual)
                door.S = (130 * door.W /2) / door.H;
            //door.H = door.H - door.FramugaH ?? 0;
            int h= (door.H + 20) + (door.FramugaH ?? 0);
            using (Image<La32> img = new Image<La32>(door.W + 20, h))
            {
                img.Mutate(imageContext =>
                {
                    imageContext.BackgroundColor(Color.Transparent);
                    drawRect(imageContext, new PointF(10, 10), new Point(door.W, door.H));
                    if (door.NavesCount != null)
                        drawNaves(imageContext, new PointF(door.Open == OpenType.Left ? door.W + 10 : 10, 10), door.H, door.NavesCount ?? 0);
                    if (door.S == null)
                    {

                    }
                    if (door.S != null)
                    {
                        drawRect(imageContext, new PointF(door.Open == OpenType.Left ? 10 : 10 + door.W - (door.S ?? 0), 10), new Point(door.S ?? 0, door.H));

                    }
                    //Ручка открывания
                    float doorlockX = door.Open == OpenType.Left ? 20 + (door.S ?? 0) : door.W - 10 - (door.S ?? 0);
                    imageContext.DrawLines(linePen, new PointF[] {
                            new PointF(doorlockX,3*door.H/8),
                            new PointF(doorlockX,2*door.H/8+3*door.H/8),
                        });
                    if (door.FramugaH != null)
                        drawRect(imageContext, new PointF(10, door.H + 10), new Point(door.W, door.FramugaH ?? 0));
                    imageContext.Flip(FlipMode.Vertical);
                    //imageContext.Rotate(180);
                });
                string rootpath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "uploads","1.png");
                img.SaveAsPng(rootpath);
            };
        }

        private static void drawRect(IImageProcessingContext context, PointF start, PointF size)
        {
            context.DrawLines(linePen, new[] { 
                new PointF(x: start.X, y: start.Y),
                new PointF(x: start.X, y: start.Y+size.Y),
                new PointF(x: start.X+size.X, y: start.Y + size.Y),
                new PointF(x: start.X+size.X, y: start.Y),
                new PointF(x: start.X, y: start.Y)
            });
        }

        private static void drawNaves(IImageProcessingContext context, PointF start, int height, int count)
        {
            for(int i=1;i<=count; i++)
            {
                float startHeight = start.Y + height / (count +1) * i;
                context.DrawLines(linePen, new PointF[] {
                    new PointF(start.X - 5, startHeight-5),
                    new PointF(start.X + 5, startHeight+5)
                });
                context.DrawLines(linePen, new PointF[] {
                    new PointF(start.X - 5, startHeight+5),
                    new PointF(start.X + 5, startHeight-5)
                });
            }
        }

        private class Door
        {
            public int H { get; set; }
            public int W { get; set; }
            public int? S { get; set; }
            public bool SEqual { get; set; }
            public OpenType Open { get; set; } = OpenType.Left;
            public NalichnikType Nalichnik { get; set; } = NalichnikType.No;
            public DovodType Dovod { get; set; } = DovodType.No;
            public int? NavesCount { get; set; }
            public int? NavesStvorkaCount { get; set; }
            public int? WindowCount { get; set; }
            public int? WindowStvorkaCount { get; set; }
            public bool Framuga { get; set; }
            public int? FramugaH { get; set; }

            public Door(OrderDoor orderDoor)
            {
                H = orderDoor.H;
                W = orderDoor.W;
                S = orderDoor.S;
                SEqual = orderDoor.SEqual;
                Open = orderDoor.Open;
                Nalichnik = orderDoor.Nalichnik;
                Dovod = orderDoor.Dovod;
                NavesCount = orderDoor.NavesCount;
                NavesStvorkaCount = orderDoor.NavesStvorkaCount;
                WindowCount = orderDoor.WindowCount;
                WindowStvorkaCount = orderDoor.WindowStvorkaCount;
                Framuga = orderDoor.Framuga;
                FramugaH = orderDoor.FramugaH;
            }
        }
    }
}
