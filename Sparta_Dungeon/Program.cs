namespace Sparta_Dungeon
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            GameManager gamemanager = new GameManager();
            gamemanager.StartGame();
            gamemanager.MainMenu();

        }
    }
    class GameManager
    {
        Player player = new Player();

        // shop 변수만 선언하고 이후 DesplayShop() 메서드에서 초기화
        public void StartGame()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        }

        public void MainMenu()
        {

            // 메뉴 선택

            while (true)
            {
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.\n");

                string input = Console.ReadLine();
                int menu;

                if (!int.TryParse(input, out menu))
                {
                    Console.WriteLine("1~3 사이 숫자를 입력해주세요.\n");

                }
                else if (menu < 1 || menu > 3)
                {
                    Console.WriteLine("1~3 사이 숫자를 입력해주세요.\n");
                }
                else
                {
                    switch (menu)
                    {
                        case 1:
                            player.Status();
                            break;
                        case 2:
                            player.Inventory();
                            break;
                        case 3:
                            Shop shop = new Shop();
                            shop.DisplayShop();
                            break;

                    }
                    
                }
            }
        }

    }

    public class Player
    {
        int level = 1;
        string name = "르탄이";
        string job = "전사";
        int attack = 10;
        int defense = 5;
        int health = 100;
        public int gold = 1500;

        public InventoryInfo[] inventorys;
        


        // 캐릭터 상태 표시
        public void Status()
        {
            Console.WriteLine("\n[상태 보기]\n캐릭터의 상태가 표시됩니다.\n");
            Console.WriteLine("레벨 : {0}", level);
            Console.WriteLine("{0} ( {1} )", name, job);
            Console.WriteLine("공격력 : {0}", attack);
            Console.WriteLine("방어력 : {0}", defense);
            Console.WriteLine("체력 : {0}", health);
            Console.WriteLine("골드 : {0}", gold);
            Console.WriteLine("\n0. 나가기");

            while (true)
            {
                Console.WriteLine("\n원하시는 행동을 입력해주세요.\n");
                string input = Console.ReadLine();
                int menu;
                if (!int.TryParse(input, out menu))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (menu != 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else
                {
                    break;
                }
            }

        }


        public void Inventory()
        {
            Console.WriteLine("\n[인벤토리]\n보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목룍]\n");

            // 아이템이 있을때 목록을 추가할 예정
            

            Console.WriteLine("1. 장착 관리 \n0. 나가기 \n");

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                string input = Console.ReadLine();
                int menu;

                if (!int.TryParse(input, out menu))
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (menu > 1 || menu < 0)
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
                else if (menu == 1)
                {
                    Console.WriteLine("준비중입니다.");
                    break;
                }
                else
                {
                    Console.WriteLine("준비중입니다.");
                    break;
                }
            }
        }
        public void EquipItem()
        {

        }
    }
    public class InventoryInfo
    {
        public string Name;          // 아이템 이름
        public string PowerType;     // 공격력, 방어력
        public int Power;            // 아이템 능력치
        public string Description;   // 아이템 설명
        public bool IsEquipped;      // 장착 여부
    }

    public class Shop
    {
        Player player = new Player();
        public ItemInfo[] items;

        public Shop()
        {
            items = new ItemInfo[6];

            items[0] = new ItemInfo()
            {
                Name = "수련자 갑옷",
                PowerType = "방어력",
                Power = 5,
                Description = "수련에 도움을 주는 갑옷입니다.",
                Price = 1000,
                IsPurchased = false
            };
            items[1] = new ItemInfo()
            {
                Name = "무쇠갑옷",
                PowerType = "방어력",
                Power = 9,
                Description = "무쇠로 만들어져 튼튼한 갑옷입니다.",
                Price = 2000,
                IsPurchased = false
            };
            items[2] = new ItemInfo()
            {
                Name = "스파르타의 갑옷",
                PowerType = "방어력",
                Power = 15,
                Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
                Price = 3500,
                IsPurchased = false
            };
            items[3] = new ItemInfo()
            {
                Name = "낡은 검",
                PowerType = "공격력",
                Power = 2,
                Description = "쉽게 볼 수 있는 낡은 검입니다.",
                Price = 600,
                IsPurchased = false
            };
            items[4] = new ItemInfo()
            {
                Name = "청동 도끼",
                PowerType = "공격력",
                Power = 5,
                Description = "어디선가 사용됐던거 같은 도끼입니다.",
                Price = 1500,
                IsPurchased = false
            };
            items[5] = new ItemInfo()
            {
                Name = "스파르타의 창",
                PowerType = "공격력",
                Power = 7,
                Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.",
                Price = 3000,
                IsPurchased = false
            };
        }
        public void DisplayShop()
        {
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]\n{0}G\n", player.gold);
            Console.WriteLine("[아이템 목록]");
        }
    }

    public class ItemInfo
    {
        public string Name;          // 아이템 이름
        public string PowerType;     // 공격력, 방어력
        public int Power;            // 아이템 능력치
        public string Description;   // 아이템 설명
        public int Price;            // 아이템 가격
        public bool IsPurchased;    // 구매 여부 


    }



}
