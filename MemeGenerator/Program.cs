using System;
using System.Drawing;

namespace MemeGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            string inputImage = "";
            string outputImage = "meme.jpg";
            string topText = "";
            string bottomText = "";
            string fontColor = "#ffffff";
            int fontSize = 24;

            try
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] == "--image" || args[i] == "-i")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            inputImage = args[i + 1];
                        }
                    }

                    if (args[i] == "--out" || args[i] == "-o")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            outputImage = args[i + 1];
                        }
                    }

                    if (args[i] == "--top" || args[i] == "-t")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            topText = args[i + 1];
                            topText = topText.Replace("\\n", Environment.NewLine);
                            topText = topText.ToUpper();
                        }
                    }

                    if (args[i] == "--bottom" || args[i] == "-b")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            bottomText = args[i + 1];
                            bottomText = bottomText.Replace("\\n", Environment.NewLine);
                            bottomText = bottomText.ToUpper();
                        }
                    }

                    if (args[i] == "--size" || args[i] == "-s")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            fontSize = Convert.ToInt32(args[i + 1]);
                        }
                    }

                    if (args[i] == "--color" || args[i] == "-c")
                    {
                        if (args[i + 1].IndexOf("-") != 0)
                        {
                            fontColor = args[i + 1];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong arguments {Environment.NewLine} {ex.ToString()}");
                return -2;
            }

            if (inputImage == "")
            {
                Console.WriteLine("Not specified input image");
                return -1;
            }

            if (topText == "" && bottomText == "")
            {
                Console.WriteLine("Not specified text");
                return -1;
            }

            Bitmap bitmap = new Bitmap(inputImage);
            Graphics graphics = Graphics.FromImage(bitmap);
            Font font = new Font("Impact", fontSize, FontStyle.Bold);
            Rectangle rectangle = new Rectangle(0, fontSize / 3, bitmap.Width, bitmap.Height - fontSize/2);
            StringFormat stringFormat = new StringFormat();
            Color color = ColorTranslator.FromHtml(fontColor);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Near;
            graphics.DrawString(topText, font, new SolidBrush(color), rectangle, stringFormat);

            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Far;
            graphics.DrawString(bottomText, font, new SolidBrush(color), rectangle, stringFormat);

            bitmap.Save(outputImage);

            return 0;
        }
    }
}
