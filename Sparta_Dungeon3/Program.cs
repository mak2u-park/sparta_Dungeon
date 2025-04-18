using System.Numerics;

namespace Sparta_Dungeon_Test
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
        Inventory inventory = new Inventory();

        public void StartGame()
        {
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.\n");
        }

        public void MainMenu()
        {
            while (true)
            {
                Console.WriteLine("\n[메인 메뉴]\n");
                Console.WriteLine("1. 상태보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine("3. 상점");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.\n");

                string input = Console.ReadLine();
                int menu;

                if (!int.TryParse(input, out menu) || menu < 1 || menu > 3)
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
                            Shop shop = new Shop(player, inventory);
                            shop.DisplayShop();
                            break;
                    }
                }
            }
        }
    }

    public class Player
    {
        public int level = 1;
        public string name = "르탄이";
        public string job = "전사";
        public int attack = 10;
        public int defense = 5;
        public int health = 100;
        public int gold = 1500;

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
    }

    public class Item
    {
        public int Num;
        public string Name;
        public string PowerType;
        public int Power;
        public string Description;
    }

    public class InventoryItem
    {
        public Item itemInfo;
        public bool isEquipped = false;
    }

    public class ShopItem
    {
        public Item itemInfo;
        public int Price;
        public bool isPurchased = false;
    }

    public class Inventory
    {
        public List<InventoryItem> inventoryList = new List<InventoryItem>();

        public void AddItem(Item item)
        {
            inventoryList.Add(new InventoryItem { itemInfo = item });
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[아이템 목록]\n");

            foreach (var InventoryItem in inventoryList)
            {
                string tagEquipped = InventoryItem.isEquipped ? "[E]" : "";
                Console.WriteLine("{0}{1}\t| {2} {3} | {4}",
                    tagEquipped, InventoryItem.itemInfo.Name, InventoryItem.itemInfo.PowerType,
                    InventoryItem.itemInfo.Power, InventoryItem.itemInfo.Description);
            }

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
                    Console.WriteLine("인벤토리에서 나갑니다.");
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

            shopList.Add(new ShopItem { itemInfo = new Item { Num = 1, Name = "수련자 갑옷", PowerType = "방어력", Power = 5, Description = "수련에 도움을 주는 갑옷입니다." }, Price = 1000 });
            shopList.Add(new ShopItem { itemInfo = new Item { Num = 2, Name = "무쇠갑옷", PowerType = "방어력", Power = 9, Description = "무쇠로 만들어져 튼튼한 갑옷입니다." }, Price = 2000 });
            shopList.Add(new ShopItem { itemInfo = new Item { Num = 3, Name = "스파르타의 갑옷", PowerType = "방어력", Power = 15, Description = "스파르타의 전사들이 사용했다는 전설의 갑옷입니다." }, Price = 3500 });
            shopList.Add(new ShopItem { itemInfo = new Item { Num = 4, Name = "낡은 검", PowerType = "공격력", Power = 2, Description = "쉽게 볼 수 있는 낡은 검입니다." }, Price = 600 });
            shopList.Add(new ShopItem { itemInfo = new Item { Num = 5, Name = "청동 도끼", PowerType = "공격력", Power = 5, Description = "어디선가 사용됐던거 같은 도끼입니다." }, Price = 1500 });
            shopList.Add(new ShopItem { itemInfo = new Item { Num = 6, Name = "스파르타의 창", PowerType = "공격력", Power = 7, Description = "스파르타의 전사들이 사용했다는 전설의 창입니다." }, Price = 3000 });
        }

        public void DisplayShop()
        {
            Console.WriteLine("\n[상점]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]\n{0}", player.gold);
            Console.WriteLine("\n[아이템 목록]\n");

            foreach (var ShopItem in shopList)
            {
                string tagPurchased = ShopItem.isPurchased ? "구매완료" : ShopItem.Price.ToString();
                Console.WriteLine("{0}. {1}\t| {2} {3}\t| {4} \t| {5}",
                    ShopItem.itemInfo.Num, ShopItem.itemInfo.Name, ShopItem.itemInfo.PowerType,
                    ShopItem.itemInfo.Power, ShopItem.itemInfo.Description, tagPurchased);
            }

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
                else if (menu == 1)
                {
                    while (true)
                    {
                        Console.WriteLine("\n구매할 아이템의 번호를 입력해주세요.");
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
                        else if (itemNumber < 1 || itemNumber > shopList.Count)
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }
                        else if (shopList[itemNumber - 1].isPurchased)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }
                        else if (player.gold < shopList[itemNumber - 1].Price)
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                        else
                        {
                            player.gold -= shopList[itemNumber - 1].Price;
                            shopList[itemNumber - 1].isPurchased = true;
                            inventory.AddItem(shopList[itemNumber - 1].itemInfo);
                            Console.WriteLine("\n{0}을(를) 구매했습니다.", shopList[itemNumber - 1].itemInfo.Name);
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("상점에서 나갑니다.");
                    break;
                }
            }
        }
    }
}
