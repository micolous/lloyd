using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Lloyd
{
    /// <summary>
    /// Provides information about standard drinks.
    /// </summary>
    public class StandardDrink
    {

        private static Dictionary<CultureInfo, StandardDrink> cultures = new Dictionary<CultureInfo, StandardDrink>();

        static StandardDrink()
        {
            // http://en.wikipedia.org/wiki/Standard_drink

            // Australia
            new StandardDrink(12.7, new CultureInfo("en-AU"));
            // Austria
            new StandardDrink(7.62, new CultureInfo("de-AT"));
            // Canada
            new StandardDrink(17.1, new CultureInfo("en-CA"));
            new StandardDrink(17.1, new CultureInfo("fr-CA"));
            // Denmark
            new StandardDrink(15.2, new CultureInfo("da"));
            // Finland
            new StandardDrink(15.2, new CultureInfo("fi"));
            // France
            new StandardDrink(15.2, new CultureInfo("fr-FR"));
            // Hungary
            new StandardDrink(21.5, new CultureInfo("hu"));
            // Iceland
            new StandardDrink(10.0, new CultureInfo("is"));
            // Ireland
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
            if (cultures.ContainsKey(CultureInfo.CurrentCulture))
                return cultures[CultureInfo.CurrentCulture];

            // unknown
            return null;
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
        /// Finds the number of millilitres of alcohol in a quantity of standard drinks.
        /// </summary>
        /// <param name="standard_drinks">The number of standard drinks.</param>
        /// <returns>An amount in millilitres of alcohol.</returns>
        public double MillilitresAlcoholByStandardDrinks(double standard_drinks)
        {
            return standard_drinks * this.alcohol_ml;
        }

        public override string ToString()
        {
            return String.Format("<StandardDrink: alcohol_ml={0}, culture={1}>", this.alcohol_ml, this.culture);
        }
    }
}
