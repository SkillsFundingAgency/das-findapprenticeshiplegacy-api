using System.ComponentModel.DataAnnotations;

namespace SFA.DAS.FAA.Legacy.Domain.Models.Apprenticeship
{
    public class GeoPoint
    {
        [Required]
        public double Longitude { get; init; }

        [Required]
        public double Latitude { get; init; }

        [Required]
        public int Easting { get; init; }

        [Required]
        public int Northing { get; init; }

        public static GeoPoint NotSet
        {
            get
            {
                return new GeoPoint()
                {
                    Latitude = double.NaN,
                    Longitude = double.NaN,
                    Easting = int.MinValue,
                    Northing = int.MinValue
                };
            }
        }

        public override string ToString()
        {
            return string.Format("Latitude:{0}, Longitude:{1}, Easting: {2}, Northing:{3}", (object)this.Latitude, (object)this.Longitude, (object)this.Easting, (object)this.Northing);
        }

        public bool IsSet() => !this.Equals(GeoPoint.NotSet);

        public GeoPoint Clone()
        {
            return new GeoPoint()
            {
                Latitude = this.Latitude,
                Longitude = this.Longitude,
                Easting = this.Easting,
                Northing = this.Northing
            };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (this == obj)
                return true;
            return !(obj.GetType() != this.GetType()) && this.Equals((GeoPoint)obj);
        }

        protected bool Equals(GeoPoint other)
        {
            return this.Longitude.Equals(other.Longitude) && this.Latitude.Equals(other.Latitude) && this.Easting == other.Easting && this.Northing == other.Northing;
        }

        public override int GetHashCode()
        {
            double num1 = this.Longitude;
            int num2 = num1.GetHashCode() * 397;
            num1 = this.Latitude;
            int hashCode = num1.GetHashCode();
            return ((num2 ^ hashCode) * 397 ^ this.Easting) * 397 ^ this.Northing;
        }
    }
}
