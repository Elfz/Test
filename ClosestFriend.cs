using System;

namespace world
{
    class ClosestFriend
    {
        public Friend friend { get; set; }
        public double distance { get; set; }
        
        public ClosestFriend(Friend friend, double distance)  
        {
            this.friend = friend;
            this.distance = distance;
        }

        public override string ToString()
        {
            return $"[{this.friend.name} com distância de {this.distance:f2}]";
        }

    }
}
