/*
 * Lloyd - An alcohol and tab monitoring program.
 * Copyright 2011 Michael Farrell <http://micolous.id.au/>.
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Lloyd
{
    /// <summary>
    /// Provides information about standard drinks in various cultures, and
    /// provides helpful calculation functionality.
    /// 
    /// In this library, the term "alcohol" and "ethanol" are used
    /// interchangably -- that is, "alcohol" is always referring to C2H6O.
    /// </summary>
    public class StandardDrink
    {

        private static Dictionary<CultureInfo, StandardDrink> cultures = new Dictionary<CultureInfo, StandardDrink>();

        static StandardDrink()
        {
            // Note:
            // List of locales is here: http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx

            // References:
            // [0]: Wikipedia - Standard Drink
            //      http://en.wikipedia.org/wiki/Standard_drink
            // [1]: ICAP Report 5 - What is a standard drink
            //      http://www.icap.org/portals/0/download/all_pdfs/ICAP_Reports_English/report5.pdf
            //
            // Note that the amounts here are expressed in millilitres of
            // ethanol (alcohol), not grams.
            //
            // Ethanol has a density of 0.789 g/mL (g/cm³).

            // Australia
            new StandardDrink(12.7, new CultureInfo("en-AU"));

            // Austria
            // A special case! They define it as 12g ethanol for beers and wines,
            // but 6g ethanol for spirits.  [0] takes the lower of the two as the
            // "standard drink", because of [1].
            new StandardDrink(7.62, new CultureInfo("de-AT"));

            // Canada
            new StandardDrink(17.1, new CultureInfo("en-CA"));
            new StandardDrink(17.1, new CultureInfo("fr-CA"));

            // Denmark
            new StandardDrink(15.2, new CultureInfo("da"));

            // Finland
            new StandardDrink(15.2, new CultureInfo("fi"));

            // France
            new StandardDrink(15.2, new CultureInfo("fr"));
            new StandardDrink(15.2, new CultureInfo("fr-FR"));

            // Hungary
            new StandardDrink(21.5, new CultureInfo("hu"));

            // Iceland
            new StandardDrink(10.0, new CultureInfo("is"));

            // Ireland
            // Despite this being in the list of supported cultures, "ga" is not...
            //new StandardDrink(12.7, new CultureInfo("ga"));
            new StandardDrink(12.7, new CultureInfo("ga-IE"));
            new StandardDrink(12.7, new CultureInfo("en-IE"));

            // Italy
            new StandardDrink(12.7, new CultureInfo("it-IT"));

            // Japan
            new StandardDrink(25.0, new CultureInfo("ja"));

            // Netherlands
            new StandardDrink(12.5, new CultureInfo("nl"));

            // New Zealand
            new StandardDrink(12.7, new CultureInfo("en-NZ"));

            // Poland
            new StandardDrink(12.7, new CultureInfo("pl"));

            // Portugal
            new StandardDrink(17.7, new CultureInfo("pt"));

            // Spain
            new StandardDrink(12.7, new CultureInfo("es"));

            // UK
            new StandardDrink(10.0, new CultureInfo("en-GB"));

            // USA (defined as 0.6 US fluid ounces)
            new StandardDrink(0.6 * 29.5735295625, new CultureInfo("en-US"));
            new StandardDrink(0.6 * 29.5735295625, new CultureInfo("es-US"));
        }

        /// <summary>
        /// Alcohol has a density of 0.789 grams per mL (g/cm³).
        /// </summary>
        public const double alcohol_density_g_ml = 0.789;

        double alcohol_ml;
        CultureInfo culture;

        /// <summary>
        /// The number of millilitres of alcohol per "standard drink".
        /// </summary>
        public double AlcoholMl
        {
            get
            {
                return alcohol_ml;
            }
        }

        /// <summary>
        /// The number of grams of alcohol per "standard drink".
        /// </summary>
        public double AlcoholGrams
        {
            get
            {
                return alcohol_ml * alcohol_density_g_ml;
            }
        }

        /// <summary>
        /// A CultureInfo describing the culture that this standard is enforced in.
        /// </summary>
        public CultureInfo Culture
        {
            get
            {
                return culture;
            }
        }

        private StandardDrink(double alcohol_ml, CultureInfo culture)
        {
            this.alcohol_ml = alcohol_ml;
            this.culture = culture;

            // register the culture automatically.
            cultures.Add(culture, this);
        }

        /// <summary>
        /// Gets the StandardDrink associated with the current locale.
        /// </summary>
        /// <returns>A StandardDrink object for the current locale, or null if unknown.</returns>
        public static StandardDrink GetForCurrentLocale()
        {
            return GetForLocale(CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the StandardDrink associated with the specified locale.
        /// </summary>
        /// <param name="ci">The CultureInfo specifying the locale to look up.</param>
        /// <returns>A StandardDrink object for the specified locale, or null if unknown.</returns>
        public static StandardDrink GetForLocale(CultureInfo ci)
        {
            if (cultures.ContainsKey(ci))
                return cultures[ci];

            // unknown
            return null;
        }

        /// <summary>
        /// Returns all supported StandardDrink cultures.
        /// </summary>
        public static IEnumerable<StandardDrink> Cultures {
            get
            {
                foreach (var c in cultures.Values)
                {
                    yield return c;
                }
            }
        }

        /// <summary>
        /// Finds the number of standard drinks in a beverage by percent of alcohol by volume in a certain volume of drink.
        /// </summary>
        /// <param name="percent_by_volume">The percentage of alcohol in the beverage by volume.</param>
        /// <param name="millilitres">The number of millilitres of beverage.</param>
        /// <returns>The number of standard drinks the beverage contains.</returns>
        public double StandardDrinksByPercent(double percent_by_volume, double millilitres)
        {
            return StandardDrinksByVolumeAlcohol((percent_by_volume / 100.0) * millilitres);
        }

        /// <summary>
        /// Finds the number of standard drinks in a volume of alcohol.
        /// </summary>
        /// <param name="alcohol_ml">The number of millilitres of alcohol in a beverage.</param>
        /// <returns>The number of standard drinks that beverage contains.</returns>
        public double StandardDrinksByVolumeAlcohol(double alcohol_ml)
        {
            return alcohol_ml / this.alcohol_ml;
        }

        /// <summary>
        /// Finds the number of standard drinks in a mass of alcohol.
        /// </summary>
        /// <param name="alcohol_g">The number of grams of alcohol in a beverage.</param>
        /// <returns>The number of standard drinks that beverage contains.</returns>
        public double StandardDrinksByMassAlcohol(double alcohol_g)
        {
            return alcohol_g / (this.alcohol_ml * alcohol_density_g_ml);
        }

        /// <summary>
        /// Finds the number of millilitres of alcohol in a quantity of standard drinks.
        /// </summary>
        /// <param name="standard_drinks">The number of standard drinks.</param>
        /// <returns>An amount in millilitres of alcohol.</returns>
        public double MillilitresAlcoholByStandardDrinks(double standard_drinks)
        {
            return standard_drinks * this.alcohol_ml;
        }

        /// <summary>
        /// Finds the number of grams of alcohol in a quantity of standard drinks.
        /// </summary>
        /// <param name="standard_drinks">The number of standard drinks.</param>
        /// <returns>An amount in grams of alcohol.</returns>
        public double GramsAlcoholByStandardDrinks(double standard_drinks)
        {
            return standard_drinks * this.alcohol_ml * alcohol_density_g_ml;
        }

        /// <summary>
        /// Finds the percentage of alcohol in a drink by the number of standard drinks and it's volume.
        /// </summary>
        /// <param name="standard_drinks">The number of standard drinks in the beverage.</param>
        /// <param name="volume_ml">The volume of beverage.</param>
        /// <returns>The percentage of alcohol by volume in the beverage.</returns>
        public double PercentAlcoholByStandardDrinkVolume(double standard_drinks, double volume_ml)
        {
            return (MillilitresAlcoholByStandardDrinks(standard_drinks) / volume_ml) * 100.0;
        }

        /// <summary>
        /// Gets a string representation of the StandardDrink object.
        /// </summary>
        /// <returns>A string containing the data in the StandardDrink object.</returns>
        public override string ToString()
        {
            return String.Format("<StandardDrink: alcohol_ml={0}, culture={1}>", this.alcohol_ml, this.culture);
        }
    }
}
