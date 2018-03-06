using System;

namespace world
{
    class Friend
    {
        
		public string name { get; }
        public double latitude { get; }
        public double longitude { get; }

        public Friend(string name, double latitude, double longitude)  
        {
        	this.name = name;
        	this.latitude = latitude;
        	this.longitude = longitude;
        }


        public override string ToString()
        {
            return $"[{this.name} com latitude de {this.latitude:f2} e longitude de {this.longitude:f2}]";
        }

        public bool Equals(Friend friend)
        {
            return (this.latitude == friend.latitude && this.longitude == friend.longitude);
        }
    }
}
