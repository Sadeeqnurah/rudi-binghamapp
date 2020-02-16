using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudiBingham
{
	class Program
	{
		static void Main(string[] args)
		{
			double BPv, BYp, BPm, BDh, BDp,
					BPs, BDc, BRop, BRpm, BCconc;
			double BDT, BDTSqrd, BVcut, BVs1,
					BVmin, BD1, BUa, BRe,
						BF, BVslip, Angl1;
			Console.Write("Enter input variables:\t");
			Console.Write("Plastic Viscosity (cP):\t");
			BPv = Convert.ToDouble(Console.ReadLine());
			Console.Write("Yield Point (lbf/100ft2):\t");
			BYp = Convert.ToDouble(Console.ReadLine());
			Console.Write("Density of Mud (ppg):\t");
			BPm = Convert.ToDouble(Console.ReadLine());
			Console.Write("Hole Diameter (inch):\t");
			BDh = Convert.ToDouble(Console.ReadLine());
			Console.Write("Pipe Diameter (inch):\t");
			BDp = Convert.ToDouble(Console.ReadLine());
			Console.Write("Density of Cutting (ppg):\t");
			BPs = Convert.ToDouble(Console.ReadLine());
			Console.Write("Cutting Diameter (inch):\t");
			BDc = Convert.ToDouble(Console.ReadLine());
			Console.Write("Rate of Penetration (ft/hr):\t");
			BRop = Convert.ToDouble(Console.ReadLine());
			Console.Write("RPM:\t");
			BRpm = Convert.ToDouble(Console.ReadLine());
			Console.Write("Cutting Concentration (%):\t");
			BCconc = Convert.ToDouble(Console.ReadLine());
			// Calculations
			BDT = BDp / BDh;
			BDTSqrd = 1 - (Math.Pow(BDT, 2));

			// a
			BVcut = BRop / (36 * BDTSqrd * BCconc);
			// b
			BVs1 = 3.14;
			// c
			BVmin = BVcut + BVs1;

			BD1 = BDh - BDp;
			// d
			BUa = BPv + (5 * BYp * BD1 / BVmin);
			// e
			BRe = (928 * BPm * BDc * BVs1) / BUa;

			BF = 0;
			if (BRe <= 3)
			{
				BF = 40 / BRe;
			}
			else if (BRe >= 300)
			{
				BF = 1.54;
			}
			else if (BRe > 3 && BRe < 300)
			{
				BF = 22 / Math.Sqrt(BRe);
			}

			// g
			BVslip = 1.89 * Math.Sqrt(Math.Abs((((BDc / BF) * ((BPs - BPm) / BPm)))));
			// h
			double[] BVMin = new double[91];
			double i;

			for (i = 0; i < 90; i++)
			{
                Angl1 = i;
                if (i <= 45)
				{
                    
                    BVMin[0] = Math.Round(BVcut + ((1 + (2 * i / 45)) * (1 - (BRpm / 600)) * ((3 + BPm) / 15) * BVslip), 2);                     
                    Console.WriteLine("\nAngle (Deg):\t" + Angl1);
                    //Console.WriteLine(Angl1);
                    Console.WriteLine("\nVmin (ft/sec):\t" + BVMin[0]);
                    //Console.WriteLine(BVMin[0]);
                    Console.WriteLine(BVMin[0]);
				}

				else if (i > 45)
				{
                    
					BVMin[45] = Math.Round(BVcut + (3 * ((3 + BPm) / 15) * (1 - (BRpm / 600)) * BVslip), 2);
                    Console.WriteLine("\nAngle (Deg):\t" + Angl1);
                    //Console.WriteLine(Angl1);
                    Console.WriteLine("\nVmin (ft/sec):\t" + BVMin[45]);
                    //Console.WriteLine(BVMin[45]);                    
                    Console.WriteLine(BVMin[45]);

                    Console.ReadLine();


                }
                
            }
		}
	}
}
