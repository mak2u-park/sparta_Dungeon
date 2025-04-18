using System.Numerics;

namespace Sparta_Dungeon2
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
        Player player = new Player();           // 플레이어 객체 생성, 초기화
        Inventory inventory = new Inventory();  // 인벤토리 객체 생성, 초기화
        Shop shop ;                             // 상점 객체 생성
        public void StartGame()
        {
            shop = new Shop(player, inventory); // 상점 초기화

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        }

        public void MainMenu()
        {
            // 메뉴 선택

            while (true)
            {
                Console.WriteLine("\n[메인 메뉴]\n");
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
                            inventory.DisplayInventory();
                            break;
                        case 3:
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
        public int gold { get; set; } = 1500;




        // 캐릭터 상태 표시
        public void Status()
        {
            Console.WriteLine("\n[상태 보기]\n캐릭터의 상태가 표시됩니다.\n");
            Console.WriteLine("레벨 : {0}", level);
            Console.WriteLine("{0} ( {1} )", name, job);
            Console.WriteLine("공격력 : {0}", attack);
            Console.WriteLine("방어력 : {0}", defense);
            Console.WriteLine("체력 : {0}", health);
            Console.WriteLine("골드 : {0}G", gold);
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
    }

    // 아이템 정보
    public class Item
    {
        public int Num;                       // 아이템 번호
        public string Name;                   // 아이템 이름
        public string PowerType;              // 공격력, 방어력
        public int Power;                     // 아이템 능력치
        public string Description;            // 아이템 설명
    }

    // 인벤토리 아이템 정보 (장착 여부 추가)
    public class InventoryItem
    {
        public Item itemInfo;                 // 아이템 정보
        public bool isEquipped = false;       // 장착 여부

        public string name => itemInfo.Name; // Name 프로퍼티 추가
    }

    // 상점 아이템 정보 (구매 여부 추가)
    public class ShopItem
    {
        public Item itemInfo;                 // 아이템 정보
        public int Price;                     // 아이템 가격
        public bool isPurchased = false;      // 구매 여부
    }

    public class Inventory
    {
        public List<InventoryItem> inventoryList = new List<InventoryItem>();

        // 인벤토리에 아이템을 추가할 때 사용
        public void AddItem(Item item)
        {
            // 새로운 인스턴스를 생성하며 이 인스턴스의 itemInfo 필드에 item을 할당
            inventoryList.Add(new InventoryItem { itemInfo = item });
        }

        // 인벤토리 아이템 목록 출력하는 메서드
        public void CallInventoryList()
        {
            Console.WriteLine("\n[아이템 목룍]\n");
            if (inventoryList.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.\n");
                return; 
            }
            foreach (var InventoryItem in inventoryList)
            {
                string tagEquipped = InventoryItem.isEquipped ? "[E]" : "";
                Console.WriteLine("\n{0}. {1}{2}\t| {3} {4} | {5}",
                    inventoryList.Count, tagEquipped, InventoryItem.itemInfo.Name, InventoryItem.itemInfo.PowerType,
                    InventoryItem.itemInfo.Power, InventoryItem.itemInfo.Description);

            }
        }


        public void DisplayInventory()
        {
            Console.WriteLine("\n[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            CallInventoryList();

            

            while (true)
            {
                Console.WriteLine("\n1. 장착 관리 \n0. 나가기 \n");
                Console.WriteLine("원하시는 행동을 입력해주세요.\n");
                string input = Console.ReadLine();
                int menu;

                if (!int.TryParse(input, out menu))
                {
                }
                else if (menu > 1 || menu < 0)
                {
                    Console.WriteLine("\n잘못된 입력입니다.");
                }
                else if (menu == 1) // 장착 관리
                {
                    CallInventoryList();
                    Console.WriteLine("\n장착(해제)하려는 아이템 번호를 입력해주세요\n0. 나가기\n");
                    string input2 = Console.ReadLine();
                    int itemNum;

                    if (!int.TryParse(input2, out itemNum))
                    {
                        Console.WriteLine("잘못된 입력입니다.\n");                        
                    }
                    else if (itemNum == 0)
                    {
                        Console.WriteLine("장착 관리에서 나갑니다.\n");
                        break;
                    }
                    else if (itemNum < 0 || itemNum > inventoryList.Count)
                    {
                        Console.WriteLine("잘못된 입력입니다.\n");
                    }
                    else if (inventoryList[itemNum - 1].isEquipped == true)
                    {
                        inventoryList[itemNum - 1].isEquipped = false;
                        Console.WriteLine("{0}을(를) 해제했습니다.\n", inventoryList[itemNum - 1].itemInfo.Name);
                    }
                    else
                    {
                        inventoryList[itemNum - 1].isEquipped = true;
                        Console.WriteLine("{0}을(를) 장착했습니다.\n", inventoryList[itemNum - 1].itemInfo.Name);
                    }
                }
                else                // 나가기
                {
                    Console.WriteLine("인벤토리에서 나갑니다.\n");
                    break;
                }
            }
        }
    }

    public class Shop
    {
        Player player;
        Inventory inventory;

        public List<ShopItem> shopList;


        public Shop(Player player, Inventory inventory)
        {
            this.player = player;
            this.inventory = inventory;
            shopList = new List<ShopItem>();

            // 리스트에 상점 아이템 추가

            // (1) 수련자 갑옷
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 1,
                    Name = "수련자 갑옷   ",
                    PowerType = "방어력",
                    Power = 5,
                    Description = "수련에 도움을 주는 갑옷입니다.                  ",

                },
                Price = 1000,
                isPurchased = false
            });

            // (2) 무쇠갑옷
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 2,
                    Name = "무쇠갑옷      ",
                    PowerType = "방어력",
                    Power = 9,
                    Description = "무쇠로 만들어져 튼튼한 갑옷입니다.               ",
                     
                },
                Price = 2000,
                isPurchased = false
            });

            // (3) 스파르타의 갑옷
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 3,
                    Name = "스파르타의 갑옷",
                    PowerType = "방어력",
                    Power = 15,
                    Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",

                },
                Price = 3500,
                isPurchased = false
            });

            // (4) 낡은 검
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 4,
                    Name = "낡은 검       ",
                    PowerType = "공격력",
                    Power = 2,
                    Description = "쉽게 볼 수 있는 낡은 검입니다.                     ",

                },
                Price = 600,
                isPurchased = false
            });

            // (5) 청동 도끼
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 5,
                    Name = "청동 도끼      ",
                    PowerType = "공격력",
                    Power = 5,
                    Description = "어디선가 사용됐던거 같은 도끼입니다.          ",

                },
                Price = 1500,
                isPurchased = false
            });

            // (6) 스파르타의 창
            shopList.Add(new ShopItem
            {
                itemInfo = new Item
                {
                    Num = 6,
                    Name = "스파르타의 창",
                    PowerType = "공격력",
                    Power = 7,
                    Description = "스파르타의 전사들이 사용했다는 전설의 창입니다.   ",

                },
                Price = 3000,
                isPurchased = false
            });

        }

        public void CallShopList()
        {
            Console.WriteLine("[보유 골드]\n{0}G", player.gold);
            Console.WriteLine("\n[아이템 목록]\n");


            foreach (var ShopItem in shopList)
            {
                string price = ShopItem.Price.ToString();
                // tagEquipped가 true일 경우 [E]를 출력, false일 경우 빈 문자열 출력
                string tagPurchased = ShopItem.isPurchased ? "구매완료" : price + "G";

                Console.WriteLine("{0}. {1}\t| {2} {3}\t| {4} \t| {5}",
                    ShopItem.itemInfo.Num, ShopItem.itemInfo.Name, ShopItem.itemInfo.PowerType,
                    ShopItem.itemInfo.Power, ShopItem.itemInfo.Description, tagPurchased);
            }
        }
        public void DisplayShop()
        {
            Console.WriteLine("\n[상점]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");

            CallShopList();

            Console.WriteLine("\n1. 아이템 구매\n0. 나가기\n");
            

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
                else if (menu == 1) // 구매 관리
                {
                    while (true)
                    {
                        Console.WriteLine("\n구매할 아이템의 번호를 입력해주세요.");
                        CallShopList();
                        Console.WriteLine("\n0. 나가기\n");
                        string input2 = Console.ReadLine();
                        int itemNumber;
                        if (!int.TryParse(input2, out itemNumber))
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        else if (itemNumber == 0)
                        {
                            Console.WriteLine("상점에서 나갑니다.");
                            break;
                        }
                        else if (itemNumber < 0 || itemNumber > 6)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        else if (shopList[itemNumber-1].isPurchased == true)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.gold < shopList[itemNumber-1].Price)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        
                        else
                        {
                            player.gold -= shopList[itemNumber - 1].Price;
                            shopList[itemNumber - 1].isPurchased = true;
                            Console.WriteLine("\n{0}을(를) 구매했습니다.", shopList[itemNumber - 1].itemInfo.Name);
                            Console.WriteLine("남은 골드: {0}G", player.gold);
                            inventory.AddItem(shopList[itemNumber - 1].itemInfo);   // shopList[itemNumber - 1].itemInfo인 이유는 ShopItem 전체가 아니라 itemInfo만 필요하기 때문
                        }
                        
                    }
                    break;

                }
                else                // 나가기
                {
                    Console.WriteLine("상점에서 나갑니다.");
                    break;
                }
            }
        }


    }
}
