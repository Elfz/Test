using System;
using System.Collections.Generic;

namespace world
{
    class Program
    {
        static List<Friend> friends = new List<Friend>();

        static void Main(string[] args)
        {
        	Friend friend;
	    	while(true)
			{
				string input = Menu();
				int option;
				if(!Int32.TryParse(input, out option))
				{
					Console.WriteLine("Opção inválida!");
					continue;
				}
				switch(option){
			    	case 1:
						friend = ReadFriend();
						if(friend != null)
						{
				    		AddFriend(friend);    
						}                        
						break;
			    	case 2:
						friend = ReadFriend();
						if(friend != null)
						{
							List<ClosestFriend> closestFriends = ClosestFriends(friend, 3);
							PrintClosestFriends(friend, closestFriends);        
						}
						break;
					case 3:
						PrintFriends();
						break;
					case 4:
						System.Environment.Exit(0);
						break;
					default:
						Console.WriteLine("Opção inválida!");
						break;
				}
			}
        }

        static string Menu()
        {
			Console.WriteLine("\n\n===============================");
            Console.WriteLine("Escolha uma das opções abaixo:");
            Console.WriteLine("1 - Cadastrar um amigo");
            Console.WriteLine("2 - Buscar amigos mais próximos");
            Console.WriteLine("3 - Listar os amigos cadastrados");
            Console.WriteLine("4 - Sair");
            Console.WriteLine("===============================");
            Console.Write("Informe a opção: ");
            return Console.ReadLine();
        }

        static Friend ReadFriend()
        {
			Console.Write("Informe o nome do amigo que você está visitanto: ");
			string name = Console.ReadLine();
            
			Console.Write("Informe a latitude e longitude separadas por espaço: ");
			string coordinates = Console.ReadLine();
		
			double latitude, longitude;
			var parts = coordinates.Split(' ');
			if(parts.Length != 2 || !Double.TryParse(parts[0], out latitude) || !Double.TryParse(parts[1], out longitude))
			{
				Console.WriteLine("Coordenadas inválidas!");
				return null;
			}
			return new Friend(name, latitude, longitude);
        }

		static void AddFriend(Friend friend)
        {
    		if(CheckIfAlreadyExists(friend))
			{
				Console.WriteLine($"Já existe um amigo cadastrado com latitude {friend.latitude} e longitude {friend.longitude}");                
			}
			else
			{
				Console.WriteLine($"{friend.name} foi cadastrado com sucesso");
				friends.Add(friend);                
			}
        }

        static bool CheckIfAlreadyExists(Friend friend)
        {
    		foreach(var f in friends)
    		{
			if(f.latitude == friend.latitude && f.longitude == friend.longitude)
	    			return true;
            }
            return false;
        }

		static List<ClosestFriend> ClosestFriends(Friend friend, int numberOfClosestFriends)
        {
            List<ClosestFriend> closestFriends = new List<ClosestFriend>();
            for(int i = 0; i < friends.Count; i++)
            {
                if(!friend.Equals(friends[i]))
                {
                    closestFriends.Add(new ClosestFriend(friends[i], Dist(friend, friends[i])));    
                }
                
            }

            closestFriends.Sort(delegate(ClosestFriend x, ClosestFriend y)
            {
                return x.distance.CompareTo(y.distance);
            });

			if(closestFriends.Count > numberOfClosestFriends)
            {
                closestFriends.RemoveRange(numberOfClosestFriends, closestFriends.Count-numberOfClosestFriends);
            }
			
			return closestFriends;
		}

        static double Dist(Friend f1, Friend f2)
        {
            return Math.Sqrt(Math.Pow(f1.latitude-f2.latitude,2) + Math.Pow(f1.longitude-f2.longitude,2));                  
        }

        static void PrintClosestFriends(Friend friend, List<ClosestFriend> closestFriends)
        {   
            Console.WriteLine("\n\n===============================");
            Console.WriteLine($"Os amigos mais próximos de {friend.name} são: ");
			foreach(var closestFriend in closestFriends)
			{
				Console.WriteLine(closestFriend);				
			}
            Console.WriteLine("===============================");			
        }

        static void PrintFriends()
        {
            Console.WriteLine("\n\n===============================");
            Console.WriteLine($"Os amigos cadastrados são:");
            foreach(var friend in friends)
            {
				Console.WriteLine(friend);               
            }
            Console.WriteLine("===============================");
        }
    }
}
