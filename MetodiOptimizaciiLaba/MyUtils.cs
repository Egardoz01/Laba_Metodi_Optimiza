using Microsoft.SolverFoundation.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodiOptimizaciiLaba
{
    public static class RationalExtension
    {
        public static Rational ParseRational(this string s)
        {
            s.Replace(',', '.');
            if (s.Contains("/"))
            {
                string[] nums = s.Split('/');

                return Rational.Get(int.Parse(nums[0]), int.Parse(nums[1]));
            }
            else
            {

                Rational frac;
                if (!s.Contains('.'))    // if whole number
                {
                    int res = int.Parse(s);
                    frac = Rational.Get(res, 1);
                }
                else
                {

                    string strTemp = s;
                    double dTemp = 1;
                    long iMultiple = 1;
                    int i = 0;
                    while (strTemp[i] != '.')
                        i++;
                    int iDigitsAfterDecimal = strTemp.Length - i - 1;
                    while (iDigitsAfterDecimal > 0)
                    {
                        dTemp *= 10;
                        iMultiple *= 10;
                        iDigitsAfterDecimal--;
                    }
                    frac = Rational.Get((int)Math.Round(dTemp), iMultiple);
                }
                return frac;
            }


        }
    }
}
