using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Drawing.Text;

namespace Playbook_Editor
{
    #region Classes

    public class PSALroute
    {
        public class Steps
        {
            public int rec { get; set; }
            public int code { get; set; }
            public int val1 { get; set; }
            public int val2 { get; set; }
            public int val3 { get; set; }
            public int PSAL { get; set; }
            public int step { get; set; }
            public int PLRR { get; set; }
            public int ARTL { get; set; }

            public Steps DeepCopy()
            {
                Steps other = (Steps)MemberwiseClone();
                return other;
            }

            public override string ToString()
            {
                return
                    "Rec#: " + rec +
                    "   code: " + code +
                    "   val1: " + val1 +
                    "   val2: " + val2 +
                    "   val3: " + val3 +
                    "   PSAL: " + PSAL +
                    "   step: " + step +
                    "   PLRR: " + PLRR;
            }
        }

        public bool Highlighted;
        public string Position;
        public int ID;
        public int PLRR;
        public int ARTL;
        public Color routeColor = Color.Black;
        public double AngleRatio = 0.35556;
        public XY playerXY;
        public int startIndex, endIndex;
        public List<SETP> SETP;
        public List<Steps> steps;
        public List<XY> route;
        public List<XY> routeOption1;
        public List<XY> routeOption2;
    }

    public class XY
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ID
    {
        public ushort id { get; set; }
        public string Name { get; set; }
    }

    public class Formation
    {
        public ID FORM { get; set; }
        public ID SETL { get; set; }
        public Point poso0 { get; set; }
        public Point poso1 { get; set; }
        public Point poso2 { get; set; }
        public Point poso3 { get; set; }
        public Point poso4 { get; set; }
        public Point poso5 { get; set; }
        public Point poso6 { get; set; }
        public Point poso7 { get; set; }
        public Point poso8 { get; set; }
        public Point poso9 { get; set; }
        public Point poso10 { get; set; }
    }

    public class TableNames
    {
        public int rec { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return "Rec#: " + rec + "   Name: " + name;
        }
    }

    public class CPFM
    {
        public int rec { get; set; }
        public int FORM { get; set; }
        public int FTYP { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   FORM: " + FORM +
                "   FTYP: " + FTYP +
                "   Name: " + name;
        }
    }

    public class SETL
    {
        public int rec { get; set; }
        public int setl { get; set; }
        public int FORM { get; set; }
        public int MOTN { get; set; }
        public int CLAS { get; set; }
        public int SETT { get; set; }
        public int SITT { get; set; }
        public int SLF_ { get; set; }
        public string name { get; set; }
        public int poso { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   SETL: " + setl +
                "   FORM: " + FORM +
                "   MOTN: " + MOTN +
                "   CLAS: " + CLAS +
                "   SETT: " + SETT +
                "   SITT: " + SITT +
                "   SLF_: " + SLF_ +
                "   Name: " + name +
                "   poso: " + poso;
        }
    }

    public class PBPL
    {
        public int rec { get; set; }
        public int COMF { get; set; }
        public int SETL { get; set; }
        public int PLYL { get; set; }
        public int SRMM { get; set; }
        public int SITT { get; set; }
        public int PLYT { get; set; }
        public int PLF_ { get; set; }
        public string name { get; set; }
        public int risk { get; set; }
        public int motn { get; set; }
        public int vpos { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   COMF: " + COMF +
                "   SETL: " + SETL +
                "   PLYL: " + PLYL +
                "   SRMM: " + SRMM +
                "   SITT: " + SITT +
                "   PLYT: " + PLYT +
                "   PLF_: " + PLF_ +
                "   Name: " + name +
                "   risk: " + risk +
                "   motn: " + motn +
                "   vpos: " + vpos;
        }
    }

    public class PLPD
    {
        public int rec { get; set; }
        public int com1 { get; set; }
        public int con1 { get; set; }
        public int per1 { get; set; }
        public int rcv1 { get; set; }
        public int com2 { get; set; }
        public int con2 { get; set; }
        public int per2 { get; set; }
        public int rcv2 { get; set; }
        public int com3 { get; set; }
        public int con3 { get; set; }
        public int per3 { get; set; }
        public int rcv3 { get; set; }
        public int com4 { get; set; }
        public int con4 { get; set; }
        public int per4 { get; set; }
        public int rcv4 { get; set; }
        public int com5 { get; set; }
        public int con5 { get; set; }
        public int per5 { get; set; }
        public int rcv5 { get; set; }
        public int PLYL { get; set; }
    }

    public class PLRD
    {
        public int rec { get; set; }
        public int PLYL { get; set; }
        public int hole { get; set; }
    }

    public class PLYS : IEquatable<PLYS>
    {
        public int rec { get; set; }
        public int PSAL { get; set; }
        public int ARTL { get; set; }
        public int PLYL { get; set; }
        public int PLRR { get; set; }
        public int poso { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   PSAL: " + PSAL +
                "   ARTL: " + ARTL +
                "   PLYL: " + PLYL +
                "   PLRR: " + PLRR +
                "   poso: " + poso;
        }

        public bool Equals(PLYS other)
        {
            //Check whether the compared object is null. 
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (ReferenceEquals(this, other)) return true;

            //Check whether the PSAL IDs are equal. 
            return PSAL.Equals(other.PSAL);
        }

        // If Equals() returns true for a pair of objects then GetHashCode() must return the same value for these objects. 

        public override int GetHashCode()
        {
            //Get hash code for the Code field. 
            int hashPSALID = PSAL.GetHashCode();

            //Calculate the hash code for the product. 
            return hashPSALID;
        }
    }

    public class SETP
    {
        public int rec { get; set; }
        public int SETL { get; set; }
        public int setp { get; set; }
        public int SGT_ { get; set; }
        public int arti { get; set; }
        public int opnm { get; set; }
        public int tabo { get; set; }
        public int poso { get; set; }
        public int odep { get; set; }
        public int flas { get; set; }
        public int DPos { get; set; }
        public int EPos { get; set; }
        public int fmtx { get; set; }
        public int artx { get; set; }
        public int fmty { get; set; }
        public int arty { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   SETL: " + SETL +
                "   setp: " + setp +
                "   SGT_: " + SGT_ +
                "   arti: " + arti +
                "   opnm: " + opnm +
                "   tabo: " + tabo +
                "   poso: " + poso +
                "   odep: " + odep +
                "   flas: " + flas +
                "   DPos: " + DPos +
                "   EPos: " + EPos +
                "   fmtx: " + fmtx +
                "   artx: " + artx +
                "   fmty: " + fmty +
                "   arty: " + arty;
        }
    }

    public class SETG
    {
        public int rec { get; set; }
        public int SETP { get; set; }
        public int SGF_ { get; set; }
        public int SF__ { get; set; }
        public float x___ { get; set; }
        public float y___ { get; set; }
        public float fx__ { get; set; }
        public float fy__ { get; set; }
        public int anm_ { get; set; }
        public int dir_ { get; set; }
        public int fanm { get; set; }
        public int fdir { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   SETP: " + SETP +
                "   SGF_: " + SGF_ +
                "   SF__: " + SF__ +
                "   x___: " + x___ +
                "   y___: " + y___ +
                "   fx__: " + fx__ +
                "   fy__: " + fy__ +
                "   anm_: " + anm_ +
                "   dir_: " + dir_ +
                "   fanm: " + fanm +
                "   fdir: " + fdir;
        }
    }

    public class SGFF
    {
        public int rec { get; set; }
        public int SETL { get; set; }
        public int SGF_ { get; set; }
        public string name { get; set; }
        public int dflt { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   SETL: " + SETL +
                "   SGF_: " + SGF_ +
                "   Name: " + name +
                "   dflt: " + dflt;
        }
    }

    public struct PLAY
    {
        public List<PBPL> PBPL { get; set; }
        public List<PLPD> PLPD { get; set; }
        public List<PLRD> PLRD { get; set; }
        public List<PLYS> PLYS { get; set; }
        public List<SETP> SETP { get; set; }
        public List<SETG> SETG { get; set; }
        public List<SGFF> SGFF { get; set; }
        public PSALroute poso0 { get; set; }
        public PSALroute poso1 { get; set; }
        public PSALroute poso2 { get; set; }
        public PSALroute poso3 { get; set; }
        public PSALroute poso4 { get; set; }
        public PSALroute poso5 { get; set; }
        public PSALroute poso6 { get; set; }
        public PSALroute poso7 { get; set; }
        public PSALroute poso8 { get; set; }
        public PSALroute poso9 { get; set; }
        public PSALroute poso10 { get; set; }
    }

    public class PSAL : IEquatable<PSAL>
    {
        public int rec { get; set; }
        public int val1 { get; set; }
        public int val2 { get; set; }
        public int val3 { get; set; }
        public int psal { get; set; }
        public int code { get; set; }
        public int step { get; set; }

        public override string ToString()
        {
            return
                "Rec#: " + rec +
                "   val1: " + val1 +
                "   val2: " + val2 +
                "   val3: " + val3 +
                "   psal: " + psal +
                "   code: " + code +
                "   step: " + step;
        }

        public bool Equals(PSAL other)
        {
            //Check whether the compared object is null. 
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (ReferenceEquals(this, other)) return true;

            //Check whether the PSAL IDs are equal. 
            return psal.Equals(other.psal);
        }

        // If Equals() returns true for a pair of objects then GetHashCode() must return the same value for these objects. 

        public override int GetHashCode()
        {
            //Get hash code for the Code field. 
            int hashPSALID = psal.GetHashCode();

            //Calculate the hash code for the product. 
            return hashPSALID;
        }
    }

    public class PLRR : IEquatable<PLRR>
    {
        public int psal { get; set; }
        public int plrr { get; set; }
        public int artl { get; set; }
        public string type { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return
                "psal: " + psal +
                "   plrr: " + plrr +
                "   artl: " + artl +
                "   type: " + type +
                "   name: " + name;
        }

        public bool Equals(PLRR other)
        {
            //Check whether the compared object is null. 
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data. 
            if (ReferenceEquals(this, other)) return true;

            //Check whether the PSAL IDs are equal. 
            return plrr.Equals(other.plrr);
        }

        // If Equals() returns true for a pair of objects then GetHashCode() must return the same value for these objects. 

        public override int GetHashCode()
        {
            //Get hash code for the Code field. 
            int hashPSALID = plrr.GetHashCode();

            //Calculate the hash code for the product. 
            return hashPSALID;
        }
    }

    public static class PLRRname
    {
        public static IDictionary<int, string> PLRRnameDic = new Dictionary<int, string>()
        {
            { 1, "PASS BLOCK" },
            { 2, "RUN BLOCK" },
            { 24, "FIELD GOAL" },
            { 25, "FIELD GOAL SHOVEL" },
            { 26, "BLOCK" },
            { 27, "ONSIDE KICK" },
            { 28, "SQUIB KICK" },
            { 29, "PUNT" },
            { 30, "FAKE PUNT PASS" },
            { 31, "FAKE PUNT SWEEP" },
            { 32, "QB RUN" },
            { 33, "FAKE FG SHOVEL" },
            { 34, "FAKE FG HOLDER BLAST" },
            { 35, "FAKE SPIKE" },
            { 36, "FAKE FG FLIP PASS" },
            { 37, "FAKE FG DIRECT SNAP" },
            { 38, "QB KNEEL" },
            { 39, "QB OPTION" },
            { 40, "QB DROPBACK" },
            { 41, "QB PLAY ACTION" },
            { 43, "QB OPTION" },
            { 44, "QB SHOVEL/SPEED OPTION" },
            { 45, "SPIKE BALL" },
            { 47, "HB RUN POWER O" },
            { 48, "HB RUN DIVE" },
            { 49, "HB RUN DRAW" },
            { 50, "HB RUN DRAW BUBBLE" },
            { 52, "FAKE PUNT FB OFF TACKLE" },
            { 53, "HB RUN TRIPLE OPTION" },
            { 54, "HB RUN READ OPTION" },
            { 55, "HB PASS PHILLY SPECIAL" },
            { 56, "HB RUN ZONE" },
            { 57, "HB RUN STRETCH" },
            { 58, "HB RUN TOSS" },
            { 60, "POST CORNER/CORNER POST" },
            { 61, "COMEBACK" },
            { 62, "POST/CORNER" },
            { 63, "SLANT" },
            { 64, "POST CORNER/CORNER POST" },
            { 65, "DEEP CURL" },
            { 66, "POST/CORNER" },
            { 67, "CROSS" },
            { 68, "CURL" },
            { 69, "CURL" },
            { 70, "CURL N GO" },
            { 71, "DRAG" },
            { 72, "FLAT LEFT" },
            { 73, "FLAT RIGHT" },
            { 74, "HITCH" },
            { 75, "HITCH N GO" },
            { 76, "IN/OUT" },
            { 77, "IN/OUT" },
            { 78, "OUT N GO/IN N GO" },
            { 79, "SHORT IN/OUT" },
            { 80, "OPTION" },
            { 81, "IN/OUT" },
            { 82, "IN/OUT" },
            { 83, "OUT N UP/IN N UP" },
            { 85, "SHORT IN/SHORT OUT" },
            { 86, "POCO/COPO" },
            { 87, "POST/CORNER/POCO/COPO" },
            { 88, "POST/CORNER" },
            { 89, "POST SIT/CORNER SIT" },
            { 90, "HB ANGLE" },
            { 91, "HB IN/OUT" },
            { 92, "HB OUT/IN" },
            { 93, "SCREEN" },
            { 94, "HB FLAT LEFT" },
            { 95, "HB FLAT RIGHT" },
            { 96, "SHORT SLANT" },
            { 97, "SLUGGO" },
            { 98, "STREAK/FADE/SEAM" },
            { 99, "ORBIT" },
            { 100, "HB SWING RIGHT" },
            { 101, "HB WHEEL" },
            { 102, "WHEEL" },
            { 103, "TRAIL/SHAKE" },
            { 104, "WHIP" },
            { 105, "KICK RETURN" },
            { 106, "KICKOFF" },
            { 107, "KICK RETURN" },
            { 108, "PUNT RETURN" },
            { 111, "QB DROPBACK" },
            { 112, "QB SNEAK" },
            { 113, "QB TOSS" },
            { 115, "DELAY LEFT" },
            { 116, "DELAY RIGHT" },
            { 118, "DELAY GO" },
            { 119, "DELAY RIGHT" },
            { 121, "DELAY RIGHT" },
            { 123, "HB DELAY HITCH" },
            { 124, "HB DELAY HITCH" },
            { 125, "HB DELAY ANGLE" },
            { 126, "SPOT/SIT ROUTE" },
            { 127, "PUNT" },
            { 130, "JETSWEEP/END AROUND" },
            { 131, "FK END AROUND" },
            { 138, "ONSIDE KICK" },
            { 139, "ONSIDE RECOVER" },
            { 141, "GOAL LINE FADE" }
        };
    }

    public class MyRenderer : ToolStripProfessionalRenderer
    {
        public MyRenderer() : base(new MyColors()) { }
    }

    public class MyColors : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.Yellow; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(0, Color.Yellow); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.Yellow; }
        }
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(0, Color.Yellow); }
        }

    } 

    #endregion

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmPlaybook());
        }

        public static void drawPlayerCircle(Graphics g, Color color, PSALroute PSAL, int playerSize)
        {
            //define basic player circle
            SolidBrush sb = new SolidBrush(color);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //define text properties
            StringFormat format = new StringFormat(){Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center};

            try
            {
                if (PSAL.Position == "C")
                {
                    g.FillRectangle(sb, (int)(PSAL.playerXY.X - (playerSize / 2)), (int)(PSAL.playerXY.Y - (playerSize / 2)), playerSize, playerSize);
                }
                else
                {
                    g.FillEllipse(sb, (int)(PSAL.playerXY.X - (playerSize / 2)), (int)(PSAL.playerXY.Y - (playerSize / 2)), playerSize, playerSize);
                }

                if (PSAL.Position.Length == 1)
                {
                    if (PSAL.Position == "T")
                    {
                        g.DrawString(PSAL.Position, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, (float)(PSAL.playerXY.X + .5), (float)(PSAL.playerXY.Y + 1.5), format);
                    }
                    else
                    {
                        g.DrawString(PSAL.Position, new Font("Tahoma", 12, FontStyle.Bold), Brushes.Black, (float)(PSAL.playerXY.X + .5), PSAL.playerXY.Y + 1, format);
                    }
                }
                else
                {
                    g.DrawString(PSAL.Position, new Font("Tahoma", 12, FontStyle.Bold), Brushes.White, PSAL.playerXY.X, PSAL.playerXY.Y + (int)(playerSize * 1.35), format);
                }
            }
            catch
            {
                g.FillEllipse(sb, (int)(PSAL.playerXY.X - (playerSize / 2)), (int)(PSAL.playerXY.Y - (playerSize / 2)), playerSize, playerSize);
            }

            sb.Dispose();
        }

        public static void drawPlayerHighlight(Graphics g, Color color, PSALroute PSAL, int playerSize)
        {
            //define highlighted player gradient ellipse
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse((int)(PSAL.playerXY.X - (playerSize * 5 / 2)), (int)(PSAL.playerXY.Y - (playerSize * 5 / 2)), playerSize * 5, playerSize * 5);
            PathGradientBrush pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = Color.FromArgb(255, 64, 0, 255);
            Color[] colors = { Color.FromArgb(0, 0, 0, 0) };
            pthGrBrush.SurroundColors = colors;

            if (PSAL.Highlighted)
            {
                g.FillEllipse(pthGrBrush, (int)(PSAL.playerXY.X - (playerSize * 5 / 2)), (int)(PSAL.playerXY.Y - (playerSize * 5 / 2)), playerSize * 5, playerSize * 5);
            }

            path.Dispose();
            pthGrBrush.Dispose();
        }

        public static void drawRoute(Graphics g, PSALroute PSAL)
        {
            //define route line
            Pen pen = new Pen(PSAL.routeColor, 5);
            pen.LineJoin = LineJoin.Round;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;

            //define blocking endcap
            GraphicsPath blockingPath = new GraphicsPath();
            blockingPath.AddLine((float)-1.4, 0, (float)1.4, 0);
            CustomLineCap blockingEndCap = new CustomLineCap(null, blockingPath);

            // create AdjustableArrowCap or no end cap if blocking
            if (!(PSAL.routeColor.R == 160) && !(PSAL.routeColor.G == 160) && !(PSAL.routeColor.B == 160))
            {
                pen.CustomEndCap = new AdjustableArrowCap(3, 4);
            }
            else
            {
                pen.CustomEndCap = blockingEndCap;
            }

            //draw PSAL
            try
            {
                if (PSAL.route.Count > 1)
                {
                    g.DrawLines(pen, XYtoPoint(PSAL.route));
                }

                //draw option route 1
                if (!(PSAL.routeOption1 == null))
                {
                    pen.Color = Color.FromArgb(128, pen.Color.R, pen.Color.G, pen.Color.B);
                    g.DrawLines(pen, XYtoPoint(PSAL.routeOption1));
                }

                //draw option route 2
                if (!(PSAL.routeOption2 == null))
                {
                    pen.Color = Color.FromArgb(128, pen.Color.R, pen.Color.G, pen.Color.B);
                    g.DrawLines(pen, XYtoPoint(PSAL.routeOption2));
                }
            }
            catch
            {
            }

            pen.Dispose();
        }

        public static PSALroute convertPSAL(PSALroute PSAL, Point LOS)
        {
            //translate the PSAL vals to XY in pixels based on the player position and define the route color
            PSAL.route = new List<XY>();
            PSAL.route.Add(PSAL.playerXY);

            for (int i = 0; i < PSAL.steps.Count; i++)
            {
                switch (PSAL.steps[i].code)
                {
                    case 1:
                        #region Run To Endzone

                        //PSAL.steps.RemoveAt(i);
                        //i--;
                        break;

                    #endregion

                    case 2:
                        #region Chase Ball?

                        break;

                    #endregion

                    case 3:
                        #region MoveDirDist

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        if (PSAL.routeColor.Name == "Black")
                        {
                            PSAL.routeColor = Color.FromArgb(255, 191, 181, 84);
                        }
                        break;

                    #endregion

                    case 4:
                        #region MoveDirDistConst

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        if (PSAL.routeColor.Name == "Black")
                        {
                            PSAL.routeColor = Color.FromArgb(255, 191, 181, 84);
                        }
                        break;

                    #endregion

                    case 5:
                        #region Face Direction

                        break;

                    #endregion

                    case 7:
                        #region QB Scramble

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 33, 255, 131);
                        break;

                    #endregion

                    case 8:
                        #region Receiver Run Route

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        if (PSAL.route[PSAL.route.Count - 1].X < 50 || PSAL.route[PSAL.route.Count - 1].X > 483)
                        {
                            PSAL.route[PSAL.route.Count - 1] = (MoveDirDistToXY(60, PSAL.steps[i].val2, PSAL.AngleRatio));
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //assign route color
                        if (PSAL.routeColor.Name == "Black")
                        {
                            PSAL.routeColor = Color.FromArgb(255, 191, 181, 84);
                        }
                        break;

                    #endregion

                    case 9:
                        #region Receiver Cut Move
                        //1 = 45 degrees
                        if (PSAL.steps[i].val2 == 1)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (45 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (45 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //2 = 90 degrees
                        if (PSAL.steps[i].val2 == 2)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (90 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (90 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //3 = 22 degrees
                        if (PSAL.steps[i].val2 == 3)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (22 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (22 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //4 = 67 degrees
                        if (PSAL.steps[i].val2 == 4)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //5 = Curl
                        if (PSAL.steps[i].val2 == 5)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (135 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (135 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //7 = HitchComback, 8 = HitchGoIn and 9 = HitchGoOut
                        if (PSAL.steps[i].val2 == 7 || PSAL.steps[i].val2 == 8 || PSAL.steps[i].val2 == 9)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 - (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 + (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //10 = OutAndUp
                        if (PSAL.steps[i].val2 == 10)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 - (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(PSAL.steps[i - 1].val2 + (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //11 = Smash and 17 = SmashQuick
                        if (PSAL.steps[i].val2 == 11 || PSAL.steps[i].val2 == 17)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(-10 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(190 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //13 = WRScrn
                        if (PSAL.steps[i].val2 == 13)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(-15 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(195 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };

                            //assign route color
                            if (PSAL.routeColor.Name == "Black")
                            {
                                PSAL.routeColor = Color.FromArgb(255, 191, 181, 84);
                            }
                        }

                        //14 = 90Inside
                        if (PSAL.steps[i].val2 == 14)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(0 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(180 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //16 = 180Partial
                        if (PSAL.steps[i].val2 == 16)
                        {
                            PSAL.route.Add(MoveDirDistToXY(24, (int)(270 * PSAL.AngleRatio), PSAL.AngleRatio));
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //18 = Hitch
                        if (PSAL.steps[i].val2 == 18)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(PSAL.steps[i - 1].val2 - (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(PSAL.steps[i - 1].val2 + (105 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //20 = ShakeCut
                        if (PSAL.steps[i].val2 == 20)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 + (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 - (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //21 = StutterCut
                        if (PSAL.steps[i].val2 == 21)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 - (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(8, (int)(PSAL.steps[i - 1].val2 + (67 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //22 = HingeCut
                        if (PSAL.steps[i].val2 == 22)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(145 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(32, (int)(35 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //23 = PostCorner
                        if (PSAL.steps[i].val2 == 23)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(48, (int)(PSAL.steps[i - 1].val2 + (45 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(48, (int)(PSAL.steps[i - 1].val2 - (45 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //25 = StutterStreak
                        if (PSAL.steps[i].val2 == 25)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(4, (int)(PSAL.steps[i - 1].val2 + (90 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(4, (int)(PSAL.steps[i - 1].val2 - (90 * PSAL.AngleRatio)), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //26 = WR Swing
                        if (PSAL.steps[i].val2 == 26)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(-35 * PSAL.AngleRatio), PSAL.AngleRatio));
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                                //PSAL.steps[i].val2 = (int)(-35 * PSAL.AngleRatio);
                                i++;
                                PSAL.steps.Insert(i, PSAL.steps[i - 1].DeepCopy());

                                PSAL.route.Add(MoveDirDistToXY(24, (int)(0 * PSAL.AngleRatio), PSAL.AngleRatio));
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(215 * PSAL.AngleRatio), PSAL.AngleRatio));
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                                //PSAL.steps[i].val2 = (int)(215 * PSAL.AngleRatio);
                                i++;
                                PSAL.steps.Insert(i, PSAL.steps[i - 1].DeepCopy());

                                PSAL.route.Add(MoveDirDistToXY(24, (int)(180 * PSAL.AngleRatio), PSAL.AngleRatio));
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                            }
                        }

                        //28 = Sluggo
                        if (PSAL.steps[i].val2 == 28)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(22 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(158 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        //29 = Out n Up
                        if (PSAL.steps[i].val2 == 29)
                        {
                            if (PSAL.steps[i].val1 == 1)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(180 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            else if (PSAL.steps[i].val1 == 2)
                            {
                                PSAL.route.Add(MoveDirDistToXY(24, (int)(0 * PSAL.AngleRatio), PSAL.AngleRatio));
                            }
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }

                        break;
                    #endregion

                    case 10:
                        #region Receiver Get Open

                        break;

                    #endregion

                    case 11:
                        #region Pitch Ball?

                        break;

                    #endregion

                    case 12:
                        #region Option Handoff

                        break;

                    #endregion

                    case 13:
                        #region Receive Hand Off

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 202, 48, 84);
                        break;

                    #endregion

                    case 14:
                        #region PassBlock

                        if (PSAL.steps[i].val1 == 0)
                        {
                            //assign route color
                            PSAL.routeColor = Color.FromArgb(255, 160, 160, 160);

                            //manual offset of 2 yards back
                            if (i == 0)
                            {
                                PSAL.route.Add(MoveDirDistToXY(16, 96, PSAL.AngleRatio));
                                //convert to offest
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                            }
                        }
                        else
                        {
                            PSAL.route.Add(PSAL.route[PSAL.route.Count - 1]);

                            //assign route color
                            PSAL.routeColor = Color.FromArgb(255, 59, 106, 233);
                        }

                        break;

                    #endregion

                    case 15:
                        #region RunBlock

                        if (PSAL.steps[i].val1 == 0)
                        {
                            //assign route color
                            PSAL.routeColor = Color.FromArgb(255, 160, 160, 160);

                            //manual offset of 2 yards forward
                            if (i == 0)
                            {
                                PSAL.route.Add(MoveDirDistToXY(16, 32, PSAL.AngleRatio));
                                //convert to offest
                                PSAL.route[PSAL.route.Count - 1] = new XY
                                {
                                    X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                    Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                                };
                            }
                        }
                        else
                        {
                            PSAL.route.Add(PSAL.route[PSAL.route.Count - 1]);

                            //assign route color
                            PSAL.routeColor = Color.FromArgb(255, 59, 106, 233);
                        }

                        break;

                    #endregion

                    case 16:
                        #region Kickoff?

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 202, 48, 84);
                        break;

                    #endregion

                    case 18:
                        #region LeadBlock

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 160, 160, 160);
                        break;

                    #endregion

                    case 25:
                        #region Delay

                        break;

                    #endregion

                    case 26:
                        #region Initial Anim

                        if (PSAL.steps[i].val1 == 1 || PSAL.steps[i].val1 == 4 || PSAL.steps[i].val1 == 5 || PSAL.steps[i].val1 == 6)
                        {
                            //convert to offest
                            PSAL.route.Add(MoveDirDistToXY(16, PSAL.steps[i].val2, PSAL.AngleRatio));
                            PSAL.route[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                                Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                            };
                        }
                        else
                        {
                            //PSAL.steps.RemoveAt(i);
                            //i--;
                        }

                        //assign route color
                        if (PSAL.routeColor.Name == "Black")
                        {
                            PSAL.routeColor = Color.FromArgb(255, 191, 181, 84);
                        }
                        break;

                    #endregion

                    case 27:
                        #region Punt?

                        break;

                    #endregion

                    case 28:
                        #region FG Spot?

                        break;

                    #endregion

                    case 29:
                        #region FG Kick?

                        break;

                    #endregion

                    case 30:
                        #region Stop Clock?

                        break;

                    #endregion

                    case 31:
                        #region Kneel?

                        break;

                    #endregion

                    case 32:
                        #region Receive Pitch

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 202, 48, 84);
                        break;

                    #endregion

                    case 35:
                        #region Head Turn Run Route

                        //convert to offest
                        PSAL.route.Add(MoveDirDistToXY(PSAL.steps[i].val1, PSAL.steps[i].val2, PSAL.AngleRatio));
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };
                        break;

                    #endregion

                    case 36:
                        #region Option Route

                        //Option Route Base
                        PSAL.route.Add(getOptionOffset(PSAL.steps[i].val1, PSAL.AngleRatio));

                        //Option route 1
                        PSAL.routeOption1 = new List<XY>(PSAL.route);
                        PSAL.routeOption1[PSAL.routeOption1.Count - 1] = getOptionOffset(PSAL.steps[i].val2, PSAL.AngleRatio);
                        PSAL.routeOption1[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.routeOption1[PSAL.routeOption1.Count - 2].X + PSAL.routeOption1[PSAL.routeOption1.Count - 1].X,
                            Y = PSAL.routeOption1[PSAL.routeOption1.Count - 2].Y + PSAL.routeOption1[PSAL.routeOption1.Count - 1].Y
                        };

                        //Option route 2
                        if (!(PSAL.steps[i].val3 == 255))
                        {
                            PSAL.routeOption2 = new List<XY>(PSAL.route);
                            PSAL.routeOption2[PSAL.routeOption2.Count - 1] = getOptionOffset(PSAL.steps[i].val3, PSAL.AngleRatio);
                            PSAL.routeOption2[PSAL.route.Count - 1] = new XY
                            {
                                X = PSAL.routeOption2[PSAL.routeOption2.Count - 2].X + PSAL.routeOption2[PSAL.routeOption2.Count - 1].X,
                                Y = PSAL.routeOption2[PSAL.routeOption2.Count - 2].Y + PSAL.routeOption2[PSAL.routeOption2.Count - 1].Y
                            };
                        }

                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = PSAL.route[PSAL.route.Count - 2].X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = PSAL.route[PSAL.route.Count - 2].Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        break;

                    #endregion

                    case 37:
                        #region Option Route Extra Info

                        break;

                    #endregion

                    case 38:
                        #region Handoff Turn?

                        break;

                    #endregion

                    case 39:
                        #region Handoff Give?

                        break;

                    #endregion

                    case 40:
                        #region Option Run?

                        break;

                    #endregion

                    case 42:
                        #region Hand Off Fake?

                        break;

                    #endregion

                    case 43:
                        #region Option Follow

                        break;

                    #endregion

                    case 45:
                        #region Auto Motion

                        //convert to offest
                        PSAL.route.Add( new XY { X = (int)(PSAL.steps[i].val1 / 5.6667 * 10), Y = (int)(Math.Abs(PSAL.steps[i].val2 / 5.6667 * 10)) } );
                        PSAL.route[PSAL.route.Count - 1] = new XY
                        {
                            X = LOS.X + PSAL.route[PSAL.route.Count - 1].X,
                            Y = LOS.Y + PSAL.route[PSAL.route.Count - 1].Y
                        };

                        //assign route color
                        PSAL.routeColor = Color.FromArgb(255, 161, 233, 238);
                        break;

                    #endregion

                    case 46:
                        #region Auto Motion Snap

                        break;

                    #endregion

                    case 48:
                        #region Player offset

                        PSAL.playerXY.X = LOS.X + (int)(PSAL.steps[i].val1 / 5.6667 * 10);
                        PSAL.playerXY.Y = LOS.Y + Math.Abs((int)(PSAL.steps[i].val2 / 5.6667 * 10));

                        PSAL.route[0] = new XY { X = PSAL.playerXY.X, Y = PSAL.playerXY.Y };

                        //PSAL.route.Add(new XY
                        //{
                        //    X = PSAL.route[PSAL.route.Count - 1].X + (int)(PSAL.steps[i].val1 / 5.6667),
                        //    Y = PSAL.route[PSAL.route.Count - 1].Y + (int)(PSAL.steps[i].val2 / -8.3)
                        //};

                        break;

                    #endregion

                    case 58:
                        #region Animation

                        break;

                    #endregion

                    case 255:
                        #region End of Route

                        break;

                        #endregion
                }
            }

            return PSAL;
        }

        public static XY MoveDirDistToXY(int dist, int dir, double angleRatio)
        {
            double angle = Math.PI * (dir / angleRatio) / 180.0;
            double sinAngle = Math.Sin(angle);
            double cosAngle = Math.Cos(angle);

            if (dist > 128)
            {
                dist = (int)(dist * .5);
            }

            return new XY
            {
                X = (int)(cosAngle * (dist / .8)),
                Y = (int)(sinAngle * (dist / .8)) * -1
            };
        }

        public static XY getOptionOffset(int code, double angleRatio)
        {
            if (code == 0)     //Curl left
            {
                return MoveDirDistToXY(32, (int)(225 * angleRatio), angleRatio);
            }

            if (code == 1)    //Curl right
            {
                return MoveDirDistToXY(32, (int)(-45 * angleRatio), angleRatio);
            }

            if (code == 2)    //Post right
            {
                return MoveDirDistToXY(90, (int)(45 * angleRatio), angleRatio);
            }

            if (code == 3)    //Corner left
            {
                return MoveDirDistToXY(90, (int)(135 * angleRatio), angleRatio);
            }

            if (code == 5)     //Slant right
            {
                return MoveDirDistToXY(90, (int)(33 * angleRatio), angleRatio);
            }

            if (code == 6)    //Fade/Streak left
            {
                return MoveDirDistToXY(90, (int)(93 * angleRatio), angleRatio);
            }

            if (code == 7)    //Slant left
            {
                return MoveDirDistToXY(90, (int)(147 * angleRatio), angleRatio);
            }

            if (code == 8)    //Fade/Streak right
            {
                return MoveDirDistToXY(90, (int)(87 * angleRatio), angleRatio);
            }

            if (code == 9)     //In/Out right
            {
                return MoveDirDistToXY(90, (int)(0 * angleRatio), angleRatio);
            }

            if (code == 10)    //In/Out left
            {
                return MoveDirDistToXY(90, (int)(180 * angleRatio), angleRatio);
            }

            if (code == 11)   //Fade left
            {
                return MoveDirDistToXY(90, (int)(93 * angleRatio), angleRatio);
            }

            if (code == 12)    //Hitch left
            {
                return MoveDirDistToXY(32, (int)(225 * angleRatio), angleRatio);
            }

            if (code == 13)    //Hitch right
            {
                return MoveDirDistToXY(32, (int)(-45 * angleRatio), angleRatio);
            }

            if (code == 15)   //180 Partial
            {
                return MoveDirDistToXY(32, (int)(270 * angleRatio), angleRatio);
            }

            if (code == 16)   //180 Partial
            {
                return MoveDirDistToXY(32, (int)(270 * angleRatio), angleRatio);
            }

            if (code == 17)   //Drag right
            {
                return MoveDirDistToXY(90, (int)(3 * angleRatio), angleRatio);
            }

            if (code == 18)   //Drag left
            {
                return MoveDirDistToXY(90, (int)(177 * angleRatio), angleRatio);
            }

            if (code == 19)   //Hitch right
            {
                return MoveDirDistToXY(32, (int)(-45 * angleRatio), angleRatio);
            }

            if (code == 20)   //Hitch left
            {
                return MoveDirDistToXY(32, (int)(225 * angleRatio), angleRatio);
            }
            return new XY { X = 0, Y = 0 };
        }

        public static Point[] XYtoPoint(List<XY> xy)
        {
            Point[] points = new Point[xy.Count];

            for (int i = 0; i < xy.Count; i++)
            {
                points[i].X = xy[i].X;
                points[i].Y = xy[i].Y;
            }

            return points;
        }

        public static void ResizeDataGrid(DataGridView dgv)
        {
            int i = 0;
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                i += c.Width;
            }
            dgv.Width = i + 3;
            try { dgv.Height = dgv.GetRowDisplayRectangle(dgv.Rows.Count - 1, false).Height * (dgv.Rows.Count + 1) + 1; }
            catch { }
        }
    }
}